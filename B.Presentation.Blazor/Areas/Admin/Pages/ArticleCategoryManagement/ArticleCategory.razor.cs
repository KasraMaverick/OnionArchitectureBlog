using B.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using Radzen.Blazor.Rendering;

namespace B.Presentation.Blazor.Areas.Admin.Pages.ArticleCategoryManagement
{
    public partial class ArticleCategory
    {

        #region INJECTIONS

        [Inject]
        private IArticleCategoryApplication _articleCategoryApplication { get; set; }

        [Inject]
        public NotificationService notificationService { get; set; }

        [Inject]
        public DialogService dialogService { get; set; }

        #endregion


        #region PROPERTIES 

        public IQueryable<ArticleCategoryViewModel> ArticleCategoriesQueryable { get; set; }
        public IList<ArticleCategoryViewModel> SelectedArticleCategories { get; set; }
        private bool showAddDialog;

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

        public async void ShowAddDialog()
        {
            await dialogService.OpenAsync<AddArticleCategory>("Add Article Category", null, null);
        }
    }
}
