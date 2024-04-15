using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using salesforce3.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace salesforce3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private const string SalesforceApiEndpoint = "/services/data/v58.0/";
        private IConfiguration _configuration;
        private static HttpClient _client;
        private static string _accessToken;
        private static string _instanceUrl;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            AuthenticateSalesforce().Wait();
        }

        private async Task AuthenticateSalesforce()
        {
            try
            {
                var clientId = _configuration["SalesforceConfig:ClientId"];
                var clientSecret = _configuration["SalesforceConfig:ClientSecret"];
                var username = _configuration["SalesforceConfig:Username"];
                var password = _configuration["SalesforceConfig:Password"];
                var securityToken = _configuration["SalesforceConfig:SecurityToken"];
                var loginEndpoint = _configuration["SalesforceConfig:LoginEndpoint"];

                var client = new HttpClient();
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "username", username },
                    { "password", password + securityToken }
                });

                var message = await client.PostAsync(loginEndpoint + "/services/oauth2/token", content);
                var response = await message.Content.ReadAsStringAsync();

                if (message.IsSuccessStatusCode)
                {
                    var authData = JsonConvert.DeserializeObject<AuthResponse>(response);
                    _accessToken = authData.access_token;
                    _instanceUrl = authData.instance_url;

                    _client = new HttpClient
                    {
                        BaseAddress = new Uri(_instanceUrl),
                        DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", _accessToken) }
                    };
                }
                else
                {
                    throw new Exception($"Salesforce authentication failed. Status Code: {message.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Salesforce authentication error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOpportunity(Opputunity opportunity)
        {
            try
            {
                if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_instanceUrl))
                {
                    throw new Exception("Salesforce authentication credentials are not available.");
                }

                var createOpportunityUrl = $"{_instanceUrl}{SalesforceApiEndpoint}sobjects/Opportunity/";
                var jsonOpportunityData = JsonConvert.SerializeObject(opportunity);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _client.PostAsync(createOpportunityUrl, new StringContent(jsonOpportunityData, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var createdOpportunity = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    return Ok($"Opportunity created with ID: {createdOpportunity.id}");
                }
                else
                {
                    return BadRequest($"Failed to create Opportunity. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("{opportunityId}")]
        public async Task<IActionResult> UpdateOpportunity(string opportunityId, Opputunity patchOpportunity)
        {
            try
            {
                if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_instanceUrl))
                {
                    throw new Exception("Salesforce authentication credentials are not available.");
                }

                var updateOpportunityUrl = $"{_instanceUrl}{SalesforceApiEndpoint}sobjects/Opportunity/{opportunityId}";
                var jsonPatchOpportunityData = JsonConvert.SerializeObject(patchOpportunity);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _client.PatchAsync(updateOpportunityUrl, new StringContent(jsonPatchOpportunityData, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return Ok($"Opportunity updated with ID");
                }
                else
                {
                    return BadRequest($"Failed to update Opportunity. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpDelete("{opportunityId}")]
        public async Task<IActionResult> DeleteOpportunity(string opportunityId)
        {
            try
            {
                if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_instanceUrl))
                {
                    throw new Exception("Salesforce authentication credentials are not available.");
                }

                var deleteOpportunityUrl = $"{_instanceUrl}{SalesforceApiEndpoint}sobjects/Opportunity/{opportunityId}";
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _client.DeleteAsync(deleteOpportunityUrl);

                if (response.IsSuccessStatusCode)
                {
                    return Ok($"Opportunity with ID {opportunityId} deleted successfully");
                }
                else
                {
                    return BadRequest($"Failed to delete Opportunity. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpGet("{opportunityId}")]
        public async Task<IActionResult> GetOpportunity(string opportunityId)
        {
            try
            {
                if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_instanceUrl))
                {
                    throw new Exception("Salesforce authentication credentials are not available.");
                }

                var getOpportunityUrl = $"{_instanceUrl}{SalesforceApiEndpoint}sobjects/Opportunity/{opportunityId}";
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _client.GetAsync(getOpportunityUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var opportunity = JsonConvert.DeserializeObject<Opputunity>(responseContent);
                    return Ok(opportunity);
                }
                else
                {
                    return BadRequest($"Failed to retrieve Opportunity. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        private class AuthResponse
        {
            public string access_token { get; set; }
            public string instance_url { get; set; }
        }
    }
}
