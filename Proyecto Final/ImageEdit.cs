using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class ImageEdit : Form
    {

        [DllImport("kernel.dll", EntryPoint = "GenerateHistograms", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUHistogram(int width, int height, IntPtr pixels, IntPtr redHistogram, IntPtr greenHistogram, IntPtr blueHistogram);
        
        [DllImport("kernel.dll", EntryPoint = "GrayscaleFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUGrayscale(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "NegativeFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUNegative(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "SepiaFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUSepia(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "GaussianFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUGaussian(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "EmbossFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUEmboss(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "EdgeFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUEdge(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "ThermalFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUThermal(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "ContrastFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUContrast(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "SharpenFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUSharpen(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "NoiseFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUNoise(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "TiltFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUTilt(int width, int height, IntPtr pixels, IntPtr result);

        [DllImport("kernel.dll", EntryPoint = "SketchFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUSketch(int width, int height, IntPtr pixels, IntPtr result);


        Bitmap image = null;
        Bitmap filteredImage = null;
        bool imageLoaded = false;

        public ImageEdit()
        {
            InitializeComponent();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        //private void LoadHistograms(Bitmap img)
        //{
        //    HistogramBar.Visible = true;
        //    HistogramBar.Value = 0;
            
        //    int[] redHistogram = new int[256];
        //    int[] greenHistogram = new int[256];
        //    int[] blueHistogram = new int[256];

        //    for (int i = 0; i < img.Width; i++)
        //    {
        //        for (int j = 0; j < img.Height; j++)
        //        {
        //            Color pixel = img.GetPixel(i, j);
        //            redHistogram[pixel.R]++;
        //            greenHistogram[pixel.G]++;
        //            blueHistogram[pixel.B]++;

        //            HistogramBar.Value = (int)(((double)(i * img.Height + j) / (img.Width * img.Height)) * 100);
        //        }
        //    }
            
        //    HistogramChart.Series["Green"].Points.Clear();
        //    HistogramChart.Series["Blue"].Points.Clear();
        //    HistogramChart.Series["Red"].Points.Clear();
        //    RedHistogram.Series["Red"].Points.Clear();
        //    GreenHistogram.Series["Green"].Points.Clear();
        //    BlueHistogram.Series["Blue"].Points.Clear();

        //    for (int i = 0; i < 256; i++)
        //    {
        //        HistogramChart.Series["Red"].Points.AddXY(i, redHistogram[i]);
        //        RedHistogram.Series["Red"].Points.AddXY(i, redHistogram[i]);
        //        HistogramChart.Series["Green"].Points.AddXY(i, greenHistogram[i]);
        //        GreenHistogram.Series["Green"].Points.AddXY(i, greenHistogram[i]);
        //        HistogramChart.Series["Blue"].Points.AddXY(i, blueHistogram[i]);
        //        BlueHistogram.Series["Blue"].Points.AddXY(i, blueHistogram[i]);
        //    }

        //    HistogramBar.Visible = false;

        //}

        private void Grayscale_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDAGrayscale() : CPUGrayscale();
            ImagePreview.Image = filteredImage ?? image;

            LoadHistograms();

        }
        private Bitmap CUDAGrayscale()
        {
            if (!imageLoaded) return null;

            try
            {
                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);
                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUGrayscale(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
        private Bitmap CPUGrayscale()
        {
            try
            {
                Bitmap newImage = new Bitmap(image.Width, image.Height);

                ImageBar.Visible = true;
                ImageBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = filteredImage.GetPixel(i, j);

                        int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                        Color newPixel = Color.FromArgb(gray, gray, gray);
                        newImage.SetPixel(i, j, newPixel);
                        ImageBar.Value = (int)(((double)(i * newImage.Height + j) / (newImage.Width * newImage.Height)) * 100);
                    }
                }

                ImageBar.Value = 100;
                ImageBar.Visible = false;

                return newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error ocurred: " + ex.Message);
                return null;
            }
        }

        private void Sepia_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDASepia() : CPUSepia();
            ImagePreview.Image = filteredImage;

            LoadHistograms();

        }
        private Bitmap CUDASepia()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSepia(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
        private Bitmap CPUSepia()
        {
            try
            {
                Bitmap newImage = new Bitmap(image.Width, image.Height);

                ImageBar.Visible = true;
                ImageBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = filteredImage.GetPixel(i, j);
                        int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                        int newRed = Math.Min(255, gray + 40);
                        int newGreen = Math.Min(255, gray + 20);
                        int newBlue = Math.Min(255, gray);
                        Color newPixel = Color.FromArgb(newRed, newGreen, newBlue);
                        newImage.SetPixel(i, j, newPixel);
                        ImageBar.Value = (int)(((double)(i * newImage.Height + j) / (newImage.Width * newImage.Height)) * 100);
                    }
                }

                ImageBar.Value = 100;
                ImageBar.Visible = false;

                return newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error ocurred: " + ex.Message);
                return null;
            }
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDANegative() : CPUNegative();
            ImagePreview.Image = filteredImage;

            LoadHistograms();

        }
        private Bitmap CUDANegative()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUNegative(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
        private Bitmap CPUNegative()
        {
            try
            {
                Bitmap newImage = new Bitmap(image.Width, image.Height);

                ImageBar.Visible = true;
                ImageBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = filteredImage.GetPixel(i, j);
                        Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                        newImage.SetPixel(i, j, newPixel);
                        ImageBar.Value = (int)(((double)(i * newImage.Height + j) / (newImage.Width * newImage.Height)) * 100);
                    }
                }

                ImageBar.Value = 100;
                ImageBar.Visible = false;

                return newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error ocurred: " + ex.Message);
                return null;
            }
        }

        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDAGaussian() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDAGaussian()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUGaussian(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void Emboss_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDAEmboss() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDAEmboss()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUEmboss(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void EdgeDetection_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            //filteredImage = CUDA.Checked ? CUDAGaussian() : image;
            filteredImage = CUDA.Checked ? CUDAEdge() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDAEdge()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUEdge(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void Thermal_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDAThermal() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDAThermal()
        {

            if (!imageLoaded) return null;

            try
            {
                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUThermal(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void Contrast_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDAContrast() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDAContrast()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUContrast(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void Sharpen_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDASharpen() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDASharpen()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSharpen(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void Noise_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDAGaussian() : image;
            filteredImage = CUDA.Checked ? CUDANoise() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDANoise()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUNoise(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void TiltShift_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDATilt() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDATilt()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUTilt(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void Sketch_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filteredImage = CUDA.Checked ? CUDASketch() : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }
        private Bitmap CUDASketch()
        {

            if (!imageLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredImage.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredImage.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSketch(filteredImage.Width, filteredImage.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredImage.Width, filteredImage.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;
            filteredImage = image;
            ImagePreview.Image = image;
            LoadHistograms();
        }

        private void SaveFile()
        {
            if (!imageLoaded) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filteredImage.Save(saveFileDialog.FileName);
            }
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = SelectedImage;
            openFileDialog.Filter = "Image Files(*png; *.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                image = new Bitmap(selectedFilePath);
                filteredImage = image;

                ImagePreview.Image = image;
                LoadHistograms();

                imageLoaded = true;
            }
        }
        private void ToggleButtons()
        {
            ImageButton.Enabled = !ImageButton.Enabled;
            Grayscale.Enabled = !Grayscale.Enabled;
            Sepia.Enabled = !Sepia.Enabled;
            Negative.Enabled = !Negative.Enabled;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelectedImage_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void LoadHistograms()
        {
            HistogramBar.Visible = true;
            HistogramBar.Value = 0;
            var histograms = GenerateHistogram(filteredImage);
            //HistogramWorker.RunWorkerAsync();

            HistogramChart.Series["Red"].Points.Clear();
            RedHistogram.Series["Red"].Points.Clear();
            HistogramChart.Series["Green"].Points.Clear();
            GreenHistogram.Series["Green"].Points.Clear();
            HistogramChart.Series["Blue"].Points.Clear();
            BlueHistogram.Series["Blue"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                HistogramChart.Series["Red"].Points.AddXY(i, histograms.redHistogram[i]);
                RedHistogram.Series["Red"].Points.AddXY(i, histograms.redHistogram[i]);
                HistogramChart.Series["Green"].Points.AddXY(i, histograms.greenHistogram[i]);
                GreenHistogram.Series["Green"].Points.AddXY(i, histograms.greenHistogram[i]);
                HistogramChart.Series["Blue"].Points.AddXY(i, histograms.blueHistogram[i]);
                BlueHistogram.Series["Blue"].Points.AddXY(i, histograms.blueHistogram[i]);
            }

            HistogramBar.Visible = false;

        }
        private (int[] redHistogram, int[] greenHistogram, int[] blueHistogram) GenerateHistogram(Bitmap img)
        {
            return CUDA.Checked ? CUDAHistogram(img) : CPUHistogram(img);
        }
        private (int[] redHistogram, int[] greenHistogram, int[] blueHistogram) CUDAHistogram(Bitmap img)
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
        private (int[] redHistogram, int[] greenHistogram, int[] blueHistogram) CPUHistogram(Bitmap img)
        {
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    redHistogram[pixel.R]++;
                    greenHistogram[pixel.G]++;
                    blueHistogram[pixel.B]++;
                    int progress = (int)(((double)(i * img.Height + j) / (img.Width * img.Height)) * 100);
                    HistogramBar.Value = progress;
                }
            }

            return (redHistogram, greenHistogram, blueHistogram);
        }
        private void ClearHistograms()
        {
            HistogramChart.Series["Red"].Points.Clear();
            RedHistogram.Series["Red"].Points.Clear();
            HistogramChart.Series["Green"].Points.Clear();
            GreenHistogram.Series["Green"].Points.Clear();
            HistogramChart.Series["Blue"].Points.Clear();
            BlueHistogram.Series["Blue"].Points.Clear();
        }

    }
}
