using System.Net.Http;

namespace Blog.Presentation.BlazorWebAssembly.Services
{
    public class CommentService
    {
        private readonly HttpClient _httpClient;
        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7170/api/");
        }
    }
}
