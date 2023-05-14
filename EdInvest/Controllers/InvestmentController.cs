using API.Auth;
using API.Routes;
using Domain.Helpers;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Responses.Investments;
using Shared.Models;
using Shared.Constants;

namespace API.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>,
                           CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest,
                                          GetAllInvestmentsRequest, N_NKey, GetInvestmentResponse,
                                                         GetAllInvestmentsResponse, InvestmentsValidation
                           > _investmentService;
        public InvestmentController(BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>,
                           CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest,
                                          GetAllInvestmentsRequest, N_NKey, GetInvestmentResponse,
                                                         GetAllInvestmentsResponse, InvestmentsValidation
                           > investmentService)
        {
            _investmentService = investmentService;
        }
        [HttpGet(AppRoutes.Investments.Get)]
        public async Task<ActionResult<GetInvestmentResponse>> Get([FromRoute] Guid investorId, [FromRoute] Guid itemId)
        {
            var request = new GetInvestmentRequest
            {
                InvestorId = investorId,
                itemId = itemId
            };
            return await _investmentService.GetById(request);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.Investments.Create)] 
        public async Task<ActionResult<CreateInvestmentResponse>> Post([FromRoute] Guid itemId, [FromBody] int tier, CancellationToken cancellationToken)
        {
            var request = new CreateInvestmentRequest
            {
                ItemId = itemId,
                Tier = tier,
                CreatedAt = DateTime.UtcNow,
                InvestorId = HttpContext.GetUserId()
                
            };
            var item = await _investmentService.Create(request, cancellationToken);
            return new CreateInvestmentResponse
            {
                Success = item != null,
                Investment = item,
            };
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.Investments.Update)]
        public async Task<ActionResult<UpdateInvestmentResponse>> Update([FromRoute] Guid itemId, [FromBody] int tier, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateInvestmentRequest
                {
                    InvestorId = HttpContext.GetUserId(),
                    ItemId = itemId,
                    Tier = tier,
                    UpdatedAt = DateTime.UtcNow,
                };
            var item = await _investmentService.Update(updateRequest, cancellationToken);
            return new UpdateInvestmentResponse
            {
                Success = item != null,
                Investment = item,
            };
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
            return new DeleteInvestmentResponse
            {
                Success = item != null,
            };
        }
        [HttpGet(AppRoutes.Investments.GetAll)]
        public async Task<ActionResult<GetAllInvestmentsResponse>> GetAll([FromQuery] GetAllInvestmentsRequest options)
        {
            var items = await _investmentService.GetAll(options);
            return new GetAllInvestmentsResponse
            {
                Investments = items
            };
        }
    }
}
