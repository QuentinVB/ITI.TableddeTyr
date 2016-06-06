using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.InterfaceUser
{
    public partial class HnefataflRules : Form
    {
        public HnefataflRules()
        {
            InitializeComponent();
        }

        private void m_buttonInitialisationPlateau_Click(object sender, EventArgs e)
        {
            m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Initialisation_d_un_plateau;
        }

        private void m_buttonRulesPawns_Click(object sender, EventArgs e)
        {
            m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_pions;
        }

        private void m_buttonRulesCapture_Click(object sender, EventArgs e)
        {
            m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_différentes_types_de_captures;
        }

        private void m_ButtonRulesVictoryCondition_Click(object sender, EventArgs e)
        {
            m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_conditions_de_victoires;
        }

        private void m_ButtonReturn_Click(object sender, EventArgs e)
        {

        }
    }
}
