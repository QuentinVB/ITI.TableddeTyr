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
    public partial class Tutoriel : Form
    {
        
        Button _lastExplanation;
        Button _showGameRules;
        Button _help;
        TextBox _showTutorielExplanation;

        
        bool _atkTurn = true;
        int _width = 7;
        int _height = 7;
        int[,] _plateau;
        string _temp;
        string _text;
        int _count = 0;
        int _ValidateStepTutoriel = 0;


        //////////////
        int _valeurXBoard;
        int _valeurYBoard;
        int _widthBoard;
        int _heightBoard;
        int _valeurXBoardNextCase;
        int _valeurYBoardNextCase;
        //

        int[,] _mvtPossible;
        int _pawnMoveX = 9;
        int _pawnMoveY = 9;
        int _pawnDestinationX = 9;
        int _pawnDestinationY = 9;
        bool _firstClick = false;



        /// <summary>
        /// le tutoriel permet au joueur de tester différent cas de figuer du jeux possibles
        /// le tutoriel est scripté entièrement et 
        /// permet uniquement au joueur de faire ce que le programmeur veut qu'il fasse.
        /// </summary>
        public Tutoriel()
        {
            InitializeComponent();
            _mvtPossible = new int[_width, _height];
            createTutorielform();
            InitializeBoard();
            tutorielStep();
        }

        private void tutorielStep()
        {
            if(_count < 0)
            {
                _count = 0;
            }
            if(_count > _ValidateStepTutoriel)
            {
                _count = _ValidateStepTutoriel;
            }

            if(_count == 0 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                firstStep();
            }
            if(_count == 1 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                secondStep();
            }
            if(_count == 2 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                thirdStep();
            }
            if(_count == 3 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                fourthStep();
            }
            if(_count == 4 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                fifthStep();
            }
            if(_count == 5 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                sixthStep();
            }
            if(_count == 6 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                seventhStep();
            }
            if (_count == 7 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                eighthStep();
            }
            if (_count == 8 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                ninthStep();
            }
            if (_count == 9 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                tenthStep();
            }
            if (_count == 10 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                eleventhStep();
            }
            if (_count == 11 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                twelfthStep();
            }
            if (_count == 12 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                thirteenthStep();
            }
            if (_count == 13 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = true;
                fourteenthStep();
            }
            if (_count == 14 && _ValidateStepTutoriel == _count)
            {
                _atkTurn = false;
                fifteenthStep();
            }
        }

        private void setPawn()
        {
            _pawnDestinationX = 9;
            _pawnDestinationY = 9;
            _pawnMoveX = 9;
            _pawnMoveY = 9;
        }

        private void InitializeBoard()
        {
            _plateau = new int[_width, _height];

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
        }

        private void createTutorielform()
        {

            _help = new Button();
            _help.Text = "Aide aux joueurs";
            _help.Location = new Point(this.Location.X + 50, this.Location.Y + 465);
            _help.Size = new System.Drawing.Size(150, 75);
            _help.Click += delegate (object sender, EventArgs e)
            {

            };
            this.Controls.Add(_help);
            _help.BringToFront();


            _lastExplanation = new Button();
            _lastExplanation.Text = "Continuer";
            _lastExplanation.Location = new Point(this.Location.X + 250, this.Location.Y + 465);
            _lastExplanation.Size = new System.Drawing.Size(150, 75);
            _lastExplanation.Click += delegate (object sender, EventArgs e)
            {
                if(_count == 14)
                {

                }else
                {
                    _count++;
                    tutorielStep();
                }
                
            };
            this.Controls.Add(_lastExplanation);
            _lastExplanation.BringToFront();


            _showGameRules = new Button();
            _showGameRules.Text = "Règles du jeu";
            _showGameRules.Location = new Point(this.Location.X + 450, this.Location.Y + 465);
            _showGameRules.Size = new System.Drawing.Size(150, 75);
            _showGameRules.Click += delegate (object sender, EventArgs e)
            {
                HnefataflRules Rules = new HnefataflRules();
                if (Rules.ShowDialog() == DialogResult.Cancel)
                {
                    Rules.Dispose();
                }

            };
            this.Controls.Add(_showGameRules);
            _showGameRules.BringToFront();


            _showTutorielExplanation = new TextBox();
            _showTutorielExplanation.Location = new Point(this.Location.X + 500, this.Location.Y + 25);
            _showTutorielExplanation.Size = new System.Drawing.Size(225, 300);
            _showTutorielExplanation.Multiline = true;
            this.Controls.Add(_showTutorielExplanation);
            _showTutorielExplanation.BringToFront();
        }

        private void m_PictureBoxTutorielBoard_Paint(object sender, PaintEventArgs e)
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
            _widthBoard = (m_PictureBoxTutorielBoard.Width - (_valeurXBoard * _width + 1)) / _width;
            _heightBoard = (m_PictureBoxTutorielBoard.Height - (_valeurYBoard * _height + 1)) / _height;
            _valeurXBoardNextCase = _widthBoard + _valeurXBoard; ;
            _valeurYBoardNextCase = _heightBoard + _valeurYBoard;
            ///////

            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            mvtPiecePossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            m_PictureBoxTutorielBoard.BackColor = Color.Black;


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

                    if (_mvtPossible[i, j] == 1)
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                        Board.DrawImage(mvtPiecePossible, Rect);
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

        private void m_PictureBoxTutorielBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int x = 0, y = 0;
            int pawnplay;

            _valeurXBoard = 3;
            _valeurYBoard = 3;
            _widthBoard = (m_PictureBoxTutorielBoard.Width - (_valeurXBoard * _width + 1)) / _width;
            _heightBoard = (m_PictureBoxTutorielBoard.Height - (_valeurYBoard * _height + 1)) / _height;
            _valeurXBoardNextCase = _widthBoard + _valeurXBoard; ;
            _valeurYBoardNextCase = _heightBoard + _valeurYBoard;

            if (_atkTurn == true)
            {
                pawnplay = 1;
            }
            else
            {
                pawnplay = 2;
            }

            if(_atkTurn == false)
            {
                for (int j = 0; j < _height; j++)
                {
                    x = _valeurXBoard;

                    for (int i = 0; i < _width; i++)
                    {
                        if (e.X > x && e.X < x + _widthBoard && e.Y > y && e.Y < y + _heightBoard)
                        {
                            if (_firstClick == false)
                            {

                                if ((_plateau[i, j] != 0) &&
                                        ((_plateau[i, j] == 1) && (pawnplay == 1))
                                        || ((_plateau[i, j] == 2) && (pawnplay == 2))
                                        || ((_plateau[i, j] == 3) && (pawnplay == 2))
                                        )
                                {
                                    _firstClick = true;
                                    _pawnMoveX = i;
                                    _pawnMoveY = j;
                                    showHelpPlayer(_pawnMoveX, _pawnMoveY);
                                    m_PictureBoxTutorielBoard.Refresh();

                                }
                            }
                            else
                            {

                                if ((_plateau[i, j] != _plateau[_pawnMoveX, _pawnMoveY])
                                    && (_plateau[i, j] == 0)
                                    && (_mvtPossible[i, j] == 1))
                                {
                                    _pawnDestinationX = i;
                                    _pawnDestinationY = j;
                                    _firstClick = false;
                                    resetHelpPlayer();
                                    m_PictureBoxTutorielBoard.Refresh();
                                    tutorielStep();
                                }else
                                {
                                    _firstClick = false;
                                    resetHelpPlayer();
                                    m_PictureBoxTutorielBoard.Refresh();
                                }
                            }
                        
                        }
                        x = x + _valeurXBoardNextCase;
                    }
                    y = y + _valeurYBoardNextCase;
                }
            }
            
        }

        private void resetHelpPlayer()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _mvtPossible[x, y] = 0;
                }
            }
        }

        private void showHelpPlayer(int pawnLocationX, int pawnLocationY)
        {
            int x = 0, y = 0;

            for (x = pawnLocationX - 1; x >= 0; x--)
            {
                if ((_plateau[x, pawnLocationY] != 0)
                    || ((x == 0) && (pawnLocationY == 0) && (_plateau[pawnLocationX, pawnLocationY] != 3))
                    || ((x == 0) && (pawnLocationY == _height - 1) && (_plateau[pawnLocationX, pawnLocationY] != 3)))
                {
                    break;
                }
                else
                {
                    _mvtPossible[x, pawnLocationY] = 1;
                }
            }

            for (x = pawnLocationX + 1; x < _width; x++)
            {
                if ((_plateau[x, pawnLocationY] != 0)
                    || ((x == _width - 1) && (pawnLocationY == 0) && (_plateau[pawnLocationX, pawnLocationY] != 3))
                    || ((x == _width - 1) && (pawnLocationY == _height - 1) && (_plateau[pawnLocationX, pawnLocationY] != 3)))
                {
                    break;
                }
                else
                {
                    _mvtPossible[x, pawnLocationY] = 1;
                }
            }

            for (y = pawnLocationY - 1; y >= 0; y--)
            {
                if ((_plateau[pawnLocationX, y] != 0)
                    || ((pawnLocationX == 0) && (y == 0) && (_plateau[pawnLocationX, pawnLocationY] != 3))
                    || ((pawnLocationX == _width - 1) && (y == 0) && (_plateau[pawnLocationX, pawnLocationY] != 3)))
                {
                    break;
                }
                else
                {
                    _mvtPossible[pawnLocationX, y] = 1;
                }
            }

            for (y = pawnLocationY + 1; y < _height; y++)
            {
                if ((_plateau[pawnLocationX, y] != 0)
                    || ((pawnLocationX == 0) && (y == _width - 1) && (_plateau[pawnLocationX, pawnLocationY] != 3))
                    || ((pawnLocationX == _width - 1) && (y == _width - 1) && (_plateau[pawnLocationX, pawnLocationY] != 3)))
                {
                    break;
                }
                else
                {
                    _mvtPossible[pawnLocationX, y] = 1;
                }
            }

            if(_plateau[pawnLocationX, pawnLocationY] != 3)
            {
                _mvtPossible[(_width - 1) / 2, (_height - 1) / 2] = 0;
            }
            
        }


        private void playerHelp()
        {
            for(int j = 0; j < _height; j++)
            {
                for(int i = 0; i < _width; i++)
                {
                    if(_plateau[i, j] == 2)
                    {
                        showHelpPlayer(i, j);
                    }
                }
            }
            m_PictureBoxTutorielBoard.Refresh();
        }

        private void firstStep()
        {
            _temp = ("Nous allons jouer une partie en tant que défenseur");
            _text = _temp;
            _temp = ("\r\n\r\nNous allons vous laissez jouer une partie et vous expliquer à chacun de vos mouvements pourquoi et en quoi ils sont bons ou mauvais jusqu'à que vous jouiez le meilleurs mouvements possibles.");
            _text += _temp;
            _showTutorielExplanation.Text = _text;
            _ValidateStepTutoriel++;
        }

        private void secondStep()
        {
            _temp = ("Au jeu de tafl, c'est le joueur attaquant qui commence. \r\n\r\nPour son premier mouvement, votre adversaire déplace un de ses pions pour envisager au prochain tour la capture de trois défenseurs.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[2, 5] = _plateau[2, 6];
            _plateau[2, 6] = 0;
            m_PictureBoxTutorielBoard.Refresh();
            _ValidateStepTutoriel++;
        }

        private void thirdStep()
        {

            _temp = ("A vous de jouez. \r\n\r\nN'oubliez pas que vos pions se déplacent comme des tours au jeu d'échec, c'est à dire en ligne droite horizontale ou verticale.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if((_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 5 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 5 && _pawnDestinationY == 4))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas intéressant car il laisse la possibilité à l'adversaire de faire une triple capture à son tour. \r\n\r\nN'oubliez pas que vous avez 2 fois moins de pions que lui. \r\n\r\nEn jouant défenseur, il faut savoir préservez ses pions.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if((_pawnDestinationX == 1 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 1))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas intéressant car il laisse la possibilité à l'adversaire de faire une double capture à son tour et de préparer une double capture pour son prochain tour. \r\n\r\nN'oubliez pas que vous avez 2 fois moins de pions que lui. \r\n\r\nEn jouant défenseur, il faut savoir préservez ses pions.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 1 && _pawnDestinationY == 4)
            {
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant.\r\n\r\nVotre adversaire ne peut plus effectuer de triple capture et vous prenez 1 des ses pions.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[1, 4] = _plateau[2, 4];
                _plateau[2, 4] = 0;
                _plateau[0, 4] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nAppuyer sur Continuer");
                _showTutorielExplanation.Text += _temp;
                _ValidateStepTutoriel++;
                setPawn();
            }
        }

        private void fourthStep()
        {
            _temp = ("Maintenant c'est au tour de votre adversaire. \r\n\r\nIl a choisi de déplacer son pion pour préparer 2 double capture au prochain tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[2, 4] = _plateau[2, 5];
            _plateau[2, 5] = 0;
            m_PictureBoxTutorielBoard.Refresh();
            _ValidateStepTutoriel++;
        }

        private void fifthStep()
        {
            _temp = ("A votre tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if ((_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 5 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 5 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 1))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas le meilleur pour ce tour car vous capturez 1 des ses pions mais l'attaquant capturera 2 défenseurs à son tour, ce qui est à l'avantage du joueur attaquant.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if ((_pawnDestinationX == 0 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 6))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas interessant car le pion déplacer ne permet pas de capturer un pion adverse, ni d'en bloquer.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 1 && _pawnDestinationY == 2)
            {
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant.\r\n\r\nVotre adversaire ayant préparer 2 double capture pour son prochain tour, le mouvement le plus interessant revient à effectuer vous aussi une double capture ce tour.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[1, 2] = _plateau[2, 2];
                _plateau[2, 2] = 0;
                _plateau[0, 2] = 0;
                _plateau[1, 3] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nAppuyer sur Continuer");
                _showTutorielExplanation.Text += _temp;
                setPawn();
                _ValidateStepTutoriel++;
            }
        }

        private void sixthStep()
        {
            _temp = ("A votre adversaire. \r\n\r\nVotre adversaire tente de faire une capture de groupe");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[1, 3] = _plateau[0, 3];
            _plateau[0, 3] = 0;
            _plateau[2, 3] = 0;
            m_PictureBoxTutorielBoard.Refresh();
            _ValidateStepTutoriel++;
        }

        private void seventhStep()
        {
            _temp = ("A votre tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if ((_pawnDestinationX == 1 && _pawnDestinationY == 0)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 6)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 3)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 5 && _pawnDestinationY == 2))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas le mouvement le plus interessant pour ce tour ni pour preparer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 5 && _pawnDestinationY == 4)
            { 
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant pour prérarer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[5,4] = _plateau[4, 4];
                _plateau[4, 4] = 0;
                _plateau[6, 4] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nAppuyer sur Continuer");
                _showTutorielExplanation.Text += _temp;
                setPawn();
                _ValidateStepTutoriel++;
            }
        }

        private void eighthStep()
        {
            _temp = ("A votre adversaire.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[5, 5] = _plateau[3, 5];
            _plateau[3, 5] = 0;
            _plateau[5, 4] = 0;
            m_PictureBoxTutorielBoard.Refresh();

            _ValidateStepTutoriel++;
        }

        private void ninthStep()
        {
            _temp = ("A votre tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if ((_pawnDestinationX == 1 && _pawnDestinationY == 0)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 5 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 3)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 6 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 6))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas le mouvement le plus interessant pour ce tour ni pour preparer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 5 && _pawnDestinationY == 4)
            {
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant pour prérarer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[5, 4] = _plateau[3, 4];
                _plateau[3, 4] = 0;
                _plateau[6, 4] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nAppuyer sur Continuer");
                _showTutorielExplanation.Text += _temp;
                setPawn();
                _ValidateStepTutoriel++;
            }
        }

        private void tenthStep()
        {
            _temp = ("A votre adversaire.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[5, 2] = _plateau[6, 2];
            _plateau[6, 2] = 0;
            m_PictureBoxTutorielBoard.Refresh();

            _ValidateStepTutoriel++;
        }

        private void eleventhStep()
        {
            _temp = ("A votre tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if ((_pawnDestinationX == 1 && _pawnDestinationY == 0)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 3)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 6 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 6))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas le mouvement le plus interessant pour ce tour ni pour preparer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 3 && _pawnDestinationY == 5)
            {
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant pour prérarer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[3, 5] = _plateau[3, 3];
                _plateau[3, 3] = 0;
                _plateau[3, 6] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nAppuyer sur Continuer");
                _showTutorielExplanation.Text += _temp;
                setPawn();
                _ValidateStepTutoriel++;
            }
        }

        private void twelfthStep()
        {
            _temp = ("A votre adversaire.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[2, 5] = _plateau[2, 4];
            _plateau[2, 4] = 0;
            m_PictureBoxTutorielBoard.Refresh();
            _ValidateStepTutoriel++;
        }

        private void thirteenthStep()
        {
            _temp = ("A votre tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if ((_pawnDestinationX == 1 && _pawnDestinationY == 0)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 3)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 6 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 6)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 6))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas le mouvement le plus interessant pour ce tour ni pour preparer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 4 && _pawnDestinationY == 5)
            {
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant pour prérarer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[4, 5] = _plateau[4, 3];
                _plateau[4, 3] = 0;
                _plateau[4, 6] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nAppuyer sur Continuer");
                _showTutorielExplanation.Text += _temp;
                setPawn();
                _ValidateStepTutoriel++;
            }
        }

        private void fourteenthStep()
        {
            _temp = ("A votre adversaire.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            _plateau[2, 2] = _plateau[2, 0];
            _plateau[2, 0] = 0;
            _plateau[3, 2] = 0;
            _plateau[4, 2] = 0;
            m_PictureBoxTutorielBoard.Refresh();
            _ValidateStepTutoriel++;
        }

        private void fifteenthStep()
        {
            _temp = ("A votre tour.");
            _text = _temp;
            _showTutorielExplanation.Text = _text;

            if ((_pawnDestinationX == 1 && _pawnDestinationY == 0)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 1)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 2)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 3)
                || (_pawnDestinationX == 0 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 2 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 6 && _pawnDestinationY == 4)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 5)
                || (_pawnDestinationX == 1 && _pawnDestinationY == 6)
                || (_pawnDestinationX == 3 && _pawnDestinationY == 6)
                || (_pawnDestinationX == 4 && _pawnDestinationY == 6))
            {
                _temp = ("\r\n\r\nCe mouvement n'est pas le mouvement le plus interessant pour ce tour ni pour preparer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;
            }
            if (_pawnDestinationX == 3 && _pawnDestinationY == 2)
            {
                _temp = ("\r\n\r\nCe mouvement est en effet le plus interressant pour prérarer le tour prochain.");
                _showTutorielExplanation.Text = _text + _temp;

                _plateau[3, 2] = _plateau[3, 5];
                _plateau[3, 5] = 0;
                _plateau[3, 0] = 0;
                _plateau[3, 1] = 0;
                _plateau[2, 2] = 0;
                m_PictureBoxTutorielBoard.Refresh();

                _temp = ("\r\n\r\n\r\nA partir de ce moment, la victoire est à porter de main. En effet, votre roi est sortie de son trone et peut facilement atteindre une des forteresses du haut du plateau \r\n\r\n Cliquer sur retour au menu pour quitter le tutoriel");
                _showTutorielExplanation.Text += _temp;
                setPawn();
            }
        }



    }
}
