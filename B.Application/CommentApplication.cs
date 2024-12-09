using _0_Framework.Application.Model;
using _0_Framework.Log;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Application.Contracts.Comment.Dtos;
using Blog.Management.Domain.ArticleAgg;
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

        public async Task<OperationResult> Create(CreateCommentDto comment)
        {
            var operation = new OperationResult();
            try
            {
                var commentDto = new Comment(comment.CommentText, comment.authorId, comment.articleId);
                var res = await _commentRepository.Create(commentDto);
                if (res == null)
                {
                    _logService.LogError(@$"{className}/Create", "create results were null"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                _logService.LogInformation($@"{className}/Create", "create results were successful"); //-- LOG (INF) --
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in create"); //-- LOG (EXC) --
                throw;
            }
        }


        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll(long articleId)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Update(EditCommentDto commentDto)
        {
            var operation = new OperationResult();

            try
            {
                Comment comment = await _commentRepository.GetById(commentDto.CommentId);
                comment.Edit(commentDto.CommentText);
                var res = await _commentRepository.Edit(comment, commentDto.CommentId);

                if (res == null)
                {
                    _logService.LogError(@$"{className}/Update", "update results were null"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                _logService.LogInformation($@"{className}/Update", "update results were successful"); //-- LOG (ERR) --
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in update"); //-- LOG (EXC) --
                throw;
            }
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

        #region LIKE/DISLIKE

        public async Task<OperationResult> LikeComment(long commentId)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _commentRepository.Like(commentId);

                if (res)
                {
                    _logService.LogInformation($@"{className}/Like", "like results were true"); //-- LOG (INF) --
                    return operation.Succeeded(res);
                }

                _logService.LogError(@$"{className}/Like", "like results were false"); //-- LOG (ERR) --
                return operation.Failed();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in like"); //-- LOG (EXC) --
                throw;
            }
        }

        public async Task<OperationResult> DislikeComment(long commentId)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _commentRepository.Dislike(commentId);

                if (res)
                {
                    _logService.LogInformation($@"{className}/Dislike", "dislike results were true"); //-- LOG (INF) --
                    return operation.Succeeded(res);
                }

                _logService.LogError(@$"{className}/Dislike", "dislike results were false"); //-- LOG (ERR) --
                return operation.Failed();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in dislike"); //-- LOG (EXC) --
                throw;
            }
        }

        #endregion

    }
}
