namespace PhotoHub
{
    partial class CameraEdit
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SelectedImage = new System.Windows.Forms.OpenFileDialog();
            this.SaveImage = new System.Windows.Forms.SaveFileDialog();
            this.CameraPreview = new System.Windows.Forms.PictureBox();
            this.CameraButton = new System.Windows.Forms.Button();
            this.Grayscale = new System.Windows.Forms.Button();
            this.Sepia = new System.Windows.Forms.Button();
            this.Negative = new System.Windows.Forms.Button();
            this.ImageBar = new System.Windows.Forms.ProgressBar();
            this.ColorsButton = new System.Windows.Forms.Button();
            this.HistogramBar = new System.Windows.Forms.ProgressBar();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelC = new System.Windows.Forms.Label();
            this.LabelB = new System.Windows.Forms.Label();
            this.LabelA = new System.Windows.Forms.Label();
            this.LabelL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StopDetecting = new System.Windows.Forms.Button();
            this.OffButton = new System.Windows.Forms.Button();
            this.CUDA = new System.Windows.Forms.CheckBox();
            this.SelectedColor = new System.Windows.Forms.PictureBox();
            this.DetectButton = new System.Windows.Forms.Button();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.Thermal = new System.Windows.Forms.Button();
            this.EdgeDetection = new System.Windows.Forms.Button();
            this.Sketch = new System.Windows.Forms.Button();
            this.TiltShift = new System.Windows.Forms.Button();
            this.Noise = new System.Windows.Forms.Button();
            this.Sharpen = new System.Windows.Forms.Button();
            this.Contrast = new System.Windows.Forms.Button();
            this.GaussianBlur = new System.Windows.Forms.Button();
            this.Emboss = new System.Windows.Forms.Button();
            this.ForwardButton = new FontAwesome.Sharp.IconButton();
            this.BackwardsButton = new FontAwesome.Sharp.IconButton();
            this.PhotoButton = new FontAwesome.Sharp.IconButton();
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
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.CheckActiveFrame = new System.Windows.Forms.Timer(this.components);
            this.RestoreButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPreview)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedColor)).BeginInit();
            this.Filters.SuspendLayout();
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
            // 
            // CameraPreview
            // 
            this.CameraPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CameraPreview.Image = global::PhotoHub.Properties.Resources.PlagueDoctor;
            this.CameraPreview.Location = new System.Drawing.Point(12, 41);
            this.CameraPreview.Name = "CameraPreview";
            this.CameraPreview.Size = new System.Drawing.Size(688, 339);
            this.CameraPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CameraPreview.TabIndex = 0;
            this.CameraPreview.TabStop = false;
            this.CameraPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CameraPreview_MouseClick);
            // 
            // CameraButton
            // 
            this.CameraButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CameraButton.BackColor = System.Drawing.Color.DimGray;
            this.CameraButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CameraButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CameraButton.Location = new System.Drawing.Point(12, 386);
            this.CameraButton.Name = "CameraButton";
            this.CameraButton.Size = new System.Drawing.Size(202, 32);
            this.CameraButton.TabIndex = 1;
            this.CameraButton.Text = "Turn On Camera";
            this.CameraButton.UseVisualStyleBackColor = false;
            this.CameraButton.Click += new System.EventHandler(this.CameraButton_Click);
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
            // ColorsButton
            // 
            this.ColorsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorsButton.BackColor = System.Drawing.Color.DimGray;
            this.ColorsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ColorsButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ColorsButton.Location = new System.Drawing.Point(12, 424);
            this.ColorsButton.Name = "ColorsButton";
            this.ColorsButton.Size = new System.Drawing.Size(202, 32);
            this.ColorsButton.TabIndex = 11;
            this.ColorsButton.Text = "Pick A Color";
            this.ColorsButton.UseVisualStyleBackColor = false;
            this.ColorsButton.Click += new System.EventHandler(this.ColorsButton_Click);
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
            this.MainPanel.Controls.Add(this.RestoreButton);
            this.MainPanel.Controls.Add(this.groupBox1);
            this.MainPanel.Controls.Add(this.StopDetecting);
            this.MainPanel.Controls.Add(this.OffButton);
            this.MainPanel.Controls.Add(this.CUDA);
            this.MainPanel.Controls.Add(this.SelectedColor);
            this.MainPanel.Controls.Add(this.DetectButton);
            this.MainPanel.Controls.Add(this.Filters);
            this.MainPanel.Controls.Add(this.ForwardButton);
            this.MainPanel.Controls.Add(this.BackwardsButton);
            this.MainPanel.Controls.Add(this.PhotoButton);
            this.MainPanel.Controls.Add(this.HistogramBar);
            this.MainPanel.Controls.Add(this.ColorsButton);
            this.MainPanel.Controls.Add(this.ImageBar);
            this.MainPanel.Controls.Add(this.CameraButton);
            this.MainPanel.Controls.Add(this.CameraPreview);
            this.MainPanel.Controls.Add(this.MenuStrip);
            this.MainPanel.Controls.Add(this.tabControl1);
            this.MainPanel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1109, 647);
            this.MainPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.LabelC);
            this.groupBox1.Controls.Add(this.LabelB);
            this.groupBox1.Controls.Add(this.LabelA);
            this.groupBox1.Controls.Add(this.LabelL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(14, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 131);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del Color";
            // 
            // LabelC
            // 
            this.LabelC.AutoSize = true;
            this.LabelC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelC.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LabelC.Location = new System.Drawing.Point(6, 98);
            this.LabelC.Name = "LabelC";
            this.LabelC.Size = new System.Drawing.Size(103, 23);
            this.LabelC.TabIndex = 32;
            this.LabelC.Text = "Cuadrante: ";
            // 
            // LabelB
            // 
            this.LabelB.AutoSize = true;
            this.LabelB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelB.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LabelB.Location = new System.Drawing.Point(138, 53);
            this.LabelB.Name = "LabelB";
            this.LabelB.Size = new System.Drawing.Size(26, 23);
            this.LabelB.TabIndex = 31;
            this.LabelB.Text = "B:";
            // 
            // LabelA
            // 
            this.LabelA.AutoSize = true;
            this.LabelA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelA.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LabelA.Location = new System.Drawing.Point(70, 53);
            this.LabelA.Name = "LabelA";
            this.LabelA.Size = new System.Drawing.Size(27, 23);
            this.LabelA.TabIndex = 30;
            this.LabelA.Text = "A:";
            // 
            // LabelL
            // 
            this.LabelL.AutoSize = true;
            this.LabelL.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelL.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LabelL.Location = new System.Drawing.Point(1, 53);
            this.LabelL.Name = "LabelL";
            this.LabelL.Size = new System.Drawing.Size(24, 23);
            this.LabelL.TabIndex = 29;
            this.LabelL.Text = "L:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Valores en CIE L*A*B*";
            // 
            // StopDetecting
            // 
            this.StopDetecting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopDetecting.BackColor = System.Drawing.Color.DimGray;
            this.StopDetecting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StopDetecting.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.StopDetecting.Location = new System.Drawing.Point(12, 596);
            this.StopDetecting.Name = "StopDetecting";
            this.StopDetecting.Size = new System.Drawing.Size(202, 32);
            this.StopDetecting.TabIndex = 27;
            this.StopDetecting.Text = "Stop Detecting Colors";
            this.StopDetecting.UseVisualStyleBackColor = false;
            this.StopDetecting.Visible = false;
            this.StopDetecting.Click += new System.EventHandler(this.StopDetecting_Click);
            // 
            // OffButton
            // 
            this.OffButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OffButton.BackColor = System.Drawing.Color.DimGray;
            this.OffButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OffButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.OffButton.Location = new System.Drawing.Point(12, 386);
            this.OffButton.Name = "OffButton";
            this.OffButton.Size = new System.Drawing.Size(202, 32);
            this.OffButton.TabIndex = 25;
            this.OffButton.Text = "Turn Off Camera";
            this.OffButton.UseVisualStyleBackColor = false;
            this.OffButton.Visible = false;
            this.OffButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // CUDA
            // 
            this.CUDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CUDA.AutoSize = true;
            this.CUDA.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CUDA.Checked = true;
            this.CUDA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CUDA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CUDA.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CUDA.Location = new System.Drawing.Point(520, 386);
            this.CUDA.Name = "CUDA";
            this.CUDA.Size = new System.Drawing.Size(180, 44);
            this.CUDA.TabIndex = 24;
            this.CUDA.Text = "Use GPU CUDA cores";
            this.CUDA.UseVisualStyleBackColor = true;
            // 
            // SelectedColor
            // 
            this.SelectedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SelectedColor.InitialImage = null;
            this.SelectedColor.Location = new System.Drawing.Point(220, 424);
            this.SelectedColor.Name = "SelectedColor";
            this.SelectedColor.Size = new System.Drawing.Size(32, 32);
            this.SelectedColor.TabIndex = 23;
            this.SelectedColor.TabStop = false;
            // 
            // DetectButton
            // 
            this.DetectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DetectButton.BackColor = System.Drawing.Color.DimGray;
            this.DetectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DetectButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DetectButton.Location = new System.Drawing.Point(12, 596);
            this.DetectButton.Name = "DetectButton";
            this.DetectButton.Size = new System.Drawing.Size(202, 32);
            this.DetectButton.TabIndex = 22;
            this.DetectButton.Text = "Detect Colors";
            this.DetectButton.UseVisualStyleBackColor = false;
            this.DetectButton.Click += new System.EventHandler(this.DetectButton_Click);
            // 
            // Filters
            // 
            this.Filters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filters.Controls.Add(this.Thermal);
            this.Filters.Controls.Add(this.EdgeDetection);
            this.Filters.Controls.Add(this.Sketch);
            this.Filters.Controls.Add(this.TiltShift);
            this.Filters.Controls.Add(this.Noise);
            this.Filters.Controls.Add(this.Sharpen);
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
            this.Thermal.TabIndex = 32;
            this.Thermal.Text = "Thermal Camera";
            this.Thermal.UseVisualStyleBackColor = false;
            this.Thermal.Click += new System.EventHandler(this.Thermal_Click);
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
            this.EdgeDetection.TabIndex = 31;
            this.EdgeDetection.Text = "Edge Detection";
            this.EdgeDetection.UseVisualStyleBackColor = false;
            this.EdgeDetection.Click += new System.EventHandler(this.EdgeDetection_Click);
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
            this.ForwardButton.Location = new System.Drawing.Point(423, 386);
            this.ForwardButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(77, 32);
            this.ForwardButton.TabIndex = 19;
            this.ForwardButton.UseVisualStyleBackColor = false;
            this.ForwardButton.Visible = false;
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
            this.BackwardsButton.Location = new System.Drawing.Point(220, 386);
            this.BackwardsButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.BackwardsButton.Name = "BackwardsButton";
            this.BackwardsButton.Size = new System.Drawing.Size(77, 32);
            this.BackwardsButton.TabIndex = 18;
            this.BackwardsButton.UseVisualStyleBackColor = false;
            this.BackwardsButton.Visible = false;
            // 
            // PhotoButton
            // 
            this.PhotoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PhotoButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.PhotoButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PhotoButton.IconChar = FontAwesome.Sharp.IconChar.CameraAlt;
            this.PhotoButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PhotoButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PhotoButton.IconSize = 25;
            this.PhotoButton.Location = new System.Drawing.Point(303, 386);
            this.PhotoButton.MaximumSize = new System.Drawing.Size(220, 32);
            this.PhotoButton.Name = "PhotoButton";
            this.PhotoButton.Size = new System.Drawing.Size(114, 32);
            this.PhotoButton.TabIndex = 1;
            this.PhotoButton.UseVisualStyleBackColor = false;
            this.PhotoButton.Click += new System.EventHandler(this.PhotoButton_Click);
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
            this.tabControl1.TabIndex = 26;
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
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisX.LineColor = System.Drawing.Color.White;
            chartArea5.AxisX.Maximum = 255D;
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisY.IsLabelAutoFit = false;
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisY.LineColor = System.Drawing.Color.White;
            chartArea5.Name = "ChartArea1";
            this.HistogramChart.ChartAreas.Add(chartArea5);
            legend5.BackColor = System.Drawing.Color.DimGray;
            legend5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.ForeColor = System.Drawing.Color.White;
            legend5.IsTextAutoFit = false;
            legend5.Name = "Legend1";
            this.HistogramChart.Legends.Add(legend5);
            this.HistogramChart.Location = new System.Drawing.Point(0, 0);
            this.HistogramChart.Name = "HistogramChart";
            this.HistogramChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "Red";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.SeaGreen;
            series8.Legend = "Legend1";
            series8.Name = "Green";
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.RoyalBlue;
            series9.Legend = "Legend1";
            series9.Name = "Blue";
            this.HistogramChart.Series.Add(series7);
            this.HistogramChart.Series.Add(series8);
            this.HistogramChart.Series.Add(series9);
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
            chartArea6.AxisX.IsLabelAutoFit = false;
            chartArea6.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisX.Maximum = 255D;
            chartArea6.AxisX.Minimum = 0D;
            chartArea6.AxisY.IsLabelAutoFit = false;
            chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.Name = "ChartArea1";
            this.RedHistogram.ChartAreas.Add(chartArea6);
            legend6.BackColor = System.Drawing.Color.DimGray;
            legend6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend6.ForeColor = System.Drawing.Color.White;
            legend6.IsTextAutoFit = false;
            legend6.Name = "Legend1";
            this.RedHistogram.Legends.Add(legend6);
            this.RedHistogram.Location = new System.Drawing.Point(0, 0);
            this.RedHistogram.Name = "RedHistogram";
            this.RedHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.Red;
            series10.LabelForeColor = System.Drawing.Color.Empty;
            series10.Legend = "Legend1";
            series10.Name = "Red";
            this.RedHistogram.Series.Add(series10);
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
            chartArea7.AxisX.IsLabelAutoFit = false;
            chartArea7.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisX.Maximum = 255D;
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.AxisY.IsLabelAutoFit = false;
            chartArea7.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.Name = "ChartArea1";
            this.GreenHistogram.ChartAreas.Add(chartArea7);
            legend7.BackColor = System.Drawing.Color.DimGray;
            legend7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend7.ForeColor = System.Drawing.Color.White;
            legend7.IsTextAutoFit = false;
            legend7.Name = "Legend1";
            this.GreenHistogram.Legends.Add(legend7);
            this.GreenHistogram.Location = new System.Drawing.Point(0, 0);
            this.GreenHistogram.Name = "GreenHistogram";
            this.GreenHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series11.ChartArea = "ChartArea1";
            series11.Color = System.Drawing.Color.SeaGreen;
            series11.Legend = "Legend1";
            series11.Name = "Green";
            this.GreenHistogram.Series.Add(series11);
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
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX.Maximum = 255D;
            chartArea8.AxisX.Minimum = 0D;
            chartArea8.AxisY.IsLabelAutoFit = false;
            chartArea8.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.Name = "ChartArea1";
            this.BlueHistogram.ChartAreas.Add(chartArea8);
            legend8.BackColor = System.Drawing.Color.DimGray;
            legend8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend8.ForeColor = System.Drawing.Color.White;
            legend8.IsTextAutoFit = false;
            legend8.Name = "Legend1";
            this.BlueHistogram.Legends.Add(legend8);
            this.BlueHistogram.Location = new System.Drawing.Point(0, 0);
            this.BlueHistogram.Name = "BlueHistogram";
            this.BlueHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series12.ChartArea = "ChartArea1";
            series12.Color = System.Drawing.Color.RoyalBlue;
            series12.Legend = "Legend1";
            series12.Name = "Blue";
            this.BlueHistogram.Series.Add(series12);
            this.BlueHistogram.Size = new System.Drawing.Size(370, 307);
            this.BlueHistogram.TabIndex = 14;
            this.BlueHistogram.Text = "chart1";
            // 
            // CheckActiveFrame
            // 
            this.CheckActiveFrame.Tick += new System.EventHandler(this.CheckActiveFrame_Tick);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RestoreButton.BackColor = System.Drawing.Color.DimGray;
            this.RestoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RestoreButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.RestoreButton.Location = new System.Drawing.Point(220, 386);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(202, 32);
            this.RestoreButton.TabIndex = 12;
            this.RestoreButton.Text = "Restore Image";
            this.RestoreButton.UseVisualStyleBackColor = false;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // CameraEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 647);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CameraEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Philter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.CameraPreview)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedColor)).EndInit();
            this.Filters.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox CameraPreview;
        private System.Windows.Forms.Button CameraButton;
        private System.Windows.Forms.Button Grayscale;
        private System.Windows.Forms.Button Sepia;
        private System.Windows.Forms.Button Negative;
        private System.Windows.Forms.ProgressBar ImageBar;
        private System.Windows.Forms.Button ColorsButton;
        private System.Windows.Forms.ProgressBar HistogramBar;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button Emboss;
        private System.Windows.Forms.Button GaussianBlur;
        private FontAwesome.Sharp.IconButton BackwardsButton;
        private FontAwesome.Sharp.IconButton PhotoButton;
        private FontAwesome.Sharp.IconButton ForwardButton;
        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Button Sketch;
        private System.Windows.Forms.Button TiltShift;
        private System.Windows.Forms.Button Noise;
        private System.Windows.Forms.Button Sharpen;
        private System.Windows.Forms.Button Contrast;
        private System.Windows.Forms.Button DetectButton;
        private System.Windows.Forms.ColorDialog ColorPicker;
        private System.Windows.Forms.PictureBox SelectedColor;
        private System.Windows.Forms.CheckBox CUDA;
        private System.Windows.Forms.Button OffButton;
        private System.Windows.Forms.Timer CheckActiveFrame;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart HistogramChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart RedHistogram;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart GreenHistogram;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart BlueHistogram;
        private System.Windows.Forms.Button Thermal;
        private System.Windows.Forms.Button EdgeDetection;
        private System.Windows.Forms.Button StopDetecting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelC;
        private System.Windows.Forms.Label LabelB;
        private System.Windows.Forms.Label LabelA;
        private System.Windows.Forms.Label LabelL;
        private System.Windows.Forms.Button RestoreButton;
    }
}

