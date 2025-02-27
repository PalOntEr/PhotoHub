using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using PhotoHub.Filters;

namespace PhotoHub
{
    public partial class CameraEdit : Form
    {
        VideoCapture camera = null;
        Bitmap frame = null;
        Bitmap filteredFrame = null;
        bool frameLoaded = false;
        bool detectingColor = false;

        readonly Filter filters = null;
        int activeFilter = 0;

        public CameraEdit()
        {
            InitializeComponent();
            filters = Filter.GetFilterClass();
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            ActivateCamera();
        }


        private void Grayscale_Click(object sender, EventArgs e)
        {
            activeFilter = 1;
        }

        private void Sepia_Click(object sender, EventArgs e)
        {
            activeFilter = 2;
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            activeFilter = 3;
        }

        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            activeFilter = 4;
        }
        
        private void Emboss_Click(object sender, EventArgs e)
        {
            activeFilter = 5;

            CameraPreview.Image = filteredFrame ?? frame;
        }
        
        private void EdgeDetection_Click(object sender, EventArgs e)
        {
            activeFilter = 6;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        
        private void Thermal_Click(object sender, EventArgs e)
        {
            activeFilter = 7;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        
        private void Contrast_Click(object sender, EventArgs e)
        {
            activeFilter = 8;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        
        private void Sharpen_Click(object sender, EventArgs e)
        {
            activeFilter = 9;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        
        private void Noise_Click(object sender, EventArgs e)
        {
            activeFilter = 10;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        
        private void TiltShift_Click(object sender, EventArgs e)
        {
            activeFilter = 11;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        
        private void Sketch_Click(object sender, EventArgs e)
        {
            activeFilter = 12;

            CameraPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }
        

        private void DetectButton_Click(object sender, EventArgs e)
        {
            detectingColor = !detectingColor;
            DetectButton.Visible = false;
            StopDetecting.Visible = true;

            LoadHistograms();
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
            filters.SetProgressBar(ImageBar);
            switch (activeFilter)
            {
                case 1:
                    filteredFrame = CUDA.Checked ? filters.CUDAGrayscale(filteredFrame) : filters.CPUGrayscale(filteredFrame);
                    break;
                case 2:
                    filteredFrame = CUDA.Checked ? filters.CUDASepia(filteredFrame) : filters.CPUSepia(filteredFrame);
                    break;
                case 3:
                    filteredFrame = CUDA.Checked ? filters.CUDANegative(filteredFrame) : filters.CPUNegative(filteredFrame);
                    break;
                case 4:
                    filteredFrame = CUDA.Checked ? filters.CUDAGaussian(filteredFrame) : null;
                    break;
                case 5:
                    filteredFrame = CUDA.Checked ? filters.CUDAEmboss(filteredFrame) : null;
                    break;
                case 6:
                    filteredFrame = CUDA.Checked ? filters.CUDAEdge(filteredFrame) : null;
                    break;
                case 7:
                    filteredFrame = CUDA.Checked ? filters.CUDAThermal(filteredFrame) : null;
                    break;
                case 8:
                    filteredFrame = CUDA.Checked ? filters.CUDAContrast(filteredFrame) : null;
                    break;
                case 9:
                    filteredFrame = CUDA.Checked ? filters.CUDASharpen(filteredFrame) : null;
                    break;
                case 10:
                    filteredFrame = CUDA.Checked ? filters.CUDANoise(filteredFrame) : null;
                    break;
                case 11:
                    filteredFrame = CUDA.Checked ? filters.CUDATilt(filteredFrame) : null;
                    break;
                case 12:
                    filteredFrame = CUDA.Checked ? filters.CUDASketch(filteredFrame) : null;
                    break;
                default:
                    filteredFrame = frame;
                    break;
            }

            filteredFrame = detectingColor ? filters.CUDADetectColor(filteredFrame, SelectedColor.BackColor) : filteredFrame;

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
        private void DeactivateCamera()
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
            filters.SetProgressBar(HistogramBar);
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
            return CUDA.Checked ? filters.CUDAHistogram(img) : filters.CPUHistogram(img);
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
            DeactivateCamera();
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frameLoaded)
            {
                ActivateCamera();
            }
            else
            {
                DeactivateCamera();
            }
        }
    }
}
