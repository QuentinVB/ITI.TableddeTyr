namespace ITI.InterfaceUser
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.m_ButtonPlay = new System.Windows.Forms.Button();
            this.m_ButtonRules = new System.Windows.Forms.Button();
            this.m_ButtonLeave = new System.Windows.Forms.Button();
            this.m_PictureBoxTittle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxTittle)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ButtonPlay
            // 
            this.m_ButtonPlay.Location = new System.Drawing.Point(402, 217);
            this.m_ButtonPlay.Name = "m_ButtonPlay";
            this.m_ButtonPlay.Size = new System.Drawing.Size(197, 92);
            this.m_ButtonPlay.TabIndex = 0;
            this.m_ButtonPlay.Text = "Play";
            this.m_ButtonPlay.UseVisualStyleBackColor = true;
            this.m_ButtonPlay.Click += new System.EventHandler(this.m_ButtonPlay_Click);
            // 
            // m_ButtonRules
            // 
            this.m_ButtonRules.Location = new System.Drawing.Point(402, 358);
            this.m_ButtonRules.Name = "m_ButtonRules";
            this.m_ButtonRules.Size = new System.Drawing.Size(197, 92);
            this.m_ButtonRules.TabIndex = 1;
            this.m_ButtonRules.Text = "Rules";
            this.m_ButtonRules.UseVisualStyleBackColor = true;
            this.m_ButtonRules.Click += new System.EventHandler(this.m_ButtonRules_Click);
            // 
            // m_ButtonLeave
            // 
            this.m_ButtonLeave.Location = new System.Drawing.Point(402, 496);
            this.m_ButtonLeave.Name = "m_ButtonLeave";
            this.m_ButtonLeave.Size = new System.Drawing.Size(197, 92);
            this.m_ButtonLeave.TabIndex = 2;
            this.m_ButtonLeave.Text = "Leave";
            this.m_ButtonLeave.UseVisualStyleBackColor = true;
            this.m_ButtonLeave.Click += new System.EventHandler(this.m_ButtonLeave_Click);
            // 
            // m_PictureBoxTittle
            // 
            this.m_PictureBoxTittle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_PictureBoxTittle.BackgroundImage")));
            this.m_PictureBoxTittle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_PictureBoxTittle.InitialImage = null;
            this.m_PictureBoxTittle.Location = new System.Drawing.Point(204, 2);
            this.m_PictureBoxTittle.Name = "m_PictureBoxTittle";
            this.m_PictureBoxTittle.Size = new System.Drawing.Size(651, 182);
            this.m_PictureBoxTittle.TabIndex = 3;
            this.m_PictureBoxTittle.TabStop = false;
            this.m_PictureBoxTittle.Click += new System.EventHandler(this.m_PictureBoxTittle_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_PictureBoxTittle);
            this.Controls.Add(this.m_ButtonLeave);
            this.Controls.Add(this.m_ButtonRules);
            this.Controls.Add(this.m_ButtonPlay);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxTittle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonPlay;
        private System.Windows.Forms.Button m_ButtonRules;
        private System.Windows.Forms.Button m_ButtonLeave;
        private System.Windows.Forms.PictureBox m_PictureBoxTittle;
    }
}

