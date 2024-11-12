namespace Blog.Presentation.BlazorWebAssembly.Services.Shared
{
    public interface IApiService<T> where T : class
    {
        Task<List<T>>? GetAll(T request, string path);
        Task<T>? GetById(int entityId, string path);
        Task<T> Post(T entity, string path);
        Task<T>? Put(T entity, string path);
        Task<bool> Delete(int entityId, string path);
    }
}
