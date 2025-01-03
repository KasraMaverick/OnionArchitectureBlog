﻿using _0_Framework.Application.Enums;
using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Domain.AuthorAgg;
using Blog.Management.Domain.CommentAgg;

namespace Blog.Management.Domain.ArticleAgg
{
    public class Article
    {
        #region PROPERTIES

        public long ArticleId { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public DateTime ArchivedDate { get; private set; }
        public string Content { get; private set; }
        public string Excerpt { get; private set; }
        public string FeaturedImage { get; private set; }
        public DateTime LastEditedDate { get; private set; }
        public int Status { get; private set; }
        public bool Active { get; private set; }


        //---------- RELATIONSHIPS ----------\\

        //----- TO AUTHOR
        public long AuthorId { get; private set; }
        public Author Author { get; private set; }

        //----- TO COMMENT
        public List<Comment> Comments { get; private set; }

        //----- TO ARTICLE CATEGORY
        public ArticleCategory ArticleCategory { get; private set; }
        public long ArticleCategoryId { get; private set; }

        #endregion


        #region CONSTRUCTOR

        protected Article() { }

        public Article(string title,long categoryId, long authorId, string content, string excerpt, string featuredImage)
        {
            CreatedDate = DateTime.Now;
            Title = title;
            ArticleCategoryId = categoryId;
            AuthorId = authorId;
            Content = content;
            Excerpt = excerpt;
            FeaturedImage = featuredImage;
            Status = (int)StatusEnums.Status.Draft;
            Comments = new List<Comment>();
            Active = true;
        }

        #endregion


        #region METHODS

        public void Edit(long categoryId, string title, string content, string excerpt,string featuredImage)
        {
            Title = title;
            Content = content;
            Excerpt = excerpt;
            FeaturedImage = featuredImage;
            LastEditedDate = DateTime.Now;
            ArticleCategoryId = categoryId;
        }

        public void Publish()
        {
            Status = (int)StatusEnums.Status.Published;
            PublishedDate = DateTime.Now;
        }

        public void Archive()
        {
            Status = (int)StatusEnums.Status.Archived;
            ArchivedDate = DateTime.Now;
        }

        public void Activate()
        {
            Active = true;
        }

        public void DeActivate()
        {
            Active = false;
        }

        #endregion

    }
}
