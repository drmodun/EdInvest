using Data.Entities.Models.Items;
using Data.Enums;
using Domain.Contracts.Requests.Items.OnlineCourse;
using Domain.Contracts.Responses.Items.OnlineCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers

{
    public   class OnlineCourseMapper
    {
      public   GetOnlineCourseResponse ToDTO(OnlineCourse onlineCourse)
        {
            return new GetOnlineCourseResponse
            {
                Id = onlineCourse.Id,
                Name = onlineCourse.Name,
                CategoryId = onlineCourse.CategoryId,
                Description = onlineCourse.Description,
                CountryId = onlineCourse.CountryId,
                CurrentAmount = onlineCourse.CurrentAmount,
                Images = onlineCourse.Images,
                Goal = onlineCourse.Goal,
                Investments = onlineCourse.Investments.Select(InvestmentMapper.ToDTO).ToList(),
                OrganisationId  = onlineCourse.OrganisationId,
                Prices = onlineCourse.Prices,
                SubcategoryId = onlineCourse.SubcategoryId,
                Tiers = onlineCourse.Tiers,
                LinksToChannels = onlineCourse.LinksToChannels,
                Lessons = onlineCourse.Lessons,
                LessonsDate = onlineCourse.LessonsDate,
                AvarageDuration = onlineCourse.AvarageDuration,
                ExpectedAudience = onlineCourse.ExpectedAudience,
                Type = ItemType.OnlineCourse,
                CreatedAt = onlineCourse.CreatedAt,
                UpdatedAt = onlineCourse.UpdatedAt
            };
        }
      public   OnlineCourse ToEntity(CreateOnlineCourseRequest request)
        {
            return new OnlineCourse
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Description = request .Description,
                CountryId = request .CountryId,
                CurrentAmount = request .CurrentAmount,
                Images = request .Images,
                Goal = request .Goal,
                OrganisationId = request .OrganisationId,
                Prices = request .Prices,
                SubcategoryId = request .SubcategoryId,
                Tiers = request .Tiers,
                LinksToChannels = request .LinksToChannels,
                Lessons = request .Lessons,
                LessonsDate = request .LessonsDate,
                AvarageDuration = request .AvarageDuration,
                ExpectedAudience = request .ExpectedAudience,
                Type = ItemType.OnlineCourse,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                
            };
        }
        public   OnlineCourse ToUpdatedEntity(UpdateOnlineCourseRequest request)
        {
            var onlineCourse = new OnlineCourse()
            {
                Name = request.Name,
                Id = request.Id,
                CategoryId = request.CategoryId,
                Description = request.Description,
                CountryId = request.CountryId,
                CurrentAmount = request.CurrentAmount,
                Images = request.Images,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Prices = request.Prices,
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                LinksToChannels = request.LinksToChannels,
                Lessons = request.Lessons,
                LessonsDate = request.LessonsDate,
                AvarageDuration = request.AvarageDuration,
                ExpectedAudience = request.ExpectedAudience,
                Type = ItemType.OnlineCourse,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return onlineCourse;
        }


       

    }
}
