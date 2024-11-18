using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author;
using Blog.Management.Application.Contracts.Author.Dtos;
using Blog.Provider.Contracts.Author;

namespace Blog.Provider.Author
{
    public class AuthorRequestProvider : IAuthorRequestProvider
    {
        private readonly IAuthorApplication _authorApplication;
        public AuthorRequestProvider(IAuthorApplication authorApplication)
        {
            _authorApplication = authorApplication;
        }

        public Task<OperationResult> Create(CreateAuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Delete(DeleteAuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultWithData<List<GetAuthorDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(UpdateAuthorDto author)
        {
            throw new NotImplementedException();
        }
    }
}
