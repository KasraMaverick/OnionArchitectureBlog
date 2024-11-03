using B.Application.Contracts.ArticleCategory;
using B.Domain.ArticleCategoryAgg;
using System.Globalization;

namespace B.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        //----------------------------------- GET ALL ARTICLE CATEGORIES -----------------------------------\\
        public async Task<List<ArticleCategoryViewModel>> GetAllArticleCategories()
        {
            var articleCategories = await _articleCategoryRepository.GetAllArticleCategories();
            var result = new List<ArticleCategoryViewModel>();

            foreach(var articleCategory in articleCategories) 
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreatedDate = articleCategory.CreatedDate.ToString(CultureInfo.InvariantCulture),
                    UpdatedDate = articleCategory.UpdatedDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return result;
        }
    }
}
