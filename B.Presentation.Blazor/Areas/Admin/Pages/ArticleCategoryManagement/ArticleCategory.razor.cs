using B.Application.Contracts.ArticleCategory;

namespace B.Presentation.Blazor.Areas.Admin.Pages.ArticleCategoryManagement
{
    public partial class ArticleCategory
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; } = new();
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ArticleCategory(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;   
        }

        protected override async Task OnInitializedAsync()
        {
            await GetAllArticleCategories();
        }

        public async Task GetAllArticleCategories()
        {
            var result = await _articleCategoryApplication.GetAllArticleCategories();
            ArticleCategories = result;
        }
    }
}
