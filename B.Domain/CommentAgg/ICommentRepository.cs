using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetAllForArticle(long articleId);
        Task<List<Comment>> GetAllForAuthor(long authorId);

        Task<bool> Activate(long commentId);
        Task<bool> Deactivate(long commentId);

        Task<bool> Like(long commentId);
        Task<bool> Dislike(long commentId);
    }
}
