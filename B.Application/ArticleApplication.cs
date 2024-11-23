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

        public Task<OperationResultWithData<List<GetArticleDto>>> GetAll(long authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Update(UpdateArticleDto articleDto)
        {
            var operation = new OperationResult();

            try
            {
                Article article = await _articleRepository.GetById(articleDto.Id);
                article.Edit(articleDto.CategoryId, articleDto.Title, articleDto.Content, articleDto.Excerpt, articleDto.FeaturedImage);
                var res = await _articleRepository.Edit(article, articleDto.Id);

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
    }
}
