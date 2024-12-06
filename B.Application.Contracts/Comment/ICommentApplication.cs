using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment.Dtos;

namespace Blog.Management.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        Task<OperationResult> Create(CreateCommentDto comment);
        Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll(long articleId);
        Task<OperationResult> Update(EditCommentDto comment);
        Task<OperationResult> ActivateForArticle(long articleId);
        Task<OperationResult> DeactivateForArticle(long articleId);
        
    }
}
