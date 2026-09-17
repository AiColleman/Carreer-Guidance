using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class VocationalDbContextFactory : IDesignTimeDbContextFactory<VocationalDbContext>
    {
        public VocationalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VocationalDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");

            return new VocationalDbContext(optionsBuilder.Options);
        }
    }
}
