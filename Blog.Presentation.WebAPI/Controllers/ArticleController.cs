using Blog.Provider.Contracts.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRequestProvider _articleRequestProvider;
        public ArticleController(IArticleRequestProvider articleRequestProvider)
        {
            _articleRequestProvider = articleRequestProvider;
        }
    }
}
