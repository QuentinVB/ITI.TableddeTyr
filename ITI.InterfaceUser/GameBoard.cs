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
        public bool _allowMove = false;
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
        int[,] plateau;


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
            int atk = 1;
            int def = 2;
            int roi = 3;
            plateau = new int[_width, _height];
            //

            if (_width == 7 && _height == 7)
            {
                _valeurXBoard = 3;
                _valeurYBoard = 3;
                _widthBoard = 70;
                _heightBoard = 70;
                _valeurXBoardNextCase = 73;
                _valeurYBoardNextCase = 73;
                
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
            }
            if (_width == 9 && _height == 9)
            {
                _valeurXBoard = 6;
                _valeurYBoard = 6;
                _widthBoard = 53;
                _heightBoard = 53;
                _valeurXBoardNextCase = 56;
                _valeurYBoardNextCase = 56;

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
                #endregion
            }
            if (_width == 11 && _height == 11)
            {
                _valeurXBoard = 5;
                _valeurYBoard = 5;
                _widthBoard = 43;
                _heightBoard = 43;
                _valeurXBoardNextCase = 46;
                _valeurYBoardNextCase = 46;
                
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
                #endregion
            }
            if (_width == 13 && _height == 13)
            {
                _valeurXBoard = 5;
                _valeurYBoard = 5;
                _widthBoard = 36;
                _heightBoard = 36;
                _valeurXBoardNextCase = 39;
                _valeurYBoardNextCase = 39;

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
                #endregion
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

            Rectangle Rect;

            Graphics Pawn = e.Graphics;
            Graphics Board = e.Graphics;

            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.PawnHnefatafl;
            pictureBox1.BackColor = Color.Black;

            
            y = _valeurYBoard;

            for (int j = 0; j < _height; j++)
            {
                x = _valeurXBoard;
                for (int i = 0; i < _width; i++)
                {
                    /*
                    Rect = new Rectangle(x, y, _widthBoard, _heightBoard);
                    Board.DrawImage(Case, Rect);
                    */
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
                    //if (_plateau[i, j] == GameCore.Pawn.Attacker)
                    if (plateau[i,j] == 1)     // test
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionNoir;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    //if (_plateau[i, j] == GameCore.Pawn.Defender)
                    if (plateau[i, j] == 2)     // test
                    {
                        Piece = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                        Pawn.DrawImage(Piece, Rect);
                    }
                    //if (_plateau[i, j] == GameCore.Pawn.King)
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
            //int up = 0, down = 0, left = 0, right = 0;

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
                            if(plateau[_pawnMoveX, _pawnMoveY] != 0)
                            {
                                _firstClick = true;
                                m_positionSouris.Text = "x = " + _pawnMoveX + " y = " + _pawnMoveY;
                                _possibleMove = _partie.CanMove(_pawnMoveX, _pawnMoveY);
                            }
                            /*
                            if(_possibleMove.isFree == true)
                            {
                                _firstclock = true;
                                up = _possibleMove.Up;
                                down = _possibleMove.Down;
                                left = _possibleMove.left;
                                right = _possibleMove.Right
                            */
                        }
                        else
                        {

                            _pawnDestinationX = i;
                            _pawnDestinationY = j;
                            if (plateau[_pawnDestinationX, _pawnDestinationY] != plateau[_pawnMoveX, _pawnMoveY]
                                && plateau[_pawnDestinationX, _pawnDestinationY] != 1
                                && plateau[_pawnDestinationX, _pawnDestinationY] != 2
                                && plateau[_pawnDestinationX, _pawnDestinationY] != 3)
                            {
                                m_positionSouris.Text = "x = " + _pawnDestinationX + " y = " + _pawnDestinationY;
                                if (_partie.MovePawn(_pawnMoveX, _pawnMoveY, _pawnDestinationX, _pawnDestinationY) == true)
                                {
                                    _endTurn = true;
                                }
                                else
                                {
                                    m_positionSouris.Text = "Mouvement Impossible";
                                    _firstClick = false;
                                    //pictureBox1.Refresh(); refresh les cases vertes
                                }
                            }
                        }

                        if (_endTurn == true)
                        {
                            //_plateau = _partie.Tafl;
                            plateau[_pawnDestinationX, _pawnDestinationY] = plateau[_pawnMoveX, _pawnMoveY];
                            plateau[_pawnMoveX, _pawnMoveY] = 0;
                            _endTurn = false;
                            _firstClick = false;
                            _allowMove = false;
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
            //_atkTurn = _partie.IsAtkPlaying;
            _atkTurn = !(_atkTurn);
            if (_atkTurn == true)
            {
                m_PlayerTurn.Text = "c'est au tour de l'attaquant";
            }
            else
            {
                m_PlayerTurn.Text = "C'est au tour du défenseur";
            }
        }
    }
}
