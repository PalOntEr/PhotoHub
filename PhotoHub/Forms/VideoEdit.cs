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
using PhotoHub.Filters;

namespace PhotoHub
{
    public partial class VideoEdit : Form
    {
        VideoCapture video = null;
        Bitmap frame = null;
        Bitmap filteredFrame = null;
        double totalFrames = 0;
        int currentFrame = 0;
        bool frameLoaded = false;
        bool pause = true;

        readonly Filter filters = null;
        int activeFilter = 0;

        public VideoEdit()
        {
            InitializeComponent();
            filters = Filter.GetFilterClass();
        }

        private void VideoButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void Grayscale_Click(object sender, EventArgs e)
        {
            activeFilter = 1;
            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void Sepia_Click(object sender, EventArgs e)
        {
            activeFilter = 2;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            activeFilter = 3;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            activeFilter = 4;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void Emboss_Click(object sender, EventArgs e)
        {
            activeFilter = 5;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;
        }

        private void EdgeDetection_Click(object sender, EventArgs e)
        {
            activeFilter = 6;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }

        private void Thermal_Click(object sender, EventArgs e)
        {
            activeFilter = 7;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }

        private void Contrast_Click(object sender, EventArgs e)
        {
            activeFilter = 8;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }

        private void Sharpen_Click(object sender, EventArgs e)
        {
            activeFilter = 9;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }

        private void Noise_Click(object sender, EventArgs e)
        {
            activeFilter = 10;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }

        private void TiltShift_Click(object sender, EventArgs e)
        {
            activeFilter = 11;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

            LoadHistograms();
        }

        private void Sketch_Click(object sender, EventArgs e)
        {
            activeFilter = 12;

            if (pause) ApplyActiveFilter();
            VideoPreview.Image = filteredFrame ?? frame;

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
