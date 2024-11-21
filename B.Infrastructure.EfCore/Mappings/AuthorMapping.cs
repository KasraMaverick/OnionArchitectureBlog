using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.AuthorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Management.Infrastructure.EfCore.Mappings
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.AuthorId);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.UserId);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Bio);
            builder.Property(x => x.ArticleCount);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.IsActive);

            //---------- RELATIONSHIPS -----------\\
            builder.HasMany(x => x.Articles).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
            builder.HasMany(x => x.Comments).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
        }
    }
}
