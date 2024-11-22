using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.AuthorAgg;

namespace Blog.Management.Domain.CommentAgg
{
    public class Comment
    {
        public long CommentId { get; private set; }
        public string CommentText { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }
        public long AuthorId { get; private set; }
        public Author Author { get; private set; }
        public bool IsDeleted { get; private set; }
        public int LikesCount { get; private set; }
        public int DislikesCount { get; private set; }

        public Comment(string commentText, long articleId, long authorId)
        {
            CommentText = commentText;
            ArticleId = articleId;
            AuthorId = authorId;
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

        public void Like()
        {
            LikesCount ++;
        }

        public void DisLike()
        {
            DislikesCount --;
        }

        public void DeleteComment()
        {
            IsDeleted = true;
        }
    }
}
