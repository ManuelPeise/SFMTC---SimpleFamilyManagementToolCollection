using Microsoft.Extensions.Options;
using Shared.Data.Models.AppConfig;
using Shared.Services.Interfaces;


namespace Shared.Services
{
    public class ConfigService : IConfigService
    {
        private IOptions<ApiConfiguration> _options;

        public ConfigService(IOptions<ApiConfiguration> options)
        {
            _options = options;
        }

        public IOptions<ApiConfiguration> ApiConfig { get => _options; }
    }
}
