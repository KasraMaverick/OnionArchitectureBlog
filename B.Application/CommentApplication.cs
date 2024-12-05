using _0_Framework.Application.Model;
using _0_Framework.Log;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Management.Domain.CommentAgg;

namespace Blog.Management.Application
{
    public class CommentApplication : ICommentApplication
    {

        #region INJECTION

        private readonly ICommentRepository _commentRepository;
        private readonly ILogService _logService;
        public CommentApplication(ICommentRepository commentRepository,
                                  ILogService logService)
        {
            _commentRepository = commentRepository;
            _logService = logService;
        }

        #endregion


        #region CRUD

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

        #endregion

    }
}
