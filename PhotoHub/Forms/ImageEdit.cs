using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PhotoHub.Filters;

namespace PhotoHub
{
    public partial class ImageEdit : Form
    {
        Bitmap image = null;
        Bitmap filteredImage = null;
        readonly Filter filters = null;
        bool imageLoaded = false;

        public ImageEdit()
        {
            InitializeComponent();
            filters = Filter.GetFilterClass();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void Grayscale_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDAGrayscale(filteredImage) : filters.CPUGrayscale(filteredImage);
            ImagePreview.Image = filteredImage ?? image;

            LoadHistograms();

        }

        private void Sepia_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDASepia(filteredImage) : filters.CPUSepia(filteredImage);
            ImagePreview.Image = filteredImage;

            LoadHistograms();

        }

        private void Negative_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDANegative(filteredImage) : filters.CPUNegative(filteredImage);
            ImagePreview.Image = filteredImage;

            LoadHistograms();

        }

        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDAGaussian(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void Emboss_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDAEmboss(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void EdgeDetection_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            //filteredImage = CUDA.Checked ? CUDAGaussian() : image;
            filteredImage = CUDA.Checked ? filters.CUDAEdge(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void Thermal_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDAThermal(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void Contrast_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDAContrast(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void Sharpen_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDASharpen(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void Noise_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDAGaussian(filteredImage) : image;
            filteredImage = CUDA.Checked ? filters.CUDANoise(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void TiltShift_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDATilt(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

            LoadHistograms();
        }

        private void Sketch_Click(object sender, EventArgs e)
        {
            if (!imageLoaded) return;

            filters.SetProgressBar(ImageBar);
            filteredImage = CUDA.Checked ? filters.CUDASketch(filteredImage) : image;

            if (!CUDA.Checked)
            {
                MessageBox.Show("This filter is not available for CPU processing");
                return;
            }

            ImagePreview.Image = filteredImage;

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
            filters.SetProgressBar(HistogramBar);
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
            return CUDA.Checked ? filters.CUDAHistogram(img) : filters.CPUHistogram(img);
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
