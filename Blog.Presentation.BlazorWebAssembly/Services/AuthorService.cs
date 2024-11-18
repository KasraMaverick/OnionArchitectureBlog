namespace Blog.Presentation.BlazorWebAssembly.Services
{
    public class AuthorService
    {

        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7170/api/");
        }
    }
}
