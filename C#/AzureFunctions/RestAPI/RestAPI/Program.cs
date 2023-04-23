using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApiExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // Set the base URL of the API endpoint
            //client.BaseAddress = new Uri("https://api.ipify.org?format=json");
            client.BaseAddress = new Uri("http://bcdemo:7048/BC/ODataV4/Company('CRONUS%20International%20Ltd.')/Job_Task_Lines?$select=Job_No,Job_Task_No,Description");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            

            // Call the API endpoint and get the response
            HttpResponseMessage response = await client.GetAsync("?format=json");

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Get the response content as a string
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }
    }
}