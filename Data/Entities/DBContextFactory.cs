using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shared.Helpers;

namespace Data.Entities
{
    public class DbContextFactory : IDesignTimeDbContextFactory<EdInvestContext>
    {
        public EdInvestContext CreateDbContext(string[] args)
        {

            var options = new DbContextOptionsBuilder<EdInvestContext>()
                .UseNpgsql(ConfigurationHelper.GetConfiguration().GetConnectionString("Database"))
                .Options;

            return new EdInvestContext(options);
        }
    }
}
