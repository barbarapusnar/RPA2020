using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.Models
{
    class Ekipa
    {
        public string ImeEkipe { get; private set; }
        private List<Igralec> _igralci = new List<Igralec>();
        public IEnumerable<Igralec> Igralci
        {
            get { return new List<Igralec>(_igralci); }
        }
        public Ekipa(string i, IEnumerable<Igralec> ig)
        {
            ImeEkipe = i;
            _igralci.AddRange(ig);
        }
    }
}
