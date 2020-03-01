using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace cw1
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://regexlib.com/Search.aspx?k=email&c=-1&m=-1&ps=20");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();              
                string pattern = @"[\w-]+@([\w-]+\.)+[\w-]+";
                Regex rgx = new Regex(pattern);
                foreach (Match match in rgx.Matches(responseBody))
                    Console.WriteLine("Found '{0}' at position {1}",
                                      match.Value, match.Index);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
