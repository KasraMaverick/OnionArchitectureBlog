using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Domain.CommentAgg;

namespace Blog.Management.Domain.ArticleAgg
{
    public class Article
    {
        public int ArticleId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public DateTime ArchivedDate { get; private set; }
        public string Content { get; private set; }

        public string Excerpt { get; private set; }
        public ArticleCategory Categories { get; private set; }
        public List<Comment> Comments { get; private set; }
        public string FeaturedImage { get; private set; }
        public DateTime LastEditedDate { get; private set; }
        public int Status { get; private set; }

        public Article()
        {
            
        }

    }
}
