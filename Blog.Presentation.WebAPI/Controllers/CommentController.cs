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
        //-------------------- INJECTIONS --------------------\\
        private readonly ICommentRequestProvider _commentRequestProvider;
        public CommentController(ICommentRequestProvider commentRequestProvider)
        {
            _commentRequestProvider = commentRequestProvider;
        }

        //--------------------------------------------------------------------------------------------------------------

        [HttpGet("GetAll")]
        public async Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll()
        {
            var list = await _commentRequestProvider.GetAll();
            return list;
        }

        [HttpPost("Create")]
        public async Task<OperationResult> Create(CreateCommentDto dto)
        {
            var res = await _commentRequestProvider.Create(dto);
            return res;
        }

        [HttpDelete("Delete")]
        public async Task<OperationResult> Delete(DeleteCommentDto dto)
        {
            var res = await _commentRequestProvider.Delete(dto);
            return res;
        }

        [HttpPut("Update")]
        public async Task<OperationResult> Edit(EditCommentDto dto)
        {
            var res = await _commentRequestProvider.Update(dto);
            return res;
        }
    }
}
