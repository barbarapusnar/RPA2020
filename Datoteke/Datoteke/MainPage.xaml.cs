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
using Windows.Storage;
using Windows.UI.Popups;
using Windows.ApplicationModel;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Datoteke
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string ime = "MojaDatoteka.txt";
            StorageFolder mapa = ApplicationData.Current.LocalFolder;
            var novo = CreationCollisionOption.ReplaceExisting;
            StorageFile dat = await mapa.CreateFileAsync(ime, novo);
            await FileIO.WriteTextAsync(dat, txtVnos.Text);
            MessageDialog m = new MessageDialog("Zapisano");
            await m.ShowAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ime = "MojaDatoteka.txt";
            StorageFolder mapa = ApplicationData.Current.LocalFolder;
            StorageFile dat = await mapa.GetFileAsync(ime);
            string prebrano = await FileIO.ReadTextAsync(dat);
            txtVnos.Text = prebrano;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StorageFolder mapa = Package.Current.InstalledLocation;
            //ms-appx:///ime.dat --> za uporabo v xamlu
            StorageFolder podmapa = await mapa.GetFolderAsync("Assets");
            StorageFile dat = await podmapa.GetFileAsync("vaje.json");
            string prebrano = await FileIO.ReadTextAsync(dat);
            txtVnos.Text = prebrano;
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FileOpenPicker op = new FileOpenPicker();
            op.ViewMode = PickerViewMode.List;
            op.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            op.FileTypeFilter.Add(".txt");
            op.FileTypeFilter.Add(".cs");
            StorageFile f = await op.PickSingleFileAsync();
            if (f != null)
            {
                var vsebina = await FileIO.ReadTextAsync(f);
                txtVnos.Text = vsebina;
            }
            else
            {
                await new MessageDialog("Ni izbrana datoteka").ShowAsync();
            }
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            StorageFolder mapa = KnownFolders.MusicLibrary;
            StorageFile nova = await mapa.CreateFileAsync("Nova.txt");
            await FileIO.WriteTextAsync(nova, "blablabla");
        }
    }
}
