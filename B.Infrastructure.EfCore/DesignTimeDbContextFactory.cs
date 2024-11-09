using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Blog.Management.Infrastructure.EfCore
{
    public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            // Configure the DbContextOptions with a connection string
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            var connectionString = configuration.GetConnectionString("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BlogDb;Persist Security Info=True;User ID=sa;Password=kasra123");
            optionsBuilder.UseSqlServer(connectionString);

            return new BlogContext(optionsBuilder.Options);
        }
    }
}
