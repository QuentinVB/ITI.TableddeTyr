namespace ITI.InterfaceUser
{
    partial class PlayInterface
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
            this.m_ButtonReturn = new System.Windows.Forms.Button();
            this.m_ButtonBoard11x11 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ButtonReturn
            // 
            this.m_ButtonReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonReturn.Location = new System.Drawing.Point(874, 602);
            this.m_ButtonReturn.Name = "m_ButtonReturn";
            this.m_ButtonReturn.Size = new System.Drawing.Size(120, 59);
            this.m_ButtonReturn.TabIndex = 0;
            this.m_ButtonReturn.Text = "Return";
            this.m_ButtonReturn.UseVisualStyleBackColor = true;
            this.m_ButtonReturn.Click += new System.EventHandler(this.m_ButtonReturn_Click);
            // 
            // m_ButtonBoard11x11
            // 
            this.m_ButtonBoard11x11.Location = new System.Drawing.Point(68, 29);
            this.m_ButtonBoard11x11.Name = "m_ButtonBoard11x11";
            this.m_ButtonBoard11x11.Size = new System.Drawing.Size(222, 99);
            this.m_ButtonBoard11x11.TabIndex = 1;
            this.m_ButtonBoard11x11.Text = "Plateau 11x11";
            this.m_ButtonBoard11x11.UseVisualStyleBackColor = true;
            this.m_ButtonBoard11x11.Click += new System.EventHandler(this.m_ButtonBoard11x11_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Board11x111;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(68, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 220);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PlayInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_ButtonBoard11x11);
            this.Controls.Add(this.m_ButtonReturn);
            this.Name = "PlayInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonReturn;
        private System.Windows.Forms.Button m_ButtonBoard11x11;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}