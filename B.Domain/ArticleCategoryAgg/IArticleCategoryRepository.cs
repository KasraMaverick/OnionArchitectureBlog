using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<ArticleCategory>
    {
        Task<string> GetTitleById(long categoryId);
    }
}
