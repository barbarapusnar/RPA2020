using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoNuts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Kava : Page
    {
        private string _tip;
        private string _sladilo;
        private string _dodatek;
        public Kava()
        {
            this.InitializeComponent();
        }
        private void Roast_Click(object sender, RoutedEventArgs e)
        {
            var s = (MenuFlyoutItem)sender;
            _tip = s.Text;
            tbIzbor.Text="Izbral si "+_tip+"+"+_sladilo + "+" + _dodatek;
        }
        private void Sladilo_Click(object sender, RoutedEventArgs e)
        {
            var s = (MenuFlyoutItem)sender;
           _sladilo = s.Text;
            tbIzbor.Text = "Izbral si " + _tip + "+" + _sladilo + "+" + _dodatek;
        }
        private void Dodatek_Clcik(object sender, RoutedEventArgs e)
        {
            var s = (MenuFlyoutItem)sender;
           _dodatek = s.Text;
            tbIzbor.Text = "Izbral si " + _tip + "+" + _sladilo + "+" + _dodatek;
        }
    }
}
