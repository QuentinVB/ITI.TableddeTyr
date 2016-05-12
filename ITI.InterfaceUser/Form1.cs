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
            PlayInterface F2 = new PlayInterface();
            if(F2.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                F2.Dispose();
            }
            this.Show();
        }

        private void m_ButtonRules_Click(object sender, EventArgs e)
        {

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
