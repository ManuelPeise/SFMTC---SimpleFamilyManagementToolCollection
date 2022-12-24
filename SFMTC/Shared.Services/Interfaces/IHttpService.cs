namespace Shared.Services.Interfaces
{
    public interface IHttpService: IDisposable
    {
        Task<T?> Get<T>(string url, List<KeyValuePair<string, string>>? parameters);

        Task Post(string url, List<KeyValuePair<string, string>>? parameters);
    }
}
