using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp
{
    internal class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
            //optionsBuilder.UseSqlServer("Server=10.67.5.10;Database=UkrBilling;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=gies1;Database=UkrBilling;Trusted_Connection=True;");

            return new MainDbContext(optionsBuilder.Options);
        }
    }
}
