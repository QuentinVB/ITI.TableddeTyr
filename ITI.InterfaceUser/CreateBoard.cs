using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;

namespace ITI.InterfaceUser
{
    public partial class CreateBoard : Form
    {
        NumericUpDown _choixLongueurPlateau;
        NumericUpDown _choixHauteurPlateau;

        Button _putAtkOnBoard;
        Button _putDefOnBoard;
        Button _generateBoard;
        Button _confirmSave;
        Button _cancelSave;
        Button _save;

        TextBox _textBoxName;
        TextBox _textBoxTest;

        int _valeurXBoard;
        int _valeurYBoard;
        int _widthBoard;
        int _heightBoard;
        int _valeurXBoardNextCase;
        int _valeurYBoardNextCase;

        int _width = 15;
        int _height = 15;

        int[,] plateau;
        int _pawn = 0;

        public CreateBoard()
        {
            InitializeComponent();
            CreateControlNewBoard();
        }

        private void m_PictureBoxCreateBoard_Paint(object sender, PaintEventArgs e)
        {
            int x = 0, y = 0;
            Rectangle Rect;

            Graphics Board = e.Graphics;
            Graphics Pawn = e.Graphics;

            Image Case;
            Image Piece;
            Image caseInterdite;

            plateau = new int[_width, _height];

            #region variable création plateau
            if(_width == 7)
            {
                _valeurXBoard = 3;
                _widthBoard = 70;
                _valeurXBoardNextCase = 73;
            }
            if(_width == 9)
            {
                _valeurXBoard = 6;
                _widthBoard = 53;
                _valeurXBoardNextCase = 56;
            }
            if (_width == 11)
            {
                _valeurXBoard = 5;
                _widthBoard = 43;
                _valeurXBoardNextCase = 46;
            }
            if (_width == 13)
            {
                _valeurXBoard = 5;
                _widthBoard = 36;
                _valeurXBoardNextCase = 39;
            }
            if (_width == 15)
            {
                _valeurXBoard = 4;
                _widthBoard = 31;
                _valeurXBoardNextCase = 34;
            }

            if (_height == 7)
            {
                _valeurYBoard = 3;
                _heightBoard = 70;
                _valeurYBoardNextCase = 73;
            }
            if (_height == 9)
            {
                _valeurYBoard = 6;
                _heightBoard = 53;
                _valeurYBoardNextCase = 56;
            }
            if (_height == 11)
            {
                _valeurYBoard = 5;
                _heightBoard = 43;
                _valeurYBoardNextCase = 46;
            }
            if (_height == 13)
            {
                _valeurYBoard = 5;
                _heightBoard = 36;
                _valeurYBoardNextCase = 39;
            }
            if (_height == 15)
            {
                _valeurYBoard = 4;
                _heightBoard = 31;
                _valeurYBoardNextCase = 34;

            }
            #endregion

            m_PictureBoxCreateBoard.BackColor = Color.Black;
            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.PawnHnefatafl;

            plateau[(_width - 1) / 2, (_height - 1) / 2] = 3;

            y = _valeurYBoard;

            for (int j = 0; j < _height; j++)
            {
                x = _valeurXBoard;
                for (int i = 0; i < _width; i++)
                {
                    if (((i == 0) && (j == 0))
                        || ((i == _width - 1) && (j == _height - 1))
                            || ((i == _width - 1) && (j == 0))
                            || ((i == 0) && (j == _height - 1)))
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                        Board.DrawImage(caseInterdite, Rect);
                    }
                    else
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                        Board.DrawImage(Case, Rect);
                    }
                    
                    if (plateau[i, j] == 1)     // test
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionNoir;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (plateau[i, j] == 2)     // test
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (plateau[i, j] == 3)     // test
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionRoi;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    x = x + _valeurXBoardNextCase;
                }
                y = y + _valeurYBoardNextCase;
            }
        }

        private void m_PictureBoxCreateBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int x = 0, y = 0;

            for (int j = 0; j < _height; j++)
            {
                x = _valeurXBoard;

                for (int i = 0; i < _width; i++)
                {
                    if (e.X > x && e.X < x + _widthBoard && e.Y > y && e.Y < y + _heightBoard)
                    {
                        plateau[i, j] = _pawn;
                        m_PictureBoxCreateBoard.Refresh();
                    }
                    x = x + _valeurXBoardNextCase;
                }
                y = y + _valeurYBoardNextCase;
            }
        }

        private void CreateControlNewBoard()
        {
            #region Button put atk on board
            _putAtkOnBoard = new Button();
            _putAtkOnBoard.Text = "Cliquez pour placer des attaquants sur le plateau";
            _putAtkOnBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 200);
            _putAtkOnBoard.Size = new System.Drawing.Size(150, 75);
            _putAtkOnBoard.Click += delegate (object sender, EventArgs e)
            {
                _pawn = 1;
            };
            this.Controls.Add(_putAtkOnBoard);
            _putAtkOnBoard.BringToFront();
            #endregion

            #region Button put def on board
            _putDefOnBoard = new Button();
            _putDefOnBoard.Text = "Cliquez pour placer des défenseurs sur le plateau";
            _putDefOnBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 300);
            _putDefOnBoard.Size = new System.Drawing.Size(150, 75);
            _putDefOnBoard.Click += delegate (object sender, EventArgs e)
            {
                _pawn = 2;
            };
            this.Controls.Add(_putDefOnBoard);
            _putDefOnBoard.BringToFront();
            #endregion

            #region Button générer plateau 
            _generateBoard = new Button();
            _generateBoard.Text = "Génerer le plateau personnalisé";
            _generateBoard.Location = new Point(this.Location.X + 550, this.Location.Y + 100);
            _generateBoard.Size = new System.Drawing.Size(150, 75);
            _generateBoard.Click += delegate (object sender, EventArgs e)
            {
                m_PictureBoxCreateBoard.Refresh();
            };
            this.Controls.Add(_generateBoard);
            _generateBoard.BringToFront();
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
            };
            this.Controls.Add(_choixHauteurPlateau);
            _choixHauteurPlateau.BringToFront();
            #endregion

            #region Button save
            _save = new Button();
            _save.Text = "Sauvegardez le nouveau plateau";
            _save.Location = new Point(this.Location.X + 550, this.Location.Y + 390);
            _save.Size = new System.Drawing.Size(150, 75);
            _save.Click += delegate (object sender, EventArgs e)
            {
                _putAtkOnBoard.Hide();
                _putDefOnBoard.Hide();
                _choixHauteurPlateau.Hide();
                _choixLongueurPlateau.Hide();
                _generateBoard.Hide();
                _save.Hide();
                saveNewBoard();
            };
            this.Controls.Add(_save);
            _save.BringToFront();
            #endregion
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

        private void saveNewBoard()
        {

            #region Button confirm save
            _confirmSave = new Button();
            _confirmSave.Text = "Confirmer la sauvegarde du plateau";
            _confirmSave.Location = new Point(this.Location.X + 500, this.Location.Y + 100);
            _confirmSave.Size = new System.Drawing.Size(150, 75);
            _confirmSave.Click += delegate (object sender, EventArgs e)
            {
                _textBoxTest = new TextBox();
                _textBoxTest.Location = new Point(this.Location.X + 250, this.Location.Y + 300);
                _textBoxTest.Text = saveName;
                _textBoxTest.Size = new System.Drawing.Size(50, 150);
                this.Controls.Add(_textBoxTest);
                _textBoxTest.BringToFront();
            };
            this.Controls.Add(_confirmSave);
            _confirmSave.BringToFront();
            #endregion

            #region Button Cancel save
            _cancelSave = new Button();
            _cancelSave.Text = "Annuler la sauvegarde du plateau";
            _cancelSave.Location = new Point(this.Location.X + 500, this.Location.Y + 200);
            _cancelSave.Size = new System.Drawing.Size(150, 75);
            _cancelSave.Click += delegate (object sender, EventArgs e)
            {
                _choixLongueurPlateau.Show();
                _choixHauteurPlateau.Show();
                _putAtkOnBoard.Show();
                _putDefOnBoard.Show();
                _generateBoard.Show();
                _save.Show();
                _confirmSave.Hide();
                _cancelSave.Hide();
            };
            this.Controls.Add(_cancelSave);
            _cancelSave.BringToFront();
            #endregion
            /*
            _textBoxName = new TextBox();
            _textBoxName.Location = new Point(this.Location.X + 450, this.Location.Y + 300);
            _textBoxName.Size = new System.Drawing.Size(50, 150);
            _textBoxName.Text = "unnamed";
            this.Controls.Add(_textBoxName);
            _textBoxName.BringToFront();*/
        }

        public string saveName
        {
            get
            {
                return _textBoxName.Text;
            }
        }
        
        private void saveBoard()
        {
            

            TextBox textBoxName = new TextBox();
            TextBox textBoxTest = new TextBox();

            textBoxName.Text = "aAé2@=";

            XDocument test = new XDocument(
                new XElement("user",
                    new XElement("name", textBoxName.Text)
                )
            );
            test.Save("user.xml");

            //
            textBoxTest.Location = new Point(this.Location.X + 450, this.Location.Y + 300);
            textBoxTest.Text = Convert.ToString(test);
            textBoxTest.Size = new System.Drawing.Size(50, 150);
            this.Controls.Add(textBoxTest);
            textBoxTest.BringToFront();
            //

        }
        

    }
}
