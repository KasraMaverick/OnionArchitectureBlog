namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryCacheService
    {
        Task<ArticleCategory> Get(long categoryId);
    }
}
