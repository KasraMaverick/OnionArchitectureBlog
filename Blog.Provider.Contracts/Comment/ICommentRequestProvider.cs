using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment.Dtos;

namespace Blog.Provider.Contracts.Comment
{
    public interface ICommentRequestProvider
    {
        Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll(long articleId);
        Task<OperationResult> Create(CreateCommentDto comment);
        Task<OperationResult> Update(EditCommentDto comment);
        Task<OperationResult> ActivateForArticle(long articleId);
        Task<OperationResult> DeactivateForArticle(long articleId);
        Task<OperationResult> ActivateForAuthor(long authorId);
        Task<OperationResult> DeactivateForAuthor(long authorId);
        Task<OperationResult> LikeComment(long commentId);
        Task<OperationResult> DislikeComment(long commentId);

    }
}
