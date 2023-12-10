using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Controls;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;

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
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.StreamSource = stream;
                            bitmap.EndInit();
                            bitmap.Freeze();

                            return bitmap;
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


       

        public static ImageSource CropImage(ImageSource imageSource, int x, int y, int width, int height)
        {
            var croppedBitmap = new CroppedBitmap((BitmapSource)imageSource, new Int32Rect(x, y, width, height));
            croppedBitmap.Freeze();

            return croppedBitmap;
        }


        public static ImageSource ResizeImage(byte[] imageBytes, int newWidth, int newHeight)
        {
            using (var image = Image.Load<Rgba32>(imageBytes))
            {
                image.Mutate(x => x.Resize(newWidth, newHeight, KnownResamplers.NearestNeighbor));

                using (var stream = new MemoryStream())
                {
                    image.Save(stream, new PngEncoder());

                    stream.Seek(0, SeekOrigin.Begin);
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();

                    return bitmapImage;
                }
            }
        }


        internal static ImageSource ResizeImage(ImageSource imageSource, int newWidth, int newHeight)
        {
            byte[] bytes = ImageSourceToBytes(imageSource);
            return ResizeImage(bytes, newWidth, newHeight);
        }

        private static byte[] ImageSourceToBytes(ImageSource imageSource)
        {
            var encoder = new JpegBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imageSource));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
