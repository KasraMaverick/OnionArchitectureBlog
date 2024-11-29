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
        #region INJECTION

        private readonly IAuthorRequestProvider _authorRequestProvider;
        public AuthorController(IAuthorRequestProvider authorRequestProvider)
        {
            _authorRequestProvider = authorRequestProvider;
        }

        #endregion


        #region CRUD

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

        #endregion


        #region ACTIVATE/DEACTIVATE

        [HttpPut("Activate")]
        public async Task<OperationResult> Activate(long authorId)
        {
            var res = await _authorRequestProvider.Activate(authorId);
            return res;
        }

        [HttpPut("Deactivate")]
        public async Task<OperationResult> Edit(long authorId)
        {
            var res = await _authorRequestProvider.Deactivate(authorId);
            return res;
        }

        #endregion
    }
}
