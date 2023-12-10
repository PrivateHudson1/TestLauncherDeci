using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TestLauncher.Core.SkinViewer.Helpers;

namespace TestLauncher.Core.SkinViewer
{
    internal class SkinViewerManager 
    {

        public ImageSource ImageSource;
        private string _imageUrl;

        public SkinViewerManager(string url)
        {
            _imageUrl = url;
        }


        public async Task LoadAsync()
        {
            ImageSource = await SkinViewerHelper.LoadImageAsync(_imageUrl);
        }

        
        internal ImageSource GetHead(int scale = 1)
        {
            if (ImageSource == null)
            {
                throw new ArgumentNullException(nameof(ImageSource));
            }

            var croppedImage = SkinViewerHelper.CropImage(ImageSource, 8, 8, 8, 8);

            return SkinViewerHelper.ResizeImage(croppedImage, Convert.ToInt32(croppedImage.Width) * scale, Convert.ToInt32(croppedImage) * scale);
        }
    }
}
