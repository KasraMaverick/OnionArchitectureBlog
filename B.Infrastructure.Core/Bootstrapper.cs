#region USINGS

using Blog.Management.Application;
using Blog.Management.Application.Contracts.Article;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Infrastructure.EfCore;
using Blog.Management.Infrastructure.EfCore.Repositories;
using Blog.Provider.Article;
using Blog.Provider.ArticleCategory;
using Blog.Provider.Contracts.Article;
using Blog.Provider.Contracts.ArticleCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

            #endregion

            #region COMMENT

            

            #endregion

            services.AddDbContext<BlogContext>(options => options.UseSqlServer("BlogDb"));
        }
    }
}
