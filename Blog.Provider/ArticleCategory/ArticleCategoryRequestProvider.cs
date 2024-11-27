using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;
using Blog.Provider.Contracts.ArticleCategory;

namespace Blog.Provider.ArticleCategory
{
    public class ArticleCategoryRequestProvider : IArticleCategoryRequestProvider
    {

        #region INJECTION

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ArticleCategoryRequestProvider(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        #endregion


        #region CRUD

        public async Task<OperationResultWithData<List<GetArticleCategoryDto>>> GetAll()
        {
            return await _articleCategoryApplication.GetAll();
        }

        public async Task<OperationResult> Create(CreateArticleCategoryDto dto)
        {
           return await _articleCategoryApplication.Create(dto);
        }

        public async Task<OperationResult> Update(UpdateArticleCategoryDto dto)
        {
            return await _articleCategoryApplication.Update(dto);
        }

        public async Task<OperationResult> Delete(DeleteArticleCategoryDto dto)
        {
            return await _articleCategoryApplication.Delete(dto);
        }

        #endregion
    }
}
