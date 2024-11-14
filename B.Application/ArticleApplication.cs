using Blog.Management.Application.Contracts.Article;
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
    }
}
