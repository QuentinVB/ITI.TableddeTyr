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
            this.m_buttonInitialisationPlateau = new System.Windows.Forms.Button();
            this.m_buttonRulesPawns = new System.Windows.Forms.Button();
            this.m_buttonRulesCapture = new System.Windows.Forms.Button();
            this.m_ButtonRulesVictoryCondition = new System.Windows.Forms.Button();
            this.m_RichTextBoxRules = new System.Windows.Forms.RichTextBox();
            this.m_ButtonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_buttonInitialisationPlateau
            // 
            this.m_buttonInitialisationPlateau.Location = new System.Drawing.Point(12, 12);
            this.m_buttonInitialisationPlateau.Name = "m_buttonInitialisationPlateau";
            this.m_buttonInitialisationPlateau.Size = new System.Drawing.Size(187, 99);
            this.m_buttonInitialisationPlateau.TabIndex = 0;
            this.m_buttonInitialisationPlateau.Text = "Initialisation d\'un plateau";
            this.m_buttonInitialisationPlateau.UseVisualStyleBackColor = true;
            this.m_buttonInitialisationPlateau.Click += new System.EventHandler(this.m_buttonInitialisationPlateau_Click);
            // 
            // m_buttonRulesPawns
            // 
            this.m_buttonRulesPawns.Location = new System.Drawing.Point(12, 135);
            this.m_buttonRulesPawns.Name = "m_buttonRulesPawns";
            this.m_buttonRulesPawns.Size = new System.Drawing.Size(187, 99);
            this.m_buttonRulesPawns.TabIndex = 1;
            this.m_buttonRulesPawns.Text = "Les pions ";
            this.m_buttonRulesPawns.UseVisualStyleBackColor = true;
            this.m_buttonRulesPawns.Click += new System.EventHandler(this.m_buttonRulesPawns_Click);
            // 
            // m_buttonRulesCapture
            // 
            this.m_buttonRulesCapture.Location = new System.Drawing.Point(12, 265);
            this.m_buttonRulesCapture.Name = "m_buttonRulesCapture";
            this.m_buttonRulesCapture.Size = new System.Drawing.Size(187, 99);
            this.m_buttonRulesCapture.TabIndex = 2;
            this.m_buttonRulesCapture.Text = "Les différentes types de captures";
            this.m_buttonRulesCapture.UseVisualStyleBackColor = true;
            this.m_buttonRulesCapture.Click += new System.EventHandler(this.m_buttonRulesCapture_Click);
            // 
            // m_ButtonRulesVictoryCondition
            // 
            this.m_ButtonRulesVictoryCondition.Location = new System.Drawing.Point(12, 395);
            this.m_ButtonRulesVictoryCondition.Name = "m_ButtonRulesVictoryCondition";
            this.m_ButtonRulesVictoryCondition.Size = new System.Drawing.Size(187, 99);
            this.m_ButtonRulesVictoryCondition.TabIndex = 3;
            this.m_ButtonRulesVictoryCondition.Text = "Les conditions de victoires";
            this.m_ButtonRulesVictoryCondition.UseVisualStyleBackColor = true;
            this.m_ButtonRulesVictoryCondition.Click += new System.EventHandler(this.m_ButtonRulesVictoryCondition_Click);
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
            this.m_ButtonReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonReturn.Location = new System.Drawing.Point(866, 586);
            this.m_ButtonReturn.Name = "m_ButtonReturn";
            this.m_ButtonReturn.Size = new System.Drawing.Size(128, 75);
            this.m_ButtonReturn.TabIndex = 5;
            this.m_ButtonReturn.Text = "Return";
            this.m_ButtonReturn.UseVisualStyleBackColor = true;
            this.m_ButtonReturn.Click += new System.EventHandler(this.m_ButtonReturn_Click);
            // 
            // HnefataflRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.m_ButtonReturn);
            this.Controls.Add(this.m_RichTextBoxRules);
            this.Controls.Add(this.m_ButtonRulesVictoryCondition);
            this.Controls.Add(this.m_buttonRulesCapture);
            this.Controls.Add(this.m_buttonRulesPawns);
            this.Controls.Add(this.m_buttonInitialisationPlateau);
            this.Name = "HnefataflRules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HnefataflRules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonInitialisationPlateau;
        private System.Windows.Forms.Button m_buttonRulesPawns;
        private System.Windows.Forms.Button m_buttonRulesCapture;
        private System.Windows.Forms.Button m_ButtonRulesVictoryCondition;
        private System.Windows.Forms.RichTextBox m_RichTextBoxRules;
        private System.Windows.Forms.Button m_ButtonReturn;
    }
}