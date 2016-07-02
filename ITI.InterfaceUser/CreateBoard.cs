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
using System.Xml.Linq;

namespace ITI.InterfaceUser
{
    public partial class CreateBoard : Form
    {
        InterfaceOptions _interfaceOptions;
        TaflBasic _tafl;
        XML_Tafl _xml;

        NumericUpDown _choixLongueurPlateau;
        NumericUpDown _choixHauteurPlateau;

        TextBox _createTaflName;

        Button _putAtkOnBoard;
        Button _putDefOnBoard;
        Button _putEmptyCase;
        Button _confirmSave;
        Button _cancelSave;
        Button _save;

        Image save;
        Image retour;
        Image cancelSave;
        Image confirmSave;
        Image putDefOnBoard;
        Image putAtkOnBoard;
        Image putEmptyCase;
        int _rectanglePositionX;
        int _rectanglePositionY;
        int _rectangleWidth;
        int _rectangleHeight;
        int _nextRectanglePositionX;
        int _nextRectanglePositionY;

        int _width = 7;
        int _height = 7;
        int _pawn = 0;

        public CreateBoard(InterfaceOptions interfaceOptions)
        {
            InitializeComponent();
            _interfaceOptions = interfaceOptions;
            
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            setLanguages();
            CreateControlNewBoard();
            _confirmSave.Hide();
            _cancelSave.Hide();
            _tafl = new TaflBasic(_width, _height);
            _xml = new XML_Tafl();
        }

        private void setLanguages()
        {
            if (_interfaceOptions.Languages == true)
            {
                putAtkOnBoard = ITI.InterfaceUser.Properties.Resources.insererattaquant;
                putDefOnBoard = ITI.InterfaceUser.Properties.Resources.insererdefenseur;
                putEmptyCase = ITI.InterfaceUser.Properties.Resources.retirerpion;
                confirmSave = ITI.InterfaceUser.Properties.Resources.confirmersauvegarde;
                cancelSave = ITI.InterfaceUser.Properties.Resources.annulersauvegarde;
                save = ITI.InterfaceUser.Properties.Resources.sauvegarder;
                retour = ITI.InterfaceUser.Properties.Resources.Retour;
            }
            else
            {
                putAtkOnBoard = ITI.InterfaceUser.Properties.Resources.insertattacker;
                putDefOnBoard = ITI.InterfaceUser.Properties.Resources.insertdefender;
                putEmptyCase = ITI.InterfaceUser.Properties.Resources.removepawn;
                confirmSave = ITI.InterfaceUser.Properties.Resources.confirmsave;
                cancelSave = ITI.InterfaceUser.Properties.Resources.cancelsave;
                save = ITI.InterfaceUser.Properties.Resources.saveboard;
                retour = ITI.InterfaceUser.Properties.Resources.Return;
            }
        }

        private void setGameBoardInformation()
        {
            _interfaceOptions.setPictureBox(_width, _height);
            _rectanglePositionX = _interfaceOptions.RectanglePositionX;
            _rectanglePositionY = _interfaceOptions.RectanglePositionY;
            _rectangleWidth = _interfaceOptions.RectangleWidth;
            _rectangleHeight = _interfaceOptions.RectangleHeight;
            _nextRectanglePositionX = _interfaceOptions.NextRectanglePositionX;
            _nextRectanglePositionY = _interfaceOptions.NextRectanglePositionY;
        }

        private void m_PictureBoxCreateBoard_Paint(object sender, PaintEventArgs e)
        {
            Rectangle Rect;

            Graphics Board = e.Graphics;
            Graphics Pawn = e.Graphics;

            Image Case;
            Image Piece;
            Image caseInterdite;

            setGameBoardInformation();

            m_PictureBoxCreateBoard.BackColor = Color.Black;
            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.CaseInterdite;

            _tafl[(_width - 1) / 2, (_height - 1) / 2] = GameCore.Pawn.King; ;

            int x = 0;
            int y = _rectanglePositionY;

            for (int j = 0; j < _height; j++)
            {
                x = _rectanglePositionX;
                for (int i = 0; i < _width; i++)
                {
                    if (((i == 0) && (j == 0))
                        || ((i == _width - 1) && (j == _height - 1))
                            || ((i == _width - 1) && (j == 0))
                            || ((i == 0) && (j == _height - 1))
                            || ((i == (_width - 1) / 2) && (j == (_height - 1)/2)))
                    {
                        Rect = new Rectangle(x, y, _rectangleWidth, _rectangleHeight);
                        Board.DrawImage(caseInterdite, Rect);
                    }
                    else
                    {
                        Rect = new Rectangle(x, y, _rectangleWidth, _rectangleHeight);
                        Board.DrawImage(Case, Rect);
                    }
                    
                    if (_tafl[i, j] == GameCore.Pawn.Attacker) 
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionNoir;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (_tafl[i, j] == GameCore.Pawn.Defender) 
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (_tafl[i, j] == GameCore.Pawn.King)   
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionRoi;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    x = x + _nextRectanglePositionX;
                }
                y = y + _nextRectanglePositionY;
            }
        }

