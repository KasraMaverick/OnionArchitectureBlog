using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;
using Blog.Management.Domain.ArticleCategoryAgg;
using System.Globalization;
using _0_Framework.Log;

namespace Blog.Management.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {

        #region INJECTION

        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly ILogService _logService;
        const string className = nameof(ArticleCategoryApplication);
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
                                          ILogService logService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _logService = logService;
        }

        #endregion


        #region CRUD

        //----------------------------------- CREATE -----------------------------------\\
        public async Task<OperationResult> Create(CreateArticleCategoryDto articleCategoryDto)
        {
            var operation = new OperationResult();

            try
            {
                var articleCategory = new ArticleCategory(articleCategoryDto.Title);
                var res = await _articleCategoryRepository.Create(articleCategory);
                if (res == null)
                {
                    _logService.LogError(@$"{className}/Create", "create results were null"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                _logService.LogInformation($@"{className}/Create", "create was successful"); //-- LOG (INF) --
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in create"); //-- LOG (EXC) --
                throw;
            }
        }


        //----------------------------------- GET ALL -----------------------------------\\
        public async Task<OperationResultWithData<List<GetArticleCategoryDto>>> GetAll()
        {
            var operation = new OperationResultWithData<List<GetArticleCategoryDto>>();

            try
            {
                var res = await _articleCategoryRepository.Get();

                if (res == null)
                {
                    _logService.LogWarning($@"{className}/Getall", "getall results were null"); //-- LOG (WAR) --
                    return operation.Failed();
                }

                var result = new List<GetArticleCategoryDto>();

                foreach (var articleCategory in res)
                {
                    result.Add(new GetArticleCategoryDto
                    {
                        ArticleCategoryId = articleCategory.ArticleCategoryId,
                        Title = articleCategory.Title,
                        CreatedDate = articleCategory.CreatedDate.ToString(CultureInfo.InvariantCulture),
                        UpdatedDate = articleCategory.UpdatedDate.ToString(CultureInfo.InvariantCulture)
                    });
                }

                _logService.LogInformation($@"{className}/GetAll", "getall was successful"); //-- LOG (INF) --
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in getall"); // -- LOG (EXC) --
                return operation.Failed();
            }
        }

        //----------------------------------- GET TITLE BY ID -----------------------------------\\
        public async Task<OperationResultWithData<List<GetArticleCategoryTitleDto>>> GetTitles()
        {
            var operation = new OperationResultWithData<List<GetArticleCategoryTitleDto>>();

            try
            {
                var res = await _articleCategoryRepository.Get();

                if (res == null)
                {
                    _logService.LogWarning($@"{className}/GetTitles", "get-titles results were null"); //-- LOG (WAR) --
                    return operation.Failed();
                }

                var result = new List<GetArticleCategoryTitleDto>();

                foreach (var articleCategory in res)
                {
                    result.Add(new GetArticleCategoryTitleDto
                    {
                        CategoryId = articleCategory.ArticleCategoryId,
                        Title = articleCategory.Title,
                    });
                }

                _logService.LogInformation($@"{className}/GetTitles", "get-titles was successful"); //-- LOG (INF) --
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in get-titles"); // -- LOG (EXC) --
                return operation.Failed();
            }
        }


        //----------------------------------- UPDATE -----------------------------------\\
        public async Task<OperationResult> Update(UpdateArticleCategoryDto articleCategoryDto)
        {
            var operation = new OperationResult();

            try
            {
                ArticleCategory articleCategory = await _articleCategoryRepository.GetById(articleCategoryDto.Id);
                articleCategory.Edit(articleCategoryDto.Title);
                var res = await _articleCategoryRepository.Edit(articleCategory, articleCategoryDto.Id);

                if (res == null)
                {
                    _logService.LogError(@$"{className}/Update", "update results were null"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                _logService.LogInformation($@"{className}/Update", "update was successful"); //-- LOG (INF) -
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in update"); // -- LOG (EXE) --
                throw;
            }
        }


        //----------------------------------- DELETE -----------------------------------\\
        public async Task<OperationResult> Delete(DeleteArticleCategoryDto articleCategoryDto)
        {
            var operation = new OperationResult();

            try
            {
                var res = await _articleCategoryRepository.Delete(articleCategoryDto.Id);

                if (!res)
                {
                    _logService.LogError(@$"{className}/Create", "create results were null"); //-- LOG (ERR) --
                    return operation.Failed();
                }

                _logService.LogInformation($@"{className}/Delete", "delete was successful"); //-- LOG (INF) --
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in delete"); // -- LOG (EXC) -
                throw;
            }
        }

        #endregion

    }
}

