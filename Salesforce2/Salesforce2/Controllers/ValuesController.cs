using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Salesforce2.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Salesforce2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        private const string SalesforceInstanceUrl = "https://claysystechnologiespvtltd-dev-ed.develop.my.salesforce.com";
        private const string ClientId = "3MVG95mg0lk4bathLfjnAnkpVZSm1j1zyZSTQRzCPuy7yQ_Mx3NVhBP.n_kHligaEsEwFSP0vmJnQFF5TpKaG";
        private const string ClientSecret = "F8D3BCB23EE6767C0E5D23AAE9F894D5B0C801C1FDDEF2E3270601B3777B9F35";
        private const string Username = "nitheeshclaysys28@gmail.com";
        private const string Password = "Nitheesh*28";
        private const string SecurityToken = "A6s2AEYukI0R7C0ckGa231IP";

        [HttpPost]
        public async Task<IActionResult> Post(Opputunity opportunity)
        {
            try
            {
                // Obtain the access token
                var accessToken = await GetAccessTokenAsync();

                using (var client = new HttpClient())
                {
                    // Set the base URL for Salesforce REST API
                    client.BaseAddress = new Uri(SalesforceInstanceUrl);

                    // Set the authorization header with the access token
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    // Serialize the Opportunity data to JSON
                    var jsonOpportunityData = JsonConvert.SerializeObject(opportunity);

                    // Set the content type header to JSON
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsync("/services/data/v58.0/sobjects/Opportunity", new StringContent(jsonOpportunityData, System.Text.Encoding.UTF8, "application/json"));

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
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        private async Task<string> GetAccessTokenAsync()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://login.salesforce.com/services/oauth2/token");
                var requestBody = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", ClientId),
                    new KeyValuePair<string, string>("client_secret", ClientSecret),
                    new KeyValuePair<string, string>("username", Username),
                    new KeyValuePair<string, string>("password", Password + SecurityToken)
                };
                request.Content = new FormUrlEncodedContent(requestBody);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseBody);
                    return tokenResponse.AccessToken;
                }
                else
                {
                    throw new Exception($"Failed to obtain access token. Status Code: {response.StatusCode}");
                }
            }
        }

        public class TokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            // Add other properties as needed (e.g., "expires_in", "token_type", etc.)
        }
    }
}
