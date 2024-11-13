namespace Blog.Shared.Dtos.ArticleCategory
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
