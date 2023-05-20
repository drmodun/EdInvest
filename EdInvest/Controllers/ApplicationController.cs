using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Items.Application;
using Shared.Contracts.Responses.Items.Application;
using Shared.Models.Items;

namespace API.Controllers
{
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly BaseService<Application, ApplicationMapper, ItemRepo<Application, GetApplicationRequest, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllApplicationsResponse, ApplicationValidation
                > _applicationService;

        public ApplicationController(BaseService<Application, ApplicationMapper, ItemRepo<Application, GetApplicationRequest, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllApplicationsResponse, ApplicationValidation
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
            var item = await _applicationService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.Application.Create)]
        public async Task<ActionResult<CreateApplicationResponse>> Post([FromBody] CreateApplicationRequest request, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var item = await _applicationService.Create(request, cancellationToken);
            var response = new CreateApplicationResponse { Success = item != null, Application = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.Application.Update)]
        public async Task<ActionResult<UpdateApplicaionResponse>> Update([FromBody] CreateApplicationRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var updateRequest =
                new UpdateApplicationRequest
                {
                    AppPurpose = request.AppPurpose,
                    CategoryId = request.CategoryId,

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
            var item = await _applicationService.Update(updateRequest, cancellationToken, updateRequest.Id);
            var response = new UpdateApplicaionResponse { Success = item != null, Application = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpDelete(AppRoutes.Application.Delete)]

        public async Task<ActionResult<DeleteApplicationResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _applicationService.GetById(new GetApplicationRequest { Id = id });
            if (item.OrganisationId != HttpContext.GetUserId()) { return BadRequest("Cannot delete a item that you do not own"); }
            var deletion = await _applicationService.Delete(id, cancellationToken);
            var response = new DeleteApplicationResponse { Success = deletion };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpGet(AppRoutes.Application.GetAll)]
        public async Task<ActionResult<GetAllApplicationsResponse>> GetAll([FromQuery] GetAllApplicationsRequest options)
        {
            var items = await _applicationService.GetAll(options);
            return new GetAllApplicationsResponse
            {
                Applications = items,
            };
        }

    }
}
