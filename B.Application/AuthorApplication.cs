using System.Globalization;
using _0_Framework.Application.Model;
using _0_Framework.Log;
using Blog.Management.Application.Contracts.Author;
using Blog.Management.Application.Contracts.Author.Dtos;
using Blog.Management.Domain.AuthorAgg;

namespace Blog.Management.Application
{
    public class AuthorApplication : IAuthorApplication
    {

        #region INJECTION

        private readonly ILogService _logService;
        private readonly IAuthorRepository _authorRepository;
        const string className = nameof(AuthorApplication);

        public AuthorApplication(IAuthorRepository authorRepository,
                                 ILogService logService)
        {
            _authorRepository = authorRepository;
            _logService = logService;
        }

        #endregion


        #region CRUD

        public Task<OperationResult> Create(CreateAuthorDto author)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResultWithData<List<GetAuthorDto>>> GetAll()
        {
            var operation = new OperationResultWithData<List<GetAuthorDto>>();

            try
            {
                var res = await _authorRepository.Get();

                if (res == null)
                {
                    _logService.LogWarning(@$"{className}/GetAll", "getall results were null");
                    return operation.Failed();
                }

                var result = new List<GetAuthorDto>();

                foreach (var author in res)
                {
                    result.Add(new GetAuthorDto
                    {
                        AuthorId = author.AuthorId,
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        ImageUrl = author.ImageUrl,
                        Bio = author.Bio,
                        ArticleCount = author.ArticleCount,
                        CreatedDate = author.CreatedDate.ToString(CultureInfo.InvariantCulture),
                    });
                }

                _logService.LogInformation(@$"{className}/GetAll", "getall was successful");
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in getall");
                return operation.Failed();
            }
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
                    _logService.LogError(@$"{className}/Update", "update results were null");
                    return operation.Failed();
                }

                _logService.LogInformation(@$"{className}/Update", "update was successful");
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in activate");
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
                    _logService.LogInformation(@$"{className}/AddArticleCount", "addarticlecount results were true");
                    return operation.Succeeded(res);
                }

                _logService.LogError(@$"{className}/AddArticleCount", "addarticlecount results were false");
                return operation.Failed();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in addarticlecount");
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
                    _logService.LogInformation(@$"{className}/Activate", "activate results were true");
                    return operation.Succeeded(res);
                }

                _logService.LogError(@$"{className}/Activate", "activate results were false");
                return operation.Failed();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in activate");
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
                    _logService.LogInformation(@$"{className}/DeActivate", "deactivate results were true");
                    return operation.Succeeded(res);
                }

                _logService.LogError(@$"{className}/Deactivate", "deactivate results were false");
                return operation.Failed();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in deactivate");
                throw;
            }
        }

        #endregion

    }
}
