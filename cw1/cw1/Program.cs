using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace cw1
{
    class Program
    {
        //static void Main(string[] args)
        //{
            //Console.WriteLine("Hello World!");
            //await mainn();
            
        //}

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://regexlib.com/Search.aspx?k=email&c=-1&m=-1&ps=20");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                //System.Text.RegularExpressions.MatchCollection Matches(string responseBody);
                string pattern = @"[\w-]+@([\w-]+\.)+[\w-]+";
                Regex rgx = new Regex(pattern);
                foreach (Match match in rgx.Matches(responseBody))
                    Console.WriteLine("Found '{0}' at position {1}",
                                      match.Value, match.Index);



                //MatchCollection matches(responseBody, "^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

                // Use foreach-loop.
               
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                //^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$

                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


    }
}
