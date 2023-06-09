﻿using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Responses.Users.Investor;
using Shared.Models.Users;

namespace API.Controllers
{
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly BaseService<Investor, InvestorMapper, UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest,
                GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorsResponse, InvestorValidation
                > _investorService;

        public InvestorController(BaseService<Investor, InvestorMapper, UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest,
                GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorsResponse, InvestorValidation
                > investorService)
        {
            _investorService = investorService;
        }
        [HttpGet(AppRoutes.Investor.Get)]
        public async Task<ActionResult<GetInvestorResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetInvestorRequest { Id = id };
            var item = await _investorService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [HttpPost(AppRoutes.Investor.Create)]
        public async Task<ActionResult<CreateInvestorResponse>> Post([FromBody] CreateInvestorRequest request, CancellationToken cancellationToken)
        {
            var item = await _investorService.Create(request, cancellationToken);
            var response = new CreateInvestorResponse { Success = item != null, Investor = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.Investor.Update)]
        public async Task<ActionResult<UpdateInvestorResponse>> Update([FromBody] CreateInvestorRequest request, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateInvestorRequest
                {
                    Name = request.Name,
                    Description = request.Description,

                    Email = request.Email,
                    LocationName = request.LocationName,
                    NumberOfEmployees = request.NumberOfEmployees,
                    Password = request.Password,
                    ProfilePicture = request.ProfilePicture,
                    SocialLinks = request.SocialLinks,
                    Type = request.Type,
                    WalletAddress = request.WalletAddress,
                    Id = (Guid)HttpContext.GetUserId(),
                };
            var item = await _investorService.Update(updateRequest, cancellationToken, updateRequest.Id);
            var response = new UpdateInvestorResponse { Success = item != null, Investor = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.AdminUserPolicyName)]
        [HttpDelete(AppRoutes.Investor.Delete)]
        public async Task<ActionResult<DeleteInvestorResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _investorService.Delete(id, cancellationToken);
            var response = new DeleteInvestorResponse { Success = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet(AppRoutes.Investor.GetAll)]
        public async Task<ActionResult<GetAllInvestorsResponse>> GetAll([FromQuery] GetAllInvestorsRequest request)
        {
            var items = await _investorService.GetAll(request);
            return new GetAllInvestorsResponse
            {
                Investors = items,
            };

        }

    }
}
