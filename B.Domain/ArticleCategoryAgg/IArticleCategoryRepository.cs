using _0_Framework.Application.Model;
using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<ArticleCategory>
    {
        Task<List<ArticleCategory>> GetTitles();
    }
}
