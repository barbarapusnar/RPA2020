using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.Models
{
    class Igralec
    {
        public string Ime { get; set; }
        public int Številka { get; set; }
        public bool Starter { get; set; }
        public Igralec(string i, int š, bool s)
        {
            Ime = i;Številka = š;Starter = s;
        }
    }
}
