using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MedEl.Infrastructure.Database
{
    internal class MedElContextFactory : IDesignTimeDbContextFactory<MedElContext>
    {
        public MedElContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedElContext>();
            optionsBuilder.UseNpgsql("");

            return new MedElContext(optionsBuilder.Options, null);
        }
    }
}