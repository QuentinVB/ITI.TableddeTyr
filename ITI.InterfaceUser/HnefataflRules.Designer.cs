namespace ITI.InterfaceUser
{
    partial class HnefataflRules
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
            this.m_RichTextBoxRules = new System.Windows.Forms.RichTextBox();
            this.m_ButtonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_RichTextBoxRules
            // 
            this.m_RichTextBoxRules.Location = new System.Drawing.Point(271, 12);
            this.m_RichTextBoxRules.Name = "m_RichTextBoxRules";
            this.m_RichTextBoxRules.Size = new System.Drawing.Size(663, 481);
            this.m_RichTextBoxRules.TabIndex = 4;
            this.m_RichTextBoxRules.Text = "";
            // 
            // m_ButtonReturn
            // 
            this.m_ButtonReturn.BackColor = System.Drawing.Color.Transparent;
            this.m_ButtonReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonReturn.Location = new System.Drawing.Point(866, 586);
            this.m_ButtonReturn.Name = "m_ButtonReturn";
            this.m_ButtonReturn.Size = new System.Drawing.Size(128, 75);
            this.m_ButtonReturn.TabIndex = 5;
            this.m_ButtonReturn.UseVisualStyleBackColor = false;
            // 
            // HnefataflRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_ButtonReturn);
            this.Controls.Add(this.m_RichTextBoxRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HnefataflRules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox m_RichTextBoxRules;
        private System.Windows.Forms.Button m_ButtonReturn;
    }
}