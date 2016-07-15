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
using System.IO;

namespace ITI.InterfaceUser
{
    public partial class PlayInterface : Form
    {
        XML_Tafl _xml;
        TaflBasic _tafl;

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

        int _rectanglePositionX;
        int _rectanglePositionY;
        int _rectangleWidth;
        int _rectangleHeight;
        int _nextRectanglePositionX;
        int _nextRectanglePositionY;
        bool _BoardChooseLoad;

        string _nameTaflLoad;


        public PlayInterface(InterfaceOptions interfaceoptions)
        {
            InitializeComponent();
            _xml = new XML_Tafl();
            _interfaceOptions = interfaceoptions;

            this.Text = _interfaceOptions.Title;
            this.Refresh();
            setInterfaceBoard();

            setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
            _tafl = _xml.ReadXmlTafl(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
            m_PictureBoxInterfaceBoard.Refresh();

            listboxtest.Hide();
            listboxtest.ScrollAlwaysVisible = true;
            
        }

        private void setPlateau(int width, int height)
        {
            if (width == 7)
            {
                _rectanglePositionX = 3;
                _rectangleWidth = 61;
                _nextRectanglePositionX = 64;
                
            }
            if(height == 7)
            {
                _rectanglePositionY = 4;
                _rectangleHeight = 60;
                _nextRectanglePositionY = 63;
            }

            if(width == 9)
            {
                _rectanglePositionX = 2;
                _rectangleWidth = 47;
                _nextRectanglePositionX = 50;
                
            }

            if(height == 9)
            {
                _rectanglePositionY = 4;
                _rectangleHeight = 46;
                _nextRectanglePositionY = 49;
            }

            if(width == 11)
            {
                _rectanglePositionX = 6;
                _rectangleWidth = 37;
                _nextRectanglePositionX = 40;
            }

            if(height == 11)
            {
                _rectanglePositionY = 5;
                _rectangleHeight = 37;
                _nextRectanglePositionY = 40;
            }

            if(width == 13)
            {
                _rectanglePositionX = 5;
                _rectangleWidth = 31;
                _nextRectanglePositionX = 34;
                
            }

            if(height == 13)
            {
                _rectanglePositionY = 4;
                _rectangleHeight = 31;
                _nextRectanglePositionY = 34;
            }
        }

        

        private void setInterfaceBoard()
        {

            _button7x7 = new Button();
            _button7x7.Location = new Point(this.Location.X + 25, this.Location.Y + 5);
            _button7x7.Size = new System.Drawing.Size(150, 75);
            _button7x7.BackgroundImage = (Image)_interfaceOptions.ImageBoard7x7;
            _button7x7.BackgroundImageLayout = ImageLayout.Stretch;
            _button7x7.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.BoardWidth = 7;
                _interfaceOptions.BoardHeight = 7;
                m_PictureBoxInterfaceBoard.Show();
                listboxtest.Hide();
                _BoardChooseLoad = false;
                setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                _tafl = _xml.ReadXmlTafl(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                m_PictureBoxInterfaceBoard.Refresh();
                
            };
            this.Controls.Add(_button7x7);
            _button7x7.BringToFront();
            

            _button9x9 = new Button();
            _button9x9.Location = new Point(_button7x7.Location.X + 180, _button7x7.Location.Y);
            _button9x9.Size = new System.Drawing.Size(150, 75);
            _button9x9.BackgroundImage = (Image)_interfaceOptions.ImageBoard9x9;
            _button9x9.BackgroundImageLayout = ImageLayout.Stretch;
            _button9x9.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.BoardWidth = 9;
                _interfaceOptions.BoardHeight = 9;
                m_PictureBoxInterfaceBoard.Show();
                listboxtest.Hide();
                _BoardChooseLoad = false;
                setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                _tafl = _xml.ReadXmlTafl(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button9x9);
            _button9x9.BringToFront();
            
            
            _button11x11 = new Button();
            _button11x11.Location = new Point(_button9x9.Location.X + 180, _button9x9.Location.Y);
            _button11x11.Size = new System.Drawing.Size(150, 75);
            _button11x11.BackgroundImage = (Image)_interfaceOptions.ImageBoard11x11;
            _button11x11.BackgroundImageLayout = ImageLayout.Stretch;
            _button11x11.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.BoardWidth = 11;
                _interfaceOptions.BoardHeight = 11;
                m_PictureBoxInterfaceBoard.Show();
                listboxtest.Hide();
                _BoardChooseLoad = false;
                setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                _tafl = _xml.ReadXmlTafl(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button11x11);
            _button11x11.BringToFront();


            _button13x13 = new Button();
            _button13x13.Location = new Point(_button11x11.Location.X + 180, _button11x11.Location.Y);
            _button13x13.Size = new System.Drawing.Size(150, 75);
            _button13x13.BackgroundImage = (Image)_interfaceOptions.ImageBoard13x13;
            _button13x13.BackgroundImageLayout = ImageLayout.Stretch;
            _button13x13.Click += delegate (object sender, EventArgs e)
            {
                _interfaceOptions.BoardWidth = 13;
                _interfaceOptions.BoardHeight = 13;
                m_PictureBoxInterfaceBoard.Show();
                listboxtest.Hide();
                _BoardChooseLoad = false;
                setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                _tafl = _xml.ReadXmlTafl(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_button13x13);
            _button13x13.BringToFront();

            _CreateBoard = new Button();
            _CreateBoard.Location = new Point(this.Location.X + 480, this.Location.Y + 200);
            _CreateBoard.Size = new System.Drawing.Size(250, 75);
            _CreateBoard.BackgroundImage = (Image)_interfaceOptions.ImageCreateBoard;
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
                _interfaceOptions.BoardWidth = 7;
                _interfaceOptions.BoardHeight = 7;
                listboxtest.Hide();
                m_PictureBoxInterfaceBoard.Show();
                setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                _tafl = _xml.ReadXmlTafl(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                m_PictureBoxInterfaceBoard.Refresh();
            };
            this.Controls.Add(_CreateBoard);
            _CreateBoard.BringToFront();


            _loadBoard = new Button();
            _loadBoard.Location = new Point(this.Location.X + 480, this.Location.Y + 300);
            _loadBoard.Size = new System.Drawing.Size(250, 75);
            _loadBoard.BackgroundImage = (Image)_interfaceOptions.ImageLoadBoard;
            _loadBoard.BackgroundImageLayout = ImageLayout.Stretch;
            _loadBoard.Click += delegate (object sender, EventArgs e)
            {
                listboxtest.Items.Clear();
                string[] fileName;
                string road = _interfaceOptions.RoadTaflSave;
                fileName = Directory.GetFileSystemEntries(road);
                string test;
                foreach (string current in fileName)
                {
                    test = Path.GetFileNameWithoutExtension(current);
                    listboxtest.Items.Add(test);
                    listboxtest.Show();
                    m_PictureBoxInterfaceBoard.Hide();
                }
            };
            this.Controls.Add(_loadBoard);
            _loadBoard.BringToFront();



            _play = new Button();
            _play.Location = new Point(this.Location.X + 465, this.Location.Y + 465);
            _play.Size = new System.Drawing.Size(150, 75);
            _play.BackgroundImage = (Image)_interfaceOptions.ImagePlay;
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
                listboxtest.Hide();
                m_buttonReturn.Hide();
                createButtonChoixAdversaire();
            };
            this.Controls.Add(_play);
            _play.BringToFront();

            
            m_buttonReturn.BackgroundImage = (Image)_interfaceOptions.ImageReturn;
            m_buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            m_buttonReturn.BringToFront();
        }

        private void createButtonChoixAdversaire()
        {
            
            _JoueurVsJoueur = new Button();
            _JoueurVsJoueur.Location = new Point((this.Width /20), (this.Height / 10));
            _JoueurVsJoueur.Size = new System.Drawing.Size(250, 300);
            _JoueurVsJoueur.BackgroundImage = (Image)_interfaceOptions.ImagePlayerVsPlayer;
            _JoueurVsJoueur.BackgroundImageLayout = ImageLayout.Stretch;
            _JoueurVsJoueur.Click += delegate (object sender, EventArgs e)
            {
                _JoueurVsFreyja.Hide();
                _JoueurVsJoueur.Hide();
                _RetourChoixPlateau.Hide(); 
                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_interfaceOptions, false, false, _BoardChooseLoad, _nameTaflLoad);
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
            _JoueurVsFreyja.Location = new Point((this.Width / 20) * 12, (this.Height / 10));
            _JoueurVsFreyja.Size = new System.Drawing.Size(250, 300);
            _JoueurVsFreyja.BackgroundImage = (Image)_interfaceOptions.ImagePlayerVsIa;
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
            _RetourChoixPlateau.Location = new Point((this.Width / 10) * 4, (this.Height / 10) * 8);
            _RetourChoixPlateau.Size = new System.Drawing.Size(150, 75);
            _RetourChoixPlateau.BackgroundImage = (Image)_interfaceOptions.ImageReturn;
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
                listboxtest.Hide();
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
            _jouerAttaquant.Location = new Point((this.Width / 20), (this.Height / 10));
            _jouerAttaquant.Size = new System.Drawing.Size(250, 300);
            _jouerAttaquant.BackgroundImage = (Image)_interfaceOptions.ImagePlayAttacker;
            _jouerAttaquant.BackgroundImageLayout = ImageLayout.Stretch;
            _jouerAttaquant.Click += delegate (object sender, EventArgs e)
            {
                _jouerAttaquant.Hide();
                _jouerDefenseur.Hide();
                _RetourChoixAdversaire.Hide();

                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_interfaceOptions, false, true, _BoardChooseLoad, _nameTaflLoad);
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
            _jouerDefenseur.Location = new Point((this.Width / 20) * 12, (this.Height / 10));
            _jouerDefenseur.Size = new System.Drawing.Size(250, 300);
            _jouerDefenseur.BackgroundImage = (Image)_interfaceOptions.ImagePlayDefender;
            _jouerDefenseur.BackgroundImageLayout = ImageLayout.Stretch;
            _jouerDefenseur.Click += delegate (object sender, EventArgs e)
            {
                _jouerAttaquant.Hide();
                _jouerDefenseur.Hide();
                _RetourChoixAdversaire.Hide();

                this.Hide();
                m_GameBoard GameBoard = new m_GameBoard(_interfaceOptions, true, false, _BoardChooseLoad, _nameTaflLoad);
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
            _RetourChoixAdversaire.Location = new Point((this.Width / 10) * 4, (this.Height / 10) * 8);
            _RetourChoixAdversaire.Size = new System.Drawing.Size(150, 75);
            _RetourChoixAdversaire.BackgroundImage = (Image)_interfaceOptions.ImageReturn;
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
            Rectangle Rect;
            Graphics Draw = e.Graphics;
            m_PictureBoxInterfaceBoard.BackColor = Color.Black;
            

            int y = _rectanglePositionY;

            for (int j = 0; j < _interfaceOptions.BoardHeight; j++)
            {
                int x = _rectanglePositionX;
                for (int i = 0; i < _interfaceOptions.BoardWidth; i++)
                {
                    Rect = new Rectangle(x, y, _rectangleWidth, _rectangleHeight);
                    if (((i == 0) && (j == 0))
                            || ((i == _interfaceOptions.BoardWidth - 1) && (j == _interfaceOptions.BoardHeight - 1))
                            || ((i == _interfaceOptions.BoardWidth - 1) && (j == 0))
                            || ((i == 0) && (j == _interfaceOptions.BoardHeight - 1))
                            || ((i == ((_interfaceOptions.BoardWidth - 1) / 2)) && (j == ((_interfaceOptions.BoardHeight - 1) / 2))))
                    {
                        Draw.DrawImage(_interfaceOptions.ImageForbiddenSquare, Rect);
                    }
                    else
                    {
                        Draw.DrawImage(_interfaceOptions.ImageSquare, Rect);
                    }

                    if (_tafl[i, j] == GameCore.Pawn.Attacker)
                    {
                        Draw.DrawImage(_interfaceOptions.ImageAtkPawnDesignUse, Rect);
                    }
                    if (_tafl[i, j] == GameCore.Pawn.Defender)
                    {
                        Draw.DrawImage(_interfaceOptions.ImageDefPawnDesignUse, Rect);
                    }
                    if (_tafl[i, j] == GameCore.Pawn.King)
                    {
                        Draw.DrawImage(_interfaceOptions.ImageKingPawn, Rect);
                    }
                    x = x + _nextRectanglePositionX;
                }
                y = y + _nextRectanglePositionY;
            }
        }

        private void plateau_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(listboxtest.Text != (""))
            {
                _nameTaflLoad = listboxtest.SelectedItem.ToString();

                if (_interfaceOptions.Languages == true)
                {
                    if (MessageBox.Show("Chargement du plateau !",
                       "Voulez vous charger ce plateau ?",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _tafl = _xml.ReadXmlTafl(_nameTaflLoad);
                        listboxtest.Hide();
                        _interfaceOptions.BoardHeight = _tafl.Height;
                        _interfaceOptions.BoardWidth = _tafl.Width;
                        _BoardChooseLoad = true;
                        setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                        m_PictureBoxInterfaceBoard.Show();
                        m_PictureBoxInterfaceBoard.Refresh();
                    }
                    else
                    {
                        listboxtest.Hide();
                        m_PictureBoxInterfaceBoard.Show();
                    }
                }
                else
                {
                    if (MessageBox.Show("Loading Board !",
                    "Do you want to load this board ?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _tafl = _xml.ReadXmlTafl(_nameTaflLoad);
                        listboxtest.Hide();
                        _interfaceOptions.BoardHeight = _tafl.Height;
                        _interfaceOptions.BoardWidth = _tafl.Width;
                        _BoardChooseLoad = true;
                        setPlateau(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
                        m_PictureBoxInterfaceBoard.Show();
                        m_PictureBoxInterfaceBoard.Refresh();
                    }
                    else
                    {
                        listboxtest.Hide();
                        m_PictureBoxInterfaceBoard.Show();
                    }

                }
            }
            
            
        }
    }
}
