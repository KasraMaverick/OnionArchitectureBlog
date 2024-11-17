using Blog.Management.Domain.ArticleAgg;

namespace Blog.Management.Domain.CommentAgg
{
    public class Comment
    {
        public long CommentId { get; private set; }
        public string CommentText { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public Article Article { get; private set; }
        //public Author AuthorId { get; private set; }
        public bool IsDeleted { get; private set; }
        public int LikesCount { get; private set; }
        public int DislikesCount { get; private set; }

        public Comment(bool IsDeleted)
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

    }
}
