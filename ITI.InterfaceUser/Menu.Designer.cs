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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_buttonPlay = new System.Windows.Forms.Button();
            this.m_buttonRules = new System.Windows.Forms.Button();
            this.m_buttonLeave = new System.Windows.Forms.Button();
            this.m_buttonCreateNewBoard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.TableDeTyr1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(219, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(565, 129);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // m_buttonPlay
            // 
            this.m_buttonPlay.Location = new System.Drawing.Point(438, 194);
            this.m_buttonPlay.Name = "m_buttonPlay";
            this.m_buttonPlay.Size = new System.Drawing.Size(177, 85);
            this.m_buttonPlay.TabIndex = 1;
            this.m_buttonPlay.Text = "Play";
            this.m_buttonPlay.UseVisualStyleBackColor = true;
            this.m_buttonPlay.Click += new System.EventHandler(this.m_buttonPlay_Click);
            // 
            // m_buttonRules
            // 
            this.m_buttonRules.Location = new System.Drawing.Point(438, 429);
            this.m_buttonRules.Name = "m_buttonRules";
            this.m_buttonRules.Size = new System.Drawing.Size(177, 84);
            this.m_buttonRules.TabIndex = 2;
            this.m_buttonRules.Text = "Rules";
            this.m_buttonRules.UseVisualStyleBackColor = true;
            this.m_buttonRules.Click += new System.EventHandler(this.m_buttonRules_Click);
            // 
            // m_buttonLeave
            // 
            this.m_buttonLeave.Location = new System.Drawing.Point(438, 553);
            this.m_buttonLeave.Name = "m_buttonLeave";
            this.m_buttonLeave.Size = new System.Drawing.Size(177, 85);
            this.m_buttonLeave.TabIndex = 3;
            this.m_buttonLeave.Text = "Leave";
            this.m_buttonLeave.UseVisualStyleBackColor = true;
            this.m_buttonLeave.Click += new System.EventHandler(this.m_buttonLeave_Click);
            // 
            // m_buttonCreateNewBoard
            // 
            this.m_buttonCreateNewBoard.Location = new System.Drawing.Point(438, 319);
            this.m_buttonCreateNewBoard.Name = "m_buttonCreateNewBoard";
            this.m_buttonCreateNewBoard.Size = new System.Drawing.Size(177, 75);
            this.m_buttonCreateNewBoard.TabIndex = 4;
            this.m_buttonCreateNewBoard.Text = "Create New Board";
            this.m_buttonCreateNewBoard.UseVisualStyleBackColor = true;
            this.m_buttonCreateNewBoard.Click += new System.EventHandler(this.m_buttonCreateNewBoard_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_buttonCreateNewBoard);
            this.Controls.Add(this.m_buttonLeave);
            this.Controls.Add(this.m_buttonRules);
            this.Controls.Add(this.m_buttonPlay);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button m_buttonPlay;
        private System.Windows.Forms.Button m_buttonRules;
        private System.Windows.Forms.Button m_buttonLeave;
        private System.Windows.Forms.Button m_buttonCreateNewBoard;
    }
}