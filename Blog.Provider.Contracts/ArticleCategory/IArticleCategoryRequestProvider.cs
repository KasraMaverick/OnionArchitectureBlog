using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;

namespace Blog.Provider.Contracts.ArticleCategory
{
    public interface IArticleCategoryRequestProvider
    {
        public Task<OperationResultWithData<List<GetArticleCategoryDto>>> GetAll();
        public Task<OperationResult> Create(CreateArticleCategoryDto articleCategory);
        public Task<OperationResult> Update(UpdateArticleCategoryDto articleCategory);
        public Task<OperationResult> Delete(DeleteArticleCategoryDto articleCategory);
    }
}
