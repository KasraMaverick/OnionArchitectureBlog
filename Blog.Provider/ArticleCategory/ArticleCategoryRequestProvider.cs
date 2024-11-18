using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;
using Blog.Provider.Contracts.ArticleCategory;

namespace Blog.Provider.ArticleCategory
{
    public class ArticleCategoryRequestProvider : IArticleCategoryRequestProvider
    {

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ArticleCategoryRequestProvider(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        //--------------------- SIMPLE CRUD ---------------------\\
        public async Task<OperationResultWithData<List<GetAuthorDto>>> GetAll()
        {
            return await _articleCategoryApplication.GetAll();
        }

        public async Task<OperationResult> Create(CreateArticleCategoryDto dto)
        {
           return await _articleCategoryApplication.Create(dto);
        }

        public async Task<OperationResult> Update(UpdateAuthorDto dto)
        {
            return await _articleCategoryApplication.Update(dto);
        }

        public async Task<OperationResult> Delete(DeleteAuthorDto dto)
        {
            return await _articleCategoryApplication.Delete(dto);
        }
    }
}
