using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientStatus
{
    class Program
    {
        private const string URL = "https://en.wikipedia.org/wiki/Lenna#/media/File:Lenna_(test_image).png";
        static async Task Main(string[] args)
        {
            // HttpClient
            Console.WriteLine("\nHttpClient\n");
            var httpClient = new HttpClient();
            var httpContent = await httpClient.GetAsync(URL);
            Console.WriteLine(httpContent);

            // RestClient
            Console.WriteLine("\nRestClient\n");
            var restClient = new RestClient(URL);
            var client = new RestClient("https://api.twitter.com/1.1");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");
            var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);
            var restContent = restClient.Get(request);
            Console.WriteLine(restContent.Content);
        }
    }
}