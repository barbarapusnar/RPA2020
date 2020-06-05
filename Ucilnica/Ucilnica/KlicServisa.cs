using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ucilnica
{
    class KlicServisa
    {
        public static async Task NapolniPoglavja(ObservableCollection<Poglavja> poglavja)
        {
            string url = "https://eucilnica.scng.si/webservice/rest/server.php?wstoken=df95bf67c1672ffe7a5e48df58cee724&wsfunction=core_course_get_contents&courseid=110&moodlewsrestformat=json";
            List<Poglavja> p = new List<Poglavja>();
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                p =await sp.Content.ReadAsAsync<List<Poglavja>>();
            }
            foreach (var p1 in p)
                poglavja.Add(p1);
        }
    }
}
