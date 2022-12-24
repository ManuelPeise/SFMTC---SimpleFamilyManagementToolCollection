using Newtonsoft.Json;
using Shared.Services.Interfaces;
using System.Net.Http.Json;
using System.Web;

namespace Shared.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private bool disposedValue;

        public HttpService()
        {
            _httpClient= new HttpClient();
        }

        public async Task<T?> Get<T>(string url, List<KeyValuePair<string, string>>? parameters)
        {
            var uri = parameters != null && parameters.Any() ? GetUrlWithQueryString(url, parameters) : url;

            using(var client = _httpClient)
            using (var msg = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                var response = await client.SendAsync(msg);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }

            return default;
        }


        public async Task Post(string url, List<KeyValuePair<string, string>>? parameters)
        {
            throw new NotImplementedException();
        }

        #region private

        private string GetUrlWithQueryString(string url, List<KeyValuePair<string, string>>? parameters)
        {
            var query = from p in parameters
                        select $"{p.Key}={p.Value}";

            return $"{url}?{string.Join("&", query)}";
        }

        #endregion

        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}