using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NajprejKoda.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public int Leto { get; set; }
        public string Tip { get; set; }
        public double Cena { get; set; }
    }
}