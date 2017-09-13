using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace AvImage.ImageProcessing
{
    public class ImageFileExtractor
    {
        private readonly string[] supportedImageFormats = { ".jpg", ".bmp", ".png"};

        private readonly string filePath;
        private readonly FileInfo imageFile;
        public  byte[] RgbValues;
        public ImageFileExtractor(string filePath)
        {
            this.filePath = filePath;
            this.imageFile = new FileInfo(filePath);
            ExtractPixels();
        }

        private void ExtractPixels()
        {
            if (!ImageFormatSupported())
            {
                Console.WriteLine("Image format not supported");
                return;
            }
            var bitMap = new Bitmap(filePath);
            var rect = new Rectangle(0, 0, bitMap.Width, bitMap.Height);
            var bmpData = bitMap.LockBits(rect, ImageLockMode.ReadWrite, bitMap.PixelFormat);
            var ptr = bmpData.Scan0;

            var bytes = Math.Abs(bmpData.Stride) * bitMap.Height;
            this.RgbValues = new byte[bytes];

            Marshal.Copy(ptr, RgbValues, 0, bytes);

            bitMap.UnlockBits(bmpData);
        }

        private bool ImageFormatSupported()
        {
            return supportedImageFormats.Contains(imageFile.Extension.ToLower());
        }
    }
}
