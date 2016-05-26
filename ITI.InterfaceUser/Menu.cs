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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void m_ButtonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayInterface InterfaceForm = new PlayInterface();
            if(InterfaceForm.ShowDialog() == DialogResult.Cancel)
            {
                InterfaceForm.Dispose();
            }
            this.Show();
        }

        private void m_ButtonRules_Click(object sender, EventArgs e)
        {
            this.Hide();
            HnefataflRules RulesForm = new HnefataflRules();
            if (RulesForm.ShowDialog() == DialogResult.Cancel)
            {
                RulesForm.Dispose();
            }
            this.Show();
        }

        private void m_ButtonLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_PictureBoxTittle_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
