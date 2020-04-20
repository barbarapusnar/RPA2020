using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVCinWebAPI.Models
{
    public class NaročilaInicializator:DropCreateDatabaseIfModelChanges<NarocilaContext>
    {
        protected override void Seed(NarocilaContext context)
        {
            var p = new List<Produkt>()
            {
                new Produkt(){ Id=1,Ime="Juha",Cena=1.3m,Stroški=0.99m},
                new Produkt(){ Id=2,Ime="Kladivo",Cena=16.99m,Stroški=10},
                new Produkt(){ Id=3,Ime="Žoga",Cena=6.99m,Stroški=2m}
            };
            foreach (var p1 in p)
            {
                context.Produkts.Add(p1);
            }
            context.SaveChanges();
            var n = new Naročilo() { Stranka = "Janez" };
            var po = new List<Podrobnosti>()
            {
                new Podrobnosti(){Produkt=p[0],Količina=2,Naročilo=n},
                new Podrobnosti(){Produkt=p[2],Količina=4,Naročilo=n}
            };
            context.Naročila.Add(n);
            foreach (var po1 in po)
                context.Podrobnosti.Add(po1);
            context.SaveChanges();
        }
    

}
}