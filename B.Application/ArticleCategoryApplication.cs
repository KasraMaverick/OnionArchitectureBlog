using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Domain.ArticleCategoryAgg;
using System.Globalization;

namespace Blog.Management.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        //----------------------------------- CREATE ARTICLE CATEGORY -----------------------------------\\
        public async Task Create(CreateArticleCategoryDto articleCategoryDto)
        {
            var articleCategory = new ArticleCategory(articleCategoryDto.Title);
            await _articleCategoryRepository.AddArticleCategory(articleCategory);
        }

        //----------------------------------- GET ALL ARTICLE CATEGORIES -----------------------------------\\
        public async Task<OperationResultWithData<List<ArticleCategoryViewModel>>> GetAllArticleCategories()
        {
            var articleCategories = await _articleCategoryRepository.GetAllArticleCategories();
            var result = new List<ArticleCategoryViewModel>();

            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    ArticleCategoryId = articleCategory.ArticleCategoryId,
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
