using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TestLauncher.Core.SkinViewer;
using TestLauncher.Core.SkinViewer.Helpers;
using TestLauncher.Views.Pages;

namespace TestLauncher.ViewModel
{
    public class DashboardViewModel : MvxViewModel
    {


        #region 
        private ImageSource _skin;

        public ImageSource Skin
        {
            get => _skin;
            set => SetProperty(ref _skin, value);
        }

        #endregion



        public DashboardViewModel()
        {

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"C:\Users\rashe\source\repos\TestLauncher\TestLauncher\Views\Resources\Images\vk.jpg");
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            
            LoadSkin();

        }

        private async void LoadSkin()
        {
           await Task.Run(async () =>
                {
                    SkinViewerManager skinViewerManager = new SkinViewerManager("https://minecrafthub.com/image/share/50212_5bae1817dce46.png");

                    await skinViewerManager.LoadAsync();

                   // Skin = skinViewerManager.GetHead(13); 
                });
        }
    }
}
