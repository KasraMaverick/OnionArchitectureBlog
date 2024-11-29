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
        public List<Article> Articles { get; private set; }
        public List<Comment> Comments { get; private set; }

        protected Author() { }

        public Author(string firstName, string lastName, string imageUrl, string bio)
        {
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = DateTime.Now;
            IsActive = true;
            Articles = new List<Article>();
            Comments = new List<Comment>();
        }

        public void Edit(string firstName, string lastName, string imageUrl, string bio)
        {
            FirstName = firstName;
            LastName = lastName;
            ImageUrl = imageUrl;
            Bio = bio;
        }

        public void Activate()
        {
            IsActive = true;
        }
        public void DeActivate()
        {
            IsActive = false;
        }
        public void AddArticleCount()
        {
            ArticleCount ++;
        }
    }

}
