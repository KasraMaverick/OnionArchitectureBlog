namespace B.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        public Task<List<ArticleCategoryViewModel>> GetAllArticleCategories();
        public Task Create(CreateArticleCategoryDto articleCategoryDto);
    }
}
