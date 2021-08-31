namespace kerkenit
{
    partial class Form1
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
            this.chkUpdateRegistry = new System.Windows.Forms.CheckBox();
            this.txtPictureFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetDesktop = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // chkUpdateRegistry
            // 
            this.chkUpdateRegistry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkUpdateRegistry.AutoSize = true;
            this.chkUpdateRegistry.Location = new System.Drawing.Point(121, 37);
            this.chkUpdateRegistry.Name = "chkUpdateRegistry";
            this.chkUpdateRegistry.Size = new System.Drawing.Size(102, 17);
            this.chkUpdateRegistry.TabIndex = 6;
            this.chkUpdateRegistry.Text = "Update Registry";
            this.chkUpdateRegistry.UseVisualStyleBackColor = true;
            // 
            // txtPictureFile
            // 
            this.txtPictureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPictureFile.Location = new System.Drawing.Point(61, 11);
            this.txtPictureFile.Name = "txtPictureFile";
            this.txtPictureFile.Size = new System.Drawing.Size(241, 20);
            this.txtPictureFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Picture:";
            // 
            // btnSetDesktop
            // 
            this.btnSetDesktop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetDesktop.Location = new System.Drawing.Point(135, 76);
            this.btnSetDesktop.Name = "btnSetDesktop";
            this.btnSetDesktop.Size = new System.Drawing.Size(75, 23);
            this.btnSetDesktop.TabIndex = 5;
            this.btnSetDesktop.Text = "Set Desktop";
            this.btnSetDesktop.UseVisualStyleBackColor = true;
            this.btnSetDesktop.Click += new System.EventHandler(this.btnSetDesktop_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(308, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 20);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.CheckFileExists = false;
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Image Files|*.bmp;*.png;*.jpg;*.tif;*.gif|All Files|*.*";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSetDesktop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 111);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.chkUpdateRegistry);
            this.Controls.Add(this.txtPictureFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetDesktop);
            this.Name = "Form1";
            this.Text = "kerkenit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUpdateRegistry;
        private System.Windows.Forms.TextBox txtPictureFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetDesktop;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdImage;
    }
}

