using API.Routes;
using Domain.Helpers;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Responses.Investments;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>,
                           CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest,
                                          GetAllInvestmentsRequest, N_NKey, GetInvestmentResponse,
                                                         GetAllInvestmentsResponse, List<Investments>
                           > _investmentService;
        public InvestmentController(BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>,
                           CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest,
                                          GetAllInvestmentsRequest, N_NKey, GetInvestmentResponse,
                                                         GetAllInvestmentsResponse, List<Investments>
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
        [HttpPost(AppRoutes.Investments.Create)]
        public async Task<ActionResult<CreateInvestmentResponse>> Post([FromBody] CreateInvestmentRequest request, CancellationToken cancellationToken)
        {
            var item = await _investmentService.Create(request, cancellationToken);
            return new CreateInvestmentResponse
            {
                Success = item != null,
                Investment = item,
            };
        }
        [HttpPut(AppRoutes.Investments.Update)]
        public async Task<ActionResult<UpdateInvestmentResponse>> Update([FromBody] CreateInvestmentRequest request, [FromRoute] Guid investorId, [FromRoute] Guid itemId, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateInvestmentRequest
                {
                    InvestorId = investorId,
                    ItemId = itemId,
                    Tier = request.Tier,
                    UpdatedAt = DateTime.UtcNow,
                };
            var item = await _investmentService.Update(updateRequest, cancellationToken);
            return new UpdateInvestmentResponse
            {
                Success = item != null,
                Investment = item,
            };
        }
        [HttpDelete(AppRoutes.Investments.Delete)]
        public async Task<ActionResult<DeleteInvestmentResponse>> Delete([FromRoute] DeleteInvestmentRequest request, CancellationToken cancellationToken)
        {
            var key = new N_NKey
            {
                investorId = request.InvaestorId,
                itemId = request.ItemId
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
