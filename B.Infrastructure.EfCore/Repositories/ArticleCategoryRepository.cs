using _0_Framework.Application.Model;
using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly BlogContext _dbContext;
        public ArticleCategoryRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        //-------------------- ADD ARTICLE CATEGORY --------------------\\
        public async Task<OperationResult> AddArticleCategory(ArticleCategory articleCategory)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _dbContext.ArticleCategories.AddAsync(articleCategory);
                await SaveChanges();

                return operation.Succeeded(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //-------------------- UPDATE ARTICLE CATEGORY --------------------\\
        public async Task<OperationResult> UpdateArticleCategory(ArticleCategory articleCategory)
        {
            var operation = new OperationResult();
            try
            {
                var res = await _dbContext.ArticleCategories.Where(x => x.ArticleCategoryId == articleCategory.ArticleCategoryId).FirstOrDefaultAsync();
                
                
                _dbContext.Attach(res);

                _dbContext.Entry(res).Property(x => x.Title).IsModified = true;

                await SaveChanges();

                return operation.Succeeded(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //-------------------- GET ALL ARTICLE CATEGORIES --------------------\\
        public async Task<OperationResultWithData<List<ArticleCategory>>> GetAllArticleCategories()
        {
            var operation = new OperationResultWithData<List<ArticleCategory>>();
            try
            {
                var res = await _dbContext.ArticleCategories.ToListAsync();
                return operation.Succeeded(res);
            }
            catch (Exception)
            {

                throw;
            }
        }


        

        //------------------- SAVE CHANGES --------------------\\
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
