using _0_Framework.Application.Model;

namespace B.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        public Task<OperationResultWithData<List<ArticleCategoryViewModel>>> GetAllArticleCategories();
        public Task Create(CreateArticleCategoryDto articleCategoryDto);
    }
}
