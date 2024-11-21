using Blog.Management.Domain.ArticleAgg;
using Microsoft.VisualBasic;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long ArticleCategoryId { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public List<Article> Articles { get; private set; } 

        protected ArticleCategory() { }
        public ArticleCategory(string title)
        {
            Title = title;
            CreatedDate = DateTime.Now;
            Articles = new List<Article>();
        }
        public void Edit(string title)
        {
            Title = title;
            UpdatedDate = DateTime.Now;
        }

    }
}
