using Blog.Management.Domain.Shared;

namespace Blog.Management.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetAll(long articleId);
        Task<bool> Activate(long articleId);
        Task<bool> Deactivate(long articleId);
    }
}
