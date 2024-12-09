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

        #endregion


        #region CRUD

        public Task<OperationResult> Create(CreateCommentDto comment)
        {
            throw new NotImplementedException();
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


        #region ACTIVATE/DEACTIVATE FOR ARTICLE AND AUTHOR

        //----------------------- ACTIVATE (FOR ARTICLE) -----------------------\\
        public async Task<OperationResult> ActivateForArticle(long articleId)
        {
            var operation = new OperationResult();
            try
            {
                if (articleId == 0)
                {
                    _logService.LogError(@$"{className}/ActivateForArticle", "articleId is zero"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                var commentList = await _commentRepository.GetAllForArticle(articleId);

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
                        _logService.LogError(@$"{className}/ActivateForArticle", "activate result was false"); //-- LOG (ERR) --
                        return operation.Failed();
                    }
                }

                _logService.LogInformation($@"{className}/ActivateForArticle", "activate results were true and successful"); //-- LOG (INF) --
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in activateforarticle"); //-- LOG (EXC) --
                throw;
            }
        }

        //----------------------- DEACTIVATE (FOR ARTICLE) -----------------------\\
        public async Task<OperationResult> DeactivateForArticle(long articleId)
        {
            var operation = new OperationResult();
            try
            {
                if (articleId == 0)
                {
                    _logService.LogError(@$"{className}/DeactivateForArticle", "articleId is zero"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                var commentList = await _commentRepository.GetAllForArticle(articleId);

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
                        _logService.LogError(@$"{className}/DectivateForArticle", "deativate result was false"); //-- LOG (ERR) --
                        return operation.Failed();
                    }
                }

                _logService.LogInformation($@"{className}/DeactivateForArticle", "deactivate results were true and successful"); //-- LOG (INF) --
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in deactivateforarticle"); //-- LOG (EXC) --
                throw;
            }
        }

        //----------------------- ACTIVATE (FOR AUTHOR) -----------------------\\
        public async Task<OperationResult> ActivateForAuthor(long authorId)
        {
            var operation = new OperationResult();
            try
            {
                if (authorId == 0)
                {
                    _logService.LogError(@$"{className}/ActivateForAuthor", "articleId is zero"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                var commentList = await _commentRepository.GetAllForAuthor(authorId);

                if (commentList == null)
                {
                    _logService.LogWarning(@$"{className}/ActivateForArticle/GetAll", "getall results were null"); //-- LOG (WAR) --
                    return operation.Failed();
                }

                foreach (var comment in commentList)
                {
                    var res = await _commentRepository.Activate(comment.AuthorId);
                    if (!res)
                    {
                        _logService.LogError(@$"{className}/ActivateForAuthor", "activate result was false"); //-- LOG (ERR) --
                        return operation.Failed();
                    }
                }

                _logService.LogInformation($@"{className}/ActivateForAuthor", "activate results were true and successful"); //-- LOG (INF) --
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in activateforauthor"); //-- LOG (EXC) --
                throw;
            }
        }

        //----------------------- DEACTIVATE (FOR AUTHOR)-----------------------\\
        public async Task<OperationResult> DeactivateForAuthor(long authorId)
        {
            var operation = new OperationResult();
            try
            {
                if (authorId == 0)
                {
                    _logService.LogError(@$"{className}/DeactivateForAuthor", "articleId is zero"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                var commentList = await _commentRepository.GetAllForAuthor(authorId);

                if (commentList == null)
                {
                    _logService.LogWarning(@$"{className}/DeeactivateForAuthor/GetAll", "getall results were null"); //-- LOG (WAR) --
                    return operation.Failed();
                }

                foreach (var comment in commentList)
                {
                    var res = await _commentRepository.Deactivate(comment.AuthorId);
                    if (!res)
                    {
                        _logService.LogError(@$"{className}/DectivateForAuthor", "deativate result was false"); //-- LOG (ERR) --
                        return operation.Failed();
                    }
                }

                _logService.LogInformation($@"{className}/DeactivateForAuthor", "deactivate results were true and successful"); //-- LOG (INF) --
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in deactivateforauthor"); //-- LOG (EXC) --
                throw;
            }
        }

        #endregion

    }
}
