using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCinWebAPI.Models
{
    public class Naročilo
    {
        public int ID { get; set; }
        public string Stranka { get; set; }
        public ICollection<Podrobnosti> Vrstice { get; set; }
    }
    public class Podrobnosti
    {
        public int Id { get; set; }
        public int Količina { get; set; }
        public int IdNaročila { get; set; }
        public int IdProdukta { get; set; }
        //navigation property
        public Produkt Produkt { get; set; }
        public Naročilo Naročilo { get; set; }
    }
}