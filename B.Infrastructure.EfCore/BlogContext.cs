using B.Domain.ArticleCategoryAgg;
using B.Infrastructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace B.Infrastructure.EfCore
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
