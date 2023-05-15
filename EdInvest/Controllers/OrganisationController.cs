using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Requests.Users.organisation;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Contracts.Responses.Users.Organisation;
using Shared.Models.Users;

namespace API.Controllers
{
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly BaseService<Organisation, OrganisationMapper, UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest>, WriteRepo<Organisation, Guid>,
                CreateOrganisationRequest, UpdateOrganisationRequest, GetOrganisationRequest,
                GetAllOrganisationsRequest, Guid, GetOrganisationResponse,
                GetAllOrganisationsResponse, OrganisationValidation
                > _organisationService;

        public OrganisationController(BaseService<Organisation, OrganisationMapper, UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest>, WriteRepo<Organisation, Guid>,
                CreateOrganisationRequest, UpdateOrganisationRequest, GetOrganisationRequest,
                GetAllOrganisationsRequest, Guid, GetOrganisationResponse,
                GetAllOrganisationsResponse, OrganisationValidation
                > organisationService)
        {
            _organisationService = organisationService;
        }
        [HttpGet(AppRoutes.Organisation.Get)]
        public async Task<ActionResult<GetOrganisationResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetOrganisationRequest
            {
                Id = id,
            };
            return await _organisationService.GetById(request);
        }
        [HttpPost(AppRoutes.Organisation.Create)]
        public async Task<ActionResult<CreateOrganisationResponse>> Post([FromBody] CreateOrganisationRequest request, CancellationToken cancellationToken)
        {
            var item = await _organisationService.Create(request, cancellationToken);
            return new CreateOrganisationResponse
            {
                Success = item != null,
                Organisation = item,
            };
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]

        [HttpPut(AppRoutes.Organisation.Update)]
        public async Task<ActionResult<UpdateOrganisationResponse>> Update([FromBody] CreateOrganisationRequest request, CancellationToken cancellationToken)
        {

            var updateRequest =
                new UpdateOrganisationRequest
                {
                    Name = request.Name,
                    Description = request.Description,
                    Balance = request.Balance,
                    CountryId = request.CountryId,
                    Email = request.Email,
                    LocationName = request.LocationName,
                    NumberOfMembers = request.NumberOfMembers,
                    Password = request.Password,
                    ProfilePicture = request.ProfilePicture,
                    SocialLinks = request.SocialLinks,
                    WalletAddress = request.WalletAddress,
                    Id = (Guid)HttpContext.GetUserId(),
                };
            var item = await _organisationService.Update(updateRequest, cancellationToken);
            return new UpdateOrganisationResponse
            {
                Success = item != null,
                Organisation = item,
            };
        }
        //fix delete
        [Authorize(AuthConstants.AdminUserPolicyName)]
        [HttpDelete(AppRoutes.Organisation.Delete)]
        public async Task<ActionResult<DeleteOrganisationResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _organisationService.Delete(id, cancellationToken);
            return new DeleteOrganisationResponse
            {
                Success = item,
            };
        }
        [HttpGet(AppRoutes.Organisation.GetAll)]
        public async Task<ActionResult<GetAllOrganisationsResponse>> GetAll([FromQuery] GetAllOrganisationsRequest request)
        {
            var items = await _organisationService.GetAll(request);
            return new GetAllOrganisationsResponse
            {
                Organisations = items,
            };

        }

    }
}
