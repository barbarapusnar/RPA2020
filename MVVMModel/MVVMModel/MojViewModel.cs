using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace MVVMModel
{
    class MojViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MojZapis> Zapisi { get; set; }
        private MojZapis tekočiZapis;
        public MojZapis TekočiZapis
        {
            get { return tekočiZapis; }
            set { tekočiZapis = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TekočiZapis)));
                }
        }
        public string Naslov { get; set; }
        public DelegateCommand NarediZeleno { get; set; }
        public MojViewModel()
        {
            Zapisi = new ObservableCollection<MojZapis>();
            for (int k = 0; k < 10; k++)
            {
                Zapisi.Add(new MojZapis { Ime = k.ToString(), Barva = Color.FromArgb(255, 255, 255, 0)});               
            }
            NarediZeleno = new DelegateCommand(
                (p) => { TekočiZapis.Barva = Color.FromArgb(255,0,255,0); },
                (p) => { return TekočiZapis != null; }
                );
            TekočiZapis = Zapisi.First();
            Naslov = "Zbirka mojih zapisov";
        }
    }
}
