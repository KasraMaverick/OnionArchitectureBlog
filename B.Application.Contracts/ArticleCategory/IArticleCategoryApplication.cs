using _0_Framework.Application.Model;

namespace Blog.Management.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        public Task<OperationResultWithData<List<ArticleCategoryViewModel>>> GetAllArticleCategories();
        public Task<OperationResult> Create(CreateArticleCategoryDto articleCategoryDto);
    }
}
