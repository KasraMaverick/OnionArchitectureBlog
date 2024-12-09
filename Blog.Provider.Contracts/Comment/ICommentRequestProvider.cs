using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment.Dtos;

namespace Blog.Provider.Contracts.Comment
{
    public interface ICommentRequestProvider
    {
        Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll();
        Task<OperationResult> Create(CreateCommentDto comment);
        Task<OperationResult> Update(EditCommentDto comment);
        Task<OperationResult> Delete(DeleteCommentDto comment);
        Task<OperationResult> LikeComment(long commentId);
        Task<OperationResult> DislikeComment(long commentId);

    }
}
