using _0_Framework.Application.Model;
using _0_Framework.Log;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Management.Domain.CommentAgg;

namespace Blog.Management.Application
{
    public class CommentApplication : ICommentApplication
    {

        #region INJECTION

        private readonly ICommentRepository _commentRepository;
        private readonly ILogService _logService;
        const string className = nameof(CommentApplication);
        public CommentApplication(ICommentRepository commentRepository,
                                  ILogService logService)
        {
            _commentRepository = commentRepository;
            _logService = logService;
        }

        public async Task<OperationResult> ActivateForArticle(long articleId)
        {
            var operation = new OperationResult();
            try
            {
                if (articleId == 0)
                {
                    _logService.LogError(@$"{className}/Activate", "articleId is zero"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                var commentList = await _commentRepository.GetAll(articleId);

                if (commentList == null)
                {
                    _logService.LogWarning(@$"{className}/ActivateForArticle/GetAll", "getall results were null"); //-- LOG (WAR) --
                    return operation.Failed();
                }

                foreach (var comment in commentList)
                {
                    var res = await _commentRepository.Activate(comment.ArticleId);
                    if (!res)
                    {
                        _logService.LogError(@$"{className}/Activate", "activate result was false"); //-- LOG (ERR) --
                        return operation.Failed();
                    }
                }

                _logService.LogInformation($@"{className}/Activate", "activate results were true and successful"); //-- LOG (INF) --
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in activate"); //-- LOG (EXC) --
                throw;
            }
        }

        #endregion


        #region CRUD

        public Task<OperationResult> Create(CreateCommentDto comment)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> DeactivateForArticle(long articleId)
        {
            var operation = new OperationResult();
            try
            {
                if (articleId == 0)
                {
                    _logService.LogError(@$"{className}/Deactivate", "articleId is zero"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                var commentList = await _commentRepository.GetAll(articleId);

                if (commentList == null)
                {
                    _logService.LogWarning(@$"{className}/DeeactivateForArticle/GetAll", "getall results were null"); //-- LOG (WAR) --
                    return operation.Failed();
                }

                foreach (var comment in commentList)
                {
                    var res = await _commentRepository.Deactivate(comment.ArticleId);
                    if (!res)
                    {
                        _logService.LogError(@$"{className}/Dectivate", "deativate result was false"); //-- LOG (ERR) --
                        return operation.Failed();
                    }
                }

                _logService.LogInformation($@"{className}/Deactivate", "deactivate results were true and successful"); //-- LOG (INF) --
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in deactivate"); //-- LOG (EXC) --
                throw;
            }
        }

        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll(long articleId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(EditCommentDto comment)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
