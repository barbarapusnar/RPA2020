using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ucilnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Poglavja> VsaPoglavja { get; set; }
        public ObservableCollection<Module> Vsebina { get; set; }
        public ObservableCollection<Content> VseDatoteke { get; set; }
        Uc a = new Uc();
        public MainPage()
        {
            this.InitializeComponent();
            VsaPoglavja = new ObservableCollection<Poglavja>();
            Vsebina = new ObservableCollection<Module>();
            VseDatoteke = new ObservableCollection<Content>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mojPr.IsActive = true;
            mojPr.Visibility = Visibility.Visible;
            //await KlicServisa.NapolniPoglavja(VsaPoglavja);           
            a = await KlicServisa.GetPoglavjaAsync();
            foreach (var x in a.VasPoglavja)
                VsaPoglavja.Add(x);
            var izbranoPoglavje = VsaPoglavja.FirstOrDefault();
            foreach (var y in izbranoPoglavje.modules)
                Vsebina.Add(y);
            mojPr.IsActive = false;
            mojPr.Visibility = Visibility.Collapsed;
        }
    }
}
