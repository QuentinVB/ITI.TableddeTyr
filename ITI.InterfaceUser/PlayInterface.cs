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
        
        bool _launchGame;
        PictureBox PlayerEnemy = new PictureBox();
        

        public PlayInterface()
        {
            InitializeComponent();
            
        }

        private void m_ButtonReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void m_ButtonBoard11x11_Click(object sender, EventArgs e)
        {

            PlayerEnemy.Width = 400;
            PlayerEnemy.Height = 400;

            Image test01;
            test01 = ITI.InterfaceUser.Properties.Resources.PionRoi;
            PlayerEnemy.Image = (Image)test01;

            this.Controls.Add(PlayerEnemy);
            PlayerEnemy.BringToFront();

            if (_launchGame == true)
            {
                this.Hide();
                m_GameBoard F3 = new m_GameBoard(11, 11);
                if (F3.ShowDialog() == DialogResult.Cancel)
                {
                    F3.Dispose();
                }
                this.Show();
            }
        }

        private void m_ButtonBoard9x9_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_GameBoard F3 = new m_GameBoard(9, 9);
            if (F3.ShowDialog() == DialogResult.Cancel)
            {
                F3.Dispose();
            }

            this.Show();
        }

        private void m_m_ButtonBoard7x7_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_GameBoard F3 = new m_GameBoard(7, 7);
            if (F3.ShowDialog() == DialogResult.Cancel)
            {
                F3.Dispose();
            }

            this.Show();
        }

        private void m_ButtonBoard13x13_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_GameBoard F3 = new m_GameBoard(13, 13);
            if (F3.ShowDialog() == DialogResult.Cancel)
            {
                F3.Dispose();
            }

            this.Show();
        }
    }
}
