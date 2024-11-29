using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author.Dtos;

namespace Blog.Provider.Contracts.Author
{
    public interface IAuthorRequestProvider
    {
        Task<OperationResultWithData<List<GetAuthorDto>>> GetAll();
        Task<OperationResult> Create(CreateAuthorDto author);
        Task<OperationResult> Update(UpdateAuthorDto author);
        Task<OperationResult> Delete(DeleteAuthorDto author);
        Task<OperationResult> Activate(long authorId);
        Task<OperationResult> Deactivate(long authorId);
    }
}