        private void m_PictureBoxCreateBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int x = 0, y = 0;

            for (int j = 0; j < _height; j++)
            {
                x = _rectanglePositionX;

                for (int i = 0; i < _width; i++)
                {
                    if (e.X > x && e.X < x + _rectangleWidth && e.Y > y && e.Y < y + _rectangleHeight)
                    {
                        if ((i == 0 && j == 0)
                            || (i == (_width - 1) && j == 0)
                            || (i == 0 && j == (_height - 1))
                            || (i == (_width - 1) && j == (_height - 1))
                            || (i == (_width - 1) / 2 && j == (_height - 1) / 2))
                        {
                            m_PictureBoxCreateBoard.Refresh();
                        }
                        else
                        {
                            if(_pawn == 0)
                            {
                                _tafl[i, j] = Pawn.None;
                            }
                            if(_pawn == 1)
                            {
                                _tafl[i, j] = Pawn.Attacker;
                            }
                            if(_pawn == 2)
                            {
                                _tafl[i, j] = Pawn.Defender;
                            }
                            m_PictureBoxCreateBoard.Refresh();
                        }
                        
                    }
                    x = x + _nextRectanglePositionX;
                }
                y = y + _nextRectanglePositionY;
            }
        }

        private void CreateControlNewBoard()
        {

            #region Button put atk on board
            _putAtkOnBoard = new Button();
            _putAtkOnBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 200);
            _putAtkOnBoard.Size = new System.Drawing.Size(200, 75);
            _putAtkOnBoard.BackgroundImage = (Image)putAtkOnBoard;
            _putAtkOnBoard.BackgroundImageLayout = ImageLayout.Stretch;
            _putAtkOnBoard.Click += delegate (object sender, EventArgs e)
            {
                _pawn = 1;
            };
            this.Controls.Add(_putAtkOnBoard);
            _putAtkOnBoard.BringToFront();
            #endregion

