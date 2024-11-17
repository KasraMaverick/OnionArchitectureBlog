using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment.Dtos;

namespace Blog.Management.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        public Task<OperationResult> Create(CreateCommentDto comment);
        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll();
        public Task<OperationResult> Update(EditCommentDto comment);
        public Task<OperationResult> Delete(DeleteCommentDto comment);
    }
}
