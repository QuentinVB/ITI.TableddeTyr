namespace ITI.InterfaceUser
{
    partial class Tutoriel
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
            this.m_ButtonRetourTutorielMenu = new System.Windows.Forms.Button();
            this.m_PictureBoxTutorielBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxTutorielBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ButtonRetourTutorielMenu
            // 
            this.m_ButtonRetourTutorielMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonRetourTutorielMenu.Location = new System.Drawing.Point(870, 589);
            this.m_ButtonRetourTutorielMenu.Name = "m_ButtonRetourTutorielMenu";
            this.m_ButtonRetourTutorielMenu.Size = new System.Drawing.Size(124, 72);
            this.m_ButtonRetourTutorielMenu.TabIndex = 0;
            this.m_ButtonRetourTutorielMenu.Text = "Retour";
            this.m_ButtonRetourTutorielMenu.UseVisualStyleBackColor = true;
            // 
            // m_PictureBoxTutorielBoard
            // 
            this.m_PictureBoxTutorielBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_PictureBoxTutorielBoard.Location = new System.Drawing.Point(12, 12);
            this.m_PictureBoxTutorielBoard.Name = "m_PictureBoxTutorielBoard";
            this.m_PictureBoxTutorielBoard.Size = new System.Drawing.Size(600, 550);
            this.m_PictureBoxTutorielBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_PictureBoxTutorielBoard.TabIndex = 1;
            this.m_PictureBoxTutorielBoard.TabStop = false;
            this.m_PictureBoxTutorielBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.m_PictureBoxTutorielBoard_Paint);
            this.m_PictureBoxTutorielBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_PictureBoxTutorielBoard_MouseClick);
            // 
            // Tutoriel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_PictureBoxTutorielBoard);
            this.Controls.Add(this.m_ButtonRetourTutorielMenu);
            this.Name = "Tutoriel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutoriel";
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxTutorielBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonRetourTutorielMenu;
        private System.Windows.Forms.PictureBox m_PictureBoxTutorielBoard;
    }
}