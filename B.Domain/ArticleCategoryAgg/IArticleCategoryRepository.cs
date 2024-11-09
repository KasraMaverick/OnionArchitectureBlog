using _0_Framework.Application.Model;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        //Task<List<ArticleCategory>> SearchArticleCategories(ArticleCategory dto);
        Task<OperationResultWithData<List<ArticleCategory>>> GetAllArticleCategories();
        Task AddArticleCategory(ArticleCategory articleCategory);
    }
}
