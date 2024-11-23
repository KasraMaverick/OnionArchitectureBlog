namespace Blog.Management.Application.Contracts.Article.Dtos
{
    public class GetArticleDto
    {
        public long ArticleId { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string FeaturedImage { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
        public string LastEditedDate { get; set; }
    }
}
