using Microsoft.Extensions.Options;
using Shared.Data.Models.AppConfig;

namespace Shared.Services.Interfaces
{
    public interface IConfigService
    {
        public IOptions<ApiConfiguration> ApiConfig { get; }
    }
}
