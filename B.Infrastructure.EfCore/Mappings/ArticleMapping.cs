using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Management.Infrastructure.EfCore.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleId);
            builder.Property(x => x.Title);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.PublishedDate);
            builder.Property(x => x.ArchivedDate);
            builder.Property(x => x.Content);
            builder.Property(x => x.Excerpt);
            builder.Property(x => x.FeaturedImage);
            builder.Property(x => x.LastEditedDate);
            builder.Property(x => x.Status);
            
            builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
            builder.HasOne(x => x.Author).WithMany(x => x.Articles).HasForeignKey(x => x.AuthorId);
        }
    }
}
