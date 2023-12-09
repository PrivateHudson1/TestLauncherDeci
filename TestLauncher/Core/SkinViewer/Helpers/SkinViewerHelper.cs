using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TestLauncher.Core.SkinViewer.Helpers
{
    internal class SkinViewerHelper
    {


        public static async Task<ImageSource> LoadImageAsync(string url)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.BeginInit();
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            bitmap.Freeze();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fail to load image from {url}: {ex.Message}");
                return null;
            }
        }
    }
}
