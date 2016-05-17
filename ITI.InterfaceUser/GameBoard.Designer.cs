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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_positionSouris = new System.Windows.Forms.TextBox();
            this.m_PlayerTurn = new System.Windows.Forms.TextBox();
            this.m_updateTurn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.plateau1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(686, 633);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // m_positionSouris
            // 
            this.m_positionSouris.Location = new System.Drawing.Point(470, 15);
            this.m_positionSouris.Name = "m_positionSouris";
            this.m_positionSouris.Size = new System.Drawing.Size(198, 22);
            this.m_positionSouris.TabIndex = 1;
            this.m_positionSouris.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_PlayerTurn
            // 
            this.m_PlayerTurn.Location = new System.Drawing.Point(743, 30);
            this.m_PlayerTurn.Name = "m_PlayerTurn";
            this.m_PlayerTurn.Size = new System.Drawing.Size(195, 22);
            this.m_PlayerTurn.TabIndex = 2;
            this.m_PlayerTurn.TabStop = false;
            this.m_PlayerTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_updateTurn
            // 
            this.m_updateTurn.Location = new System.Drawing.Point(765, 319);
            this.m_updateTurn.Name = "m_updateTurn";
            this.m_updateTurn.Size = new System.Drawing.Size(133, 57);
            this.m_updateTurn.TabIndex = 3;
            this.m_updateTurn.Text = "TestUpdate";
            this.m_updateTurn.UseVisualStyleBackColor = true;
            this.m_updateTurn.Click += new System.EventHandler(this.m_updateTurn_Click);
            // 
            // m_GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 673);
            this.Controls.Add(this.m_updateTurn);
            this.Controls.Add(this.m_PlayerTurn);
            this.Controls.Add(this.m_positionSouris);
            this.Controls.Add(this.pictureBox1);
            this.Name = "m_GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            this.Load += new System.EventHandler(this.m_GameBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox m_positionSouris;
        private System.Windows.Forms.TextBox m_PlayerTurn;
        private System.Windows.Forms.Button m_updateTurn;
    }
}