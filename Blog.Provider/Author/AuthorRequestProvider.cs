using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.Author;
using Blog.Management.Application.Contracts.Author.Dtos;
using Blog.Management.Application.Contracts.Comment;
using Blog.Provider.Contracts.Author;

namespace Blog.Provider.Author
{
    public class AuthorRequestProvider : IAuthorRequestProvider
    {

        #region INJECTION

        private readonly IAuthorApplication _authorApplication;
        private readonly IArticleApplication _articleApplication;
        private readonly ICommentApplication _commentApplication;
        public AuthorRequestProvider(IAuthorApplication authorApplication, 
                                     IArticleApplication articleApplication,
                                     ICommentApplication commentApplication)
        {
            _authorApplication = authorApplication;
            _articleApplication = articleApplication;
            _commentApplication = commentApplication;
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

        public Task<OperationResult> Activate(long authorId)
        {




            return _authorApplication.Activate(authorId);
        }

        public Task<OperationResult> Deactivate(long authorId)
        {
            return _authorApplication.Activate(authorId);
        }

        #endregion
    }
}
