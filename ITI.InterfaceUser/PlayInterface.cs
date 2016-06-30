using ITI.GameCore;
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
        XML_Tafl _xml;

        InterfaceOptions _interfaceOptions;

        Button _button7x7;
        Button _button9x9;
        Button _button11x11;
        Button _button13x13;
        Button _JoueurVsJoueur;
        Button _JoueurVsFreyja;
        Button _jouerAttaquant;
        Button _jouerDefenseur;
        Button _RetourChoixPlateau;
        Button _RetourChoixAdversaire;
        Button _CreateBoard;
        Button _loadBoard;
        Button _play;

        Image button7x7;
        Image button9x9;
        Image button11x11;
        Image button13x13;
        Image CreateBoard;
        Image LoadBoard;
        Image Play;
        Image JoueurVsJoueur;
        Image JoueurVsFreyja;
        Image jouerAttaquant;
        Image jouerDefenseur;
        Image retour;

        int _rectanglePositionX;
        int _rectanglePositionY;
        int _rectangleWidth;
        int _rectangleHeight;
        int _nextRectanglePositionX;
        int _nextRectanglePositionY;
        int _width;
        int _height;
        int[,] _plateau;


        public PlayInterface(InterfaceOptions interfaceoptions)
        {
            InitializeComponent();
            _interfaceOptions = interfaceoptions;

            _interfaceOptions.FormTitle();
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            setInterfaceBoard();
            _width = _interfaceOptions.Width;
            _height = _interfaceOptions.Height;
            setPlateau(_width, _height);
        }

        private void setPlateau(int width, int height)
        {
            _width = _interfaceOptions.Width;
            _height = _interfaceOptions.Height;

            _plateau = new int[_width, _height];

            if (width == 7 && height == 7)
            {
                _rectanglePositionX = 3;
                _rectanglePositionY = 4;
                _rectangleWidth = 61;
                _rectangleHeight = 60;
                _nextRectanglePositionX = 64;
                _nextRectanglePositionY = 63;

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

            if(width == 9 && height == 9)
            {
                _rectanglePositionX = 2;
                _rectanglePositionY = 4;
                _rectangleWidth = 47;
                _rectangleHeight = 46;
                _nextRectanglePositionX = 50;
                _nextRectanglePositionY = 49;

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

            if(width == 11 && height == 11)
            {
                _rectanglePositionX = 6;
                _rectanglePositionY = 5;
                _rectangleWidth = 37;
                _rectangleHeight = 37;
                _nextRectanglePositionX = 40;
                _nextRectanglePositionY = 40;

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

            if(width == 13 && height == 13)
            {
                _rectanglePositionX = 5;
                _rectanglePositionY = 4;
                _rectangleWidth = 31;
                _rectangleHeight = 31;
                _nextRectanglePositionX = 34;
                _nextRectanglePositionY = 34;

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

        private void setLanguages()
        {
            if(_interfaceOptions.Languages == true)
            {
                button7x7 = ITI.InterfaceUser.Properties.Resources.plateau7x7;
                button9x9 = ITI.InterfaceUser.Properties.Resources.plateau9x9;
                button11x11 = ITI.InterfaceUser.Properties.Resources.plateau11x11;
                button13x13 = ITI.InterfaceUser.Properties.Resources.plateau13x13;
                CreateBoard = ITI.InterfaceUser.Properties.Resources.Créer_un_plateau;
                LoadBoard = ITI.InterfaceUser.Properties.Resources.ChargerPlateau;
                Play = ITI.InterfaceUser.Properties.Resources.Jouer_php;
                JoueurVsJoueur = ITI.InterfaceUser.Properties.Resources.JoueurVSJoueur;
                JoueurVsFreyja = ITI.InterfaceUser.Properties.Resources.JoueurVSIa;
                jouerAttaquant = ITI.InterfaceUser.Properties.Resources.Jouer_attaquant;
                jouerDefenseur = ITI.InterfaceUser.Properties.Resources.JouerDefenseur;
                retour = ITI.InterfaceUser.Properties.Resources.Retour;
            }
            else
            {
                button7x7 = ITI.InterfaceUser.Properties.Resources.Board7x7;
                button9x9 = ITI.InterfaceUser.Properties.Resources.Board9x9;
                button11x11 = ITI.InterfaceUser.Properties.Resources.Board11x11;
                button13x13 = ITI.InterfaceUser.Properties.Resources.Board13x13;
                CreateBoard = ITI.InterfaceUser.Properties.Resources.CreateBoard;
                LoadBoard = ITI.InterfaceUser.Properties.Resources.LoadBoard;
                Play = ITI.InterfaceUser.Properties.Resources.Play;
                JoueurVsJoueur = ITI.InterfaceUser.Properties.Resources.PlayerVSPlayer;
                JoueurVsFreyja = ITI.InterfaceUser.Properties.Resources.PlayerVSIA;
                jouerAttaquant = ITI.InterfaceUser.Properties.Resources.PlayAttacker;
                jouerDefenseur = ITI.InterfaceUser.Properties.Resources.PlayDefender;
                retour = ITI.InterfaceUser.Properties.Resources.Return;
            }
            
        }

        private void setInterfaceBoard()
        {
            setLanguages();

            _button7x7 = new Button();
            _button7x7.Location = new Point(this.Location.X + 25, this.Location.Y + 5);
            _button7x7.Size = new System.Drawing.Size(150, 75);
            _button7x7.BackgroundImage = (Image)button7x7;
            _button7x7.BackgroundImageLayout = ImageLayout.Stretch;
            _button7x7.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.Width = 7;
                _interfaceOptions.Height = 7;
                setPlateau(_interfaceOptions.Width, _interfaceOptions.Height);
                m_PictureBoxInterfaceBoard.Refresh();
                
            };
            this.Controls.Add(_button7x7);
            _button7x7.BringToFront();
            

            _button9x9 = new Button();
            _button9x9.Location = new Point(_button7x7.Location.X + 180, _button7x7.Location.Y);
            _button9x9.Size = new System.Drawing.Size(150, 75);
            _button9x9.BackgroundImage = (Image)button9x9;
            _button9x9.BackgroundImageLayout = ImageLayout.Stretch;
            _button9x9.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.Width = 9;
                _interfaceOptions.Height = 9;
                setPlateau(_interfaceOptions.Width, _interfaceOptions.Height);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button9x9);
            _button9x9.BringToFront();
            
            
            _button11x11 = new Button();
            _button11x11.Location = new Point(_button9x9.Location.X + 180, _button9x9.Location.Y);
            _button11x11.Size = new System.Drawing.Size(150, 75);
            _button11x11.BackgroundImage = (Image)button11x11;
            _button11x11.BackgroundImageLayout = ImageLayout.Stretch;
            _button11x11.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.Width = 11;
                _interfaceOptions.Height = 11;
                setPlateau(_interfaceOptions.Width, _interfaceOptions.Height);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button11x11);
            _button11x11.BringToFront();


            _button13x13 = new Button();
            _button13x13.Location = new Point(_button11x11.Location.X + 180, _button11x11.Location.Y);
            _button13x13.Size = new System.Drawing.Size(150, 75);
            _button13x13.BackgroundImage = (Image)button13x13;
            _button13x13.BackgroundImageLayout = ImageLayout.Stretch;
            _button13x13.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.Width = 13;
                _interfaceOptions.Height = 13;
                setPlateau(_interfaceOptions.Width, _interfaceOptions.Height);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button13x13);
            _button13x13.BringToFront();

            _CreateBoard = new Button();
            _CreateBoard.Location = new Point(this.Location.X + 480, this.Location.Y + 200);
            _CreateBoard.Size = new System.Drawing.Size(250, 75);
            _CreateBoard.BackgroundImage = (Image)CreateBoard;
            _CreateBoard.BackgroundImageLayout = ImageLayout.Stretch;
            _CreateBoard.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                CreateBoard createBoard = new CreateBoard(_interfaceOptions);
                if (createBoard.ShowDialog() == DialogResult.Cancel)
                {
                    createBoard.Dispose();
                }
                this.Show();
            };
            this.Controls.Add(_CreateBoard);
            _CreateBoard.BringToFront();


            _loadBoard = new Button();
            _loadBoard.Location = new Point(this.Location.X + 480, this.Location.Y + 300);
            _loadBoard.Size = new System.Drawing.Size(250, 75);
            _loadBoard.BackgroundImage = (Image)LoadBoard;
            _loadBoard.BackgroundImageLayout = ImageLayout.Stretch;
            _loadBoard.Click += delegate (object sender, EventArgs e)
            {
                _xml.ReadXmlTafl(_width, _height);
            };
            this.Controls.Add(_loadBoard);
            _loadBoard.BringToFront();

            _play = new Button();
            _play.Location = new Point(this.Location.X + 465, this.Location.Y + 465);
            _play.Size = new System.Drawing.Size(150, 75);
            _play.BackgroundImage = (Image)Play;
            _play.BackgroundImageLayout = ImageLayout.Stretch;
            _play.Click += delegate (object sender, EventArgs e)
            {
                _loadBoard.Hide();
                _CreateBoard.Hide();
                _button13x13.Hide();
                _button7x7.Hide();
                _button9x9.Hide();
                _button11x11.Hide();
                m_PictureBoxInterfaceBoard.Hide();
                _play.Hide();
                m_buttonReturn.Hide();
                createButtonChoixAdversaire();
            };
            this.Controls.Add(_play);
            _play.BringToFront();

            
            m_buttonReturn.BackgroundImage = (Image)retour;
            m_buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            m_buttonReturn.BringToFront();
        }

        private void createButtonChoixAdversaire()
        {
            
            _JoueurVsJoueur = new Button();
            _JoueurVsJoueur.Location = new Point((this.Width / 10), (this.Height / 10));
            _JoueurVsJoueur.Size = new System.Drawing.Size(175, 175);
            _JoueurVsJoueur.BackgroundImage = (Image)JoueurVsJoueur;
            _JoueurVsJoueur.BackgroundImageLayout = ImageLayout.Stretch;
            _JoueurVsJoueur.Click += delegate (object sender, EventArgs e)
            {
                _JoueurVsFreyja.Hide();
                _JoueurVsJoueur.Hide();
                _RetourChoixPlateau.Hide(); 
                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_interfaceOptions, false, false);
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
                _play.Show();
                m_buttonReturn.Show();
                m_PictureBoxInterfaceBoard.Show();
            };
            this.Controls.Add(_JoueurVsJoueur);
            _JoueurVsJoueur.BringToFront();

            
            _JoueurVsFreyja = new Button();
            _JoueurVsFreyja.Location = new Point((this.Width / 10) * 7, (this.Height / 10));
            _JoueurVsFreyja.Size = new System.Drawing.Size(175, 175);
            _JoueurVsFreyja.BackgroundImage = (Image)JoueurVsFreyja;
            _JoueurVsFreyja.BackgroundImageLayout = ImageLayout.Stretch;
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
            _RetourChoixPlateau.Location = new Point((this.Width / 10) * 4, (this.Height / 10) * 2);
            _RetourChoixPlateau.Size = new System.Drawing.Size(150, 75);
            _RetourChoixPlateau.BackgroundImage = (Image)retour;
            _RetourChoixPlateau.BackgroundImageLayout = ImageLayout.Stretch;
            _RetourChoixPlateau.Click += delegate (object sender, EventArgs e)
            {
                _RetourChoixPlateau.Hide();
                _JoueurVsFreyja.Hide();
                _JoueurVsJoueur.Hide();
                _play.Show();
                m_buttonReturn.Show();
                _button7x7.Show();
                _button9x9.Show();
                _button11x11.Show();
                _button13x13.Show();
                m_PictureBoxInterfaceBoard.Show();
                _CreateBoard.Show();
                _loadBoard.Show();
            };
            this.Controls.Add(_RetourChoixPlateau);
            _RetourChoixPlateau.BringToFront();

        }

        private void createButtonChoixRole()
        {
            
            _jouerAttaquant = new Button();
            _jouerAttaquant.Location = new Point((this.Width / 10), (this.Height / 10));
            _jouerAttaquant.Size = new System.Drawing.Size(175, 175);
            _jouerAttaquant.BackgroundImage = (Image)jouerAttaquant;
            _jouerAttaquant.BackgroundImageLayout = ImageLayout.Stretch;
            _jouerAttaquant.Click += delegate (object sender, EventArgs e)
            {
                _jouerAttaquant.Hide();
                _jouerDefenseur.Hide();
                _RetourChoixAdversaire.Hide();

                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_interfaceOptions, false, true);
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
                _play.Show();
                m_buttonReturn.Show();
                m_PictureBoxInterfaceBoard.Show();
            };
            this.Controls.Add(_jouerAttaquant);
            _jouerAttaquant.BringToFront();

            _jouerDefenseur = new Button();
            _jouerDefenseur.Location = new Point((this.Width / 10) * 7, (this.Height / 10));
            _jouerDefenseur.Size = new System.Drawing.Size(175, 175);
            _jouerDefenseur.BackgroundImage = (Image)jouerDefenseur;
            _jouerDefenseur.BackgroundImageLayout = ImageLayout.Stretch;
            _jouerDefenseur.Click += delegate (object sender, EventArgs e)
            {
                _jouerAttaquant.Hide();
                _jouerDefenseur.Hide();
                _RetourChoixAdversaire.Hide();

                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_interfaceOptions, true, false);
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
                _play.Show();
                m_buttonReturn.Show();
                m_PictureBoxInterfaceBoard.Show();
            };
            this.Controls.Add(_jouerDefenseur);
            _jouerDefenseur.BringToFront();

            _RetourChoixAdversaire = new Button();
            _RetourChoixAdversaire.Location = new Point((this.Width / 10) * 4, (this.Height / 10) * 2);
            _RetourChoixAdversaire.Size = new System.Drawing.Size(150, 75);
            _RetourChoixAdversaire.BackgroundImage = (Image)retour;
            _RetourChoixAdversaire.BackgroundImageLayout = ImageLayout.Stretch;
            _RetourChoixAdversaire.Click += delegate (object sender, EventArgs e)
            {
                _jouerAttaquant.Hide();
                _jouerDefenseur.Hide();
                _RetourChoixAdversaire.Hide();
                _RetourChoixPlateau.Show();
                _JoueurVsFreyja.Show();
                _JoueurVsJoueur.Show();
                _play.Show();
                m_buttonReturn.Show();
            };
            this.Controls.Add(_RetourChoixAdversaire);
            _RetourChoixAdversaire.BringToFront();
        }

        private void m_PictureBoxInterfaceBoard_Paint(object sender, PaintEventArgs e)
        {

            Graphics Pawn = e.Graphics;
            Graphics Board = e.Graphics;
            m_PictureBoxInterfaceBoard.BackColor = Color.Black;
            
            Image Piece;
            Image Case;
            Image caseInterdite;
            Image mvtPiecePossible;
            Rectangle Rect;
            

            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            mvtPiecePossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;


            int x = 0, y = _rectanglePositionY;

            for (int j = 0; j < _height; j++)
            {
                x = _rectanglePositionX;
                for (int i = 0; i < _width; i++)
                {
                    if (((i == 0) && (j == 0))
                            || ((i == _width - 1) && (j == _height - 1))
                            || ((i == _width - 1) && (j == 0))
                            || ((i == 0) && (j == _height - 1))
                            || ((i == ((_width - 1) / 2)) && (j == ((_height - 1) / 2))))
                    {
                        Rect = new Rectangle(x, y, _rectangleWidth, _rectangleHeight);
                        Board.DrawImage(caseInterdite, Rect);
                    }
                    else
                    {
                        Rect = new Rectangle(x, y, _rectangleWidth, _rectangleHeight);
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
                    x = x + _nextRectanglePositionX;
                }
                y = y + _nextRectanglePositionY;
            }
        }
    }
}
