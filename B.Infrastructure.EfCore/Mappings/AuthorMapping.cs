using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.AuthorAgg;

namespace Blog.Management.Infrastructure.EfCore.Mappings
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {

        }
    }
}
