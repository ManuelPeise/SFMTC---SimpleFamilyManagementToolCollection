using Newtonsoft.Json;
using Shared.Interfaces.User;
using Shared.Services.Interfaces;

namespace Shared.Services
{
    public class UserAccountService : IUserAccountService
    {
        public UserAccountService()
        {

        }

        public async Task<bool> IsUserLoggedIn(string url, Guid userId)
        {
            using (var client = new HttpClient())
            using (var msg = new HttpRequestMessage(HttpMethod.Get, $"{url}?userid={userId}"))
            {
                var response = await client.SendAsync(msg);

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(content);
            }
        }

        public async Task<IUser> LoginAsync(string url, ILogin login)
        {
            using (var client = new HttpClient())
            using (var msg = new HttpRequestMessage(HttpMethod.Post, $"{url}?login={login}"))
            {
                var response = await client.SendAsync(msg);

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IUser>(content);
            }
        }

        public async Task<bool> LogoutAsync(string url, Guid userId)
        {
            using (var client = new HttpClient())
            using (var msg = new HttpRequestMessage(HttpMethod.Post, $"{url}?userid={userId}"))
            {
                var response = await client.SendAsync(msg);

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(content);
            }
        }
    }
}
