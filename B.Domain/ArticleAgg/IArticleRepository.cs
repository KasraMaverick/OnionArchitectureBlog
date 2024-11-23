using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<List<Article>> GetAll(long authorId);
        Task Publish(long articleId);
        Task Archive(long articleId);
    }
}
