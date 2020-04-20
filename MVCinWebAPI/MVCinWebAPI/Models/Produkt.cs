using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCinWebAPI.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public decimal Cena { get; set; }
        public decimal Stroški { get; set; }
    }
}