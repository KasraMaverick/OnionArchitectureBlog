namespace Blog.Management.Application.Contracts.Author.Dtos
{
    public class UpdateAuthorDto
    {
        public long AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set;  }
    }
}
