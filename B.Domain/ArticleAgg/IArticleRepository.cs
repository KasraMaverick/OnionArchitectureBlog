﻿using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<List<Article>> GetAll(long authorId);
        Task<bool> Publish(long articleId);
        Task<bool> Archive(long articleId);
        Task<bool> Activate(long articleId);
        Task<bool> Deactivate(long articleId);
    }
}
