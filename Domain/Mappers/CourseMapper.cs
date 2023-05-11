using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Course;
using Shared.Contracts.Responses.Items.Course;
using Shared.Contracts.Responses.Items.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public   class CourseMapper : IMapper<Course, GetCourseResponse, CreateCourseRequest, UpdateCourseRequest>
    {
        private readonly InvestmentMapper _investmentMapper;

        public CourseMapper(InvestmentMapper investmentMapper)
        {
            _investmentMapper = investmentMapper;
        }
        public   GetCourseResponse ToDTO(Course entity)
        {
            var newDTO = new GetCourseResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity .Description,
                Images = entity .Images,
                CategoryId = entity .CategoryId,
                SubcategoryId = entity .SubcategoryId,
                Tiers = entity .Tiers,
                ActiveStudents = entity .ActiveStudents,
                ExpectedGraduates = entity .ExpectedGraduates,
                ExpectedApplicants = entity .ExpectedApplicants,
                StartDate = entity .StartDate,
                EndDate = entity .EndDate,
                CountryId = entity .CountryId,
                CreatedAt = entity .CreatedAt,
                CurrentAmount = entity .CurrentAmount,
                Goal = entity .Goal,
                OrganisationId = entity .OrganisationId,
                Investments = entity .Investments.Select(_investmentMapper.ToDTO).ToList(),
                Curriculum = entity .Curriculum,
                UpdatedAt = entity .UpdatedAt,
                Type = entity .Type,
                Prices = entity .Prices,


            };
            return newDTO;

        }

        public   Course ToEntity(CreateCourseRequest request)
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
                CreatedAt = DateTime.UtcNow,
                CurrentAmount = request.CurrentAmount,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Curriculum = request.Curriculum,
                EndDate = request.EndDate,
                ExpectedApplicants = request.ExpectedApplicants,
                ExpectedGraduates = request.ExpectedGraduates,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                Prices = request.Prices,
            };
            return newApp;
        }
        public   Course ToUpdatedEntity(UpdateCourseRequest request)
        {
            var newApp = new Course
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
                CurrentAmount = request.CurrentAmount,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Curriculum = request.Curriculum,
                EndDate = request.EndDate,
                ExpectedApplicants = request.ExpectedApplicants,
                ExpectedGraduates = request.ExpectedGraduates,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                Prices = request.Prices,
            };
            return newApp;
        }

}
}
