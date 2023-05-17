namespace Shared.Contracts.Responses
{
    public class StatsResponse
    {
        public int NumberOfInvestments { get; set; }
        public decimal TotalMoneyDonated { get; set; }

        public int NumberOfInvestors { get; set; }

        public int NumberOfProjects { get; set; }
    }
}
