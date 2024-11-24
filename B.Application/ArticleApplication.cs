using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.Article.Dtos;
using Blog.Management.Domain.ArticleAgg;
using System.Globalization;

namespace Blog.Management.Application
{
    public class ArticleApplication : IArticleApplication
    {
        #region INJECTION

        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;   
        }

        #endregion


        #region CRUD

        public async Task<OperationResult> Create(CreateArticleDto article)
        {
            var operation = new OperationResult();

            try
            {
                var articleDto = new Article(article.Title, article.CategoryId, article.AuthorId, article.Content, article.Excerpt, article.FeaturedImage);
                var res = await _articleRepository.Create(articleDto);
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

        public async Task<OperationResult> Delete(DeleteArticleDto article)
        {
            var operation = new OperationResult();

            try
            {
                
                var res = await _articleRepository.Delete(article.ArticleId);
                if (!res)
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

        public async Task<OperationResultWithData<List<GetArticleDto>>> GetAll(long authorId)
        {
            var operation = new OperationResultWithData<List<GetArticleDto>>();

            try
            {
                var res = await _articleRepository.GetAll(authorId);

                if (res == null)
                {
                    return operation.Failed();
                }

                var result = new List<GetArticleDto>();

                foreach (var article in res)
                {
                    result.Add(new GetArticleDto
                    {
                        ArticleId = article.ArticleId,
                        CategoryId = article.ArticleCategoryId,
                        Title = article.Title,
                        Excerpt = article.Excerpt,
                        Content = article.Content,
                        FeaturedImage = article.FeaturedImage,
                        CreatedDate = article.CreatedDate.ToString(CultureInfo.InvariantCulture),
                        LastEditedDate = article.LastEditedDate.ToString(CultureInfo.InvariantCulture)
                    });
                }
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                return operation.Failed();
            }
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

        #endregion


        #region PUBLISH & ARCHIVE

        public async Task<OperationResult> Publish(long articleId)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _articleRepository.Publish(articleId);

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

        public async Task<OperationResult> Archive(long articleId)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _articleRepository.Archive(articleId);

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
