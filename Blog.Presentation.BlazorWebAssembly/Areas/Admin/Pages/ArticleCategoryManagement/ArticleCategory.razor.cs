using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using Radzen.Blazor.Rendering;
using Blog.Shared.Dtos.ArticleCategory;

namespace Blog.Presentation.BlazorWebAssembly.Areas.Admin.Pages.ArticleCategoryManagement
{
    public partial class ArticleCategory
    {

        #region INJECTIONS


        [Inject]
        public NotificationService notificationService { get; set; }

        [Inject]
        public DialogService dialogService { get; set; }

        #endregion


        #region PROPERTIES 

        public IQueryable<GetArticleCategoryDto> ArticleCategoriesQueryable { get; set; }
        public IList<GetArticleCategoryDto> SelectedArticleCategories { get; set; }
        private bool showAddDialog;

        #endregion


        protected override async Task OnInitializedAsync()
        {
            await GetAllArticleCategories();
        }


        public async Task GetAllArticleCategories()
        {
            //var result = await _articleCategoryApplication.GetAllArticleCategories();
            //ArticleCategoriesQueryable = result.AsQueryable();
            //SelectedArticleCategories = new List<ArticleCategoryViewModel> { ArticleCategoriesQueryable.FirstOrDefault() };
        }

        public async void ShowAddDialog()
        {
            await dialogService.OpenAsync<AddArticleCategory>("Add Article Category", null, null);
        }
    }
}
