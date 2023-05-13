using API.Routes;
using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Application;
using Shared.Contracts.Responses.Category;
using Shared.Contracts.Responses.Items.Application;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly BaseService<Application, ApplicationMapper, ItemRepo<Application, GetApplicationRequest, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllApplicationsResponse, List<Application>
                > _applicationService;
        
        public ApplicationController(BaseService<Application, ApplicationMapper, ItemRepo<Application, GetApplicationRequest, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllApplicationsResponse, List<Application>
                > service)
        {
            _applicationService = service;
        }
        [HttpGet(AppRoutes.Application.Get)]
        public async Task<ActionResult<GetaApplicationResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetApplicationRequest
            {
                Id = id,
            };
            return await _applicationService.GetById(request);
        }
        [HttpPost(AppRoutes.Application.Create)]
        public async Task<ActionResult<CreateApplicationResponse>> Post([FromBody] CreateApplicationRequest request, CancellationToken cancellationToken)
        {
            var item = await _applicationService.Create(request, cancellationToken);
            return new CreateApplicationResponse
            {
                Success = item!=null,
                Application = item,
            };
        }
        [HttpPut(AppRoutes.Application.Update)]
        public async Task<ActionResult<UpdateApplicaionResponse>> Update([FromBody] CreateApplicationRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateApplicationRequest
                {
                    AppPurpose = request.AppPurpose,
                    CategoryId = request.CategoryId,
                    CountryId = request.CountryId,
                    CurrentAmount = request.CurrentAmount,
                    Description = request.Description,
                    EstimatedNumberOfUsers = request.EstimatedNumberOfUsers,
                    EstimatedRelease = request.EstimatedRelease,
                    Features = request.Features,
                    Goal = request.Goal,
                    Images = request.Images,
                    Id = id,
                    Markets = request.Markets,
                    Name = request.Name,
                    OrganisationId = request.OrganisationId,
                    SubcategoryId = request.SubcategoryId,
                    Prices = request.Prices,
                    Tiers = request.Tiers,
                };
            var item = await _applicationService.Update(updateRequest, cancellationToken);
            return new UpdateApplicaionResponse { Success = item != null, Application = item };

        }
        [HttpDelete(AppRoutes.Application.Delete)]
        public async Task<ActionResult<DeleteApplicationResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var deletion = await _applicationService.Delete(id, cancellationToken);
            return new DeleteApplicationResponse { Success = deletion };

        }
        [HttpGet(AppRoutes.Application.GetAll)]
        public async Task<ActionResult<GetAllApplicationsResponse>> GetAll([FromQuery] GetAllApplicationsRequest options)
        {
            var items =  await _applicationService.GetAll(options);
            return new GetAllApplicationsResponse
            {
                Applications = items,
            };
        }

    }
}
