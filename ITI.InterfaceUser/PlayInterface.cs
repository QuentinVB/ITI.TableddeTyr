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
        Button _CreateBoard;
        Button _loadBoard;
        Button _play;

        int _width = 7;
        int _height = 7;
        int _valeurXBoard;
        int _valeurYBoard;
        int _widthBoard;
        int _heightBoard;
        int _valeurXBoardNextCase;
        int _valeurYBoardNextCase;
        int[,] _plateau;


        public PlayInterface()
        {
            InitializeComponent();
            setInterfaceBoard();
            setPlateau(_width, _height);
        }

        private void setPlateau(int x, int y)
        {
            _plateau = new int[_width, _height];

            if (x == 7 && y == 7)
            {
                
                #region hard Code plateau7x7 (test)

                _plateau[2, 0] = 1;
                _plateau[3, 0] = 1;
                _plateau[4, 0] = 1;
                _plateau[3, 1] = 1;
                _plateau[0, 2] = 1;
                _plateau[0, 3] = 1;
                _plateau[0, 4] = 1;
                _plateau[1, 3] = 1;
                _plateau[6, 2] = 1;
                _plateau[6, 3] = 1;
                _plateau[6, 4] = 1;
                _plateau[5, 3] = 1;
                _plateau[2, 6] = 1;
                _plateau[3, 6] = 1;
                _plateau[4, 6] = 1;
                _plateau[3, 5] = 1;

                _plateau[2, 2] = 2;
                _plateau[2, 3] = 2;
                _plateau[2, 4] = 2;
                _plateau[3, 2] = 2;
                _plateau[3, 4] = 2;
                _plateau[4, 2] = 2;
                _plateau[4, 3] = 2;
                _plateau[4, 4] = 2;

                _plateau[3, 3] = 3;
                #endregion
            }

            if(x == 9 && y == 9)
            {
                #region hard Code plateau9x9 (test)
                _plateau[3, 0] = 1;
                _plateau[4, 0] = 1;
                _plateau[5, 0] = 1;
                _plateau[4, 1] = 1;
                _plateau[0, 3] = 1;
                _plateau[0, 4] = 1;
                _plateau[0, 5] = 1;
                _plateau[1, 4] = 1;
                _plateau[8, 3] = 1;
                _plateau[8, 4] = 1;
                _plateau[8, 5] = 1;
                _plateau[7, 4] = 1;
                _plateau[3, 8] = 1;
                _plateau[4, 8] = 1;
                _plateau[5, 8] = 1;
                _plateau[4, 7] = 1;

                _plateau[2, 4] = 2;
                _plateau[3, 4] = 2;
                _plateau[4, 2] = 2;
                _plateau[4, 3] = 2;
                _plateau[5, 4] = 2;
                _plateau[6, 4] = 2;
                _plateau[4, 5] = 2;
                _plateau[4, 6] = 2;

                _plateau[4, 4] = 3;
                #endregion
            }

            if(x == 11 && y == 11)
            {
                #region hard Code plateau11x11 (test)
                _plateau[3, 0] = 1;
                _plateau[4, 0] = 1;
                _plateau[5, 0] = 1;
                _plateau[6, 0] = 1;
                _plateau[7, 0] = 1;
                _plateau[0, 3] = 1;
                _plateau[0, 4] = 1;
                _plateau[0, 5] = 1;
                _plateau[0, 6] = 1;
                _plateau[0, 7] = 1;
                _plateau[10, 3] = 1;
                _plateau[10, 4] = 1;
                _plateau[10, 5] = 1;
                _plateau[10, 6] = 1;
                _plateau[10, 7] = 1;
                _plateau[3, 10] = 1;
                _plateau[4, 10] = 1;
                _plateau[5, 10] = 1;
                _plateau[6, 10] = 1;
                _plateau[7, 10] = 1;
                _plateau[5, 1] = 1;
                _plateau[5, 9] = 1;
                _plateau[1, 5] = 1;
                _plateau[9, 5] = 1;

                _plateau[5, 4] = 2;
                _plateau[5, 6] = 2;
                _plateau[5, 3] = 2;
                _plateau[5, 7] = 2;
                _plateau[4, 4] = 2;
                _plateau[4, 5] = 2;
                _plateau[4, 6] = 2;
                _plateau[6, 4] = 2;
                _plateau[6, 5] = 2;
                _plateau[6, 6] = 2;
                _plateau[3, 5] = 2;
                _plateau[7, 5] = 2;

                _plateau[5, 5] = 3;
                #endregion
            }

            if(x == 13 && y == 13)
            {
                #region hard Code plateau13x13 (test)
                _plateau[4, 0] = 1;
                _plateau[5, 0] = 1;
                _plateau[6, 0] = 1;
                _plateau[7, 0] = 1;
                _plateau[8, 0] = 1;
                _plateau[0, 4] = 1;
                _plateau[0, 5] = 1;
                _plateau[0, 6] = 1;
                _plateau[0, 7] = 1;
                _plateau[0, 8] = 1;
                _plateau[12, 4] = 1;
                _plateau[12, 5] = 1;
                _plateau[12, 6] = 1;
                _plateau[12, 7] = 1;
                _plateau[12, 8] = 1;
                _plateau[4, 12] = 1;
                _plateau[5, 12] = 1;
                _plateau[6, 12] = 1;
                _plateau[7, 12] = 1;
                _plateau[8, 12] = 1;
                _plateau[6, 1] = 1;
                _plateau[6, 11] = 1;
                _plateau[1, 6] = 1;
                _plateau[11, 6] = 1;

                _plateau[6, 3] = 2;
                _plateau[6, 4] = 2;
                _plateau[6, 5] = 2;
                _plateau[6, 7] = 2;
                _plateau[6, 8] = 2;
                _plateau[6, 9] = 2;
                _plateau[3, 6] = 2;
                _plateau[4, 6] = 2;
                _plateau[5, 6] = 2;
                _plateau[7, 6] = 2;
                _plateau[8, 6] = 2;
                _plateau[9, 6] = 2;

                _plateau[6, 6] = 3;

                #endregion
            }



        }

        private void setInterfaceBoard()
        {
           
            _button7x7 = new Button();
            _button7x7.Text = "Plateau 7x7";
            _button7x7.Location = new Point(this.Location.X + 25, this.Location.Y + 5);
            _button7x7.Size = new System.Drawing.Size(150, 75);
            _button7x7.Click += delegate (object sender, EventArgs e)
            {
                _width = 7;
                _height = 7;
                setPlateau(_width, _height);
                m_PictureBoxInterfaceBoard.Refresh();
                
            };
            this.Controls.Add(_button7x7);
            _button7x7.BringToFront();
            

            _button9x9 = new Button();
            _button9x9.Text = "Plateau 9x9";
            _button9x9.Location = new Point(_button7x7.Location.X + 180, _button7x7.Location.Y);
            _button9x9.Size = new System.Drawing.Size(150, 75);
            _button9x9.Click += delegate (object sender, EventArgs e)
            {
                _width = 9;
                _height = 9;
                setPlateau(_width, _height);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button9x9);
            _button9x9.BringToFront();
            
            
            _button11x11 = new Button();
            _button11x11.Text = "Plateau 11x11";
            _button11x11.Location = new Point(_button9x9.Location.X + 180, _button9x9.Location.Y);
            _button11x11.Size = new System.Drawing.Size(150, 75);
            _button11x11.Click += delegate (object sender, EventArgs e)
            {
                _width = 11;
                _height = 11;
                setPlateau(_width, _height);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button11x11);
            _button11x11.BringToFront();


            _button13x13 = new Button();
            _button13x13.Text = "Plateau 13x13";
            _button13x13.Location = new Point(_button11x11.Location.X + 180, _button11x11.Location.Y);
            _button13x13.Size = new System.Drawing.Size(150, 75);
            _button13x13.Click += delegate (object sender, EventArgs e)
            {
                _width = 13;
                _height = 13;
                setPlateau(_width, _height);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button13x13);
            _button13x13.BringToFront();

            _CreateBoard = new Button();
            _CreateBoard.Text = "Créer un plateau personnalisé";
            _CreateBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 200);
            _CreateBoard.Size = new System.Drawing.Size(150, 75);
            _CreateBoard.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                CreateBoard createBoard = new CreateBoard();
                if (createBoard.ShowDialog() == DialogResult.Cancel)
                {
                    createBoard.Dispose();
                }
                this.Show();
            };
            this.Controls.Add(_CreateBoard);
            _CreateBoard.BringToFront();


            _loadBoard = new Button();
            _loadBoard.Text = "Charger un plateau personnalisé";
            _loadBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 300);
            _loadBoard.Size = new System.Drawing.Size(150, 75);
            _loadBoard.Click += delegate (object sender, EventArgs e)
            {
               
            };
            this.Controls.Add(_loadBoard);
            _loadBoard.BringToFront();

            _play = new Button();
            _play.Text = "Jouez";
            _play.Location = new Point(this.Location.X + 465, this.Location.Y + 465);
            _play.Size = new System.Drawing.Size(150, 75);
            _play.Click += delegate (object sender, EventArgs e)
            {
                _loadBoard.Hide();
                _CreateBoard.Hide();
                _button13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                m_PictureBoxInterfaceBoard.Hide();
                createButtonChoixAdversaire();
            };
            this.Controls.Add(_play);
            _play.BringToFront();
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

                _loadBoard.Show();
                _CreateBoard.Show();
                _button13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                m_PictureBoxInterfaceBoard.Show();
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

                _loadBoard.Show();
                _CreateBoard.Show();
                _button13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                m_PictureBoxInterfaceBoard.Show();
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

                _loadBoard.Show();
                _CreateBoard.Show();
                _button13x13.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                m_PictureBoxInterfaceBoard.Show();
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

        private void m_PictureBoxInterfaceBoard_Paint(object sender, PaintEventArgs e)
        {
            Image Piece;
            Image Case;
            Image caseInterdite;
            Image mvtPiecePossible;
            Rectangle Rect;
            Graphics Pawn = e.Graphics;
            Graphics Board = e.Graphics;


            //////
            _valeurXBoard = 3;
            _valeurYBoard = 3;
            _widthBoard = (m_PictureBoxInterfaceBoard.Width - (_valeurXBoard * _width + 1)) / _width;
            _heightBoard = (m_PictureBoxInterfaceBoard.Height - (_valeurYBoard * _height + 1)) / _height;
            _valeurXBoardNextCase = _widthBoard + _valeurXBoard; ;
            _valeurYBoardNextCase = _heightBoard + _valeurYBoard;
            ///////

            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            mvtPiecePossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            m_PictureBoxInterfaceBoard.BackColor = Color.Black;


            int x = 0, y = _valeurYBoard;

            for (int j = 0; j < _height; j++)
            {
                x = _valeurXBoard;
                for (int i = 0; i < _width; i++)
                {
                    if (((i == 0) && (j == 0))
                            || ((i == _width - 1) && (j == _height - 1))
                            || ((i == _width - 1) && (j == 0))
                            || ((i == 0) && (j == _height - 1))
                            || ((i == ((_width - 1) / 2)) && (j == ((_height - 1) / 2))))
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                        Board.DrawImage(caseInterdite, Rect);
                    }
                    else
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                        Board.DrawImage(Case, Rect);
                    }
                    

                    if (_plateau[i, j] == 1)
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionNoir;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (_plateau[i, j] == 2)
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (_plateau[i, j] == 3)
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionRoi;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    x = x + _valeurXBoardNextCase;
                }
                y = y + _valeurYBoardNextCase;
            }
        }
    }
}
