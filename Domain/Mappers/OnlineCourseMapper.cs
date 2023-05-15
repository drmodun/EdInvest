using Shared.Contracts.Requests.Items.OnlineCourse;
using Shared.Contracts.Responses.Items.OnlineCourse;
using Shared.Enums;
using Shared.Models.Items;

namespace Domain.Mappers

{
    public class OnlineCourseMapper : IMapper<OnlineCourse, GetOnlineCourseResponse, CreateOnlineCourseRequest, UpdateOnlineCourseRequest>
    {
        private readonly InvestmentMapper _investmentMapper;

        public OnlineCourseMapper(InvestmentMapper investmentMapper)
        {
            _investmentMapper = investmentMapper;
        }

        public GetOnlineCourseResponse ToDTO(OnlineCourse entity)
        {
            return new GetOnlineCourseResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                CountryId = entity.CountryId,
                CurrentAmount = entity.CurrentAmount,
                Images = entity.Images,
                Goal = entity.Goal,
                Investments = entity.Investments.Select(_investmentMapper.ToDTO).ToList(),
                OrganisationId = entity.OrganisationId,
                Prices = entity.Prices,
                SubcategoryId = entity.SubcategoryId,
                Tiers = entity.Tiers,
                LinksToChannels = entity.LinksToChannels,
                Lessons = entity.Lessons,
                LessonsDate = entity.LessonsDate,
                AvarageDuration = entity.AvarageDuration,
                ExpectedAudience = entity.ExpectedAudience,
                Type = ItemType.OnlineCourse,

                UpdatedAt = entity.UpdatedAt
            };
        }
        public OnlineCourse ToEntity(CreateOnlineCourseRequest request)
        {
            return new OnlineCourse
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Description = request.Description,
                CountryId = request.CountryId,
                CurrentAmount = request.CurrentAmount,
                Images = request.Images,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Prices = request.Prices.Order().ToList(),
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                LinksToChannels = request.LinksToChannels,
                Lessons = request.Lessons,
                LessonsDate = request.LessonsDate,
                AvarageDuration = request.AvarageDuration,
                ExpectedAudience = request.ExpectedAudience,
                Type = ItemType.OnlineCourse,

                UpdatedAt = DateTime.UtcNow,
                Id = Guid.NewGuid(),

            };
        }
        public OnlineCourse ToUpdatedEntity(UpdateOnlineCourseRequest request)
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
                Prices = request.Prices.Order().ToList(),
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                LinksToChannels = request.LinksToChannels,
                Lessons = request.Lessons,
                LessonsDate = request.LessonsDate,
                AvarageDuration = request.AvarageDuration,
                ExpectedAudience = request.ExpectedAudience,
                Type = ItemType.OnlineCourse,
                UpdatedAt = DateTime.UtcNow
            };
            return onlineCourse;
        }




    }
}
