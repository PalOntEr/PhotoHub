using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace PhotoHub
{
    public partial class VideoEdit : Form
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


        VideoCapture video = null;
        Bitmap frame = null;
        Bitmap filteredFrame = null;
        double totalFrames = 0;
        int currentFrame = 0;
        bool frameLoaded = false;
        bool pause = true;

        int activeFilter = 0;

        public VideoEdit()
        {
            InitializeComponent();
        }

        private void VideoButton_Click(object sender, EventArgs e)
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
            activeFilter = 1;
            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }
        private Bitmap CUDAGrayscale()
        {
            if (!frameLoaded) return null;

            try
            {
                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);
                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUGrayscale(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
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
                Bitmap newImage = new Bitmap(frame.Width, frame.Height);

                ImageBar.Visible = true;
                ImageBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = filteredFrame.GetPixel(i, j);

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
            activeFilter = 2;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }
        private Bitmap CUDASepia()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSepia(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
                Bitmap newImage = new Bitmap(frame.Width, frame.Height);

                ImageBar.Visible = true;
                ImageBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = filteredFrame.GetPixel(i, j);
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
            activeFilter = 3;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }
        private Bitmap CUDANegative()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUNegative(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
                Bitmap newImage = new Bitmap(frame.Width, frame.Height);

                ImageBar.Visible = true;
                ImageBar.Value = 0;

                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        Color pixel = filteredFrame.GetPixel(i, j);
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
            activeFilter = 4;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }
        private Bitmap CUDAGaussian()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUGaussian(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 5;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }
        private Bitmap CUDAEmboss()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUEmboss(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 6;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDAEdge()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUEdge(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 7;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDAThermal()
        {

            if (!frameLoaded) return null;

            try
            {
                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUThermal(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 8;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDAContrast()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUContrast(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 9;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDASharpen()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSharpen(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 10;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDANoise()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUNoise(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 11;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDATilt()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUTilt(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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
            activeFilter = 12;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        private Bitmap CUDASketch()
        {

            if (!frameLoaded) return null;

            try
            {

                BitmapData bitmapData = filteredFrame.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int byteCount = bitmapData.Stride * filteredFrame.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                filteredFrame.UnlockBits(bitmapData);

                IntPtr ptrPixels = Marshal.AllocHGlobal(byteCount);
                IntPtr ptrResult = Marshal.AllocHGlobal(byteCount);

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);

                GPUSketch(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult);

                Marshal.Copy(ptrResult, pixels, 0, byteCount);

                Marshal.FreeHGlobal(ptrPixels);
                Marshal.FreeHGlobal(ptrResult);

                Bitmap newImage = new Bitmap(filteredFrame.Width, filteredFrame.Height);
                BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, filteredFrame.Width, filteredFrame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
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

        private void ApplyActiveFilter()
        {
            switch (activeFilter)
            {
                case 1:
                    filteredFrame = CUDA.Checked ? CUDAGrayscale() : CPUGrayscale();
                    break;
                case 2:
                    filteredFrame = CUDA.Checked ? CUDASepia() : CPUSepia();
                    break;
                case 3:
                    filteredFrame = CUDA.Checked ? CUDANegative() : CPUNegative();
                    break;
                case 4:
                    filteredFrame = CUDA.Checked ? CUDAGaussian() : null;
                    break;
                case 5:
                    filteredFrame = CUDA.Checked ? CUDAEmboss() : null;
                    break;
                case 6:
                    filteredFrame = CUDA.Checked ? CUDAEdge() : null;
                    break;
                case 7:
                    filteredFrame = CUDA.Checked ? CUDAThermal() : null;
                    break;
                case 8:
                    filteredFrame = CUDA.Checked ? CUDAContrast() : null;
                    break;
                case 9:
                    filteredFrame = CUDA.Checked ? CUDASharpen() : null;
                    break;
                case 10:
                    filteredFrame = CUDA.Checked ? CUDANoise() : null;
                    break;
                case 11:
                    filteredFrame = CUDA.Checked ? CUDATilt() : null;
                    break;
                case 12:
                    filteredFrame = CUDA.Checked ? CUDASketch() : null;
                    break;
                default:
                    filteredFrame = frame;
                    break;
            }

            LoadHistograms();

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
            activeFilter = 0;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void SaveFile()
        {
            if (!frameLoaded) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filteredFrame.Save(saveFileDialog.FileName);
            }
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = SelectedImage;
            openFileDialog.Filter = "Video Files(*.mp4; *.avi; *.mov)|*.mp4; *.avi; *.mov";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                video = new VideoCapture(selectedFilePath);

                frame = video.QueryFrame().ToBitmap();
                filteredFrame = frame;
                VideoPreview.Image = frame;
                frameLoaded = true;
                pause = true;

                totalFrames = video.Get(Emgu.CV.CvEnum.CapProp.FrameCount);
                VideoProgressBar.Maximum = (int)totalFrames + 1;

                MessageBox.Show("The video has been loaded succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ToggleButtons()
        {
            VideoButton.Enabled = !VideoButton.Enabled;
            Grayscale.Enabled = !Grayscale.Enabled;
            Sepia.Enabled = !Sepia.Enabled;
            Negative.Enabled = !Negative.Enabled;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadHistograms()
        {

            if (filteredFrame == null)
            {
                ClearHistograms();
                return;
            }

            HistogramBar.Value = 0;
            HistogramBar.Visible = true;

            var histograms = GenerateHistogram(filteredFrame);
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

        private void CheckActiveFrame_Tick(object sender, EventArgs e)
        {
            currentFrame = (int)video.Get(Emgu.CV.CvEnum.CapProp.PosFrames);
            if (video == null || currentFrame >= totalFrames)
            {
                CheckActiveFrame.Enabled = false;
                return;
            }

            VideoProgressBar.Value = currentFrame + 1;

            frame = video.QueryFrame()?.ToBitmap();

            if (frame == null)
            {
                CheckActiveFrame.Enabled = false;
                MessageBox.Show("The video has ended");
                video.Dispose();
                frameLoaded = false;
                video = null;
                return;
            }

            filteredFrame = frame;

            ApplyActiveFilter();

            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (video == null) return;

            CheckActiveFrame.Enabled = true;

            pause = false;
            PlayButton.Hide();
            PauseButton.Show();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (video == null) return;

            CheckActiveFrame.Enabled = false;

            pause = true;
            PauseButton.Hide();
            PlayButton.Show();
        }

        private void BackwardsButton_Click(object sender, EventArgs e)
        {
            if (video == null) return;

            currentFrame = (int)video.Get(Emgu.CV.CvEnum.CapProp.PosFrames);

            if (currentFrame - 24 >= 0)
            {
                video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, currentFrame - 24);
                currentFrame -= 24;
                VideoProgressBar.Value = currentFrame + 1;
                frame = video.QueryFrame().ToBitmap();
                filteredFrame = frame;
                ApplyActiveFilter();
                VideoPreview.Image = filteredFrame;
            }
            else
            {
                currentFrame = 0;
                video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, 0);
                MessageBox.Show("You have reached the beginning of the video", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            VideoProgressBar.Value = currentFrame + 1;

        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (video == null) return;

            currentFrame = (int)video.Get(Emgu.CV.CvEnum.CapProp.PosFrames);

            if (currentFrame + 24 < totalFrames)
            {
                video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, currentFrame + 24);
                currentFrame += 24;
                frame = video.QueryFrame().ToBitmap();
                filteredFrame = frame;
                ApplyActiveFilter();
                VideoPreview.Image = filteredFrame;
            }
            else
            {
                currentFrame = (int)totalFrames;
                video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, currentFrame);
                MessageBox.Show("You have reached the end of the video", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            VideoProgressBar.Value = currentFrame + 1;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (video == null) return;

            CheckActiveFrame.Enabled = false;

            frame = null;
            filteredFrame = null;
            VideoPreview.Image = frame;

            video.Dispose();
            video = null;

            pause = true;
            PauseButton.Visible = false;
            PlayButton.Visible = true;

            ClearHistograms();
        }

        private void RestartVideo_Click(object sender, EventArgs e)
        {
            if (video == null) return;

            CheckActiveFrame.Enabled = false;
            video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, 0);
            frame = video.QueryFrame().ToBitmap();
            filteredFrame = frame;
            VideoPreview.Image = frame;
            frameLoaded = true;

            pause = true;
            PauseButton.Visible = false;
            PlayButton.Visible = true;
        }

        private void VideoProgressBar_Scroll(object sender, EventArgs e)
        {
            if (video == null) return;

            currentFrame = VideoProgressBar.Value;
            video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, currentFrame);
            frame = video.QueryFrame().ToBitmap();
            filteredFrame = frame;
            ApplyActiveFilter();
            VideoPreview.Image = filteredFrame;
        }
    }
}
