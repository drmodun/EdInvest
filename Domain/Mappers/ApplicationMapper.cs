using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Items.Application;
using Domain.Contracts.Responses.Items.Application;

namespace Domain.Mappers
{
    public   class ApplicationMapper : IMapper<Application, GetaApplicationResponse, CreateApplicationRequest, UpdateApplicationRequest>
    {
        private readonly InvestmentMapper _investmentMapper;

        public ApplicationMapper(InvestmentMapper investmentMapper)
        {
            _investmentMapper = investmentMapper;
        }
        public   GetaApplicationResponse ToDTO(Data.Entities.Models.Items.Application entity)
        {
            var newDTO = new GetaApplicationResponse
            {
                Id = entity .Id,
                Name = entity .Name,
                Description = entity .Description,
                Images = entity .Images,
                CategoryId = entity .CategoryId,
                SubcategoryId = entity .SubcategoryId,
                Tiers = entity .Tiers,
                AppPurpose = entity .AppPurpose,
                EstimatedNumberOfUsers = entity .EstimatedNumberOfUsers,
                EstimatedRelease = entity .EstimatedRelease,
                CountryId = entity .CountryId,
                CreatedAt = entity .CreatedAt,
                CurrentAmount = entity .CurrentAmount,
                Goal = entity .Goal,
                OrganisationId = entity .OrganisationId,
                Investments = entity .Investments.Select(_investmentMapper.ToDTO).ToList(),
                Features = entity .Features,
                Markets = entity .Markets,
                UpdatedAt = entity .UpdatedAt,
                Type = entity .Type,
                Prices = entity .Prices,


            };
            return newDTO;

        }

        //problem with createdAt changing in updated property
        public   Data.Entities.Models.Items.Application ToEntity(CreateApplicationRequest request)
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
        public   Data.Entities.Models.Items.Application ToUpdatedEntity(UpdateApplicationRequest request)
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