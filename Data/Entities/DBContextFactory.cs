using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DbContextFactory : IDesignTimeDbContextFactory<EdInvestContext>
    {
        public EdInvestContext CreateDbContext(string[] args)
        {
         
            var options = new DbContextOptionsBuilder<EdInvestContext>()
                .UseNpgsql("Server = localhost; Port = 5430; Database = EdInvest; User Id = postgres; Password = postgres;")
                .Options;

            return new EdInvestContext(options);
        }
    }
}
