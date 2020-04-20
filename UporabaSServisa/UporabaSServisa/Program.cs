using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace UporabaSServisa
{
    class Program
    {
        static void Main(string[] args)
        {
            Moja().Wait();
            Console.ReadLine();
        }
        static async Task Moja()
        {
            HttpClient klient = new HttpClient();
            klient.BaseAddress = new Uri("http://localhost:49619/");
            klient.DefaultRequestHeaders.Accept.Clear();
            klient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage odg = await klient.GetAsync("api/produkti");
            if (odg.IsSuccessStatusCode)
            {
                List<Product> p1 = await odg.Content.ReadAsAsync<List<Product>>();
                foreach(var p in p1)
                Console.WriteLine(p.Ime+" "+p.Kategorija+" "+p.Cena);
            }
            
        }
    }
}
