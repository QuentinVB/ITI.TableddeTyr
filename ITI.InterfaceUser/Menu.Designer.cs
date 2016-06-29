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
            this.m_buttonPlay = new System.Windows.Forms.Button();
            this.m_buttonRules = new System.Windows.Forms.Button();
            this.m_buttonLeave = new System.Windows.Forms.Button();
            this.m_buttonTutoriel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_buttonPlay
            // 
            this.m_buttonPlay.BackColor = System.Drawing.Color.Transparent;
            this.m_buttonPlay.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Jouer_php;
            this.m_buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonPlay.Location = new System.Drawing.Point(420, 269);
            this.m_buttonPlay.Name = "m_buttonPlay";
            this.m_buttonPlay.Size = new System.Drawing.Size(177, 85);
            this.m_buttonPlay.TabIndex = 1;
            this.m_buttonPlay.UseVisualStyleBackColor = false;
            this.m_buttonPlay.Click += new System.EventHandler(this.m_buttonPlay_Click);
            // 
            // m_buttonRules
            // 
            this.m_buttonRules.BackColor = System.Drawing.Color.Transparent;
            this.m_buttonRules.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Règles_du_jeu_php;
            this.m_buttonRules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonRules.Location = new System.Drawing.Point(420, 360);
            this.m_buttonRules.Name = "m_buttonRules";
            this.m_buttonRules.Size = new System.Drawing.Size(177, 84);
            this.m_buttonRules.TabIndex = 2;
            this.m_buttonRules.UseVisualStyleBackColor = false;
            this.m_buttonRules.Click += new System.EventHandler(this.m_buttonRules_Click);
            // 
            // m_buttonLeave
            // 
            this.m_buttonLeave.BackColor = System.Drawing.Color.Transparent;
            this.m_buttonLeave.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Quitter_php;
            this.m_buttonLeave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonLeave.Location = new System.Drawing.Point(420, 540);
            this.m_buttonLeave.Name = "m_buttonLeave";
            this.m_buttonLeave.Size = new System.Drawing.Size(177, 85);
            this.m_buttonLeave.TabIndex = 3;
            this.m_buttonLeave.UseVisualStyleBackColor = false;
            this.m_buttonLeave.Click += new System.EventHandler(this.m_buttonLeave_Click);
            // 
            // m_buttonTutoriel
            // 
            this.m_buttonTutoriel.BackColor = System.Drawing.Color.Transparent;
            this.m_buttonTutoriel.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Tutoriel_php;
            this.m_buttonTutoriel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_buttonTutoriel.Location = new System.Drawing.Point(420, 450);
            this.m_buttonTutoriel.Name = "m_buttonTutoriel";
            this.m_buttonTutoriel.Size = new System.Drawing.Size(177, 84);
            this.m_buttonTutoriel.TabIndex = 5;
            this.m_buttonTutoriel.UseVisualStyleBackColor = false;
            this.m_buttonTutoriel.Click += new System.EventHandler(this.m_buttonTutoriel_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ITI.InterfaceUser.Properties.Resources.Nefataffel_1097;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_buttonTutoriel);
            this.Controls.Add(this.m_buttonLeave);
            this.Controls.Add(this.m_buttonRules);
            this.Controls.Add(this.m_buttonPlay);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button m_buttonPlay;
        private System.Windows.Forms.Button m_buttonRules;
        private System.Windows.Forms.Button m_buttonLeave;
        private System.Windows.Forms.Button m_buttonTutoriel;
    }
}