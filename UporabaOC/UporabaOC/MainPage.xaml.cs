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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UporabaOC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Icon> Ikone;
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
        }
    }
}
