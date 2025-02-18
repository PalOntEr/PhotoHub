using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class MainWindow : Form
    {
        ImageEdit imageWindow;
        VideoEdit videoWindow;
        CameraEdit cameraWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Container_Paint(object sender, PaintEventArgs e)
        {
            showImageWindow();
        }


        private void ImageButton_Click(object sender, EventArgs e)
        {
            showImageWindow();
        }
        private void VideoButton_Click(object sender, EventArgs e)
        {
            showVideoWindow();
        }
        private void CameraButton_Click(object sender, EventArgs e)
        {
            showCameraWindow();
        }

        private void MainWindowPanel_SizeChanged(object sender, EventArgs e)
        {

        }

        private void InitImageWindow()
        {
            imageWindow = new ImageEdit();
            imageWindow.TopLevel = false;
            imageWindow.Dock = DockStyle.Fill;
            imageWindow.FormBorderStyle = FormBorderStyle.None;
            MainWindowPanel.Controls.Add(imageWindow);
            imageWindow.Show();
        }

        private void InitVideoWindow()
        {
            videoWindow = new VideoEdit();
            videoWindow.TopLevel = false;
            videoWindow.Dock = DockStyle.Fill;
            videoWindow.FormBorderStyle = FormBorderStyle.None;
            MainWindowPanel.Controls.Add(videoWindow);
            videoWindow.Show();
        }
        private void InitCameraWindow()
        {
            cameraWindow = new CameraEdit();
            cameraWindow.TopLevel = false;
            cameraWindow.Dock = DockStyle.Fill;
            cameraWindow.FormBorderStyle = FormBorderStyle.None;
            MainWindowPanel.Controls.Add(cameraWindow);
            cameraWindow.Show();
        }

        private void showImageWindow()
        {
            if (imageWindow == null)
            {
                InitImageWindow();
            }
            else
            {
                imageWindow.Show();
            }

            videoWindow?.Hide();
            cameraWindow?.Hide();
        }
        private void showVideoWindow()
        {
            if (videoWindow == null)
            {
                InitVideoWindow();
            }
            else
            {
                videoWindow.Show();
            }

            imageWindow?.Hide();
            cameraWindow?.Hide();

        }
        private void showCameraWindow()
        {
            if (cameraWindow == null)
            {
                InitCameraWindow();
            }
            else
            {
                cameraWindow.Show();
            }

            imageWindow?.Hide();
            videoWindow?.Hide();

        }

    }
}
