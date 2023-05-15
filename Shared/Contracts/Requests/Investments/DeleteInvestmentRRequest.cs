namespace Shared.Contracts.Requests.Investments
{
    public class DeleteInvestmentRequest
    {
        public Guid InvaestorId { get; set; }
        public Guid ItemId { get; set; }
    }
}
