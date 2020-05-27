using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.ViewModel
{
    class IgralecViewModel
    {
        public string Ime { get; set; }
        public int Številka { get; set; }
        public IgralecViewModel(string i, int š)
        {
            Ime = i;Številka = š;
        }
    }
}
