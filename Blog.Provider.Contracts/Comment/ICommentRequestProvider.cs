using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Comment.Dtos;

namespace Blog.Provider.Contracts.Comment
{
    public interface ICommentRequestProvider
    {
        public Task<OperationResultWithData<List<GetCommentForArticleDto>>> GetAll();
        public Task<OperationResult> Create(CreateCommentDto comment);
        public Task<OperationResult> Update(EditCommentDto comment);
        public Task<OperationResult> Delete(DeleteCommentDto comment);
    }
}
