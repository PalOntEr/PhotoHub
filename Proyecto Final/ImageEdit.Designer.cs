namespace Proyecto_Final
{
    partial class ImageEdit
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend25 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea26 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend26 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea27 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend27 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series41 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea28 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend28 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series42 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SelectedImage = new System.Windows.Forms.OpenFileDialog();
            this.SaveImage = new System.Windows.Forms.SaveFileDialog();
            this.ImageButton = new System.Windows.Forms.Button();
            this.Grayscale = new System.Windows.Forms.Button();
            this.Sepia = new System.Windows.Forms.Button();
            this.Negative = new System.Windows.Forms.Button();
            this.ImageBar = new System.Windows.Forms.ProgressBar();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.HistogramBar = new System.Windows.Forms.ProgressBar();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.CUDA = new System.Windows.Forms.CheckBox();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.Sketch = new System.Windows.Forms.Button();
            this.TiltShift = new System.Windows.Forms.Button();
            this.Noise = new System.Windows.Forms.Button();
            this.Sharpen = new System.Windows.Forms.Button();
            this.EdgeDetection = new System.Windows.Forms.Button();
            this.Contrast = new System.Windows.Forms.Button();
            this.Emboss = new System.Windows.Forms.Button();
            this.GaussianBlur = new System.Windows.Forms.Button();
            this.Thermal = new System.Windows.Forms.Button();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HistogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RedHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GreenHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BlueHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MainPanel.SuspendLayout();
            this.Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedHistogram)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenHistogram)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectedImage
            // 
            this.SelectedImage.FileName = "SelectedImage";
            this.SelectedImage.FileOk += new System.ComponentModel.CancelEventHandler(this.SelectedImage_FileOk);
            // 
            // ImageButton
            // 
            this.ImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageButton.BackColor = System.Drawing.Color.DimGray;
            this.ImageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ImageButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ImageButton.Location = new System.Drawing.Point(12, 386);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(202, 32);
            this.ImageButton.TabIndex = 1;
            this.ImageButton.Text = "Select Image";
            this.ImageButton.UseVisualStyleBackColor = false;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
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
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.BackColor = System.Drawing.Color.DimGray;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SaveButton.Location = new System.Drawing.Point(12, 462);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(202, 32);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save Image";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RestoreButton.BackColor = System.Drawing.Color.DimGray;
            this.RestoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RestoreButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.RestoreButton.Location = new System.Drawing.Point(12, 424);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(202, 32);
            this.RestoreButton.TabIndex = 11;
            this.RestoreButton.Text = "Restore Image";
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
            this.MainPanel.Controls.Add(this.CUDA);
            this.MainPanel.Controls.Add(this.Filters);
            this.MainPanel.Controls.Add(this.HistogramBar);
            this.MainPanel.Controls.Add(this.RestoreButton);
            this.MainPanel.Controls.Add(this.SaveButton);
            this.MainPanel.Controls.Add(this.ImageBar);
            this.MainPanel.Controls.Add(this.ImageButton);
            this.MainPanel.Controls.Add(this.ImagePreview);
            this.MainPanel.Controls.Add(this.MenuStrip);
            this.MainPanel.Controls.Add(this.tabControl1);
            this.MainPanel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1109, 647);
            this.MainPanel.TabIndex = 0;
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
            this.CUDA.Location = new System.Drawing.Point(23, 500);
            this.CUDA.Name = "CUDA";
            this.CUDA.Size = new System.Drawing.Size(180, 44);
            this.CUDA.TabIndex = 22;
            this.CUDA.Text = "Use GPU CUDA cores";
            this.CUDA.UseVisualStyleBackColor = true;
            // 
            // Filters
            // 
            this.Filters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filters.Controls.Add(this.Sketch);
            this.Filters.Controls.Add(this.TiltShift);
            this.Filters.Controls.Add(this.Noise);
            this.Filters.Controls.Add(this.Sharpen);
            this.Filters.Controls.Add(this.EdgeDetection);
            this.Filters.Controls.Add(this.Contrast);
            this.Filters.Controls.Add(this.Emboss);
            this.Filters.Controls.Add(this.GaussianBlur);
            this.Filters.Controls.Add(this.Thermal);
            this.Filters.Controls.Add(this.Grayscale);
            this.Filters.Controls.Add(this.Sepia);
            this.Filters.Controls.Add(this.Negative);
            this.Filters.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filters.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Filters.Location = new System.Drawing.Point(719, 386);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(374, 249);
            this.Filters.TabIndex = 21;
            this.Filters.TabStop = false;
            this.Filters.Text = "Filters";
            // 
            // Sketch
            // 
            this.Sketch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sketch.BackColor = System.Drawing.Color.DimGray;
            this.Sketch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Sketch.Location = new System.Drawing.Point(200, 210);
            this.Sketch.Name = "Sketch";
            this.Sketch.Size = new System.Drawing.Size(140, 32);
            this.Sketch.TabIndex = 23;
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
            this.TiltShift.TabIndex = 22;
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
            this.Noise.TabIndex = 21;
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
            this.Sharpen.TabIndex = 20;
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
            this.EdgeDetection.TabIndex = 19;
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
            this.Contrast.TabIndex = 18;
            this.Contrast.Text = "Contrast";
            this.Contrast.UseVisualStyleBackColor = false;
            this.Contrast.Click += new System.EventHandler(this.Contrast_Click);
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
            // Thermal
            // 
            this.Thermal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Thermal.BackColor = System.Drawing.Color.DimGray;
            this.Thermal.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thermal.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Thermal.Location = new System.Drawing.Point(37, 99);
            this.Thermal.Name = "Thermal";
            this.Thermal.Size = new System.Drawing.Size(140, 32);
            this.Thermal.TabIndex = 17;
            this.Thermal.Text = "Thermal Camera";
            this.Thermal.UseVisualStyleBackColor = false;
            this.Thermal.Click += new System.EventHandler(this.Thermal_Click);
            // 
            // ImagePreview
            // 
            this.ImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ImagePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePreview.Image = global::Proyecto_Final.Properties.Resources.PlagueDoctor;
            this.ImagePreview.Location = new System.Drawing.Point(12, 41);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(688, 339);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePreview.TabIndex = 0;
            this.ImagePreview.TabStop = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1109, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(719, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 339);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HistogramChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All Colors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HistogramChart
            // 
            this.HistogramChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HistogramChart.BackColor = System.Drawing.Color.DimGray;
            chartArea25.AxisX.IsLabelAutoFit = false;
            chartArea25.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea25.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea25.AxisX.LineColor = System.Drawing.Color.White;
            chartArea25.AxisX.Maximum = 255D;
            chartArea25.AxisX.Minimum = 0D;
            chartArea25.AxisY.IsLabelAutoFit = false;
            chartArea25.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea25.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea25.AxisY.LineColor = System.Drawing.Color.White;
            chartArea25.Name = "ChartArea1";
            this.HistogramChart.ChartAreas.Add(chartArea25);
            legend25.BackColor = System.Drawing.Color.DimGray;
            legend25.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend25.ForeColor = System.Drawing.Color.White;
            legend25.IsTextAutoFit = false;
            legend25.Name = "Legend1";
            this.HistogramChart.Legends.Add(legend25);
            this.HistogramChart.Location = new System.Drawing.Point(0, 0);
            this.HistogramChart.Name = "HistogramChart";
            this.HistogramChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series37.ChartArea = "ChartArea1";
            series37.Color = System.Drawing.Color.Red;
            series37.Legend = "Legend1";
            series37.Name = "Red";
            series38.ChartArea = "ChartArea1";
            series38.Color = System.Drawing.Color.SeaGreen;
            series38.Legend = "Legend1";
            series38.Name = "Green";
            series39.ChartArea = "ChartArea1";
            series39.Color = System.Drawing.Color.RoyalBlue;
            series39.Legend = "Legend1";
            series39.Name = "Blue";
            this.HistogramChart.Series.Add(series37);
            this.HistogramChart.Series.Add(series38);
            this.HistogramChart.Series.Add(series39);
            this.HistogramChart.Size = new System.Drawing.Size(370, 307);
            this.HistogramChart.TabIndex = 8;
            this.HistogramChart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RedHistogram);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Red";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RedHistogram
            // 
            this.RedHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RedHistogram.BackColor = System.Drawing.Color.DimGray;
            chartArea26.AxisX.IsLabelAutoFit = false;
            chartArea26.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea26.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea26.AxisX.Maximum = 255D;
            chartArea26.AxisX.Minimum = 0D;
            chartArea26.AxisY.IsLabelAutoFit = false;
            chartArea26.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea26.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea26.Name = "ChartArea1";
            this.RedHistogram.ChartAreas.Add(chartArea26);
            legend26.BackColor = System.Drawing.Color.DimGray;
            legend26.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend26.ForeColor = System.Drawing.Color.White;
            legend26.IsTextAutoFit = false;
            legend26.Name = "Legend1";
            this.RedHistogram.Legends.Add(legend26);
            this.RedHistogram.Location = new System.Drawing.Point(0, 0);
            this.RedHistogram.Name = "RedHistogram";
            this.RedHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series40.ChartArea = "ChartArea1";
            series40.Color = System.Drawing.Color.Red;
            series40.LabelForeColor = System.Drawing.Color.Empty;
            series40.Legend = "Legend1";
            series40.Name = "Red";
            this.RedHistogram.Series.Add(series40);
            this.RedHistogram.Size = new System.Drawing.Size(370, 307);
            this.RedHistogram.TabIndex = 14;
            this.RedHistogram.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.GreenHistogram);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(370, 303);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Green";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GreenHistogram
            // 
            this.GreenHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GreenHistogram.BackColor = System.Drawing.Color.DimGray;
            chartArea27.AxisX.IsLabelAutoFit = false;
            chartArea27.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea27.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea27.AxisX.Maximum = 255D;
            chartArea27.AxisX.Minimum = 0D;
            chartArea27.AxisY.IsLabelAutoFit = false;
            chartArea27.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea27.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea27.Name = "ChartArea1";
            this.GreenHistogram.ChartAreas.Add(chartArea27);
            legend27.BackColor = System.Drawing.Color.DimGray;
            legend27.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend27.ForeColor = System.Drawing.Color.White;
            legend27.IsTextAutoFit = false;
            legend27.Name = "Legend1";
            this.GreenHistogram.Legends.Add(legend27);
            this.GreenHistogram.Location = new System.Drawing.Point(0, 0);
            this.GreenHistogram.Name = "GreenHistogram";
            this.GreenHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series41.ChartArea = "ChartArea1";
            series41.Color = System.Drawing.Color.SeaGreen;
            series41.Legend = "Legend1";
            series41.Name = "Green";
            this.GreenHistogram.Series.Add(series41);
            this.GreenHistogram.Size = new System.Drawing.Size(370, 307);
            this.GreenHistogram.TabIndex = 14;
            this.GreenHistogram.Text = "chart1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BlueHistogram);
            this.tabPage4.Location = new System.Drawing.Point(4, 32);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(370, 303);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Blue";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BlueHistogram
            // 
            this.BlueHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BlueHistogram.BackColor = System.Drawing.Color.DimGray;
            chartArea28.AxisX.IsLabelAutoFit = false;
            chartArea28.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea28.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea28.AxisX.Maximum = 255D;
            chartArea28.AxisX.Minimum = 0D;
            chartArea28.AxisY.IsLabelAutoFit = false;
            chartArea28.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea28.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea28.Name = "ChartArea1";
            this.BlueHistogram.ChartAreas.Add(chartArea28);
            legend28.BackColor = System.Drawing.Color.DimGray;
            legend28.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend28.ForeColor = System.Drawing.Color.White;
            legend28.IsTextAutoFit = false;
            legend28.Name = "Legend1";
            this.BlueHistogram.Legends.Add(legend28);
            this.BlueHistogram.Location = new System.Drawing.Point(0, 0);
            this.BlueHistogram.Name = "BlueHistogram";
            this.BlueHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series42.ChartArea = "ChartArea1";
            series42.Color = System.Drawing.Color.RoyalBlue;
            series42.Legend = "Legend1";
            series42.Name = "Blue";
            this.BlueHistogram.Series.Add(series42);
            this.BlueHistogram.Size = new System.Drawing.Size(370, 307);
            this.BlueHistogram.TabIndex = 14;
            this.BlueHistogram.Text = "chart1";
            // 
            // ImageEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 647);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImageEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Philter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.Filters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HistogramChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RedHistogram)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GreenHistogram)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlueHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog SelectedImage;
        private System.Windows.Forms.SaveFileDialog SaveImage;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.Button Grayscale;
        private System.Windows.Forms.Button Sepia;
        private System.Windows.Forms.Button Negative;
        private System.Windows.Forms.ProgressBar ImageBar;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.ProgressBar HistogramBar;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button GaussianBlur;
        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Button Thermal;
        private System.Windows.Forms.Button Emboss;
        private System.Windows.Forms.Button Sketch;
        private System.Windows.Forms.Button TiltShift;
        private System.Windows.Forms.Button Noise;
        private System.Windows.Forms.Button Sharpen;
        private System.Windows.Forms.Button EdgeDetection;
        private System.Windows.Forms.Button Contrast;
        private System.Windows.Forms.CheckBox CUDA;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart HistogramChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart RedHistogram;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart GreenHistogram;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart BlueHistogram;
    }
}

