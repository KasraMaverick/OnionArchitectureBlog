#region USINGS

using _0_Framework.Log;
using Blog.Management.Application;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.Author;
using Blog.Management.Application.Contracts.Comment;
using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Domain.AuthorAgg;
using Blog.Management.Domain.CommentAgg;
using Blog.Management.Infrastructure.EfCore;
using Blog.Management.Infrastructure.EfCore.Repositories;
using Blog.Management.Infrastructure.Redis;
using Blog.Provider.Article;
using Blog.Provider.ArticleCategory;
using Blog.Provider.Author;
using Blog.Provider.Comment;
using Blog.Provider.Contracts.Article;
using Blog.Provider.Contracts.ArticleCategory;
using Blog.Provider.Contracts.Author;
using Blog.Provider.Contracts.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

#endregion

namespace Blog.Management.Infrastructure.Core
{
    public static class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {

            #region ARTICLE CATEGORY

            services.AddTransient<IArticleCategoryRequestProvider, ArticleCategoryRequestProvider>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            #endregion


            #region ARTICLE

            services.AddTransient<IArticleRequestProvider, ArticleRequestProvider>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository,  ArticleRepository>();
            services.AddTransient<IArticleCategoryCacheService, ArticleCategoryCacheService>();

            #endregion


            #region COMMENT

            services.AddTransient<ICommentRequestProvider, CommentRequestProvider>();
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            #endregion


            #region AUTHOR

            services.AddTransient<IAuthorRequestProvider, AuthorRequestProvider>();
            services.AddTransient<IAuthorApplication, AuthorApplication>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            #endregion


            #region DATABASES & LOGGING

            services.AddDbContext<BlogContext>(options => options.UseSqlServer("BlogDb"));
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));

            services.AddSingleton<ILogService, LogService>();

            #endregion

        }
    }
}
