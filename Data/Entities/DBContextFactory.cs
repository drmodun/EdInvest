using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Config;

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
