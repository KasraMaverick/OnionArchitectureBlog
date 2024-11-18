using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.Article.Dtos;
using Blog.Provider.Contracts.Article;

namespace Blog.Provider.Article
{
    public class ArticleRequestProvider : IArticleRequestProvider
    {
        private readonly IArticleApplication _articleApplication;
        public ArticleRequestProvider(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public Task<OperationResult> Create(CreateArticleDto article)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Delete(DeleteArticleDto article)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultWithData<List<GetArticleDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(UpdateArticleDto article)
        {
            throw new NotImplementedException();
        }
    }
}