            #region Button put def on board
            _putDefOnBoard = new Button();
            _putDefOnBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 300);
            _putDefOnBoard.Size = new System.Drawing.Size(200, 75);
            _putDefOnBoard.BackgroundImage = (Image)putDefOnBoard;
            _putDefOnBoard.BackgroundImageLayout = ImageLayout.Stretch;
            _putDefOnBoard.Click += delegate (object sender, EventArgs e)
            {
                _pawn = 2;
            };
            this.Controls.Add(_putDefOnBoard);
            _putDefOnBoard.BringToFront();
            #endregion

            #region Button
            _putEmptyCase = new Button();
            _putEmptyCase.Location = new Point(this.Location.X + 550, this.Location.Y + 100);
            _putEmptyCase.Size = new System.Drawing.Size(200, 75);
            _putEmptyCase.BackgroundImage = (Image)putEmptyCase;
            _putEmptyCase.BackgroundImageLayout = ImageLayout.Stretch;
            _putEmptyCase.Click += delegate (object sender, EventArgs e)
            {
                _pawn = 0;
            };
            this.Controls.Add(_putEmptyCase);
            _putEmptyCase.BringToFront();
            #endregion

            #region numericUpDown longueur plateau
            _choixLongueurPlateau = new NumericUpDown();
            _choixLongueurPlateau.Location = new Point(this.Location.X + 650, this.Location.Y + 25);
            _choixLongueurPlateau.Name = "Longueur du plateau";
            _choixLongueurPlateau.Size = new System.Drawing.Size(50, 25);
            _choixLongueurPlateau.Minimum = 7;
            _choixLongueurPlateau.Maximum = 15;
            _choixLongueurPlateau.Increment = 2;
            _choixLongueurPlateau.Click += delegate (object sender, EventArgs e)
            {
                _width = Longueur;
                _tafl = new TaflBasic(_width, _height);
                m_PictureBoxCreateBoard.Refresh();
            };
            this.Controls.Add(_choixLongueurPlateau);
            _choixLongueurPlateau.BringToFront();
            #endregion

            #region numericUpDown hauteur plateau
            _choixHauteurPlateau = new NumericUpDown();
            _choixHauteurPlateau.Location = new Point(this.Location.X + 650, this.Location.Y + 50);
            _choixHauteurPlateau.Name = "Longueur du plateau";
            _choixHauteurPlateau.Size = new System.Drawing.Size(50, 25);
            _choixHauteurPlateau.Minimum = 7;
            _choixHauteurPlateau.Maximum = 15;
            _choixHauteurPlateau.Increment = 2;
            _choixHauteurPlateau.Click += delegate (object sender, EventArgs e)
            {
                _height = Hauteur;
                _tafl = new TaflBasic(_width, _height);
                m_PictureBoxCreateBoard.Refresh();
            };
            this.Controls.Add(_choixHauteurPlateau);
            _choixHauteurPlateau.BringToFront();
            #endregion

            #region Button save
            _save = new Button();
            _save.Location = new Point(this.Location.X + 550, this.Location.Y + 390);
            _save.Size = new System.Drawing.Size(200, 75);
            _save.BackgroundImage = (Image)save;
            _save.BackgroundImageLayout = ImageLayout.Stretch;
            _save.Click += delegate (object sender, EventArgs e)
            {
                _putAtkOnBoard.Hide();
                _putDefOnBoard.Hide();
                _choixHauteurPlateau.Hide();
                _choixLongueurPlateau.Hide();
                _putEmptyCase.Hide();
                _save.Hide();
                _confirmSave.Show();
                _cancelSave.Show();

                _createTaflName = new TextBox();
                _createTaflName.Location = new Point(this.Width - 235, this.Location.Y + 50);
                _createTaflName.Size = new System.Drawing.Size(200, 75);
                _createTaflName.Text = "";
                this.Controls.Add(_createTaflName);
                _createTaflName.BringToFront();
            };
            this.Controls.Add(_save);
            _save.BringToFront();
            #endregion

            #region Button confirm save
            _confirmSave = new Button();
            _confirmSave.Location = new Point(this.Location.X + 550, this.Location.Y + 250);
            _confirmSave.Size = new System.Drawing.Size(200, 75);
            _confirmSave.BackgroundImage = (Image)confirmSave;
            _confirmSave.BackgroundImageLayout = ImageLayout.Stretch;
            _confirmSave.Click += delegate (object sender, EventArgs e)
            {
                SaveBoard();
            };
            this.Controls.Add(_confirmSave);
            _confirmSave.BringToFront();
            #endregion

            #region Button Cancel save
            _cancelSave = new Button();
            _cancelSave.Location = new Point(this.Location.X + 550, this.Location.Y + 350);
            _cancelSave.Size = new System.Drawing.Size(200, 75);
            _cancelSave.BackgroundImage = (Image)cancelSave;
            _cancelSave.BackgroundImageLayout = ImageLayout.Stretch;
            _cancelSave.Click += delegate (object sender, EventArgs e)
            {

                _confirmSave.Hide();
                _createTaflName.Hide();
                _cancelSave.Hide();
                _choixLongueurPlateau.Show();
                _choixHauteurPlateau.Show();
                _putAtkOnBoard.Show();
                _putDefOnBoard.Show();
                _putEmptyCase.Show();
                _save.Show();
            };
            this.Controls.Add(_cancelSave);
            _cancelSave.BringToFront();
            #endregion

           

            m_buttonReturn.BackgroundImage = (Image)retour;
            m_buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            m_buttonReturn.BringToFront();
        }
        
        
        public int Longueur
        {
            get
            {
                return(Convert.ToInt32(_choixLongueurPlateau.Value));
            }
        }

        public int Hauteur
        {
            get
            {
                return (Convert.ToInt32(_choixHauteurPlateau.Value));
            }
        }

        private void SaveBoard()
        {
            if(CheckEmptyName() == true)
            {
                NoSaveBoard();
            }
            else if(CheckSameName() == true)
            {
                NoSaveBoard();
            }
            else
            {
                ConfirmSaveBoard();
            }
            
        }

        private void NoSaveBoard()
        {
            if (_interfaceOptions.Languages == true)
            {
                MessageBox.Show("Votre plateau n'a pas été sauvergardé ! ",
                "Sauvegarde du plateau échoué",
                MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Your board has not been saved !",
                "Save Board failed",
                MessageBoxButtons.OK);
            }
        }

        private void ConfirmSaveBoard()
        {

            //_xml.WriteXmlTafl(_tafl);
            //_xml.WriteXmlTafl(_tafl,_createTaflName.Text);
            if (_interfaceOptions.Languages == true)
            {
                MessageBox.Show("Votre plateau a été sauvergardé sous le nom de " + _createTaflName.Text,
                "Sauvegarde du plateau",
                MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Your board has been saved !",
                "Save Board",
                MessageBoxButtons.OK);
            }
        }

        private bool CheckEmptyName()
        {
            if(_createTaflName.Text == (""))
            {
                if (_interfaceOptions.Languages == true)
                {
                    MessageBox.Show("Vous devez choisir un nom de sauvegarde",
                    "Attention sauvegarde sans nom",
                    MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("You have to give a name to your save !",
                    "Warning save without name",
                    MessageBoxButtons.OK);
                }
                return true;
            }
            return false;
        }

        private bool CheckSameName()
        {
            int _countSameName = 0;

            ListBox listboxBoardSave = new ListBox();
            listboxBoardSave.Items.Clear();
            string[] fileName;
            string road = _interfaceOptions.RoadTaflSave;
            fileName = Directory.GetFileSystemEntries(road);
            string fileBoardName;
            foreach (string current in fileName)
            {
                fileBoardName = Path.GetFileNameWithoutExtension(current);
                listboxBoardSave.Items.Add(fileBoardName);
            }
            foreach (string current in listboxBoardSave.Items)
            {
                _countSameName++;
                if (current == _createTaflName.Text)
                {
                    if (_interfaceOptions.Languages == true)
                    {
                        if(MessageBox.Show("Voulez vous sauvegarder avec ce nom et supprimez l'ancien plateau",
                        "Attention deux sauvegardes avec le meme nom",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return true;
                        }else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if(MessageBox.Show("Do you want to save with this name and delete the last board !",
                        "Warning two boards with the same name",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return true;
                        }else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

    }
}
