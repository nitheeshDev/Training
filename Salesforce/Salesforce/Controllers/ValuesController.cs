using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Salesforce.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private const string SalesforceInstanceUrl = "https://claysystechnologiespvtltd-dev-ed.develop.my.salesforce.com";
        private const string AccessToken = "6Cel800D5h000008MLJr8885h000001UuwSVo3nyBmRmmQP4WWDwonB0JtArbpxjEj88Per5E7fSPnDGIO1GNYyN0xyhBVlht6PXvJ4VBfR";

        [HttpPost]
        public async Task<IActionResult> Post(Opputunity opportunity)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Set the base URL for Salesforce REST API
                    client.BaseAddress = new Uri(SalesforceInstanceUrl);

                    // Set the authorization header with the access token
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

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
        [HttpPatch("{opportunityId}")]
        public async Task<IActionResult> UpdateOpportunity(string opportunityId, Opputunity updatedOpportunity)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(SalesforceInstanceUrl);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                    var jsonUpdatedOpportunityData = JsonConvert.SerializeObject(updatedOpportunity);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var apiUrl = $"/services/data/v58.0/sobjects/Opportunity/{opportunityId}";

                    var content = new StringContent(jsonUpdatedOpportunityData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PatchAsync(apiUrl, content); // Use PatchAsync for updating

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Opportunity updated successfully.");
                    }
                    else
                    {
                        return BadRequest($"Failed to update Opportunity. Status Code: {response.StatusCode}");
                    }
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
                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(SalesforceInstanceUrl);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                    var apiUrl = $"/services/data/v58.0/sobjects/Opportunity/{opportunityId}";

                    var response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Opportunity deleted successfully.");
                    }
                    else
                    {
                        return BadRequest($"Failed to delete Opportunity. Status Code: {response.StatusCode}");
                    }
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
                using (var client = new HttpClient())
                {
  
                    client.BaseAddress = new Uri(SalesforceInstanceUrl);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                    var apiUrl = $"/services/data/v58.0/sobjects/Opportunity/{opportunityId}";

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        
                        var opportunity = Newtonsoft.Json.JsonConvert.DeserializeObject<Opputunity>(responseContent);
                        return Ok(opportunity);
                    }
                    else
                    {
                        return BadRequest($"Failed to retrieve Opportunity. Status Code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        //}
        //[HttpGet("{opportunityId}")]
        //public async Task<IActionResult> GetOpportunity(string opportunityId)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            // Set the base URL for Salesforce REST API
        //            client.BaseAddress = new Uri(SalesforceInstanceUrl);

        //            // Set the authorization header with the access token
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

        //            // Construct the SOQL query to retrieve all fields
        //            var soqlQuery = $"SELECT Name, Amount, CloseDate, StageName, CreatedBy.Name FROM Opportunity WHERE Id = '{opportunityId}'";

        //            // Encode the SOQL query
        //            var encodedQuery = Uri.EscapeDataString(soqlQuery);

        //            // Construct the URL with the SOQL query
        //            var apiUrl = $"/services/data/v58.0/query/?q={encodedQuery}";

        //            // Make the GET request to retrieve the Opportunity
        //            var response = await client.GetAsync(apiUrl);

        //            // Check if the request was successful
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var responseContent = await response.Content.ReadAsStringAsync();

        //                // Deserialize the response into the appropriate DTO
        //                var jsonResponse = JsonConvert.DeserializeObject<Opputunity>(responseContent);
        //               return Ok(jsonResponse);

        //                // Check if any records were returned

        //            }
        //            else
        //            {
        //                return BadRequest($"Failed to retrieve Opportunity. Status Code: {response.StatusCode}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error: {ex.Message}");
        //    }
        //}
        [HttpGet]
   public async Task<string> GetAllOpportunitiesAsync()

        {

            try

            {
                using (var client = new HttpClient())

                {

                    client.BaseAddress = new Uri(SalesforceInstanceUrl);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                    var response = await client.GetAsync("/services/data/v58.0/query?q=SELECT+Id,Name,StageName,CloseDate+FROM+Opportunity");

                    if (response.IsSuccessStatusCode)

                    {

                        var responseContent = await response.Content.ReadAsStringAsync();


                        var opportunitiesData = JsonConvert.DeserializeObject<dynamic>(responseContent);

                        return JsonConvert.SerializeObject(opportunitiesData, Formatting.Indented);

                    }

                    else

                    {

                        return $"Failed to retrieve Opportunity records. Status Code: {response.StatusCode}";

                    }

                }

            }

            catch (Exception ex)

            {

                return $"Error: {ex.Message}";

            }

        }

    }
}
    

