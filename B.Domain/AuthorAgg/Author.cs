using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.CommentAgg;

namespace Blog.Management.Domain.AuthorAgg
{
    public class Author
    {
        public long AuthorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public long UserId { get; private set; }
        public string ImageUrl { get; private set; }
        public string Bio { get; private set; }
        public int ArticleCount { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public List<Article> AuthorArticles { get; private set; }
        public List<Comment> AuthorComments { get; private set; }

        protected Author() { }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = DateTime.Now;
            IsActive = true;
        }


        public void Active()
        {
            IsActive = true;
        }
        public void DeActive()
        {
            IsActive = false;
        }
    }
}
