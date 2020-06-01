using DateotekeMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DateotekeMVVM.Servisi
{
    class FileService
    {
        public async Task SaveAsync(FileInfo model)
        {
            if (model != null)
            {
                await FileIO.WriteTextAsync(model.Ref, model.Text);
            }
        }
        public async Task<FileInfo> LoadAsync(StorageFile f)
        {
            return new FileInfo
            {
                Text = await FileIO.ReadTextAsync(f),
                Name = f.DisplayName,
                Ref = f
            };
        }
    }
}
