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

        private void m_buttonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayInterface Interface = new PlayInterface();
            if (Interface.ShowDialog() == DialogResult.Cancel)
            {
                Interface.Dispose();
            }
            this.Show();
        }

        private void m_buttonRules_Click(object sender, EventArgs e)
        {
            this.Hide();
            HnefataflRules Rules = new HnefataflRules();
            if (Rules.ShowDialog() == DialogResult.Cancel)
            {
                Rules.Dispose();
            }
            this.Show();
        }

        private void m_buttonLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_buttonCreateNewBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBoard createBoard = new CreateBoard();
            if (createBoard.ShowDialog() == DialogResult.Cancel)
            {
                createBoard.Dispose();
            }
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
