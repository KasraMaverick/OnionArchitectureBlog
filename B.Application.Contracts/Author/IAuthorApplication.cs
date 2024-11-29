using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author.Dtos;

namespace Blog.Management.Application.Contracts.Author
{
    public interface IAuthorApplication
    {
        Task<OperationResultWithData<List<GetAuthorDto>>> GetAll();
        Task<OperationResult> Create(CreateAuthorDto author);
        Task<OperationResult> Update(UpdateAuthorDto author);
        Task<OperationResult> Delete(DeleteAuthorDto author);
        Task<OperationResult> Activate(long authorId);
        Task<OperationResult> DeActivate(long authorId);
    }
}
