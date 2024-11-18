using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author.Dtos;

namespace Blog.Provider.Contracts.Author
{
    public interface IAuthorRequestProvider
    {
        public Task<OperationResultWithData<List<GetAuthorDto>>> GetAll();
        public Task<OperationResult> Create(CreateAuthorDto author);
        public Task<OperationResult> Update(UpdateAuthorDto author);
        public Task<OperationResult> Delete(DeleteAuthorDto author);
    }
}
