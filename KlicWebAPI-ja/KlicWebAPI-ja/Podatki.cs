using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KlicWebAPI_ja
{

    public class Podatki
    {
        public string[] message { get; set; }
        public string status { get; set; }
    }
    public class Slika
    {
        public string Pot { get; set; }
    }
    public class Klic
    {
        public static async Task PopulatePsi(ObservableCollection<Slika> poti)
        {
            string url = "https://dog.ceo/api/breed/bullterrier/staffordshire/images";
            Podatki p = new Podatki();
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                p = await sp.Content.ReadAsAsync<Podatki>();
            }
            int k = 0;
            foreach (string x in p.message)
            {
                Slika s = new Slika();
                s.Pot = x;
                poti.Add(s);
                k++;
                //if (k >= 10) break;
            }
        }
    }
}
