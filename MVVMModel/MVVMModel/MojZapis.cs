using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace MVVMModel
{
    class MojZapis : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string ime;
        public string Ime
        {
            get { return ime; }
            set {
                ime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ime))); //sprožim dogodek
            }
        }
        private Color barva;
        public Color Barva
        {
            get { return barva; }
            set
            {
                barva = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Barva))); //sprožim dogodek
            }
        }

    }
}
