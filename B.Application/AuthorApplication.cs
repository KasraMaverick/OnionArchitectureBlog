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

        public async Task<OperationResult> Update(UpdateAuthorDto author)
        {
            var operation = new OperationResult();

            try
            {
                Author article = await _authorRepository.GetById(author.AuthorId);
                article.Edit(author.FirstName, author.LastName, author.ImageUrl, author.Bio);
                var res = await _authorRepository.Edit(article, author.AuthorId);

                if (res == null)
                {
                    return operation.Failed();
                }

                return operation.Succeeded(res);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region ADD-ARTICLE-COUNT / ACTIVATE / DEACTIVATE

        public async Task<OperationResult> AddArticleCount(long authorId)
        {

            var operation = new OperationResult();
            try
            {
                var res = await _authorRepository.AddArticleCount(authorId);

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
