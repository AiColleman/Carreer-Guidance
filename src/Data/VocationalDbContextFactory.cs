using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class VocationalDbContextFactory : IDesignTimeDbContextFactory<VocationalDbContext>
    {
        public VocationalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VocationalDbContext>();
            optionsBuilder.UseSqlite("Data Source=vocational.db");

            return new VocationalDbContext(optionsBuilder.Options);
        }
    }
}
