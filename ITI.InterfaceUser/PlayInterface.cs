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
    public partial class PlayInterface : Form
    {

        public PlayInterface()
        {
            InitializeComponent();
        }

        private void m_ButtonReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void m_ButtonBoard11x11_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_GameBoard F3 = new m_GameBoard(11, 11);
            if (F3.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                F3.Dispose();
            }

            this.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
