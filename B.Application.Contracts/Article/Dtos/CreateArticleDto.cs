namespace Blog.Management.Application.Contracts.Article.Dtos
{
    public class CreateArticleDto
    {
        public long CategoryId { get; set; }
        public long AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string FeaturedImage { get; set; }
    }
}
