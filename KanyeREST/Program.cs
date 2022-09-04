using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace KanyeREST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kanyeURl = "https://api.kanye.rest/";

            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var client = new HttpClient();


            for (int i = 0; i < 5; i++) 
            {
                var kanyeResponse = client.GetStringAsync(kanyeURl).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine("Kanye:\n");
                Console.WriteLine(kanyeQuote);
                Console.WriteLine();

                var ronResponse = client.GetStringAsync(ronUrl).Result;

                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine("Ron:\n");
                Console.WriteLine(ronQuote);
                Console.WriteLine();
            }
        }
    }
}