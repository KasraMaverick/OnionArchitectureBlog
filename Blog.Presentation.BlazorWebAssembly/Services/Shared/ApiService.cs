
using System.Text;
using System.Text.Json;

namespace Blog.Presentation.BlazorWebAssembly.Services.Shared
{
    public class ApiService<T> : IApiService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _mediaType = "application/json";
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _endpoint = "https://localhost:7170/api/";
        }


        public async Task<List<T>>? GetAll(T request, string path)
        {
            var dataJson = request != null ? 
                new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, _mediaType):
                new StringContent(JsonSerializer.Serialize(default(T)), Encoding.UTF8, _mediaType);

            var response = await _httpClient.PostAsync($"{_endpoint}/{path}/GetAll", dataJson);

            return JsonSerializer.Deserialize<List<T>>(await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<T>? GetById(int entityId, string path)
        {
            return JsonSerializer.Deserialize<T>
            (await _httpClient.GetStreamAsync($"{_endpoint}/{path}/{entityId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<T> Post(T entity, string path)
        {
            try
            {
                var dataJson = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, _mediaType);

                var response = await _httpClient.PostAsync($"{_endpoint}/{path}/Create", dataJson);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Request failed with status code {response.StatusCode}: {errorMessage}");
                }

                var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (result == null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Deserialization failed. Response content: {content}");
                }

                return result;
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error deserializing the response content.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while making the PUT request.", ex);
            }

            return null; ;
        }

        public async Task<T>? Put(T entity, string path)
        {
            try
            {
                var dataJson = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, _mediaType);

                var response = await _httpClient.PutAsync($"{_endpoint}/{path}/Update", dataJson);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Request failed with status code {response.StatusCode}: {errorMessage}");
                }


                var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (result == null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Deserialization failed. Response content: {content}");
                }

                return result;
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error deserializing the response content.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while making the PUT request.", ex);
            }

            return null;
        }

        public async Task<bool> Delete(int entityId, string path)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_endpoint}/{path}/Delete");
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error deserializing the response content.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while making the PUT request.", ex);
            }
        }
    }
}
