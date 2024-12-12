using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Provider.Contracts.Comment;

namespace Blog.Provider.Comment
{
    public class CommentRequestProvider : ICommentRequestProvider
    {

        #region INJECTION

        private readonly ICommentApplication _commentApplication;
        public CommentRequestProvider(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;  
        }

        #endregion


        #region CRUD

        public async Task<OperationResult> Create(CreateCommentDto comment)
        {
            return await _commentApplication.Create(comment);
        }

        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll(long articleId)
        {
            return _commentApplication.GetAll(articleId);
        }

        public async Task<OperationResult> Update(EditCommentDto comment)
        {
            return await _commentApplication.Update(comment);
        }

        #endregion


        #region LIKE/DISLIKE

        public async Task<OperationResult> LikeComment(long commentId)
        {
            return await _commentApplication.LikeComment(commentId);
        }

        public async  Task<OperationResult> DislikeComment(long commentId)
        {
            return await _commentApplication.DislikeComment(commentId);
        }

        #endregion


        #region ACTIVATE/DEACTIVATE FOT ARTICLE & AUTHOR

        public async Task<OperationResult> ActivateForArticle(long articleId)
        {
            return await _commentApplication.ActivateForArticle(articleId);
        }

        public async Task<OperationResult> DeactivateForArticle(long articleId)
        {
            return await _commentApplication.DeactivateForArticle(articleId);
        }

        public async Task<OperationResult> ActivateForAuthor(long authorId)
        {
            return await _commentApplication.ActivateForAuthor(authorId);
        }

        public async Task<OperationResult> DeactivateForAuthor(long authorId)
        {
            return await _commentApplication.DeactivateForAuthor(authorId);
        }

        #endregion
    }
}
