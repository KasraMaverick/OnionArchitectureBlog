using Blog.Management.Application.Contracts.ArticleCategory.Dtos;
using System.Text.Json;

namespace Blog.Presentation.BlazorWebAssembly.Services
{
    public class ArticleCategoryService
    {
        private readonly HttpClient _httpClient;

        public ArticleCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7170/api/");
        }

        public async Task<List<GetArticleCategoryDto>> GetAllArticleCategories()
        {
            var response = await _httpClient.GetAsync("articlecategory/articlecategorylist");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<GetArticleCategoryDto>>(content);
        }
    }
}
