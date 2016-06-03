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

        //Variable pour création de plateau
        int _valeurXBoard;
        int _valeurYBoard;
        int _widthBoard;
        int _heightBoard;
        int _valeurXBoardNextCase;
        int _valeurYBoardNextCase;

        //// test
        //int[,] plateau;
        int[,] _mvtPossible;


        /// <summary>
        /// Call the form m_GameBoard
        /// test : I hard put the position of the pawn 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public m_GameBoard(int width, int height)
        {
            InitializeComponent();
            Game partie = new Game();
            _partie = partie;
            _plateau = partie.Tafl;
            _height = height;
            _width = width;

            showPlayerTurn();

            // test hardcodage plateau
            //int atk = 1;
            //int def = 2;
            //int roi = 3;
            //plateau = new int[_width, _height];
            //

            //
            _mvtPossible = new int[_width, _height];
            
            //

            ////a utilisez lorsque les plateaux 7x7 9x9 11x11 13x13 mis en XML
            #region variable création plateau
            /*
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
            */
            #endregion

            
            if (_width == 7 && _height == 7)
            {
                _valeurXBoard = 3;
                _valeurYBoard = 3;
                _widthBoard = 70;
                _heightBoard = 70;
                _valeurXBoardNextCase = 73;
                _valeurYBoardNextCase = 73;
                /*
                #region hard Code plateau7x7 (test)
                plateau[2, 0] = atk;
                plateau[3, 0] = atk;
                plateau[4, 0] = atk;
                plateau[3, 1] = atk;
                plateau[0, 2] = atk;
                plateau[0, 3] = atk;
                plateau[0, 4] = atk;
                plateau[1, 3] = atk;
                plateau[6, 2] = atk;
                plateau[6, 3] = atk;
                plateau[6, 4] = atk;
                plateau[5, 3] = atk;
                plateau[2, 6] = atk;
                plateau[3, 6] = atk;
                plateau[4, 6] = atk;
                plateau[3, 5] = atk;

                plateau[2, 2] = def;
                plateau[2, 3] = def;
                plateau[2, 4] = def;
                plateau[3, 2] = def;
                plateau[3, 4] = def;
                plateau[4, 2] = def;
                plateau[4, 3] = def;
                plateau[4, 4] = def;

                plateau[3, 3] = roi;
                #endregion
                */
            }
            if (_width == 9 && _height == 9)
            {
                _valeurXBoard = 6;
                _valeurYBoard = 6;
                _widthBoard = 53;
                _heightBoard = 53;
                _valeurXBoardNextCase = 56;
                _valeurYBoardNextCase = 56;
                /*
                #region hard Code plateau9x9 (test)
                plateau[3, 0] = atk;
                plateau[4, 0] = atk;
                plateau[5, 0] = atk;
                plateau[4, 1] = atk;
                plateau[0, 3] = atk;
                plateau[0, 4] = atk;
                plateau[0, 5] = atk;
                plateau[1, 4] = atk;
                plateau[8, 3] = atk;
                plateau[8, 4] = atk;
                plateau[8, 5] = atk;
                plateau[7, 4] = atk;
                plateau[3, 8] = atk;
                plateau[4, 8] = atk;
                plateau[5, 8] = atk;
                plateau[4, 7] = atk;

                plateau[2, 4] = def;
                plateau[3, 4] = def;
                plateau[4, 2] = def;
                plateau[4, 3] = def;
                plateau[5, 4] = def;
                plateau[6, 4] = def;
                plateau[4, 5] = def;
                plateau[4, 6] = def;

                plateau[4, 4] = roi;
                #endregion*/
            }
            if (_width == 11 && _height == 11)
            {
                _valeurXBoard = 5;
                _valeurYBoard = 5;
                _widthBoard = 43;
                _heightBoard = 43;
                _valeurXBoardNextCase = 46;
                _valeurYBoardNextCase = 46;
                /*
                #region hard Code plateau11x11 (test)
                plateau[3, 0] = atk;
                plateau[4, 0] = atk;
                plateau[5, 0] = atk;
                plateau[6, 0] = atk;
                plateau[7, 0] = atk;
                plateau[0, 3] = atk;
                plateau[0, 4] = atk;
                plateau[0, 5] = atk;
                plateau[0, 6] = atk;
                plateau[0, 7] = atk;
                plateau[10, 3] = atk;
                plateau[10, 4] = atk;
                plateau[10, 5] = atk;
                plateau[10, 6] = atk;
                plateau[10, 7] = atk;
                plateau[3, 10] = atk;
                plateau[4, 10] = atk;
                plateau[5, 10] = atk;
                plateau[6, 10] = atk;
                plateau[7, 10] = atk;
                plateau[5, 1] = atk;
                plateau[5, 9] = atk;
                plateau[1, 5] = atk;
                plateau[9, 5] = atk;

                plateau[5, 4] = def;
                plateau[5, 6] = def;
                plateau[5, 3] = def;
                plateau[5, 7] = def;
                plateau[4, 4] = def;
                plateau[4, 5] = def;
                plateau[4, 6] = def;
                plateau[6, 4] = def;
                plateau[6, 5] = def;
                plateau[6, 6] = def;
                plateau[3, 5] = def;
                plateau[7, 5] = def;

                plateau[5, 5] = roi;
                #endregion*/
            }
            if (_width == 13 && _height == 13)
            {
                _valeurXBoard = 5;
                _valeurYBoard = 5;
                _widthBoard = 36;
                _heightBoard = 36;
                _valeurXBoardNextCase = 39;
                _valeurYBoardNextCase = 39;
                /*
                #region hard Code plateau13x13 (test)
                plateau[4, 0] = atk;
                plateau[5, 0] = atk;
                plateau[6, 0] = atk;
                plateau[7, 0] = atk;
                plateau[8, 0] = atk;
                plateau[0, 4] = atk;
                plateau[0, 5] = atk;
                plateau[0, 6] = atk;
                plateau[0, 7] = atk;
                plateau[0, 8] = atk;
                plateau[12, 4] = atk;
                plateau[12, 5] = atk;
                plateau[12, 6] = atk;
                plateau[12, 7] = atk;
                plateau[12, 8] = atk;
                plateau[4, 12] = atk;
                plateau[5, 12] = atk;
                plateau[6, 12] = atk;
                plateau[7, 12] = atk;
                plateau[8, 12] = atk;
                plateau[6, 1] = atk;
                plateau[6, 11] = atk;
                plateau[1, 6] = atk;
                plateau[11, 6] = atk;

                plateau[6, 3] = def;
                plateau[6, 4] = def;
                plateau[6, 5] = def;
                plateau[6, 7] = def;
                plateau[6, 8] = def;
                plateau[6, 9] = def;
                plateau[3, 6] = def;
                plateau[4, 6] = def;
                plateau[5, 6] = def;
                plateau[7, 6] = def;
                plateau[8, 6] = def;
                plateau[9, 6] = def;

                plateau[6, 6] = roi;
                #endregion*/

            }

        }


        /// <summary>
        /// This function look the Itafl states and show the position of the pawn on the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x = 0, y = 0;
            
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
                    
                    if(_mvtPossible[i, j] == 1)
                    {
                        Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                        Board.DrawImage(mvtPiecePossible, Rect);
                    }

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
            int pawnplay;
            _atkTurn = _partie.IsAtkPlaying;

            if(_atkTurn == true)
            {
                pawnplay = 1;
            }
            else
            {
                pawnplay = 2;
            }

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
                                    ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.Attacker) && (pawnplay == 1))
                                    || ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.Defender) && (pawnplay == 2))
                                    || ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.King) && (pawnplay == 2))
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
                            if(_partie.UpdateTurn() == false)
                            {
                                PictureBox finDelaPartie = new PictureBox();
                                Image endGame;
                                endGame = ITI.InterfaceUser.Properties.Resources.Victoire;
                                finDelaPartie.Location = new Point(this.Location.X, this.Location.Y);
                                finDelaPartie.Size = new System.Drawing.Size(500, 500);
                                finDelaPartie.Image = (Image)endGame;
                                finDelaPartie.SizeMode = PictureBoxSizeMode.StretchImage;
                                finDelaPartie.BringToFront();
                                this.Controls.Add(finDelaPartie);
                            }
                            _endTurn = false;
                            _firstClick = false;
                            showPlayerTurn();
                            pictureBox1.Refresh();
                        }
                        
                    }
                    x = x + _valeurXBoardNextCase;
                }
                y = y + _valeurYBoardNextCase;
            }
            
        }

        private void showPlayerTurn()
        {
            _atkTurn = _partie.IsAtkPlaying;
            if (_atkTurn == true)
            {
                m_PlayerTurn.Text = "c'est au tour de l'attaquant";
            }
            else
            {
                m_PlayerTurn.Text = "C'est au tour du défenseur";
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

            _mvtPossible[(_width - 1) / 2, (_height - 1) / 2] = 0;
        }
    }
}
