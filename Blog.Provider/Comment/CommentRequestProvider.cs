using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Provider.Contracts.Comment;

namespace Blog.Provider.Comment
{
    public class CommentRequestProvider : ICommentRequestProvider
    {
        private readonly ICommentApplication _commentApplication;
        public CommentRequestProvider(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;  
        }

        public async Task<OperationResult> Create(CreateCommentDto comment)
        {
            return await _commentApplication.Create(comment);
        }

        public Task<OperationResult> Delete(DeleteCommentDto comment)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Update(EditCommentDto comment)
        {
            return await _commentApplication.Update(comment);
        }

        public async Task<OperationResult> LikeComment(long commentId)
        {
            return await _commentApplication.LikeComment(commentId);
        }

        public async  Task<OperationResult> DislikeComment(long commentId)
        {
            return await _commentApplication.DislikeComment(commentId);
        }
    }
}
