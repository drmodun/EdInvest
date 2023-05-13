﻿using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Shared.Models.Users;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Responses.Users.Investor;
using Domain.Repositories.Interfaces;

namespace API.Controllers
{
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly BaseService<Investor, InvestorMapper, UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest,
                GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorsResponse, List<Investor>
                > _investorService;

        public InvestorController(BaseService<Investor, InvestorMapper, UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest,
                GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorsResponse, List<Investor>
                > investorService)
        {
            _investorService = investorService;
        }
        [HttpGet(AppRoutes.Investor.Get)]
        public async Task<ActionResult<GetInvestorResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetInvestorRequest { Id = id };
            return await _investorService.GetById(request);
        }
        [HttpPost(AppRoutes.Investor.Create)]
        public async Task<ActionResult<CreateInvestorResponse>> Post([FromBody] CreateInvestorRequest request, CancellationToken cancellationToken)
        {
            var item = await _investorService.Create(request, cancellationToken);
            return new CreateInvestorResponse
            {
                Success = item != null,
                Investor = item,
            };
        }
        [HttpPut(AppRoutes.Investor.Update)]
        public async Task<ActionResult<UpdateInvestorResponse>> Update([FromBody] CreateInvestorRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateInvestorRequest
                {
                    Name = request.Name,
                    Description = request.Description,
                    Balance = request.Balance,
                    CountryId = request.CountryId,
                    Email = request.Email,
                    IsAdmin = request.IsAdmin,
                    LocationName = request.LocationName,
                    NumberOfEmployees = request.NumberOfEmployees,
                    Password = request.Password,
                    ProfilePicture = request.ProfilePicture,
                    SocialLinks = request.SocialLinks,
                    Type = request.Type,
                    WalletAddress = request.WalletAddress,
                    Id = id,
                };
            var item = await _investorService.Update(updateRequest, cancellationToken);
            return new UpdateInvestorResponse
            {
                Success = item != null,
                Investor = item,
            };
        }
        [HttpDelete(AppRoutes.Investor.Delete)]
        public async Task<ActionResult<DeleteInvestorResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _investorService.Delete(id, cancellationToken);
            return new DeleteInvestorResponse
            {
                Success = item,
            };
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
