namespace Proyecto_Final
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainWindowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.VideoButton = new FontAwesome.Sharp.IconButton();
            this.CameraButton = new FontAwesome.Sharp.IconButton();
            this.ImageButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // MainWindowPanel
            // 
            this.MainWindowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainWindowPanel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainWindowPanel.Location = new System.Drawing.Point(0, 0);
            this.MainWindowPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainWindowPanel.Name = "MainWindowPanel";
            this.MainWindowPanel.Size = new System.Drawing.Size(900, 647);
            this.MainWindowPanel.TabIndex = 0;
            this.MainWindowPanel.SizeChanged += new System.EventHandler(this.MainWindowPanel_SizeChanged);
            this.MainWindowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Container_Paint);
            // 
            // VideoButton
            // 
            this.VideoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.VideoButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.VideoButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.VideoButton.IconChar = FontAwesome.Sharp.IconChar.PhotoVideo;
            this.VideoButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.VideoButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.VideoButton.Location = new System.Drawing.Point(386, 552);
            this.VideoButton.Name = "VideoButton";
            this.VideoButton.Size = new System.Drawing.Size(146, 68);
            this.VideoButton.TabIndex = 11;
            this.VideoButton.UseVisualStyleBackColor = false;
            this.VideoButton.Click += new System.EventHandler(this.VideoButton_Click);
            // 
            // CameraButton
            // 
            this.CameraButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CameraButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.CameraButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CameraButton.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            this.CameraButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CameraButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CameraButton.Location = new System.Drawing.Point(664, 552);
            this.CameraButton.Name = "CameraButton";
            this.CameraButton.Size = new System.Drawing.Size(146, 68);
            this.CameraButton.TabIndex = 10;
            this.CameraButton.UseVisualStyleBackColor = false;
            this.CameraButton.Click += new System.EventHandler(this.CameraButton_Click);
            // 
            // ImageButton
            // 
            this.ImageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ImageButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.ImageButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ImageButton.IconChar = FontAwesome.Sharp.IconChar.Images;
            this.ImageButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ImageButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ImageButton.Location = new System.Drawing.Point(108, 552);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(146, 68);
            this.ImageButton.TabIndex = 0;
            this.ImageButton.UseVisualStyleBackColor = false;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.VideoButton);
            this.Controls.Add(this.CameraButton);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.MainWindowPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoHub";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainWindowPanel;
        private FontAwesome.Sharp.IconButton ImageButton;
        private FontAwesome.Sharp.IconButton CameraButton;
        private FontAwesome.Sharp.IconButton VideoButton;
    }
}