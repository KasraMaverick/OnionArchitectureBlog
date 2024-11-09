namespace Blog.Management.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UpdatedDate { get; set; }
    }
}
