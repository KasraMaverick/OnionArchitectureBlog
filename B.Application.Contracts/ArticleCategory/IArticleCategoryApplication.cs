﻿using _0_Framework.Application.Model;
using Blog.Management.Application.Contracts.ArticleCategory.Dtos;

namespace Blog.Management.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        public Task<OperationResultWithData<List<GetArticleCategoryDto>>> GetAll();
        public Task<OperationResult> Create(CreateArticleCategoryDto articleCategoryDto);
        public Task<OperationResult> Update(UpdateArticleCategoryDto articleCategoryDto);
        public Task<OperationResult> Delete(DeleteArticleCategoryDto articleCategoryDto);

    }
}
