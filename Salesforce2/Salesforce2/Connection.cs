//using Newtonsoft.Json;
//using Salesforce2.Model;

//namespace Salesforce2
//{
//    public class Connection
//    {
//        private const string SalesforceInstanceUrl = "https://claysystechnologiespvtltd-dev-ed.develop.my.salesforce.com";
//        private const string ClientId = "3MVG95mg0lk4bathLfjnAnkpVZSm1j1zyZSTQRzCPuy7yQ_Mx3NVhBP.n_kHligaEsEwFSP0vmJnQFF5TpKaG";
//        private const string ClientSecret = "F8D3BCB23EE6767C0E5D23AAE9F894D5B0C801C1FDDEF2E3270601B3777B9F35";
//        private const string Username = "nitheeshclaysys28@gmail.com";
//        private const string Password = "Nitheesh*28";
//        private const string SecurityToken = "A6s2AEYukI0R7C0ckGa231IP";

//        public async Task<string> GetAccessTokenAsync()
//        {
//            var httpClient = new HttpClient();
//            var request = new HttpRequestMessage(HttpMethod.Post, "https://login.salesforce.com/services/oauth2/token");
//            var requestBody = new List<KeyValuePair<string, string>>
//    {
//        new KeyValuePair<string, string>("grant_type", "password"),
//        new KeyValuePair<string, string>("client_id", ClientId),
//        new KeyValuePair<string, string>("client_secret", ClientSecret),
//        new KeyValuePair<string, string>("username", Username),
//        new KeyValuePair<string, string>("password", Password + SecurityToken)
//    };
//            request.Content = new FormUrlEncodedContent(requestBody);

//            var response = await httpClient.SendAsync(request);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseBody = await response.Content.ReadAsStringAsync();
//                var tokenResponse = JsonConvert.DeserializeObject<Opputunity>(responseBody);
//                return tokenResponse.AccessToken;
//            }
//            else
//            {
//                throw new Exception($"Failed to obtain access token. Status Code: {response.StatusCode}");
//            }
//        }
//    }
//}
