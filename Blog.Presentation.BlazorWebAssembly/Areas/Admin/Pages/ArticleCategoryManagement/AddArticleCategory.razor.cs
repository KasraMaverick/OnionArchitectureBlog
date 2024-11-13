using Blog.Shared.Dtos.ArticleCategory;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Blog.Presentation.BlazorWebAssembly.Areas.Admin.Pages.ArticleCategoryManagement
{
    public partial class AddArticleCategory
    {
        public CreateArticleCategoryDto AddArticleCategoryDto { get; set; } = new CreateArticleCategoryDto();

        [Inject]
        public NotificationService notificationService { get; set; }

        [Inject]
        public DialogService dialogService { get; set; }
        public async Task Add()
        {
            if (string.IsNullOrEmpty(AddArticleCategoryDto.Title) || string.IsNullOrWhiteSpace(AddArticleCategoryDto.Title))
            {
                notificationService.Notify(NotificationSeverity.Error, "Error", "Article Category cannot be empty!");
                return;
            }

            //await _articleCategoryApplication.Create(CreateArticleCategoryDto);

            notificationService.Notify(NotificationSeverity.Success, "Success", "Successfully added the article category!");
            dialogService.Close();
        }

        public void HideAddDialog()
        {
            dialogService.Close();
        }
    }
}
