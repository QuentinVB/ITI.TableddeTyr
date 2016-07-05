namespace ITI.InterfaceUser
{
    partial class RessourcesPack
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
            this.m_ButtonRessourcesRetourMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonRessourcesRetourMenu
            // 
            this.m_ButtonRessourcesRetourMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonRessourcesRetourMenu.Location = new System.Drawing.Point(620, 466);
            this.m_ButtonRessourcesRetourMenu.Name = "m_ButtonRessourcesRetourMenu";
            this.m_ButtonRessourcesRetourMenu.Size = new System.Drawing.Size(150, 75);
            this.m_ButtonRessourcesRetourMenu.TabIndex = 0;
            this.m_ButtonRessourcesRetourMenu.UseVisualStyleBackColor = true;
            // 
            // RessourcesPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.m_ButtonRessourcesRetourMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RessourcesPack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RessourcesPack";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonRessourcesRetourMenu;
    }
}