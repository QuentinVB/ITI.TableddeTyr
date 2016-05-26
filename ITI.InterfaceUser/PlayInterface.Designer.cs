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
            this.m_m_ButtonBoard7x7 = new System.Windows.Forms.Button();
            this.m_ButtonBoard9x9 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_ButtonBoard13x13 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            this.m_ButtonBoard11x11.Location = new System.Drawing.Point(166, 374);
            this.m_ButtonBoard11x11.Name = "m_ButtonBoard11x11";
            this.m_ButtonBoard11x11.Size = new System.Drawing.Size(194, 76);
            this.m_ButtonBoard11x11.TabIndex = 1;
            this.m_ButtonBoard11x11.Text = "Plateau 11x11";
            this.m_ButtonBoard11x11.UseVisualStyleBackColor = true;
            this.m_ButtonBoard11x11.Click += new System.EventHandler(this.m_ButtonBoard11x11_Click);
            // 
            // m_m_ButtonBoard7x7
            // 
            this.m_m_ButtonBoard7x7.Location = new System.Drawing.Point(166, 29);
            this.m_m_ButtonBoard7x7.Name = "m_m_ButtonBoard7x7";
            this.m_m_ButtonBoard7x7.Size = new System.Drawing.Size(194, 76);
            this.m_m_ButtonBoard7x7.TabIndex = 3;
            this.m_m_ButtonBoard7x7.Text = "Plateau 7x7";
            this.m_m_ButtonBoard7x7.UseVisualStyleBackColor = true;
            this.m_m_ButtonBoard7x7.Click += new System.EventHandler(this.m_m_ButtonBoard7x7_Click);
            // 
            // m_ButtonBoard9x9
            // 
            this.m_ButtonBoard9x9.Location = new System.Drawing.Point(537, 29);
            this.m_ButtonBoard9x9.Name = "m_ButtonBoard9x9";
            this.m_ButtonBoard9x9.Size = new System.Drawing.Size(194, 76);
            this.m_ButtonBoard9x9.TabIndex = 5;
            this.m_ButtonBoard9x9.Text = "Plateau 9x9";
            this.m_ButtonBoard9x9.UseVisualStyleBackColor = true;
            this.m_ButtonBoard9x9.Click += new System.EventHandler(this.m_ButtonBoard9x9_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Board11x11;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(166, 478);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(194, 183);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Board7x7;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(166, 149);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(194, 183);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Board9x9;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(537, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 183);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // m_ButtonBoard13x13
            // 
            this.m_ButtonBoard13x13.Location = new System.Drawing.Point(537, 374);
            this.m_ButtonBoard13x13.Name = "m_ButtonBoard13x13";
            this.m_ButtonBoard13x13.Size = new System.Drawing.Size(194, 76);
            this.m_ButtonBoard13x13.TabIndex = 7;
            this.m_ButtonBoard13x13.Text = "Plateau 13x13";
            this.m_ButtonBoard13x13.UseVisualStyleBackColor = true;
            this.m_ButtonBoard13x13.Click += new System.EventHandler(this.m_ButtonBoard13x13_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Board13x13;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(537, 478);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(194, 183);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // PlayInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.m_ButtonBoard13x13);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.m_ButtonBoard9x9);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.m_m_ButtonBoard7x7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_ButtonBoard11x11);
            this.Controls.Add(this.m_ButtonReturn);
            this.Name = "PlayInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonReturn;
        private System.Windows.Forms.Button m_ButtonBoard11x11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button m_m_ButtonBoard7x7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button m_ButtonBoard9x9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button m_ButtonBoard13x13;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}