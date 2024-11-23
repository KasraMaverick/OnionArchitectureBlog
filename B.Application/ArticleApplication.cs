﻿using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.Article.Dtos;
using Blog.Management.Domain.ArticleAgg;
using System.Globalization;

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
    }
}
