using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Management.Domain.CommentAgg;

namespace Blog.Management.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
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
