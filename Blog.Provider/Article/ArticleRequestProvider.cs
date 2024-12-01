﻿using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.Article.Dtos;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.Author;
using Blog.Provider.Contracts.Article;

namespace Blog.Provider.Article
{
    public class ArticleRequestProvider : IArticleRequestProvider
    {
        #region INJECTION

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IAuthorApplication _authorApplication;
        public ArticleRequestProvider(IArticleApplication articleApplication,
                                      IArticleCategoryApplication articleCategoryApplication,
                                      IAuthorApplication authorApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
            _authorApplication = authorApplication;
        }

        #endregion


        #region CRUD

        public async Task<OperationResult> Create(CreateArticleDto article)
        {
            //---------- CALLS AUTHOR SERVICE TO ++ ARTICLE COUNT
            await _authorApplication.AddArticleCount(article.AuthorId);

            return await _articleApplication.Create(article);
        }

        public Task<OperationResult> Delete(DeleteArticleDto article)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResultWithData<List<GetArticleDto>>> GetAll(long authorId)
        {
            var op = await _articleApplication.GetAll(authorId);
            var categoryResult = await _articleCategoryApplication.GetTitles();

            foreach (var article in op.Result)
            {
                var categoryName = categoryResult?.Result?.Where(x => x.CategoryId == article.CategoryId)?.FirstOrDefault()?.Title ?? "";
                article.CategoryName = categoryName;
            }
            return op;
        }

        public async Task<OperationResult> Update(UpdateArticleDto article)
        {
            return await _articleApplication.Update(article);   
        }

        #endregion


        #region PUBLISH AND ARCHIVE

        public async Task<OperationResult> Publish(long articleId)
        {
            return await _articleApplication.Publish(articleId);
        }
        public async Task<OperationResult> Archive(long articleId)
        {
            return await _articleApplication.Archive(articleId);
        }

        #endregion
    }
}
