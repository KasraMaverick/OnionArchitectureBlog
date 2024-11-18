using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Domain.AuthorAgg;
using Blog.Management.Domain.CommentAgg;
using Blog.Management.Infrastructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new AuthorMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
