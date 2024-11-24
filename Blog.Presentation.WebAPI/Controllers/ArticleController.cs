using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article.Dtos;
using Blog.Provider.Contracts.Article;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        #region INJECTION

        private readonly IArticleRequestProvider _articleRequestProvider;
        public ArticleController(IArticleRequestProvider articleRequestProvider)
        {
            _articleRequestProvider = articleRequestProvider;
        }

        #endregion


        #region CRUD

        [HttpGet("GetAll")]
        public async Task<OperationResultWithData<List<GetArticleDto>>> GetAll(long authorId)
        {
            var list = await _articleRequestProvider.GetAll(authorId);
            return list;
        }

        [HttpPost("Create")]
        public async Task<OperationResult> Create(CreateArticleDto dto)
        {
            var res = await _articleRequestProvider.Create(dto);
            return res;
        }

        [HttpDelete("Delete")]
        public async Task<OperationResult> Delete(DeleteArticleDto dto)
        {
            var res = await _articleRequestProvider.Delete(dto);
            return res;
        }

        [HttpPut("Update")]
        public async Task<OperationResult> Edit(UpdateArticleDto dto)
        {
            var res = await _articleRequestProvider.Update(dto);
            return res;
        }

        #endregion


        #region PUBLISH & ARCHIVE

        [HttpPut("Publish")]
        public async Task<OperationResult> Publish(long articleId)
        {
            var res = await _articleRequestProvider.Publish(articleId);
            return res;
        }

        [HttpPut("Archive")]
        public async Task<OperationResult> Archive(long articleId)
        {
            var res = await _articleRequestProvider.Archive(articleId);
            return res;
        }

        #endregion

    }
}
