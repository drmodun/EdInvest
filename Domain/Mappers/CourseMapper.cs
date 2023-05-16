﻿using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Course;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Course;
using Shared.Models.Items;

namespace Domain.Mappers
{
    public class CourseMapper : IMapper<Course, GetCourseResponse, CreateCourseRequest, UpdateCourseRequest>
    {
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;

        public CourseMapper(ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public GetCourseResponse ToDTO(Course entity)
        {
            var newDTO = new GetCourseResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Images = entity.Images,
                CategoryId = entity.CategoryId,
                SubcategoryId = entity.SubcategoryId,
                Tiers = entity.Tiers,
                ActiveStudents = entity.ActiveStudents,
                ExpectedGraduates = entity.ExpectedGraduates,
                ExpectedApplicants = entity.ExpectedApplicants,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CountryId = entity.CountryId,
                Goal = entity.Goal,
                OrganisationId = entity.OrganisationId,
                Curriculum = entity.Curriculum,
                UpdatedAt = entity.UpdatedAt,
                Type = entity.Type,
                Prices = entity.Prices,
                CurrentAmount = _itemRepo.GetCurrentAmount(entity.Id)

            };
            return newDTO;

        }

        public Course ToEntity(CreateCourseRequest request)
        {
            var newApp = new Shared.Models.Items.Course
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Images = request.Images,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                ActiveStudents = request.ActiveStudents,
                CountryId = request.CountryId,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Curriculum = request.Curriculum,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ExpectedApplicants = request.ExpectedApplicants,
                ExpectedGraduates = request.ExpectedGraduates,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                Prices = request.Prices.Order().ToList(),
            };
            return newApp;
        }
        public Course ToUpdatedEntity(UpdateCourseRequest request)
        {
            var newApp = new Course
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Images = request.Images,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                ActiveStudents = request.ActiveStudents,
                CountryId = request.CountryId,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Curriculum = request.Curriculum,
                EndDate = request.EndDate,
                ExpectedApplicants = request.ExpectedApplicants,
                ExpectedGraduates = request.ExpectedGraduates,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                Prices = request.Prices.Order().ToList(),
            };
            return newApp;
        }

    }
}
