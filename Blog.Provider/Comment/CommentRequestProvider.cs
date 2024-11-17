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

        public Task<OperationResult> Create(CreateCommentDto comment)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Delete(DeleteCommentDto comment)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(EditCommentDto comment)
        {
            throw new NotImplementedException();
        }
    }
}
