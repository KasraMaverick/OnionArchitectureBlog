namespace Blog.Management.Application.Contracts.Article.Dtos
{
    public class UpdateArticleDto
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string FeaturedImage { get; set; }
    }
}
