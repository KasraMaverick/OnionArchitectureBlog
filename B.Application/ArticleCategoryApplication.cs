using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Domain.ArticleCategoryAgg;
using System.Globalization;
using System.Net;

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
        public async Task<OperationResult> Create(CreateArticleCategoryDto articleCategoryDto)
        {
            var operation = new OperationResult();
            

            try
            {
                var articleCategory = new ArticleCategory(articleCategoryDto.Title);
                var res = await _articleCategoryRepository.AddArticleCategory(articleCategory);

                return operation.Succeeded(res);
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        //----------------------------------- GET ALL ARTICLE CATEGORIES -----------------------------------\\
        public async Task<OperationResultWithData<List<ArticleCategoryViewModel>>> GetAllArticleCategories()
        {
            var operation = new OperationResultWithData<List<ArticleCategoryViewModel>>();

            try
            {
                var res = await _articleCategoryRepository.GetAllArticleCategories();
                if (!res.IsSucceeded)
                {
                    return operation.Failed(res.Message);
                }
                if (res == null)
                {
                    return operation.Failed();
                }

                var result = new List<ArticleCategoryViewModel>();

                foreach (var articleCategory in res.Result)
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
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {

                var errorCode = ex.Error<ArticleCategoryApplication>();
                return operation.Failed(HttpStatusCode.InternalServerError, errorCode);
            }

            var articleCategories = await _articleCategoryRepository.GetAllArticleCategories();
           

            return result;
        }
    }
}
