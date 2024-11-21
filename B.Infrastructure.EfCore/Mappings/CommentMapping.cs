using Blog.Management.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Management.Infrastructure.EfCore.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.CommentText);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.LastUpdatedDate);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.LikesCount);
            builder.Property(x => x.DislikesCount);



            builder.HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId);
            builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId);
        }
    }
}
