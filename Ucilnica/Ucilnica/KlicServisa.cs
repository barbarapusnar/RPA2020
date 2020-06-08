using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

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

        public static async Task<Uc> GetPoglavjaAsync()
        {
            string url = "https://eucilnica.scng.si/webservice/rest/server.php?wstoken=df95bf67c1672ffe7a5e48df58cee724&wsfunction=core_course_get_contents&courseid=110&moodlewsrestformat=json";
            Uc result = new Uc();
            result.VasPoglavja = new ObservableCollection<Poglavja>();
            try
            {
                HttpClient klient = new HttpClient();
                var odgovor = await klient.GetAsync(url);
                var jsonMessage = await odgovor.Content.ReadAsStringAsync();
                var rezultati = JsonArray.Parse(jsonMessage);
                foreach (var item in rezultati)
                {
                    var obj = item.GetObject();
                    Poglavja p = new Poglavja();
                    foreach (var key in obj.Keys)
                    {
                        IJsonValue val;
                        if (!obj.TryGetValue(key, out val))
                            continue;
                        switch (key)
                        {
                            case "id":
                                p.id = (int)val.GetNumber();
                                break;
                            case "name":
                                p.name = val.GetString();
                                break;
                            case "summary":
                                p.summary = Windows.Data.Html.HtmlUtilities.ConvertToText(val.GetString());
                                break;
                        }//konec switch
                    }//konec for key
                    result.VasPoglavja.Add(p);
                }//konec for item
                return result;
            }
            catch(Exception a)
            { return result; }

        }

    }
}
