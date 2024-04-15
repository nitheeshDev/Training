using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_opps
{
    internal class Oppurtunity
    {
        static async Task Main(string[] args)
        {
            string consumerKey = "3MVG95mg0lk4bathLfjnAnkpVZSm1j1zyZSTQRzCPuy7yQ_Mx3NVhBP.n_kHligaEsEwFSP0vmJnQFF5TpKaG";
            string consumerSecret = "F8D3BCB23EE6767C0E5D23AAE9F894D5B0C801C1FDDEF2E3270601B3777B9F35";
            string username = "nitheeshclaysys28@gmail.com";
            string password = "Nitheesh*28";
            string securityToken = "7s8aOphkQRJIUvwIsK2ElQ8tg";

            var httpClient = new HttpClient();
            var authEndpoint = "https://login.salesforce.com/services/oauth2/token";

            var requestContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", consumerKey },
                { "client_secret", consumerSecret },
                { "username", username },
                { "password", password + securityToken }
            });

            var response = await httpClient.PostAsync(authEndpoint, requestContent);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response to get the access token
            var authResult = JsonConvert.DeserializeObject<AuthenticationResponse>(responseBody);

            string accessToken = authResult.access_token;

            string apiUrl = "https://claysystechnologiespvtltd-dev-ed.develop.my.salesforce.com/0065h00000MotEk";

            var opportunityData = new
            {
                Amount = 1,


            };

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var opportunityJson = JsonConvert.SerializeObject(opportunityData);
            var content = new StringContent(opportunityJson, Encoding.UTF8, "application/json");

            response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                // Opportunity was inserted successfully
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Opportunity Inserted Successfully. Response: " + responseContent);
            }
            else
            {
                // Handle errors
                string errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Inserting Opportunity. Response: " + errorMessage);
            }
        }
    }
    public class AuthenticationResponse
    {
        public string access_token { get; set; }

    }
}