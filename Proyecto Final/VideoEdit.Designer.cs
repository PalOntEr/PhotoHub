namespace Proyecto_Final
{
    partial class VideoEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SelectedImage = new System.Windows.Forms.OpenFileDialog();
            this.SaveImage = new System.Windows.Forms.SaveFileDialog();
            this.VideoPreview = new System.Windows.Forms.PictureBox();
            this.VideoButton = new System.Windows.Forms.Button();
            this.Grayscale = new System.Windows.Forms.Button();
            this.Sepia = new System.Windows.Forms.Button();
            this.Negative = new System.Windows.Forms.Button();
            this.HistogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ImageBar = new System.Windows.Forms.ProgressBar();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.HistogramBar = new System.Windows.Forms.ProgressBar();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.PauseButton = new FontAwesome.Sharp.IconButton();
            this.CUDA = new System.Windows.Forms.CheckBox();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.Thermal = new System.Windows.Forms.Button();
            this.Sketch = new System.Windows.Forms.Button();
            this.TiltShift = new System.Windows.Forms.Button();
            this.Noise = new System.Windows.Forms.Button();
            this.Sharpen = new System.Windows.Forms.Button();
            this.EdgeDetection = new System.Windows.Forms.Button();
            this.Contrast = new System.Windows.Forms.Button();
            this.GaussianBlur = new System.Windows.Forms.Button();
            this.Emboss = new System.Windows.Forms.Button();
            this.ForwardButton = new FontAwesome.Sharp.IconButton();
            this.BackwardsButton = new FontAwesome.Sharp.IconButton();
            this.PlayButton = new FontAwesome.Sharp.IconButton();
            this.HistogramTab = new System.Windows.Forms.TabControl();
            this.All = new System.Windows.Forms.TabPage();
            this.Red = new System.Windows.Forms.TabPage();
            this.RedHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Green = new System.Windows.Forms.TabPage();
            this.GreenHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Blue = new System.Windows.Forms.TabPage();
            this.BlueHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckActiveFrame = new System.Windows.Forms.Timer(this.components);
            this.StopButton = new FontAwesome.Sharp.IconButton();
            this.RestartVideo = new FontAwesome.Sharp.IconButton();
            this.VideoProgressBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramChart)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.Filters.SuspendLayout();
            this.HistogramTab.SuspendLayout();
            this.All.SuspendLayout();
            this.Red.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedHistogram)).BeginInit();
            this.Green.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenHistogram)).BeginInit();
            this.Blue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueHistogram)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoProgressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectedImage
            // 
            this.SelectedImage.FileName = "SelectedImage";
            // 
            // VideoPreview
            // 
            this.VideoPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VideoPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VideoPreview.Image = global::Proyecto_Final.Properties.Resources.PlagueDoctor;
            this.VideoPreview.Location = new System.Drawing.Point(12, 41);
            this.VideoPreview.Name = "VideoPreview";
            this.VideoPreview.Size = new System.Drawing.Size(688, 339);
            this.VideoPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VideoPreview.TabIndex = 0;
            this.VideoPreview.TabStop = false;
            // 
            // VideoButton
            // 
            this.VideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VideoButton.BackColor = System.Drawing.Color.DimGray;
            this.VideoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VideoButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.VideoButton.Location = new System.Drawing.Point(12, 411);
            this.VideoButton.Name = "VideoButton";
            this.VideoButton.Size = new System.Drawing.Size(202, 32);
            this.VideoButton.TabIndex = 1;
            this.VideoButton.Text = "Select Video";
            this.VideoButton.UseVisualStyleBackColor = false;
            this.VideoButton.Click += new System.EventHandler(this.VideoButton_Click);
            // 
            // Grayscale
            // 
            this.Grayscale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Grayscale.BackColor = System.Drawing.Color.DimGray;
            this.Grayscale.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grayscale.Location = new System.Drawing.Point(200, 25);
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(140, 32);
            this.Grayscale.TabIndex = 2;
            this.Grayscale.Text = "Grayscale";
            this.Grayscale.UseVisualStyleBackColor = false;
            this.Grayscale.Click += new System.EventHandler(this.Grayscale_Click);
            // 
            // Sepia
            // 
            this.Sepia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sepia.BackColor = System.Drawing.Color.DimGray;
            this.Sepia.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Sepia.Location = new System.Drawing.Point(200, 62);
            this.Sepia.Name = "Sepia";
            this.Sepia.Size = new System.Drawing.Size(140, 32);
            this.Sepia.TabIndex = 6;
            this.Sepia.Text = "Sepia";
            this.Sepia.UseVisualStyleBackColor = false;
            this.Sepia.Click += new System.EventHandler(this.Sepia_Click);
            // 
            // Negative
            // 
            this.Negative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Negative.BackColor = System.Drawing.Color.DimGray;
            this.Negative.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Negative.Location = new System.Drawing.Point(200, 99);
            this.Negative.Name = "Negative";
            this.Negative.Size = new System.Drawing.Size(140, 32);
            this.Negative.TabIndex = 7;
            this.Negative.Text = "Negative";
            this.Negative.UseVisualStyleBackColor = false;
            this.Negative.Click += new System.EventHandler(this.Negative_Click);
            // 
            // HistogramChart
            // 
            this.HistogramChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HistogramChart.BackColor = System.Drawing.Color.DimGray;
            chartArea13.AxisX.IsLabelAutoFit = false;
            chartArea13.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea13.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea13.AxisX.LineColor = System.Drawing.Color.White;
            chartArea13.AxisX.Maximum = 255D;
            chartArea13.AxisX.Minimum = 0D;
            chartArea13.AxisY.IsLabelAutoFit = false;
            chartArea13.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea13.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea13.AxisY.LineColor = System.Drawing.Color.White;
            chartArea13.Name = "ChartArea1";
            this.HistogramChart.ChartAreas.Add(chartArea13);
            legend13.BackColor = System.Drawing.Color.DimGray;
            legend13.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend13.ForeColor = System.Drawing.Color.White;
            legend13.IsTextAutoFit = false;
            legend13.Name = "Legend1";
            this.HistogramChart.Legends.Add(legend13);
            this.HistogramChart.Location = new System.Drawing.Point(0, 0);
            this.HistogramChart.Name = "HistogramChart";
            this.HistogramChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series19.ChartArea = "ChartArea1";
            series19.Color = System.Drawing.Color.Red;
            series19.Legend = "Legend1";
            series19.Name = "Red";
            series20.ChartArea = "ChartArea1";
            series20.Color = System.Drawing.Color.SeaGreen;
            series20.Legend = "Legend1";
            series20.Name = "Green";
            series21.ChartArea = "ChartArea1";
            series21.Color = System.Drawing.Color.RoyalBlue;
            series21.Legend = "Legend1";
            series21.Name = "Blue";
            this.HistogramChart.Series.Add(series19);
            this.HistogramChart.Series.Add(series20);
            this.HistogramChart.Series.Add(series21);
            this.HistogramChart.Size = new System.Drawing.Size(370, 307);
            this.HistogramChart.TabIndex = 8;
            this.HistogramChart.Text = "chart1";
            // 
            // ImageBar
            // 
            this.ImageBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.ImageBar.Location = new System.Drawing.Point(12, 357);
            this.ImageBar.Name = "ImageBar";
            this.ImageBar.Size = new System.Drawing.Size(688, 23);
            this.ImageBar.TabIndex = 9;
            this.ImageBar.Visible = false;
            // 
            // RestoreButton
            // 
            this.RestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RestoreButton.BackColor = System.Drawing.Color.DimGray;
            this.RestoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RestoreButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.RestoreButton.Location = new System.Drawing.Point(12, 449);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(202, 32);
            this.RestoreButton.TabIndex = 11;
            this.RestoreButton.Text = "Restore Video";
            this.RestoreButton.UseVisualStyleBackColor = false;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // HistogramBar
            // 
            this.HistogramBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HistogramBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.HistogramBar.Location = new System.Drawing.Point(719, 357);
            this.HistogramBar.Name = "HistogramBar";
            this.HistogramBar.Size = new System.Drawing.Size(378, 23);
            this.HistogramBar.TabIndex = 12;
            this.HistogramBar.Visible = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.Color.Gray;
            this.MainPanel.Controls.Add(this.RestartVideo);
            this.MainPanel.Controls.Add(this.StopButton);
            this.MainPanel.Controls.Add(this.PauseButton);
            this.MainPanel.Controls.Add(this.CUDA);
            this.MainPanel.Controls.Add(this.Filters);
            this.MainPanel.Controls.Add(this.ForwardButton);
            this.MainPanel.Controls.Add(this.BackwardsButton);
            this.MainPanel.Controls.Add(this.PlayButton);
            this.MainPanel.Controls.Add(this.HistogramBar);
            this.MainPanel.Controls.Add(this.RestoreButton);
            this.MainPanel.Controls.Add(this.ImageBar);
            this.MainPanel.Controls.Add(this.VideoButton);
            this.MainPanel.Controls.Add(this.VideoPreview);
            this.MainPanel.Controls.Add(this.HistogramTab);
            this.MainPanel.Controls.Add(this.MenuStrip);
            this.MainPanel.Controls.Add(this.VideoProgressBar);
            this.MainPanel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1109, 647);
            this.MainPanel.TabIndex = 0;
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PauseButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.PauseButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PauseButton.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.PauseButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PauseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PauseButton.IconSize = 25;
            this.PauseButton.Location = new System.Drawing.Point(303, 411);
            this.PauseButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(114, 32);
            this.PauseButton.TabIndex = 24;
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // CUDA
            // 
            this.CUDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CUDA.AutoSize = true;
            this.CUDA.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CUDA.Checked = true;
            this.CUDA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CUDA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CUDA.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CUDA.Location = new System.Drawing.Point(23, 487);
            this.CUDA.Name = "CUDA";
            this.CUDA.Size = new System.Drawing.Size(180, 44);
            this.CUDA.TabIndex = 23;
            this.CUDA.Text = "Use GPU CUDA cores";
            this.CUDA.UseVisualStyleBackColor = true;
            // 
            // Filters
            // 
            this.Filters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filters.Controls.Add(this.Thermal);
            this.Filters.Controls.Add(this.Sketch);
            this.Filters.Controls.Add(this.TiltShift);
            this.Filters.Controls.Add(this.Noise);
            this.Filters.Controls.Add(this.Sharpen);
            this.Filters.Controls.Add(this.EdgeDetection);
            this.Filters.Controls.Add(this.Contrast);
            this.Filters.Controls.Add(this.GaussianBlur);
            this.Filters.Controls.Add(this.Grayscale);
            this.Filters.Controls.Add(this.Sepia);
            this.Filters.Controls.Add(this.Negative);
            this.Filters.Controls.Add(this.Emboss);
            this.Filters.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filters.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Filters.Location = new System.Drawing.Point(719, 386);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(374, 249);
            this.Filters.TabIndex = 20;
            this.Filters.TabStop = false;
            this.Filters.Text = "Filters";
            // 
            // Thermal
            // 
            this.Thermal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Thermal.BackColor = System.Drawing.Color.DimGray;
            this.Thermal.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thermal.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Thermal.Location = new System.Drawing.Point(37, 98);
            this.Thermal.Name = "Thermal";
            this.Thermal.Size = new System.Drawing.Size(140, 32);
            this.Thermal.TabIndex = 30;
            this.Thermal.Text = "Thermal Camera";
            this.Thermal.UseVisualStyleBackColor = false;
            this.Thermal.Click += new System.EventHandler(this.Thermal_Click);
            // 
            // Sketch
            // 
            this.Sketch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sketch.BackColor = System.Drawing.Color.DimGray;
            this.Sketch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Sketch.Location = new System.Drawing.Point(200, 210);
            this.Sketch.Name = "Sketch";
            this.Sketch.Size = new System.Drawing.Size(140, 32);
            this.Sketch.TabIndex = 29;
            this.Sketch.Text = "Sketch";
            this.Sketch.UseVisualStyleBackColor = false;
            this.Sketch.Click += new System.EventHandler(this.Sketch_Click);
            // 
            // TiltShift
            // 
            this.TiltShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TiltShift.BackColor = System.Drawing.Color.DimGray;
            this.TiltShift.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TiltShift.Location = new System.Drawing.Point(37, 210);
            this.TiltShift.Name = "TiltShift";
            this.TiltShift.Size = new System.Drawing.Size(140, 32);
            this.TiltShift.TabIndex = 28;
            this.TiltShift.Text = "Tilt Shift";
            this.TiltShift.UseVisualStyleBackColor = false;
            this.TiltShift.Click += new System.EventHandler(this.TiltShift_Click);
            // 
            // Noise
            // 
            this.Noise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Noise.BackColor = System.Drawing.Color.DimGray;
            this.Noise.ForeColor = System.Drawing.Color.Honeydew;
            this.Noise.Location = new System.Drawing.Point(200, 173);
            this.Noise.Name = "Noise";
            this.Noise.Size = new System.Drawing.Size(140, 32);
            this.Noise.TabIndex = 27;
            this.Noise.Text = "Noise";
            this.Noise.UseVisualStyleBackColor = false;
            this.Noise.Click += new System.EventHandler(this.Noise_Click);
            // 
            // Sharpen
            // 
            this.Sharpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sharpen.BackColor = System.Drawing.Color.DimGray;
            this.Sharpen.ForeColor = System.Drawing.Color.Honeydew;
            this.Sharpen.Location = new System.Drawing.Point(37, 173);
            this.Sharpen.Name = "Sharpen";
            this.Sharpen.Size = new System.Drawing.Size(140, 32);
            this.Sharpen.TabIndex = 26;
            this.Sharpen.Text = "Sharpen";
            this.Sharpen.UseVisualStyleBackColor = false;
            this.Sharpen.Click += new System.EventHandler(this.Sharpen_Click);
            // 
            // EdgeDetection
            // 
            this.EdgeDetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EdgeDetection.BackColor = System.Drawing.Color.DimGray;
            this.EdgeDetection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EdgeDetection.ForeColor = System.Drawing.Color.Honeydew;
            this.EdgeDetection.Location = new System.Drawing.Point(200, 136);
            this.EdgeDetection.Name = "EdgeDetection";
            this.EdgeDetection.Size = new System.Drawing.Size(140, 32);
            this.EdgeDetection.TabIndex = 25;
            this.EdgeDetection.Text = "Edge Detection";
            this.EdgeDetection.UseVisualStyleBackColor = false;
            this.EdgeDetection.Click += new System.EventHandler(this.EdgeDetection_Click);
            // 
            // Contrast
            // 
            this.Contrast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Contrast.BackColor = System.Drawing.Color.DimGray;
            this.Contrast.ForeColor = System.Drawing.Color.Honeydew;
            this.Contrast.Location = new System.Drawing.Point(37, 136);
            this.Contrast.Name = "Contrast";
            this.Contrast.Size = new System.Drawing.Size(140, 32);
            this.Contrast.TabIndex = 24;
            this.Contrast.Text = "Contrast";
            this.Contrast.UseVisualStyleBackColor = false;
            this.Contrast.Click += new System.EventHandler(this.Contrast_Click);
            // 
            // GaussianBlur
            // 
            this.GaussianBlur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GaussianBlur.BackColor = System.Drawing.Color.DimGray;
            this.GaussianBlur.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GaussianBlur.Location = new System.Drawing.Point(37, 25);
            this.GaussianBlur.Name = "GaussianBlur";
            this.GaussianBlur.Size = new System.Drawing.Size(140, 32);
            this.GaussianBlur.TabIndex = 15;
            this.GaussianBlur.Text = "Gaussian Blur";
            this.GaussianBlur.UseVisualStyleBackColor = false;
            this.GaussianBlur.Click += new System.EventHandler(this.GaussianBlur_Click);
            // 
            // Emboss
            // 
            this.Emboss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Emboss.BackColor = System.Drawing.Color.DimGray;
            this.Emboss.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Emboss.Location = new System.Drawing.Point(37, 62);
            this.Emboss.Name = "Emboss";
            this.Emboss.Size = new System.Drawing.Size(140, 32);
            this.Emboss.TabIndex = 16;
            this.Emboss.Text = "Emboss";
            this.Emboss.UseVisualStyleBackColor = false;
            this.Emboss.Click += new System.EventHandler(this.Emboss_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ForwardButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.ForwardButton.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.ForwardButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ForwardButton.IconChar = FontAwesome.Sharp.IconChar.FastBackward;
            this.ForwardButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ForwardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ForwardButton.IconSize = 25;
            this.ForwardButton.Location = new System.Drawing.Point(423, 411);
            this.ForwardButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(77, 32);
            this.ForwardButton.TabIndex = 19;
            this.ForwardButton.UseVisualStyleBackColor = false;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackwardsButton
            // 
            this.BackwardsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BackwardsButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.BackwardsButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BackwardsButton.IconChar = FontAwesome.Sharp.IconChar.FastBackward;
            this.BackwardsButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackwardsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BackwardsButton.IconSize = 25;
            this.BackwardsButton.Location = new System.Drawing.Point(220, 411);
            this.BackwardsButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.BackwardsButton.Name = "BackwardsButton";
            this.BackwardsButton.Size = new System.Drawing.Size(77, 32);
            this.BackwardsButton.TabIndex = 18;
            this.BackwardsButton.UseVisualStyleBackColor = false;
            this.BackwardsButton.Click += new System.EventHandler(this.BackwardsButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlayButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.PlayButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PlayButton.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.PlayButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PlayButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PlayButton.IconSize = 25;
            this.PlayButton.Location = new System.Drawing.Point(303, 411);
            this.PlayButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(114, 32);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // HistogramTab
            // 
            this.HistogramTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HistogramTab.Controls.Add(this.All);
            this.HistogramTab.Controls.Add(this.Red);
            this.HistogramTab.Controls.Add(this.Green);
            this.HistogramTab.Controls.Add(this.Blue);
            this.HistogramTab.Location = new System.Drawing.Point(719, 41);
            this.HistogramTab.Name = "HistogramTab";
            this.HistogramTab.SelectedIndex = 0;
            this.HistogramTab.Size = new System.Drawing.Size(378, 339);
            this.HistogramTab.TabIndex = 13;
            // 
            // All
            // 
            this.All.Controls.Add(this.HistogramChart);
            this.All.Location = new System.Drawing.Point(4, 32);
            this.All.Name = "All";
            this.All.Padding = new System.Windows.Forms.Padding(3);
            this.All.Size = new System.Drawing.Size(370, 303);
            this.All.TabIndex = 0;
            this.All.Text = "All Colors";
            this.All.UseVisualStyleBackColor = true;
            // 
            // Red
            // 
            this.Red.Controls.Add(this.RedHistogram);
            this.Red.Location = new System.Drawing.Point(4, 32);
            this.Red.Name = "Red";
            this.Red.Padding = new System.Windows.Forms.Padding(3);
            this.Red.Size = new System.Drawing.Size(370, 303);
            this.Red.TabIndex = 1;
            this.Red.Text = "Red";
            this.Red.UseVisualStyleBackColor = true;
            // 
            // RedHistogram
            // 
            this.RedHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RedHistogram.BackColor = System.Drawing.Color.DimGray;
            chartArea14.AxisX.IsLabelAutoFit = false;
            chartArea14.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea14.AxisX.Maximum = 255D;
            chartArea14.AxisX.Minimum = 0D;
            chartArea14.AxisY.IsLabelAutoFit = false;
            chartArea14.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea14.Name = "ChartArea1";
            this.RedHistogram.ChartAreas.Add(chartArea14);
            legend14.BackColor = System.Drawing.Color.DimGray;
            legend14.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend14.ForeColor = System.Drawing.Color.White;
            legend14.IsTextAutoFit = false;
            legend14.Name = "Legend1";
            this.RedHistogram.Legends.Add(legend14);
            this.RedHistogram.Location = new System.Drawing.Point(0, 0);
            this.RedHistogram.Name = "RedHistogram";
            this.RedHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series22.ChartArea = "ChartArea1";
            series22.Color = System.Drawing.Color.Red;
            series22.LabelForeColor = System.Drawing.Color.Empty;
            series22.Legend = "Legend1";
            series22.Name = "Red";
            this.RedHistogram.Series.Add(series22);
            this.RedHistogram.Size = new System.Drawing.Size(370, 307);
            this.RedHistogram.TabIndex = 14;
            this.RedHistogram.Text = "chart1";
            // 
            // Green
            // 
            this.Green.Controls.Add(this.GreenHistogram);
            this.Green.Location = new System.Drawing.Point(4, 32);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(370, 303);
            this.Green.TabIndex = 2;
            this.Green.Text = "Green";
            this.Green.UseVisualStyleBackColor = true;
            // 
            // GreenHistogram
            // 
            this.GreenHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GreenHistogram.BackColor = System.Drawing.Color.DimGray;
            chartArea15.AxisX.IsLabelAutoFit = false;
            chartArea15.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea15.AxisX.Maximum = 255D;
            chartArea15.AxisX.Minimum = 0D;
            chartArea15.AxisY.IsLabelAutoFit = false;
            chartArea15.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea15.Name = "ChartArea1";
            this.GreenHistogram.ChartAreas.Add(chartArea15);
            legend15.BackColor = System.Drawing.Color.DimGray;
            legend15.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend15.ForeColor = System.Drawing.Color.White;
            legend15.IsTextAutoFit = false;
            legend15.Name = "Legend1";
            this.GreenHistogram.Legends.Add(legend15);
            this.GreenHistogram.Location = new System.Drawing.Point(0, 0);
            this.GreenHistogram.Name = "GreenHistogram";
            this.GreenHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series23.ChartArea = "ChartArea1";
            series23.Color = System.Drawing.Color.SeaGreen;
            series23.Legend = "Legend1";
            series23.Name = "Green";
            this.GreenHistogram.Series.Add(series23);
            this.GreenHistogram.Size = new System.Drawing.Size(370, 307);
            this.GreenHistogram.TabIndex = 14;
            this.GreenHistogram.Text = "chart1";
            // 
            // Blue
            // 
            this.Blue.Controls.Add(this.BlueHistogram);
            this.Blue.Location = new System.Drawing.Point(4, 32);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(370, 303);
            this.Blue.TabIndex = 3;
            this.Blue.Text = "Blue";
            this.Blue.UseVisualStyleBackColor = true;
            // 
            // BlueHistogram
            // 
            this.BlueHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BlueHistogram.BackColor = System.Drawing.Color.DimGray;
            chartArea16.AxisX.IsLabelAutoFit = false;
            chartArea16.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea16.AxisX.Maximum = 255D;
            chartArea16.AxisX.Minimum = 0D;
            chartArea16.AxisY.IsLabelAutoFit = false;
            chartArea16.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea16.Name = "ChartArea1";
            this.BlueHistogram.ChartAreas.Add(chartArea16);
            legend16.BackColor = System.Drawing.Color.DimGray;
            legend16.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend16.ForeColor = System.Drawing.Color.White;
            legend16.IsTextAutoFit = false;
            legend16.Name = "Legend1";
            this.BlueHistogram.Legends.Add(legend16);
            this.BlueHistogram.Location = new System.Drawing.Point(0, 0);
            this.BlueHistogram.Name = "BlueHistogram";
            this.BlueHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series24.ChartArea = "ChartArea1";
            series24.Color = System.Drawing.Color.RoyalBlue;
            series24.Legend = "Legend1";
            series24.Name = "Blue";
            this.BlueHistogram.Series.Add(series24);
            this.BlueHistogram.Size = new System.Drawing.Size(370, 307);
            this.BlueHistogram.TabIndex = 14;
            this.BlueHistogram.Text = "chart1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1109, 30);
            this.MenuStrip.TabIndex = 14;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // CheckActiveFrame
            // 
            this.CheckActiveFrame.Interval = 41;
            this.CheckActiveFrame.Tick += new System.EventHandler(this.CheckActiveFrame_Tick);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StopButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.StopButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.StopButton.IconChar = FontAwesome.Sharp.IconChar.Stop;
            this.StopButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.StopButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.StopButton.IconSize = 25;
            this.StopButton.Location = new System.Drawing.Point(303, 449);
            this.StopButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(114, 32);
            this.StopButton.TabIndex = 25;
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RestartVideo
            // 
            this.RestartVideo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RestartVideo.BackColor = System.Drawing.SystemColors.GrayText;
            this.RestartVideo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.RestartVideo.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.RestartVideo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RestartVideo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RestartVideo.IconSize = 25;
            this.RestartVideo.Location = new System.Drawing.Point(423, 449);
            this.RestartVideo.MaximumSize = new System.Drawing.Size(220, 32);
            this.RestartVideo.Name = "RestartVideo";
            this.RestartVideo.Size = new System.Drawing.Size(77, 32);
            this.RestartVideo.TabIndex = 26;
            this.RestartVideo.UseVisualStyleBackColor = false;
            this.RestartVideo.Click += new System.EventHandler(this.RestartVideo_Click);
            // 
            // VideoProgressBar
            // 
            this.VideoProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoProgressBar.Location = new System.Drawing.Point(12, 376);
            this.VideoProgressBar.Maximum = 24;
            this.VideoProgressBar.Minimum = 1;
            this.VideoProgressBar.Name = "VideoProgressBar";
            this.VideoProgressBar.Size = new System.Drawing.Size(688, 56);
            this.VideoProgressBar.SmallChange = 24;
            this.VideoProgressBar.TabIndex = 27;
            this.VideoProgressBar.Value = 24;
            this.VideoProgressBar.Scroll += new System.EventHandler(this.VideoProgressBar_Scroll);
            // 
            // VideoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 647);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VideoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Philter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.VideoPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramChart)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.Filters.ResumeLayout(false);
            this.HistogramTab.ResumeLayout(false);
            this.All.ResumeLayout(false);
            this.Red.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RedHistogram)).EndInit();
            this.Green.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GreenHistogram)).EndInit();
            this.Blue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlueHistogram)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoProgressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog SelectedImage;
        private System.Windows.Forms.SaveFileDialog SaveImage;
        private System.Windows.Forms.PictureBox VideoPreview;
        private System.Windows.Forms.Button VideoButton;
        private System.Windows.Forms.Button Grayscale;
        private System.Windows.Forms.Button Sepia;
        private System.Windows.Forms.Button Negative;
        private System.Windows.Forms.DataVisualization.Charting.Chart HistogramChart;
        private System.Windows.Forms.ProgressBar ImageBar;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.ProgressBar HistogramBar;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TabControl HistogramTab;
        private System.Windows.Forms.TabPage All;
        private System.Windows.Forms.TabPage Red;
        private System.Windows.Forms.DataVisualization.Charting.Chart RedHistogram;
        private System.Windows.Forms.TabPage Green;
        private System.Windows.Forms.TabPage Blue;
        private System.Windows.Forms.DataVisualization.Charting.Chart GreenHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart BlueHistogram;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button Emboss;
        private System.Windows.Forms.Button GaussianBlur;
        private FontAwesome.Sharp.IconButton BackwardsButton;
        private FontAwesome.Sharp.IconButton PlayButton;
        private FontAwesome.Sharp.IconButton ForwardButton;
        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Button Sketch;
        private System.Windows.Forms.Button TiltShift;
        private System.Windows.Forms.Button Noise;
        private System.Windows.Forms.Button Sharpen;
        private System.Windows.Forms.Button EdgeDetection;
        private System.Windows.Forms.Button Contrast;
        private System.Windows.Forms.CheckBox CUDA;
        private System.Windows.Forms.Timer CheckActiveFrame;
        private FontAwesome.Sharp.IconButton PauseButton;
        private System.Windows.Forms.Button Thermal;
        private FontAwesome.Sharp.IconButton StopButton;
        private FontAwesome.Sharp.IconButton RestartVideo;
        private System.Windows.Forms.TrackBar VideoProgressBar;
    }
}

