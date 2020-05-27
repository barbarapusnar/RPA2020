using ŠKL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.ViewModel
{
    class LigaViewModel
    {
        public EkipaViewModel EkipaJimmy { get; set; }
        public EkipaViewModel EkipaJanez {  get; set; }
        public LigaViewModel()
        {
            Ekipa janez = new Ekipa("Bomberji", DobiBomberje());
            EkipaJanez = new EkipaViewModel(janez);
            Ekipa jimmy = new Ekipa("Fantastični", DobiFantastične());
            EkipaJimmy = new EkipaViewModel(jimmy);
        }

        private IEnumerable<Igralec> DobiFantastične()
        {
            List<Igralec> a = new List<Igralec>()
            {
                new Igralec("Jimmy",42,true),
                new Igralec("Henry",11,true),
                new Igralec("Bob",4,true),
                new Igralec("Lucinda",18,true),
                new Igralec("Kim",16,true),
                new Igralec("Bertha",23,false),
                new Igralec("Ed",41,false)
            };
            return a;
        }

        private IEnumerable<Igralec> DobiBomberje()
        {
            List<Igralec> a = new List<Igralec>()
            {
                new Igralec("Janez",42,true),
                new Igralec("Miha",11,true),
                new Igralec("Matej",4,true),
                new Igralec("Lučka",18,true),
                new Igralec("Goran",16,true),
                new Igralec("Luka",23,false),
                new Igralec("Edvard",41,false)
            };
            return a;
        }
    }
}
