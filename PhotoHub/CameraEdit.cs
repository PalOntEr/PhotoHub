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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PhotoHub
{
    public partial class CameraEdit : Form
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

        [DllImport("kernel.dll", EntryPoint = "ColorDetection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GPUColorDetection(int width, int height, IntPtr pixels, IntPtr result, IntPtr color);


        VideoCapture camera = null;
        Bitmap frame = null;
        Bitmap filteredFrame = null;
        bool frameLoaded = false;
        bool detectingColor = false;

        int activeFilter = 0;

        public CameraEdit()
        {
            InitializeComponent();
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            ActivateCamera();
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

            CameraPreview.Image = filteredFrame ?? frame;
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

            CameraPreview.Image = filteredFrame ?? frame;

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

            CameraPreview.Image = filteredFrame ?? frame;

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

            CameraPreview.Image = filteredFrame ?? frame;

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

            CameraPreview.Image = filteredFrame ?? frame;

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

            CameraPreview.Image = filteredFrame ?? frame;

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

            CameraPreview.Image = filteredFrame ?? frame;

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

            CameraPreview.Image = filteredFrame ?? frame;

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

        private void DetectButton_Click(object sender, EventArgs e)
        {
            detectingColor = !detectingColor;
            DetectButton.Visible = false;
            StopDetecting.Visible = true;

            LoadHistograms();
        }
        private Bitmap CUDADetectColor()
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
                IntPtr ptrColor = Marshal.AllocHGlobal(3 * sizeof(char));

                byte[] color = new byte[3] 
                { 
                    SelectedColor.BackColor.R,
                    SelectedColor.BackColor.G,
                    SelectedColor.BackColor.B
                };

                Marshal.Copy(pixels, 0, ptrPixels, byteCount);
                Marshal.Copy(color, 0, ptrColor, 3);

                GPUColorDetection(filteredFrame.Width, filteredFrame.Height, ptrPixels, ptrResult, ptrColor);

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

        private void StopDetecting_Click(object sender, EventArgs e)
        {
            detectingColor = !detectingColor;
            DetectButton.Visible = true;
            StopDetecting.Visible = false;

            LoadHistograms();
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

            filteredFrame = detectingColor ? CUDADetectColor() : filteredFrame;

            LoadHistograms();

        }

        private void PhotoButton_Click(object sender, EventArgs e)
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
        private void ActivateCamera()
        {
            if (MessageBox.Show("Do you wish to activate your camera?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                camera = new VideoCapture(0, VideoCapture.API.Any);

                frame = camera.QueryFrame().ToBitmap();
                filteredFrame = frame;
                CameraPreview.Image = frame;
                frameLoaded = true;

                CheckActiveFrame.Enabled = true;

                CameraButton.Visible = false;
                OffButton.Visible = true;

                MessageBox.Show("The camera has been loaded succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ToggleButtons()
        {
            CameraButton.Enabled = !CameraButton.Enabled;
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
            HistogramBar.Visible = true;
            HistogramBar.Value = 0;
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
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];
            if (img == null) return(redHistogram, greenHistogram, blueHistogram);

            int width = img.Width;
            int height = img.Height;

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

        private void CheckActiveFrame_Tick(object sender, EventArgs e)
        {

            frame = camera.QueryFrame()?.ToBitmap();

            if (frame == null)
            {
                CheckActiveFrame.Enabled = false;
                MessageBox.Show("The camera has ended");
                camera.Dispose();
                return;
            }

            filteredFrame = frame;

            ApplyActiveFilter();

            CameraPreview.Image = filteredFrame ?? frame;
        }

        private void BackwardsButton_Click(object sender, EventArgs e)
        {
            if (camera == null) return;

        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (camera == null) return;

        }

        private void OffButton_Click(object sender, EventArgs e)
        {

            CameraPreview.Image = null;
            frame = null;
            filteredFrame = null;
            frameLoaded = false;

            CheckActiveFrame.Enabled = false;

            camera.Dispose();

            OffButton.Visible = false;
            CameraButton.Visible = true;

        }

        private void ColorsButton_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                SelectedColor.BackColor = ColorPicker.Color;
                SetCIELABValues(ColorPicker.Color);
            }
        }

        private void CameraPreview_MouseClick(object sender, MouseEventArgs e)
        {
            if (filteredFrame == null) return;

            int frameWidth = filteredFrame.Width;
            int frameHeight = filteredFrame.Height;
            int pictureBoxWidth = CameraPreview.ClientSize.Width;
            int pictureBoxHeight = CameraPreview.ClientSize.Height;

            float scaleX;
            float scaleY;
            int offsetX;
            int offsetY;

            float ratioX = (float)pictureBoxWidth / frameWidth;
            float ratioY = (float)pictureBoxHeight / frameHeight;
            float scale = Math.Min(ratioX, ratioY);

            scaleX = 1 / scale;
            scaleY = 1 / scale;

            int displayedWidth = (int)(frameWidth * scale);
            int displayedHeight = (int)(frameHeight * scale);

            offsetX = (pictureBoxWidth - displayedWidth) / 2;
            offsetY = (pictureBoxHeight - displayedHeight) / 2;

            int x = (int)((e.X - offsetX) * scaleX);
            int y = (int)((e.Y - offsetY) * scaleY);

            x = Math.Max(0, Math.Min(x, frameWidth - 1));
            y = Math.Max(0, Math.Min(y, frameHeight - 1));

            Color clickedColor = filteredFrame.GetPixel(x, y);
            SelectedColor.BackColor = clickedColor;

            SetCIELABValues(clickedColor);

        }

        private void SetCIELABValues(Color rgbColor)
        {
            (double L, double a, double b) = RGBtoLab();

            LabelL.Text = $"L: {L}";
            LabelA.Text = $"a: {a}";
            LabelB.Text = $"b: {b}";

            string quadrant = "";

            if (L >= 50 && a >= 0 && b >= 0)
                quadrant = "Cuadrante I: Cálido";
            else if (L >= 50 && a < 0 && b >= 0)
                quadrant = "Cuadrante II: Frío";
            else if (L >= 50 && a < 0 && b < 0)
                quadrant = "Cuadrante III: Frío";
            else if (L >= 50 && a >= 0 && b < 0)
                quadrant = "Cuadrante IV: Cálido";
            else if (L < 50 && a >= 0 && b >= 0)
                quadrant = "Cuadrante V: Cálido";
            else if (L < 50 && a < 0 && b >= 0)
                quadrant = "Cuadrante VI: Frío";
            else if (L < 50 && a < 0 && b < 0)
                quadrant = "Cuadrante VII: Frío";
            else if (L < 50 && a >= 0 && b < 0)
                quadrant = "Cuadrante VIII: Cálido";
            else
                quadrant = "Cuadrante Desconocido";
        
            LabelC.Text = quadrant;
        }

        private (double L, double a, double b) RGBtoLab()
        {
            double r = SelectedColor.BackColor.R / 255.0;
            double g = SelectedColor.BackColor.G / 255.0;
            double b = SelectedColor.BackColor.B / 255.0;

            double x = r * 0.4124564 + g * 0.3575761 + b * 0.1804375;
            double y = r * 0.2126729 + g * 0.7151522 + b * 0.0721750;
            double z = r * 0.0193339 + g * 0.1191920 + b * 0.9503041;

            x = x / 0.95047;
            y = y / 1.0;
            z = z / 1.08883;

            x = x > 0.008856 ? Math.Pow(x, 1.0 / 3.0) : (903.3 * x + 16.0) / 116.0;
            y = y > 0.008856 ? Math.Pow(y, 1.0 / 3.0) : (903.3 * y + 16.0) / 116.0;
            z = z > 0.008856 ? Math.Pow(z, 1.0 / 3.0) : (903.3 * z + 16.0) / 116.0;

            double L = 116.0 * y - 16.0;
            double A = 500.0 * (x - y);
            double B = 200.0 * (y - z);

            return (L, A, B);

        }
    }
}
