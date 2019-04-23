namespace MouseHud
{
    partial class UfSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TbFrameWidth = new System.Windows.Forms.TextBox();
            this.TbFrameHeight = new System.Windows.Forms.TextBox();
            this.TbFileName = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frame Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Frame Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Basic Filename";
            // 
            // TbFrameWidth
            // 
            this.TbFrameWidth.Location = new System.Drawing.Point(98, 6);
            this.TbFrameWidth.Name = "TbFrameWidth";
            this.TbFrameWidth.Size = new System.Drawing.Size(109, 20);
            this.TbFrameWidth.TabIndex = 3;
            // 
            // TbFrameHeight
            // 
            this.TbFrameHeight.Location = new System.Drawing.Point(98, 28);
            this.TbFrameHeight.Name = "TbFrameHeight";
            this.TbFrameHeight.Size = new System.Drawing.Size(109, 20);
            this.TbFrameHeight.TabIndex = 4;
            // 
            // TbFileName
            // 
            this.TbFileName.Location = new System.Drawing.Point(98, 51);
            this.TbFileName.Name = "TbFileName";
            this.TbFileName.Size = new System.Drawing.Size(109, 20);
            this.TbFileName.TabIndex = 5;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(113, 77);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // UfSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 107);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TbFileName);
            this.Controls.Add(this.TbFrameHeight);
            this.Controls.Add(this.TbFrameWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UfSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbFrameWidth;
        private System.Windows.Forms.TextBox TbFrameHeight;
        private System.Windows.Forms.TextBox TbFileName;
        private System.Windows.Forms.Button BtnSave;
    }
}