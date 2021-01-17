using Microsoft.Extensions.Configuration;

namespace Gramium.Api.Common
{
    public class ApiConfig : IApiConfig
    {
        private readonly IConfiguration config;

        public ApiConfig(IConfiguration config)
        {
            this.config = config;
        }

        public string JwtSecret 
        { 
            get { return this.config["Jwt:Secret"]; } 
        }
    }
}
