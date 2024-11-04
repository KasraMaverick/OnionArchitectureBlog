using B.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Components;

namespace B.Presentation.Blazor.Areas.Admin.Pages.ArticleCategoryManagement
{
    public partial class ArticleCategory
    {
        #region INJECTIONS

        [Inject]
        private IArticleCategoryApplication _articleCategoryApplication { get; set; }

        #endregion


        #region PROPERTIES 

        public IQueryable<ArticleCategoryViewModel> ArticleCategoriesQueryable { get; set; }
        public IList<ArticleCategoryViewModel> SelectedArticleCategories { get; set; }

        #endregion


        protected override async Task OnInitializedAsync()
        {
            await GetAllArticleCategories();
        }


        public async Task GetAllArticleCategories()
        {
            var result = await _articleCategoryApplication.GetAllArticleCategories();
            ArticleCategoriesQueryable = result.AsQueryable();
            SelectedArticleCategories = new List<ArticleCategoryViewModel> { ArticleCategoriesQueryable.FirstOrDefault() };
        }
    }
}
