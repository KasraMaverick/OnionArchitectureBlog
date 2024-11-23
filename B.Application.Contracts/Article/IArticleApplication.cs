using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article.Dtos;

namespace Blog.Management.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        public Task<OperationResultWithData<List<GetArticleDto>>> GetAll(long authorId);
        public Task<OperationResult> Create(CreateArticleDto article);
        public Task<OperationResult> Update(UpdateArticleDto article);
        public Task<OperationResult> Delete(DeleteArticleDto article);
    }
}
