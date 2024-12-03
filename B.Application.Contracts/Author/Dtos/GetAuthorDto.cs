namespace Blog.Management.Application.Contracts.Author.Dtos
{
    public class GetAuthorDto
    {
        public long AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set;  }
        public int ArticleCount { get; set; }
        public string CreatedDate { get; set; }
    }
}
