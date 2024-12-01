using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.AuthorAgg
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<bool> Deactivate(long authorId);
        Task<bool> Activate(long authorId);
        Task<bool> AddArticleCount(long authorId);
    }
}
