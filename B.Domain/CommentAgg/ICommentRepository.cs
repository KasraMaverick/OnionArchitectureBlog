using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<bool> ActivateFor(long articleId);
        Task<bool> DeactivateFor(long articleId);
    }
}
