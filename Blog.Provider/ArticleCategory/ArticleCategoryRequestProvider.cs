using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;

namespace Blog.Provider.ArticleCategory
{
    public class ArticleCategoryRequestProvider
    {

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ArticleCategoryRequestProvider(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        //------------------------------ GET ALL ARTICLE CATEGORIES --------------------------------\\
        public async Task<OperationResultWithData<List<ArticleCategoryViewModel>>> GetAllArticleCategories()
        {
            return await _articleCategoryApplication.GetAllArticleCategories();
        }

        //------------------------------ CREATE AN ARTICLE CATEGORY ------------------------------\\
        public async Task<OperationResult> CreateArticleCategory(CreateArticleCategoryDto dto)
        {
           return await _articleCategoryApplication.Create(dto);
           
        }
    }
}
