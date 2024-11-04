using B.Application;
using B.Application.Contracts.ArticleCategory;
using B.Domain.ArticleCategoryAgg;
using B.Infrastructure.EfCore;
using B.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B.Infrastructure.Core
{
    public static class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer("BlogDb"));
        }
    }
}
