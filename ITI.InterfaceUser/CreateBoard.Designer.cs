namespace ITI.InterfaceUser
{
    partial class CreateBoard
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
            this.m_buttonReturn = new System.Windows.Forms.Button();
            this.m_PictureBoxCreateBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxCreateBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // m_buttonReturn
            // 
            this.m_buttonReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonReturn.Location = new System.Drawing.Point(858, 583);
            this.m_buttonReturn.Name = "m_buttonReturn";
            this.m_buttonReturn.Size = new System.Drawing.Size(121, 68);
            this.m_buttonReturn.TabIndex = 0;
            this.m_buttonReturn.UseVisualStyleBackColor = true;
            // 
            // m_PictureBoxCreateBoard
            // 
            this.m_PictureBoxCreateBoard.Location = new System.Drawing.Point(12, 12);
            this.m_PictureBoxCreateBoard.Name = "m_PictureBoxCreateBoard";
            this.m_PictureBoxCreateBoard.Size = new System.Drawing.Size(686, 633);
            this.m_PictureBoxCreateBoard.TabIndex = 1;
            this.m_PictureBoxCreateBoard.TabStop = false;
            this.m_PictureBoxCreateBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.m_PictureBoxCreateBoard_Paint);
            this.m_PictureBoxCreateBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_PictureBoxCreateBoard_MouseClick);
            // 
            // CreateBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_PictureBoxCreateBoard);
            this.Controls.Add(this.m_buttonReturn);
            this.Name = "CreateBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxCreateBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonReturn;
        private System.Windows.Forms.PictureBox m_PictureBoxCreateBoard;
    }
}