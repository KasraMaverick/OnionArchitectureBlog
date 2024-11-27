using Radzen;
using System.Text.Json;
using System.Text;
using _0_Framework.Application.Model;

namespace Blog.Presentation.BlazorWebAssembly.Services
{
    public class ArticleService
    {

        #region INJECTION

        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _mediaType = "application/json";
        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _endpoint = "https://localhost:7170/api/";
        }

        #endregion


        #region PUBLISH & ARCHIVE

        public async Task<bool> Publish(long articleId)
        {
            if (articleId <= 0)
                throw new ArgumentException("Article ID must be a positive number.", nameof(articleId));

            var dataJson = new StringContent(JsonSerializer.Serialize(articleId), Encoding.UTF8, _mediaType);

            var response = await _httpClient.PutAsync($"{_endpoint}/Article/Publish", dataJson);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code {response.StatusCode}: {errorMessage}");
            }

            var result = await JsonSerializer.DeserializeAsync<OperationResult>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            if (result.IsSucceeded == false)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception($"Deserialization failed. Response content: {content}");
            }

            
            return true;
        }

        public async Task<bool> Archive(long articleId)
        {
            if (articleId <= 0)
                throw new ArgumentException("Article ID must be a positive number.", nameof(articleId));

            var dataJson = new StringContent(JsonSerializer.Serialize(articleId), Encoding.UTF8, _mediaType);

            var response = await _httpClient.PutAsync($"{_endpoint}/Article/Archive", dataJson);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code {response.StatusCode}: {errorMessage}");
            }

            var result = await JsonSerializer.DeserializeAsync<OperationResult>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            if (result.IsSucceeded == false)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception($"Deserialization failed. Response content: {content}");
            }


            return true;
        }

        #endregion
    }
}
