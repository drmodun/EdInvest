using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Items.Course;
using Domain.Contracts.Responses.Items.Course;
using Domain.Contracts.Responses.Items.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class CourseMapper
    {
        public static GetCourseResponse ToDTO(Course course)
        {
            var newDTO = new GetCourseResponse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Images = course.Images,
                CategoryId = course.CategoryId,
                SubcategoryId = course.SubcategoryId,
                Tiers = course.Tiers,
                ActiveStudents = course.ActiveStudents,
                ExpectedGraduates = course.ExpectedGraduates,
                ExpectedApplicants = course.ExpectedApplicants,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                CountryId = course.CountryId,
                CreatedAt = course.CreatedAt,
                CurrentAmount = course.CurrentAmount,
                Goal = course.Goal,
                OrganisationId = course.OrganisationId,
                Investments = course.Investments.Select(InvestmentMapper.ToDTO).ToList(),
                Curriculum = course.Curriculum,
                UpdatedAt = course.UpdatedAt,
                Type = course.Type,
                Prices = course.Prices,


            };
            return newDTO;

        }

        public static Course ToEntity(CreateCourseRequest request)
        {
            var newApp = new Data.Entities.Models.Items.Course
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
        public static Course ToUpdatedEntity(UpdateCourseRequest request)
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
