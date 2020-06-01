using DateotekeMVVM.Model;
using DateotekeMVVM.Servisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace DateotekeMVVM.ViewModel
{
    class MojViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private FileInfo _dat;
        public FileInfo Dat
        {
            get { return _dat; }
            set {
                _dat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dat)));
            }
        }
        FileService _fs = new FileService();
        public async void Shrani()
        {
            await _fs.SaveAsync(Dat);
        }
        public async void Odpri()
        {
            FileOpenPicker op = new FileOpenPicker();
            op.ViewMode = PickerViewMode.Thumbnail;
            op.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            op.FileTypeFilter.Add(".txt");
            op.FileTypeFilter.Add(".cs");
            StorageFile f = await op.PickSingleFileAsync();
            if (f == null)
                await new MessageDialog("Nobena datoteka ni izbrana").ShowAsync();
            else
                Dat =await _fs.LoadAsync(f);
        }

    }
}
