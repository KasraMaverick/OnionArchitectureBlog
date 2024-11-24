using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;

namespace Blog.Management.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        Task<OperationResultWithData<List<GetArticleCategoryDto>>> GetAll();
        Task<OperationResult> Create(CreateArticleCategoryDto articleCategory);
        Task<OperationResult> Update(UpdateArticleCategoryDto articleCategory);
        Task<OperationResult> Delete(DeleteArticleCategoryDto articleCategory);
        Task<OperationResultWithData<List<GetArticleCategoryTitleDto>>> GetTitles();

    }
}
