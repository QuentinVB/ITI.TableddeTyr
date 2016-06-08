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
        
        PictureBox _plateau7x7; 
        PictureBox _plateau9x9;
        PictureBox _plateau11x11;
        PictureBox _plateau13x13;
        PictureBox _plateauPerso;

        Button _button7x7;
        Button _button9x9;
        Button _button11x11;
        Button _button13x13;
        Button _JoueurVsJoueur;
        Button _JoueurVsFreyja;
        Button _Atk;
        Button _Def;
        Button _RetourChoixPlateau;
        Button _RetourChoixAdversaire;
        Button _ButtonPerso;

        int _width;
        int _height;


        public PlayInterface()
        {
            InitializeComponent();
            ButtonBoard();
            pictureboxPlateau();


        }

        private void m_ButtonReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureboxPlateau()
        {
            _plateau7x7 = new PictureBox();
            Image plateau7x7;
            plateau7x7 = ITI.InterfaceUser.Properties.Resources.Board7x7;
            _plateau7x7.Location = new Point(_button7x7.Location.X, _button7x7.Location.Y + 100);
            _plateau7x7.Size = new System.Drawing.Size(150, 150);
            _plateau7x7.Image = (Image)plateau7x7;
            _plateau7x7.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_plateau7x7);
            
            _plateau9x9 = new PictureBox();
            Image plateau9x9;
            plateau9x9 = ITI.InterfaceUser.Properties.Resources.Board9x9;
            _plateau9x9.Location = new Point(_button9x9.Location.X, _button9x9.Location.Y + 100);
            _plateau9x9.Size = new System.Drawing.Size(150, 150);
            _plateau9x9.Image = (Image)plateau9x9;
            _plateau9x9.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_plateau9x9);
            
            _plateau11x11 = new PictureBox();
            Image plateau11x11;
            plateau11x11 = ITI.InterfaceUser.Properties.Resources.Board11x11;
            _plateau11x11.Location = new Point(_button11x11.Location.X, _button11x11.Location.Y + 100);
            _plateau11x11.Size = new System.Drawing.Size(150, 150);
            _plateau11x11.Image = (Image)plateau11x11;
            _plateau11x11.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_plateau11x11);
           
            _plateau13x13 = new PictureBox();
            Image plateau13x13;
            plateau13x13 = ITI.InterfaceUser.Properties.Resources.Board7x7;
            _plateau13x13.Location = new Point(_button13x13.Location.X, _button13x13.Location.Y + 100);
            _plateau13x13.Size = new System.Drawing.Size(150, 150);
            _plateau13x13.Image = (Image)plateau13x13;
            _plateau13x13.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_plateau13x13);

            _plateauPerso = new PictureBox();
            Image plateauPerso;
            plateauPerso = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            _plateauPerso.Location = new Point(_ButtonPerso.Location.X, _ButtonPerso.Location.Y + 100);
            _plateauPerso.Size = new System.Drawing.Size(150, 150);
            _plateauPerso.Image = (Image)plateauPerso;
            _plateauPerso.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_plateauPerso);
        }

        private void ButtonBoard()
        {
            _button7x7 = new Button();
            _button7x7.Text = "Plateau 7x7";
            _button7x7.Location = new Point(this.Location.X + 120, this.Location.Y + 25);
            _button7x7.Size = new System.Drawing.Size(150, 75);
            _button7x7.Click += delegate (object sender, EventArgs e)
            {
                _plateau7x7.Hide();
                _plateau9x9.Hide();
                _plateau11x11.Hide();
                _plateau13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                _button13x13.Hide();
                _ButtonPerso.Hide();
                _plateauPerso.Hide();

                _width = 7;
                _height = 7;

                createButtonChoixAdversaire();
                
            };
            this.Controls.Add(_button7x7);
            _button7x7.BringToFront();
            

            _button9x9 = new Button();
            _button9x9.Text = "Plateau 9x9";
            _button9x9.Location = new Point(this.Location.X + 420, this.Location.Y + 25);
            _button9x9.Size = new System.Drawing.Size(150, 75);
            _button9x9.Click += delegate (object sender, EventArgs e)
            {
                _plateau7x7.Hide();
                _plateau9x9.Hide();
                _plateau11x11.Hide();
                _plateau13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                _button13x13.Hide();
                _ButtonPerso.Hide();
                _plateauPerso.Hide();

                _width = 9;
                _height = 9;

                createButtonChoixAdversaire();
            };
            this.Controls.Add(_button9x9);
            _button9x9.BringToFront();
            
            
            _button11x11 = new Button();
            _button11x11.Text = "Plateau 11x11";
            _button11x11.Location = new Point(this.Location.X + 120, this.Location.Y + 300);
            _button11x11.Size = new System.Drawing.Size(150, 75);
            _button11x11.Click += delegate (object sender, EventArgs e)
            {
                _plateau7x7.Hide();
                _plateau9x9.Hide();
                _plateau11x11.Hide();
                _plateau13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                _button13x13.Hide();
                _ButtonPerso.Hide();
                _plateauPerso.Hide();

                _width = 11;
                _height = 11;

                createButtonChoixAdversaire();
            };
            this.Controls.Add(_button11x11);
            _button11x11.BringToFront();


            _button13x13 = new Button();
            _button13x13.Text = "Plateau 13x13";
            _button13x13.Location = new Point(this.Location.X + 420, this.Location.Y + 300);
            _button13x13.Size = new System.Drawing.Size(150, 75);
            _button13x13.Click += delegate (object sender, EventArgs e)
            {
                _plateau7x7.Hide();
                _plateau9x9.Hide();
                _plateau11x11.Hide();
                _plateau13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                _button13x13.Hide();
                _ButtonPerso.Hide();
                _plateauPerso.Hide();

                _width = 13;
                _height = 13;

                createButtonChoixAdversaire();
            };
            this.Controls.Add(_button13x13);
            _button13x13.BringToFront();

            _ButtonPerso = new Button();
            _ButtonPerso.Text = "Jouez sur un plateau personnalisé";
            _ButtonPerso.Location = new Point(this.Location.X + 250, this.Location.Y + 100);
            _ButtonPerso.Size = new System.Drawing.Size(150, 75);
            _ButtonPerso.Click += delegate (object sender, EventArgs e)
            {
                _plateau7x7.Hide();
                _plateau9x9.Hide();
                _plateau11x11.Hide();
                _plateau13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                _button13x13.Hide();
                _ButtonPerso.Hide();
                _plateauPerso.Hide();
            };
            this.Controls.Add(_ButtonPerso);
            _ButtonPerso.BringToFront();
        }

        private void createButtonChoixAdversaire()
        {
            
            _JoueurVsJoueur = new Button();
            _JoueurVsJoueur.Text = "Joueur Contre Joueur";
            _JoueurVsJoueur.Location = new Point((this.Width / 10), (this.Height / 10));
            _JoueurVsJoueur.Size = new System.Drawing.Size(175, 175);
            _JoueurVsJoueur.Click += delegate (object sender, EventArgs e)
            {
                _JoueurVsFreyja.Hide();
                _JoueurVsJoueur.Hide();
                _RetourChoixPlateau.Hide(); 
                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_width, _height);
                if (GameBoard.ShowDialog() == DialogResult.Cancel)
                {
                    GameBoard.Dispose();
                }
                this.Show();

                _plateau7x7.Show();
                _plateau9x9.Show();
                _plateau11x11.Show();
                _plateau13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                _button13x13.Show();
            };
            this.Controls.Add(_JoueurVsJoueur);
            _JoueurVsJoueur.BringToFront();

            
            _JoueurVsFreyja = new Button();
            _JoueurVsFreyja.Text = "Jouer Contre Freyja";
            _JoueurVsFreyja.Location = new Point((this.Width / 10) * 7, (this.Height / 10));
            _JoueurVsFreyja.Size = new System.Drawing.Size(175, 175);
            _JoueurVsFreyja.Click += delegate (object sender, EventArgs e)
            {
                _JoueurVsFreyja.Hide();
                _JoueurVsJoueur.Hide();
                _RetourChoixPlateau.Hide();
                createButtonChoixRole();
            };
            this.Controls.Add(_JoueurVsFreyja);
            _JoueurVsFreyja.BringToFront();

            _RetourChoixPlateau = new Button();
            _RetourChoixPlateau.Text = "Retour au choix du plateau";
            _RetourChoixPlateau.Location = new Point((this.Width / 10) * 4, (this.Height / 10) * 2);
            _RetourChoixPlateau.Size = new System.Drawing.Size(150, 75);
            _RetourChoixPlateau.Click += delegate (object sender, EventArgs e)
            {
                _RetourChoixPlateau.Hide();
                _JoueurVsFreyja.Hide();
                _JoueurVsJoueur.Hide();
                _plateau7x7.Show();
                _plateau9x9.Show();
                _plateau11x11.Show();
                _plateau13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                _button13x13.Show();
            };
            this.Controls.Add(_RetourChoixPlateau);
            _RetourChoixPlateau.BringToFront();

        }

        private void createButtonChoixRole()
        {
            
            _Atk = new Button();
            Image Attaquant;
            Attaquant = ITI.InterfaceUser.Properties.Resources.attaquant;
            _Atk.Text = "Jouer le rôle d'attaquant";
            _Atk.Location = new Point((this.Width / 10), (this.Height / 10));
            _Atk.Size = new System.Drawing.Size(175, 175);
            _Atk.Image = (Image)Attaquant;
            _Atk.Click += delegate (object sender, EventArgs e)
            {
                // IA Def = true;

                _Atk.Hide();
                _Def.Hide();
                _RetourChoixAdversaire.Hide();

                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_width, _height);
                if (GameBoard.ShowDialog() == DialogResult.Cancel)
                {
                    GameBoard.Dispose();
                }
                this.Show();

                _plateau7x7.Show();
                _plateau9x9.Show();
                _plateau11x11.Show();
                _plateau13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                _button13x13.Show();
            };
            this.Controls.Add(_Atk);
            _Atk.BringToFront();

            _Def = new Button();
            Image Defenseur;
            Defenseur = ITI.InterfaceUser.Properties.Resources.défenseur;
            _Def.Text = "Jouer le rôle de défenseur";
            _Def.Location = new Point((this.Width / 10) * 7, (this.Height / 10));
            _Def.Size = new System.Drawing.Size(175, 175);
            _Def.Image = (Image)Defenseur;
            _Def.Click += delegate (object sender, EventArgs e)
            {
                // IA Atk = true;

                _Atk.Hide();
                _Def.Hide();
                _RetourChoixAdversaire.Hide();

                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_width, _height);
                if (GameBoard.ShowDialog() == DialogResult.Cancel)
                {
                    GameBoard.Dispose();
                }
                this.Show();

                _plateau7x7.Show();
                _plateau9x9.Show();
                _plateau11x11.Show();
                _plateau13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                _button13x13.Show();
            };
            this.Controls.Add(_Def);
            _Def.BringToFront();

            _RetourChoixAdversaire = new Button();
            _RetourChoixAdversaire.Text = "Retour au choix du rôle à jouer";
            _RetourChoixAdversaire.Location = new Point((this.Width / 10) * 4, (this.Height / 10) * 2);
            _RetourChoixAdversaire.Size = new System.Drawing.Size(150, 75);
            _RetourChoixAdversaire.Click += delegate (object sender, EventArgs e)
            {
                _Atk.Hide();
                _Def.Hide();
                _RetourChoixAdversaire.Hide();
                _RetourChoixPlateau.Show();
                _JoueurVsFreyja.Show();
                _JoueurVsJoueur.Show();
            };
            this.Controls.Add(_RetourChoixAdversaire);
            _RetourChoixAdversaire.BringToFront();
        }
    }
}
