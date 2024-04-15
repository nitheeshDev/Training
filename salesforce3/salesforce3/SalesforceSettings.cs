using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Salesforce3
{
    public class SalesforceSettings
    {
        public string LoginEndpoint { get; set; }
        public string SalesforceApiEndpoint { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecurityToken { get; set; }
    }

   
}
