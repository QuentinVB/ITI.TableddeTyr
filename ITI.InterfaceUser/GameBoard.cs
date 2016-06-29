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
    public partial class m_GameBoard : Form
    {
        public IReadOnlyTafl _plateau;
        bool _firstClick = false;
        bool _endTurn = false;
        public Game _partie;
        public PossibleMove _possibleMove;
        public bool _atkTurn;
        public int _pawnMoveX;
        public int _pawnMoveY;
        public int _pawnDestinationX;
        public int _pawnDestinationY;
        int _height;
        int _width;
        bool _IAAtk = false;
        bool _IADef = false;

        //Variable pour création de plateau
        int _valeurXBoard;
        int _valeurYBoard;
        int _widthBoard;
        int _heightBoard;
        int _valeurXBoardNextCase;
        int _valeurYBoardNextCase;
        //
        
        int[,] _mvtPossible;

        //lié au pseudoCore
        int _AtkCount = 0;
        int _DefCount = 0;
        //

        // Outil implémenter
        PictureBox _atqTurn;
        PictureBox _defTurn;

        Button _nbAtk;
        Button _nbDef;
        //


        /// <summary>
        /// Call the form m_GameBoard
        /// test : I hard put the position of the pawn 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public m_GameBoard(int width, int height, bool iAATK, bool IADef)
        {
            InitializeComponent();
            Game partie = new Game();
            _partie = partie;
            _plateau = partie.Tafl;
            _height = height;
            _width = width;
            _IAAtk = iAATK;
            _IADef = IADef;

            PseudoCoreCountAtkAndDef();             //////////////  pseudo Core
            PseudoCoreAffichageTourJoueur();
            PseudoCoreAffichageNbAtkDef();
            showPlayerTurn();
            _atkTurn = _partie.IsAtkPlaying;
            _mvtPossible = new int[_width, _height];

            if (_IAAtk == true)
            {
                // créer l'IA
                IATurn();
            }
            if(_IADef == true)
            {
                // créer l'IA
            }

            

            ////a utilisez lorsque les plateaux 7x7 9x9 11x11 13x13 mis en XML
            #region variable création plateau
            
            if (_width == 7)
            {
                _valeurXBoard = 3;
                _widthBoard = 70;
                _valeurXBoardNextCase = 73;
            }
            if (_width == 9)
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

        }


        /// <summary>
        /// This function look the Itafl states and show the position of the pawn on the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x = 0, y = 0;

            //_AtkCount = _plateau.AttackerCount;
            //_DefCount = _plateau.DefenderCount;

            Image Piece;
            Image Case;
            Image caseInterdite;
            Image mvtPiecePossible;
            

            Rectangle Rect;

            Graphics Pawn = e.Graphics;
            Graphics Board = e.Graphics;

            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            mvtPiecePossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            pictureBox1.BackColor = Color.Black;

            
            y = _valeurYBoard;

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
                    
                    if(_mvtPossible[i, j] == 1)     //////////////  pseudo Core
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);      //////////////  pseudo Core
                        Board.DrawImage(mvtPiecePossible, Rect);        //////////////  pseudo Core
                    }       //////////////  pseudo Core

                    if (_plateau[i, j] == GameCore.Pawn.Attacker)
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionNoir;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (_plateau[i, j] == GameCore.Pawn.Defender)
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    if (_plateau[i, j] == GameCore.Pawn.King)
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionRoi;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    x = x + _valeurXBoardNextCase;
                }
                y = y + _valeurYBoardNextCase;
            }
        }

        /// <summary>
        /// For the moment, This function give the x, y of the board.
        /// After, it will give x, y to the gamecore to communicate the pawn's position the user
        /// wants to move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = 0, y = 0;

            for (int j = 0; j < _height; j++)
            {
                x = _valeurXBoard;

                for (int i = 0; i < _width; i++)
                {
                    if (e.X > x && e.X < x + _widthBoard && e.Y > y && e.Y < y + _heightBoard)
                    {
                        if (_firstClick == false)
                        {
                            _pawnMoveX = i;
                            _pawnMoveY = j;
                            if ((_plateau[_pawnMoveX, _pawnMoveY] != 0) &&
                                    ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.Attacker) && (_atkTurn == true))
                                    || ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.Defender) && (_atkTurn == false))
                                    || ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.King) && (_atkTurn == false))
                                    )
                            {
                                _firstClick = true;
                                _possibleMove = _partie.CanMove(_pawnMoveX, _pawnMoveY);
                                
                                showHelpPlayer(_pawnMoveX, _pawnMoveY);
                                pictureBox1.Refresh();
                                
                            }
                        }
                        else
                        {
                            _pawnDestinationX = i;
                            _pawnDestinationY = j;

                            if ((_plateau[_pawnDestinationX, _pawnDestinationY] != _plateau[_pawnMoveX, _pawnMoveY])
                                && (_plateau[_pawnDestinationX, _pawnDestinationY] == Pawn.None)
                                && (_mvtPossible[_pawnDestinationX, _pawnDestinationY] == 1))
                            {
                                if (_partie.MovePawn(_pawnMoveX, _pawnMoveY, _pawnDestinationX, _pawnDestinationY) == true)
                                {
                                    _endTurn = true;
                                }
                                else
                                {
                                    _firstClick = false;
                                    resetHelpPlayer();
                                    pictureBox1.Refresh();
                                }
                            }else
                            {
                                _firstClick = false;
                                resetHelpPlayer();
                                pictureBox1.Refresh();
                            }
                        }

                        if (_endTurn == true)
                        {
                            _plateau = _partie.Tafl;    
                            resetHelpPlayer();
                            if((_partie.UpdateTurn() == false)
                                || (PseudoCorecheckCaptureKing() == false))       //////////////  pseudo Core
                            {
                                showVictory();

                            }else
                            {
                                _endTurn = false;
                                _firstClick = false;
                                showPlayerTurn();
                                pictureBox1.Refresh();
                            }
                            
                        }
                        
                    }
                    x = x + _valeurXBoardNextCase;
                }
                y = y + _valeurYBoardNextCase;
            }

            IATurn();
        }

        private void IATurn()
        {
            if ((_IAAtk == true && _atkTurn == true) || (_IADef == true && _atkTurn == false))
            { 
                // envoyer l'état du tafl à l'IA
                // récupérer le mouvement effectuer par L'IA
                // appeler move pawn avec les corrodnnées données par l'iA
                //vérifiez si la parie est fini.
            }
        }

        private void showVictory()
        {
            if((_IAAtk == true && _atkTurn == true) || (_IADef == true && _atkTurn == false))
            {
                PictureBox finDelaPartie = new PictureBox();
                Image endGame;
                endGame = ITI.InterfaceUser.Properties.Resources.Victoire;
                finDelaPartie.Location = new Point(0, 0);
                finDelaPartie.Size = new System.Drawing.Size(750, 400);
                finDelaPartie.Image = (Image)endGame;
                finDelaPartie.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Hide();
                _atqTurn.Hide();
                _defTurn.Hide();
                _nbAtk.Hide();
                _nbDef.Hide();
                finDelaPartie.BringToFront();
                this.Controls.Add(finDelaPartie);
            }else
            {
                PictureBox finDelaPartie = new PictureBox();
                Image endGame;
                endGame = ITI.InterfaceUser.Properties.Resources.Victoire;
                finDelaPartie.Location = new Point(0, 0);
                finDelaPartie.Size = new System.Drawing.Size(750, 400);
                finDelaPartie.Image = (Image)endGame;
                finDelaPartie.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Hide();
                _atqTurn.Hide();
                _defTurn.Hide();
                _nbAtk.Hide();
                _nbDef.Hide();
                finDelaPartie.BringToFront();
                this.Controls.Add(finDelaPartie);
            }
        }

        private void showPlayerTurn()
        {
            _atkTurn = _partie.IsAtkPlaying;
            if (_atkTurn == true)
            {
                _atqTurn.Show();
                _defTurn.Hide();
            }
            else
            {
                _atqTurn.Hide();
                _defTurn.Show();
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

            for(x = pawnLocationX - 1; x >= 0; x--)
            {
                if((_plateau[x, pawnLocationY] != 0)
                    || ((x == 0) && (pawnLocationY == 0) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King))
                    || ((x == 0) && (pawnLocationY == _height - 1) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King)))
                {
                    break;
                }else
                {
                    _mvtPossible[x, pawnLocationY] = 1;
                }
            }

            for (x = pawnLocationX + 1; x < _width; x++)
            {
                if ((_plateau[x, pawnLocationY] != 0)
                    || ((x == _width - 1) && (pawnLocationY == 0) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King))
                    || ((x == _width - 1) && (pawnLocationY == _height - 1) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King)))
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
                    || ((pawnLocationX == 0) && (y == 0) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King))
                    || ((pawnLocationX == _width - 1) && (y == 0) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King)))
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
                    ||((pawnLocationX == 0) && (y == _width - 1) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King))
                    ||((pawnLocationX == _width - 1) && (y == _width - 1) && (_plateau[pawnLocationX, pawnLocationY] != Pawn.King)))
                {
                    break;
                }
                else
                {
                    _mvtPossible[pawnLocationX, y] = 1;
                }
            }

            if (_plateau[pawnLocationX, pawnLocationY] != Pawn.King)
            {
                _mvtPossible[(_width - 1) / 2, (_height - 1) / 2] = 0;
            }
        }

        private void PseudoCoreAffichageTourJoueur()
        {
            _atqTurn = new PictureBox();
            Image atqTurn;
            atqTurn = ITI.InterfaceUser.Properties.Resources.PionNoir;
            _atqTurn.Location = new Point(this.Location.X + 550, this.Location.Y + 25);
            _atqTurn.Image = (Image)atqTurn;
            _atqTurn.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_atqTurn);

            _defTurn = new PictureBox();
            Image defTurn;
            defTurn = ITI.InterfaceUser.Properties.Resources.PionBlanc;
            _defTurn.Location = new Point(this.Location.X + 550, this.Location.Y + 25);
            _defTurn.Image = (Image)defTurn;
            _defTurn.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_defTurn);
        }
        private void PseudoCoreAffichageNbAtkDef()
        {

            _nbAtk = new Button();
            _nbAtk.Text = "Nombre d'atk est de " + _AtkCount;
            _nbAtk.Location = new Point(this.Location.X + 550, this.Location.Y + 200);
            _nbAtk.Size = new System.Drawing.Size(150, 75);
            this.Controls.Add(_nbAtk);
            _nbAtk.BringToFront();

            _nbDef = new Button();
            _nbDef.Text = "Nombre de def est de " + _DefCount;
            _nbDef.Location = new Point(this.Location.X + 550, this.Location.Y + 100);
            _nbDef.Size = new System.Drawing.Size(150, 75);
            this.Controls.Add(_nbDef);
            _nbDef.BringToFront();
        }

        private void PseudoCoreCountAtkAndDef()
        {
            int def = 0;
            int atk = 0;

            for (int y = 0; y < _height; y++)
            {
                for(int x = 0; x < _width; x++)
                {
                    if(_plateau[x, y] == Pawn.Defender)
                    {
                        def = def + 1;
                    }
                    if(_plateau[x, y] == Pawn.Attacker)
                    {
                        atk = atk + 1;
                    }
                }
            }

            _AtkCount = atk;
            _DefCount = def;
        }

        private bool PseudoCorecheckCaptureKing()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_plateau[x, y] == Pawn.King)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
