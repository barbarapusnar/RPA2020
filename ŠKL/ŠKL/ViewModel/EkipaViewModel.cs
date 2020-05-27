using ŠKL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.ViewModel
{
    class EkipaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<IgralecViewModel> Starters { get; set; }
        public ObservableCollection<IgralecViewModel> Klop { get; set; }
        private Ekipa _ekipa;
        private string _imeEkipe;
        public string ImeEkipe
        {
            get { return _imeEkipe; }
            set {
                _imeEkipe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImeEkipe)));
            }
        }
        public EkipaViewModel(Ekipa e)
        {
            _ekipa = e;
            Starters = new ObservableCollection<IgralecViewModel>();
            Klop = new ObservableCollection<IgralecViewModel>();
            ImeEkipe = _ekipa.ImeEkipe;
            PosodobiEkipe();
        }

        private void PosodobiEkipe()
        {
            var začetni = from a in _ekipa.Igralci
                          where a.Starter
                          select a;
            Starters.Clear();
            foreach (Igralec a in začetni)
            {
                Starters.Add(new IgralecViewModel(a.Ime, a.Številka));
            }
            var klop = from a in _ekipa.Igralci
                          where !a.Starter
                          select a;
            Klop.Clear();
            foreach (Igralec a in klop)
            {
                Klop.Add(new IgralecViewModel(a.Ime, a.Številka));
            }
        }
    }
}
