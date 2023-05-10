using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Items.Application;
using Domain.Contracts.Responses.Items.Application;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Mappers
{
    public static class ApplicationMapper
    {
        public static GetaApplicationResponse ToDTO(Data.Entities.Models.Items.Application application)
        {
            var newDTO = new GetaApplicationResponse
            {
                Id = application.Id,
                Name = application.Name,
                Description = application.Description,
                Images = application.Images,
                CategoryId = application.CategoryId,
                SubcategoryId = application.SubcategoryId,
                Tiers = application.Tiers,
                AppPurpose = application.AppPurpose,
                EstimatedNumberOfUsers = application.EstimatedNumberOfUsers,
                EstimatedRelease = application.EstimatedRelease,
                CountryId = application.CountryId,
                CreatedAt = application.CreatedAt,
                CurrentAmount = application.CurrentAmount,
                Goal = application.Goal,
                OrganisationId = application.OrganisationId,
                Investments = application.Investments.Select(InvestmentMapper.ToDTO).ToList(),
                Features = application.Features,
                Markets = application.Markets,
                UpdatedAt = application.UpdatedAt,
                Type = application.Type,
                Prices = application.Prices,


            };
            return newDTO;

        }

        //problem with createdAt changing in updated property
        public static Data.Entities.Models.Items.Application ToEntity(CreateApplicationRequest request)
        {
            var newApp = new Data.Entities.Models.Items.Application
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Images = request.Images,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                AppPurpose = request.AppPurpose,
                EstimatedNumberOfUsers = request.EstimatedNumberOfUsers,
                EstimatedRelease = request.EstimatedRelease,
                CountryId = request.CountryId,
                CreatedAt = DateTime.UtcNow,
                CurrentAmount = request.CurrentAmount,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Features = request.Features,
                Markets = request.Markets,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                Prices = request.Prices,
            };
            return newApp;
        }
        public static Data.Entities.Models.Items.Application ToUpdatedEntity(UpdateApplicationRequest request)
        {
            var newApp = new Data.Entities.Models.Items.Application
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Images = request.Images,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                Tiers = request.Tiers,
                AppPurpose = request.AppPurpose,
                EstimatedNumberOfUsers = request.EstimatedNumberOfUsers,
                EstimatedRelease = request.EstimatedRelease,
                CountryId = request.CountryId,
                CurrentAmount = request.CurrentAmount,
                Goal = request.Goal,
                OrganisationId = request.OrganisationId,
                Features = request.Features,
                Markets = request.Markets,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                Prices = request.Prices,
            };
            return newApp;
        }

    }
}