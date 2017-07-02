using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public static class ImageConvertUtil
    {
        public static string BitmapImageToBase64(BitmapImage image)
        {
            Stream stream = image.StreamSource;
            stream.Position = 0;
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            return Convert.ToBase64String(data);
        }
        public static BitmapImage Base64ToBitmapImage(string base64)
        {
            byte[] data = Convert.FromBase64String(base64);
            Stream stream = new MemoryStream(data);
            stream.Position = 0;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            image.Freeze();
            return image;
        }

    }
}
