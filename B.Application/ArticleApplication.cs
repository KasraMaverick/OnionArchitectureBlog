using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.Article.Dtos;
using Blog.Management.Domain.ArticleAgg;

namespace Blog.Management.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;   
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
