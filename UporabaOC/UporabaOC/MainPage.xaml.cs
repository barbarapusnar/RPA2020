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

namespace UporabaOC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Icon> Ikone;
        ObservableCollection<Contact> Kontakti;
        public MainPage()
        {
            this.InitializeComponent();
            Ikone = new List<Icon>();
            Ikone.Add(new Icon { PotIkone = "Assets/male-01.png" });
            Ikone.Add(new Icon { PotIkone = "Assets/male-02.png" });
            Ikone.Add(new Icon { PotIkone = "Assets/male-03.png" });
            Ikone.Add(new Icon { PotIkone = "Assets/female-01.png" });
            Ikone.Add(new Icon { PotIkone = "Assets/female-02.png" });
            Ikone.Add(new Icon { PotIkone = "Assets/female-03.png" });
            Kontakti = new ObservableCollection<Contact>();
        }

        private void BtnNov_Click(object sender, RoutedEventArgs e)
        {
            string avatar = ((Icon)(cboAvatar.SelectedValue)).PotIkone;
            Kontakti.Add(new Contact { Ime = txtIme.Text, Priimek = txtPriimek.Text, PotAvatar = avatar });
            txtIme.Text = "";txtPriimek.Text = "";cboAvatar.SelectedIndex = -1;
            txtIme.Focus(FocusState.Programmatic);
        }
    }
}
