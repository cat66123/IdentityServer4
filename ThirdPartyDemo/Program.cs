using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace ThirdPartyDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var disco = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }

            // var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "catClient",
                ClientSecret = "catSecret",
                Scope="catApi"
            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            else
            {
                Console.WriteLine(tokenResponse.Json);
            }


            client.SetBearerToken(tokenResponse.AccessToken);
            var response = await client.GetAsync("http://localhost:5002/api/values");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
            
            Console.ReadLine();
        }
    }
}
