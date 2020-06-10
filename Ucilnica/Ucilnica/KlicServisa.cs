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
            int števec = 1;
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
                    p.modules = new ObservableCollection<Module>();
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
                                p.imagePath = "/Assets/" + števec + ".png";
                                števec++;
                                if (števec > 7) števec = 7;
                                break;
                            case "summary":
                                p.summary = Windows.Data.Html.HtmlUtilities.ConvertToText(val.GetString());
                                break;
                            case "modules":
                                var vse = val.GetArray();
                                var list = from i in vse select i.GetObject();
                                foreach (var a in list)
                                {
                                    Module v = new Module();
                                    v.contents = new ObservableCollection<Content>();
                                    foreach (var k in a.Keys)
                                    {
                                        IJsonValue val1;
                                        if (!a.TryGetValue(k, out val1)) continue;
                                        switch (k)
                                        {
                                            case "name":
                                                v.name = val1.GetString();break;
                                            case "modicon":
                                                v.modicon = val1.GetString();break;
                                            case "contents":
                                                var vse1 = val.GetArray();
                                                var list1 = from i in vse1 select i.GetObject();
                                                foreach (var b in list1)
                                                {
                                                    Content vs = new Content();
                                                    foreach (var k2 in b.Keys)
                                                    {
                                                        IJsonValue val2;
                                                        if (!b.TryGetValue(k2, out val2)) continue;
                                                        switch (k2)
                                                        {
                                                            case "fileurl":
                                                                vs.fileurl = val2.GetString();break;
                                                            case "filename":
                                                                vs.filename = val2.GetString();break;
                                                        }//konec switch k2
                                                    }//konec for k2
                                                    v.contents.Add(vs);
                                                }

                                                break;
                                        }//konec switch k
                                    }//konec for k
                                    p.modules.Add(v);
                                }//konec for a
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
