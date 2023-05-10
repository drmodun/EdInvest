using Data.Entities.Models;
using Domain.Contracts.Requests.Investments;
using Domain.Contracts.Responses.Investments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class InvestmentMapper
    {
        public static GetInvestmentResponse ToDTO(Investments investments)
        {
            return new GetInvestmentResponse
            {
                CreatedAt = investments.CreatedAt,
                InvestorId = investments.InvestorId,
                ItemId = investments.ItemId,
                UpdatedAt = investments.UpdatedAt,
                Tier = investments.Tier,

            };
        }
        public static Investments ToUpdatedEntity(UpdateInvestmentRequest request)
        {
            return new Investments
            {
                Tier = request.Tier,
                CreatedAt = request.CreatedAt,
                InvestorId = request.InvestorId,
                ItemId = request.ItemId,
                UpdatedAt = request.UpdatedAt,
            };
        }
        public static Investments ToEntity( CreateInvestmentRequest request) {
            return new Investments
            {
                Tier = request.Tier,
                CreatedAt = request.CreatedAt,
                InvestorId = request.InvestorId,
                ItemId = request.ItemId,
                UpdatedAt = request.UpdatedAt
            };
        }
    }
}
