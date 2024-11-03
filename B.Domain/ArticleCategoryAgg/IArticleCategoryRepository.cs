namespace B.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        Task<List<ArticleCategory>> GetAllArticleCategories();
        Task AddArticleCategory(ArticleCategory articleCategory);
    }
}
