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

            builder.HasMany(x => x.Articles).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
            builder.HasMany(x => x.Comments).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
        }
    }
}
