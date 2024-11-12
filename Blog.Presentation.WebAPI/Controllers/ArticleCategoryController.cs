using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;
using Blog.Provider.ArticleCategory;
using Blog.Provider.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IArticleCategoryRequestProvider _articleCategoryProvider;
        public ArticleCategoryController(IArticleCategoryRequestProvider articleCategoryProvider)
        {
            _articleCategoryProvider = articleCategoryProvider;
        }

        [HttpGet("GetAll")]
        public async Task<OperationResultWithData<List<GetArticleCategoryDto>>> GetAll()
        {
            var list = await _articleCategoryProvider.GetAll();
            return list;
        }

        [HttpPost("Create")]
        public async Task<OperationResult> Create(CreateArticleCategoryDto dto)
        {
            var res = await _articleCategoryProvider.Create(dto);
            return res;
        }

        [HttpDelete("Delete")]
        public async Task<OperationResult> Delete(DeleteArticleCategoryDto dto)
        {
            var res = await _articleCategoryProvider.Delete(dto);
            return res;
        }

        [HttpPut("Update")]
        public async Task<OperationResult> Edit(UpdateArticleCategoryDto command)
        {
            var res = await _articleCategoryProvider.Update(command);
            return res;
        }
    }
}
