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
    }
}
