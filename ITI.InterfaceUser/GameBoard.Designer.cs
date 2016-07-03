namespace ITI.InterfaceUser
{
    partial class m_GameBoard
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
            this.m_GameBoardPictureBoxTafl = new System.Windows.Forms.PictureBox();
            this.m_buttonRetourMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_GameBoardPictureBoxTafl)).BeginInit();
            this.SuspendLayout();
            // 
            // m_GameBoardPictureBoxTafl
            // 
            this.m_GameBoardPictureBoxTafl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_GameBoardPictureBoxTafl.Location = new System.Drawing.Point(12, 12);
            this.m_GameBoardPictureBoxTafl.Name = "m_GameBoardPictureBoxTafl";
            this.m_GameBoardPictureBoxTafl.Size = new System.Drawing.Size(686, 633);
            this.m_GameBoardPictureBoxTafl.TabIndex = 0;
            this.m_GameBoardPictureBoxTafl.TabStop = false;
            this.m_GameBoardPictureBoxTafl.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.m_GameBoardPictureBoxTafl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // m_buttonRetourMenu
            // 
            this.m_buttonRetourMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonRetourMenu.Location = new System.Drawing.Point(812, 587);
            this.m_buttonRetourMenu.Name = "m_buttonRetourMenu";
            this.m_buttonRetourMenu.Size = new System.Drawing.Size(159, 74);
            this.m_buttonRetourMenu.TabIndex = 3;
            this.m_buttonRetourMenu.Text = "Retour au choix des plateaux";
            this.m_buttonRetourMenu.UseVisualStyleBackColor = true;
            // 
            // m_GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 673);
            this.Controls.Add(this.m_buttonRetourMenu);
            this.Controls.Add(this.m_GameBoardPictureBoxTafl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "m_GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.m_GameBoardPictureBoxTafl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_GameBoardPictureBoxTafl;
        private System.Windows.Forms.Button m_buttonRetourMenu;
    }
}