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
    }
}
