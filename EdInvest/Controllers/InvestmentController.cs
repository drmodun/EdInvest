using API.Auth;
using API.Routes;
using Domain.Helpers;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Responses;
using Shared.Contracts.Responses.Investments;
using Shared.Contracts.Responses.Ranked;
using Shared.Contracts.Responses.RankedInvestor;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>,
                           CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest,
                                          GetAllInvestmentsRequest, N_NKey, RankedInvestmentResponse,
                                                         AllRankedInvestmentsResponse, InvestmentsValidation
                           > _investmentService;

        private readonly RankedService _rankedService;
        public InvestmentController(BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>,
                           CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest,
                                          GetAllInvestmentsRequest, N_NKey, RankedInvestmentResponse,
                                                         AllRankedInvestmentsResponse, InvestmentsValidation
                           > investmentService, RankedService rankedService)
        {
            _investmentService = investmentService;
            _rankedService = rankedService;
        }
        [HttpGet(AppRoutes.Investments.Get)]
        public async Task<ActionResult<GetInvestmentResponse>> Get([FromRoute] Guid investorId, [FromRoute] Guid itemId)
        {
            var request = new GetInvestmentRequest
            {
                InvestorId = investorId,
                itemId = itemId
            };
            var item = await _investmentService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.Investments.Create)]
        public async Task<ActionResult<CreateInvestmentResponse>> Post([FromRoute] Guid itemId, [FromBody] decimal amount, CancellationToken cancellationToken)
        {
            var request = new CreateInvestmentRequest
            {
                ItemId = itemId,
                InvestorId = HttpContext.GetUserId(),
                Amount = amount

            };
            var item = await _investmentService.Create(request, cancellationToken);
            var response = new CreateInvestmentResponse { Success = item != null, Investment = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.Investments.Update)]
        public async Task<ActionResult<UpdateInvestmentResponse>> Update([FromRoute] Guid itemId, [FromBody] decimal amount, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateInvestmentRequest
                {
                    InvestorId = HttpContext.GetUserId(),
                    ItemId = itemId,
                    Amount = amount,
                };
            var item = await _investmentService.Update(updateRequest, cancellationToken, new N_NKey { investorId = updateRequest.InvestorId, itemId = updateRequest.ItemId });
            var response = new UpdateInvestmentResponse { Success = item != null, Investment = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpDelete(AppRoutes.Investments.Delete)]
        public async Task<ActionResult<DeleteInvestmentResponse>> Delete([FromRoute] Guid itemId, CancellationToken cancellationToken)
        {
            var key = new N_NKey
            {
                investorId = HttpContext.GetUserId(),
                itemId = itemId
            };
            var item = await _investmentService.Delete(key, cancellationToken);
            var response = new DeleteInvestmentResponse { Success = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet(AppRoutes.Investments.GetAll)]
        public async Task<ActionResult<AllRankedInvestmentsResponse>> GetAll([FromQuery] GetAllInvestmentsRequest options)
        {
            var items = await _investmentService.GetAll(options);
            return new AllRankedInvestmentsResponse
            {
                Investments = items
            };
        }

        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpGet(AppRoutes.Investments.UserInvestments)]
        public async Task<ActionResult<AllRankedItemsResponse>> GetAllFromUser()
        {

            var items = await _rankedService.GetMyInvestedItems((Guid)HttpContext.GetUserId());
            return new AllRankedItemsResponse
            {
                Items = items,
            };
        }
        [HttpGet(AppRoutes.Investments.GetInvestors)]
        public async Task<ActionResult<AllRankedResponse>> GetAllInvestors([FromRoute] Guid itemId)
        {

            var items = await _rankedService.GetInvestors(itemId);
            return new AllRankedResponse
            {
                Investments = items
            };
        }
        [HttpGet(AppRoutes.Investments.TopInvestors)]
        public async Task<ActionResult<AllRankedResponse>> GetTopInvestors()
        {
            var items = await _rankedService.GetTopInvestors();
            return new AllRankedResponse
            {
                Investments = items
            };
        }
        [HttpGet(AppRoutes.Investments.Stats)]
        public async Task<ActionResult<StatsResponse>> GetStats()
        {
            var item = await _rankedService.GetStats();
            return item;
        }

        [HttpGet(AppRoutes.Investments.GetItems)]
        public async Task<ActionResult<AllRankedItemsResponse>> GetInvestedItemsFromInvestor([FromRoute] Guid investorId)
        {
            var items = await _rankedService.GetItemsForInvestor(investorId);
            return new AllRankedItemsResponse
            {
                Items = items
            };
        
        }
        [HttpGet(AppRoutes.Investments.GetInvesstmentsForOrganisation)]
        public async Task<ActionResult<AllRankedInvestmentsResponse>> GetInvestmentsForOrganisation([FromRoute] Guid organisationId)
        {
            var items = await _rankedService.GetInvestmentsForOrganisation(organisationId);
            return new AllRankedInvestmentsResponse
            {
                Investments = items
            };
        }


    }
}
