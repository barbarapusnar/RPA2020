using SpletnaBrezVmesnika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpletnaBrezVmesnika.Controllers
{
    public class ProduktiController : ApiController
    {
        Product[] p = new Product[]
            {
                new Product{Id=1,Ime="Juha",Kategorija="Jestvine",Cena=1},
                new Product{Id=2,Ime="Žoga",Kategorija="Igrače",Cena=3.75m},
                new Product{Id=3,Ime="Kladivo",Kategorija="Železnina",Cena=16.95m},
            };
        //mvc kontroler http://localhost:3333/imekontrolerja/imemetode/1
        //api kontroler http://localhost:3333/api/imekontrolerja
        public IEnumerable<Product> GetProducts()
        {
            return p;
        }
        public Product GetProduct(int id)
        {
            var x = p.Where(a => a.Id == id).FirstOrDefault();
            return x;
        }
    }
}
