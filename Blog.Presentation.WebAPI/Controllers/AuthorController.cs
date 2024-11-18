using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author.Dtos;
using Blog.Provider.Contracts.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRequestProvider _authorRequestProvider;
        public AuthorController(IAuthorRequestProvider authorRequestProvider)
        {
            _authorRequestProvider = authorRequestProvider;
        }

        [HttpGet("GetAll")]
        public async Task<OperationResultWithData<List<GetAuthorDto>>> GetAll()
        {
            var list = await _authorRequestProvider.GetAll();
            return list;
        }

        [HttpPost("Create")]
        public async Task<OperationResult> Create(CreateAuthorDto dto)
        {
            var res = await _authorRequestProvider.Create(dto);
            return res;
        }

        [HttpDelete("Delete")]
        public async Task<OperationResult> Delete(DeleteAuthorDto dto)
        {
            var res = await _authorRequestProvider.Delete(dto);
            return res;
        }

        [HttpPut("Update")]
        public async Task<OperationResult> Edit(UpdateAuthorDto dto)
        {
            var res = await _authorRequestProvider.Update(dto);
            return res;
        }
    }
}
