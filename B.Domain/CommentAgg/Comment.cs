using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.AuthorAgg;

namespace Blog.Management.Domain.CommentAgg
{
    public class Comment
    {

        #region PROPERTIES

        public long CommentId { get; private set; }
        public string CommentText { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }
        public long AuthorId { get; private set; }
        public Author Author { get; private set; }
        public bool IsActive { get; private set; }
        public int LikesCount { get; private set; }
        public int DislikesCount { get; private set; }

        #endregion


        #region CONSTRUCTOR

        protected Comment() { }

        public Comment(string commentText, long articleId, long authorId)
        {
            CommentText = commentText;
            ArticleId = articleId;
            AuthorId = authorId;
            IsActive = false;
            CreatedDate = DateTime.Now;
        }

        #endregion


        #region METHODS

        public void Edit(string commentText)
        {
            CommentText = commentText;
            LastUpdatedDate = DateTime.Now;
        }
        public void Like()
        {
            LikesCount ++;
        }

        public void DisLike()
        {
            DislikesCount --;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
