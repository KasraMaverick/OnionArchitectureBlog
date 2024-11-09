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
    }
}
