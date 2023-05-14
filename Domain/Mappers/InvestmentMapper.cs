using Shared.Models;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Responses.Investments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public   class InvestmentMapper : IMapper<Investments, GetInvestmentResponse, CreateInvestmentRequest, UpdateInvestmentRequest>
    {
        public   GetInvestmentResponse ToDTO(Investments entity)
        {
            return new GetInvestmentResponse
            {
                CreatedAt =  entity .CreatedAt,
                InvestorId = entity .InvestorId,
                ItemId = entity .ItemId,
                UpdatedAt = entity .UpdatedAt,
                Tier = entity .Tier,

            };
        }
        public   Investments ToUpdatedEntity(UpdateInvestmentRequest request)
        {
            return new Investments
            {
                Tier = request.Tier,
                InvestorId = (Guid)request.InvestorId,
                ItemId = request.ItemId,
                UpdatedAt = request.UpdatedAt,
            };
        }
        public   Investments ToEntity( CreateInvestmentRequest request) {
            return new Investments
            {
                Tier = request.Tier,
                CreatedAt = DateTime.UtcNow,
                InvestorId = (Guid)request.InvestorId,
                ItemId = request.ItemId,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
