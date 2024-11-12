using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace B.Presentation.Blazor.Areas.Admin.Pages.ArticleCategoryManagement
{
    public partial class AddArticleCategory
    {
        [Inject]
        private IArticleCategoryApplication _articleCategoryApplication { get; set; }

        public CreateArticleCategoryDto CreateArticleCategoryDto { get; set; }=new CreateArticleCategoryDto();

        [Inject]
        public NotificationService notificationService { get; set; }

        [Inject]
        public DialogService dialogService { get; set; }
        public async Task Add()
        {
            if (string.IsNullOrEmpty(CreateArticleCategoryDto.Title) || string.IsNullOrWhiteSpace(CreateArticleCategoryDto.Title))
            {
                notificationService.Notify(NotificationSeverity.Error, "Error", "Article Category cannot be empty!");
                return;
            }

            await _articleCategoryApplication.Create(CreateArticleCategoryDto);

            notificationService.Notify(NotificationSeverity.Success, "Success", "Successfully added the article category!");
            dialogService.Close();
        }

        public void HideAddDialog()
        {
            dialogService.Close();
        }
    }
}
