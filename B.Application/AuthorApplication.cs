using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Author;
using Blog.Management.Application.Contracts.Author.Dtos;
using Blog.Management.Domain.AuthorAgg;

namespace Blog.Management.Application
{
    public class AuthorApplication : IAuthorApplication
    {

        #region INJECTION

        private readonly IAuthorRepository _authorRepository;
        public AuthorApplication(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        #endregion


        #region CRUD

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

        #endregion


        #region ACTIVATE/DEACTIVATE

        public async Task<OperationResult> Activate(long authorId)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _authorRepository.Activate(authorId);

                if (res)
                {
                    return operation.Succeeded(res);
                }

                return operation.Failed();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResult> DeActivate(long authorId)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _authorRepository.Deactivate(authorId);

                if (res)
                {
                    return operation.Succeeded(res);
                }

                return operation.Failed();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
