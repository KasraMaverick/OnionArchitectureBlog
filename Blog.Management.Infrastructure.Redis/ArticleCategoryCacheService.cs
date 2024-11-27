using Blog.Management.Domain.ArticleCategoryAgg;
using StackExchange.Redis;
using System.Text.Json;

namespace Blog.Management.Infrastructure.Redis
{
    public class ArticleCategoryCacheService : IArticleCategoryCacheService
    {
        private readonly IDatabase _redisDataBase;
        public ArticleCategoryCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _redisDataBase = connectionMultiplexer.GetDatabase();
        }

        public async Task<ArticleCategory?> Get(long categoryId)
        {
            var articleCategory = await _redisDataBase.StringGetAsync(Convert.ToInt64(categoryId).ToString());

            if (articleCategory.IsNullOrEmpty)
            {
                return default;
            }

            return JsonSerializer.Deserialize<ArticleCategory>(articleCategory!);
        }

    }
}
