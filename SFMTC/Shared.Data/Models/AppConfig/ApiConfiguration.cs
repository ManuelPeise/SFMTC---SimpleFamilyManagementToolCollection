using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Models.AppConfig
{
    public class ApiConfiguration
    {
        public string BaseUrl { get; set; } = string.Empty;
        public int Port { get; set; }
    }
}
