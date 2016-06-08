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
            this.m_ButtonRetourTutorielMenu.Click += new System.EventHandler(this.m_ButtonRetourTutorielMenu_Click);
            // 
            // Tutoriel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_ButtonRetourTutorielMenu);
            this.Name = "Tutoriel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutoriel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonRetourTutorielMenu;
    }
}