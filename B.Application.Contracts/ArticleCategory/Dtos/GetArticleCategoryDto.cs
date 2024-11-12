namespace Blog.Management.Application.Contracts.ArticleCategory.Dtos
{
    public class GetArticleCategoryDto
    {
        public long ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UpdatedDate { get; set; }
    }
}
