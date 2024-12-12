using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Provider.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        #region INJECTION

        private readonly ICommentRequestProvider _commentRequestProvider;
        public CommentController(ICommentRequestProvider commentRequestProvider)
        {
            _commentRequestProvider = commentRequestProvider;
        }

        #endregion


        #region CRUD

        [HttpGet("GetAll")]
        public async Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll(long articleId)
        {
            var list = await _commentRequestProvider.GetAll(articleId);
            return list;
        }

        [HttpPost("Create")]
        public async Task<OperationResult> Create(CreateCommentDto dto)
        {
            var res = await _commentRequestProvider.Create(dto);
            return res;
        }

        [HttpPut("Update")]
        public async Task<OperationResult> Edit(EditCommentDto dto)
        {
            var res = await _commentRequestProvider.Update(dto);
            return res;
        }

        #endregion


        #region LIKE/DISLIKE

        [HttpPut("Like")]
        public async Task<OperationResult> Like(long commentId)
        {
            var res = await _commentRequestProvider.LikeComment(commentId);
            return res;
        }

        [HttpPut("Dislike")]
        public async Task<OperationResult> Dislike(long commentId)
        {
            var res = await _commentRequestProvider.DislikeComment(commentId);
            return res;
        }

        #endregion


        #region ACTIVATE/DEACTIVATE FOR ARTICLE & AUTHOR

        [HttpPut("ActivateForArticle")]
        public async Task<OperationResult> ActivateForArticle(long articleId)
        {
            var res = await _commentRequestProvider.ActivateForArticle(articleId);
            return res;
        }

        [HttpPut("DeactivateForArticle")]
        public async Task<OperationResult> DeactivateForArticle(long articleId)
        {
            var res = await _commentRequestProvider.DeactivateForArticle(articleId);
            return res;
        }

        [HttpPut("ActivateForAuthor")]
        public async Task<OperationResult> ActivateForAuthor(long authorId)
        {
            var res = await _commentRequestProvider.ActivateForAuthor(authorId);
            return res;
        }

        [HttpPut("DeactivateForAuthor")]
        public async Task<OperationResult> DeactivateForAuthor(long authorId)
        {
            var res = await _commentRequestProvider.DeactivateForAuthor(authorId);
            return res;
        }

        #endregion

    }
}
