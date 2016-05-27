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
        

        public PlayInterface()
        {
            InitializeComponent();
            
        }

        private void m_ButtonReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void m_ButtonBoard11x11_Click(object sender, EventArgs e)
        {
            Image Défenseur;
            Défenseur = ITI.InterfaceUser.Properties.Resources.défenseur;
            Button defenseur = new Button();
            defenseur.Text = "Défenseur";
            defenseur.Location = new Point(50, 50);
            defenseur.Size = new System.Drawing.Size(200, 200);
            defenseur.Image = (Image)Défenseur;
            this.Controls.Add(defenseur);
            defenseur.BringToFront();

            Image ATK;
            ATK = ITI.InterfaceUser.Properties.Resources.attaquant;
            Button attaquant = new Button();
            attaquant.Text = "Attaquanttttttttt";
            attaquant.Location = new Point(250, 50);
            attaquant.Size = new System.Drawing.Size(200, 200);
            attaquant.Image = (Image)ATK;
            this.Controls.Add(attaquant);
            attaquant.BringToFront();

            Button retour = new Button();
            retour.Text = "retour";



            /*
            PictureBox Defenseur = new PictureBox();
            Image Défenseur;
            Défenseur = ITI.InterfaceUser.Properties.Resources.défenseur;
            Defenseur.Location = new Point(200, 200);
            Defenseur.Size = new System.Drawing.Size(300, 300);
            Defenseur.Image = (Image)Défenseur;
            Defenseur.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Defenseur);
            Defenseur.BringToFront();
            */
            //créer boutons a la place de la picture box pour vérifiez si le joueur choisi le pvp ou pvia
            //créer boutons pour choisir le role

            /*
            PictureBox Atkplayer = new PictureBox();
            Image Attaquant;
            Attaquant = ITI.InterfaceUser.Properties.Resources.attaquant;
            Atkplayer.Location = new Point(350, 200);
            Atkplayer.Size = new System.Drawing.Size(150, 150);
            Atkplayer.Image = (Image)Attaquant;
            Atkplayer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Atkplayer);
            Atkplayer.BringToFront();
            */

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
