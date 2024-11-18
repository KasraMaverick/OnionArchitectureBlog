using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author;
using Blog.Management.Application.Contracts.Author.Dtos;
using Blog.Management.Domain.AuthorAgg;

namespace Blog.Management.Application
{
    public class AuthorApplication : IAuthorApplication
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorApplication(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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
