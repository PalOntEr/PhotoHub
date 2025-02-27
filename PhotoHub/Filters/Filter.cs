using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoHub.Filters
{
    class Filter
    {
        [DllImport("kernel.dll", EntryPoint = "GenerateHistograms", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUHistogram(int width, int height, IntPtr pixels, IntPtr redHistogram, IntPtr greenHistogram, IntPtr blueHistogram);

        [DllImport("kernel.dll", EntryPoint = "GrayscaleFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUGrayscale(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "NegativeFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUNegative(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "SepiaFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUSepia(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "GaussianFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUGaussian(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "EmbossFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUEmboss(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "EdgeFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUEdge(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "ThermalFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUThermal(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "ContrastFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUContrast(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "SharpenFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUSharpen(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "NoiseFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUNoise(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "TiltFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUTilt(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "SketchFilter", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUSketch(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "ColorDetection", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GPUColorDetection(int width, int height, IntPtr pixels, IntPtr result, IntPtr color);


        private static Filter filters;
        private ProgressBar progressBar;

        private Filter() {
        }

        public static Filter GetFilterClass()
        {
            if (filters == null)
                filters = new Filter();

            return filters;
        }

        public void SetProgressBar(ProgressBar pb)
        {
            progressBar = pb;
        }

        public Bitmap CUDAGrayscale(Bitmap img)
        {
            if (img == null) return null;
            try
            {
                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);
                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUGrayscale(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Bitmap CPUGrayscale(Bitmap img)
        {
            try
            {
                Bitmap newImage = new Bitmap(img.Width, img.Height);

                progressBar.Visible = true;
                progressBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);

                        int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                        Color newPixel = Color.FromArgb(gray, gray, gray);
                        newImage.SetPixel(i, j, newPixel);
                        progressBar.Value = (int)(((double)(i * newImage.Height + j) / (newImage.Width * newImage.Height)) * 100);
                    }
                }

                progressBar.Value = 100;
                progressBar.Visible = false;

                return newImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Bitmap CUDASepia(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSepia(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public Bitmap CPUSepia(Bitmap img)
        {
            try
            {
                Bitmap newImage = new Bitmap(img.Width, img.Height);

                progressBar.Visible = true;
                progressBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);
                        int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                        int newRed = Math.Min(255, gray + 40);
                        int newGreen = Math.Min(255, gray + 20);
                        int newBlue = Math.Min(255, gray);
                        Color newPixel = Color.FromArgb(newRed, newGreen, newBlue);
                        newImage.SetPixel(i, j, newPixel);
                        progressBar.Value = (int)(((double)(i * newImage.Height + j) / (newImage.Width * newImage.Height)) * 100);
                    }
                }

                progressBar.Value = 100;
                progressBar.Visible = false;

                return newImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Bitmap CUDANegative(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUNegative(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public Bitmap CPUNegative(Bitmap img)
        {
            try
            {
                Bitmap newImage = new Bitmap(img.Width, img.Height);

                progressBar.Visible = true;
                progressBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);
                        Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                        newImage.SetPixel(i, j, newPixel);
                        progressBar.Value = (int)(((double)(i * newImage.Height + j) / (newImage.Width * newImage.Height)) * 100);
                    }
                }

                progressBar.Value = 100;
                progressBar.Visible = false;

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDAGaussian(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUGaussian(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDAEmboss(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUEmboss(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDAEdge(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUEdge(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDAThermal(Bitmap img)
        {
            if (img == null) return null;
            try
            {
                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUThermal(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDAContrast(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUContrast(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDASharpen(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSharpen(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDANoise(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUNoise(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDATilt(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUTilt(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDASketch(Bitmap img)
        {
            if (img == null) return null;
            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSketch(img.Width, img.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public Bitmap CUDADetectColor(Bitmap img, Color selectedColor)
        {
            if (img == null) return null;

            try
            {

                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * img.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                img.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrColor = Marshal.AllocHGlobal(3 * sizeof(char));

                byte[] color = new byte[3]
                {
                    selectedColor.R,
                    selectedColor.G,
                    selectedColor.B
                };

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);
                Marshal.Copy(color, 0, ptrColor, 3);

                GPUColorDetection(img.Width, img.Height, ptrPixels, ptrResult, ptrColor);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(img.Width, img.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(pixels, 0, newBitmapData.Scan0, byteCount);
                newImage.UnlockBits(newBitmapData);

                return newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error ocurred: " + ex.Message);
                return null;
            }
        }

        public (int[] redHistogram, int[] greenHistogram, int[] blueHistogram) CUDAHistogram(Bitmap img)
        {
            int width = img.Width;
            int height = img.Height;
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int byteCount = bitmapData.Stride * height;
            byte[] pixels = new byte[byteCount];
            Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
            img.UnlockBits(bitmapData);

            IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
            IntPtr ptrRedHistogram = Marshal.AllocHGlobal(256 * sizeof(int));
            IntPtr ptrGreenHistogram = Marshal.AllocHGlobal(256 * sizeof(int));
            IntPtr ptrBlueHistogram = Marshal.AllocHGlobal(256 * sizeof(int));

            Marshal.Copy(pixels, 0, ptrPixels, byteCount);
            Marshal.Copy(redHistogram, 0, ptrRedHistogram, 256);
            Marshal.Copy(greenHistogram, 0, ptrGreenHistogram, 256);
            Marshal.Copy(blueHistogram, 0, ptrBlueHistogram, 256);

            GPUHistogram(width, height, ptrPixels, ptrRedHistogram, ptrGreenHistogram, ptrBlueHistogram);

            Marshal.Copy(ptrRedHistogram, redHistogram, 0, 256);
            Marshal.Copy(ptrGreenHistogram, greenHistogram, 0, 256);
            Marshal.Copy(ptrBlueHistogram, blueHistogram, 0, 256);

            Marshal.FreeHGlobal(ptrPixels);
            Marshal.FreeHGlobal(ptrRedHistogram);
            Marshal.FreeHGlobal(ptrGreenHistogram);
            Marshal.FreeHGlobal(ptrBlueHistogram);

            return (redHistogram, greenHistogram, blueHistogram);
        }
        public (int[] redHistogram, int[] greenHistogram, int[] blueHistogram) CPUHistogram(Bitmap img)
        {
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];
            Array.Clear(redHistogram, 0, redHistogram.Length);
            Array.Clear(greenHistogram, 0, greenHistogram.Length);
            Array.Clear(blueHistogram, 0, blueHistogram.Length);
            if (img == null) return (redHistogram, greenHistogram, blueHistogram);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    redHistogram[pixel.R]++;
                    greenHistogram[pixel.G]++;
                    blueHistogram[pixel.B]++;
                    int progress = (int)(((double)(i * img.Height + j) / (img.Width * img.Height)) * 100);
                    progressBar.Value = progress;
                }
            }

            return (redHistogram, greenHistogram, blueHistogram);
        }
    }
}
