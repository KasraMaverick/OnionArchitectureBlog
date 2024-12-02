using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.Article.Dtos;

namespace Blog.Management.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        Task<OperationResultWithData<List<GetArticleDto>>> GetAll(long authorId);
        Task<OperationResult> Create(CreateArticleDto article);
        Task<OperationResult> Update(UpdateArticleDto article);
        Task<OperationResult> Publish(long articleId);
        Task<OperationResult> Archive(long articleId);
        Task<OperationResult> ActivateArticlesForAuthor(long authorId);
    }
}
