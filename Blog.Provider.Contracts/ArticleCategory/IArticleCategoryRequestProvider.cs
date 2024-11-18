using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;

namespace Blog.Provider.Contracts.ArticleCategory
{
    public interface IArticleCategoryRequestProvider
    {
        public Task<OperationResultWithData<List<GetAuthorDto>>> GetAll();
        public Task<OperationResult> Create(CreateArticleCategoryDto articleCategoryDto);
        public Task<OperationResult> Update(UpdateAuthorDto articleCategoryDto);
        public Task<OperationResult> Delete(DeleteAuthorDto articleCategoryDto);
    }
}
