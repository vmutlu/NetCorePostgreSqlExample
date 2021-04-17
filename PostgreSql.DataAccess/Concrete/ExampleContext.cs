using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostgreSql.DataAccess.Concrete.EntityFramework.Configurations;
using PostgreSql.Entities.Concrate;
using System.IO;

namespace PostgreSql.DataAccess.Concrete
{
    public class ExampleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Example> Examples { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExampleConfiguration());
        }
    }
}
