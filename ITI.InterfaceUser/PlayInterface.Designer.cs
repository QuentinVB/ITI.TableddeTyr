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
            this.button1 = new System.Windows.Forms.Button();
            this.m_PictureBoxInterfaceBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxInterfaceBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(848, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "Retour au menu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // m_PictureBoxInterfaceBoard
            // 
            this.m_PictureBoxInterfaceBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_PictureBoxInterfaceBoard.Location = new System.Drawing.Point(12, 111);
            this.m_PictureBoxInterfaceBoard.Name = "m_PictureBoxInterfaceBoard";
            this.m_PictureBoxInterfaceBoard.Size = new System.Drawing.Size(600, 550);
            this.m_PictureBoxInterfaceBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_PictureBoxInterfaceBoard.TabIndex = 2;
            this.m_PictureBoxInterfaceBoard.TabStop = false;
            this.m_PictureBoxInterfaceBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.m_PictureBoxInterfaceBoard_Paint);
            // 
            // PlayInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_PictureBoxInterfaceBoard);
            this.Controls.Add(this.button1);
            this.Name = "PlayInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxInterfaceBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox m_PictureBoxInterfaceBoard;
    }
}