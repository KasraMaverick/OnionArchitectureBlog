using Blog.Management.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Management.Infrastructure.EfCore.Mappings
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategory");
            builder.HasKey(x => x.ArticleCategoryId);
            builder.Property(x => x.Title);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
