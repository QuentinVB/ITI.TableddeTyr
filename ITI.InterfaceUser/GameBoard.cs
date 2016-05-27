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
            
            #region hardcode du tafl
            /*
            _plateau = new int[11, 11];

            _plateau[3, 0] = 1;
            _plateau[4, 0] = 1;
            _plateau[5, 0] = 1;
            _plateau[6, 0] = 1;
            _plateau[7, 0] = 1;

            _plateau[5, 1] = 1;

            _plateau[3, 10] = 1;
            _plateau[4, 10] = 1;
            _plateau[5, 10] = 1;
            _plateau[6, 10] = 1;
            _plateau[7, 10] = 1;

            _plateau[5, 9] = 1;

            _plateau[0, 3] = 1;
            _plateau[0, 4] = 1;
            _plateau[0, 5] = 1;
            _plateau[0, 6] = 1;
            _plateau[0, 7] = 1;

            _plateau[1, 5] = 1;

            _plateau[10, 3] = 1;
            _plateau[10, 4] = 1;
            _plateau[10, 5] = 1;
            _plateau[10, 6] = 1;
            _plateau[10, 7] = 1;

            _plateau[9, 5] = 1;

            _plateau[3, 5] = 2;
            _plateau[4, 4] = 2;
            _plateau[4, 5] = 2;
            _plateau[4, 6] = 2;
            _plateau[5, 3] = 2;
            _plateau[5, 4] = 2;
            _plateau[5, 6] = 2;
            _plateau[5, 7] = 2;
            _plateau[6, 4] = 2;
            _plateau[6, 5] = 2;
            _plateau[6, 6] = 2;
            _plateau[7, 5] = 2;

            _plateau[5, 5] = 3;
            */
            #endregion
            

        }


        /// <summary>
        /// This function look the Itafl states and show the position of the pawn on the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int i = 0, j = 0;
            Image Piece;
            Rectangle Rect;
            Graphics g = e.Graphics;

            if (_width == 7 && _height == 7)
            {
                pictureBox1.BackgroundImage = ITI.InterfaceUser.Properties.Resources.Board7x7;
            }
            if (_width == 9 && _height == 9)
            {
                pictureBox1.BackgroundImage = ITI.InterfaceUser.Properties.Resources.Board9x9;
            }
            if (_width == 11 && _height == 11)
            {
                pictureBox1.BackgroundImage = ITI.InterfaceUser.Properties.Resources.Board11x11;
            }
            if (_width == 13 && _height == 13)
            {
                pictureBox1.BackgroundImage = ITI.InterfaceUser.Properties.Resources.Board13x13;
            }



            for (int y = 22; y < 490; y++)
            {
                for (int x = 21; x < 490; x++)
                {
                    
                    if (_plateau[i, j] == Pawn.Attacker)
                    {
                        /*
                        using (Pen g = new Pen(Brushes.DarkBlue))
                        {
                            e.Graphics.DrawEllipse(g, x, y, 38, 38);
                        }*/
                        Piece = ITI.InterfaceUser.Properties.Resources.PionNoir;
                        Rect = new Rectangle(x, y, 38, 38);
                        g.DrawImage(Piece, Rect);
                        
                    }
                    if (_plateau[i, j] == Pawn.Defender)
                    {
                        /*
                        using (Pen a = new Pen(Brushes.White))
                        {
                            e.Graphics.DrawEllipse(a, x, y, 38, 38);
                        }*/
                        Piece = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                        Rect = new Rectangle(x, y, 38, 38);
                        g.DrawImage(Piece, Rect);
                    }
                    if (_plateau[i, j] == Pawn.King)
                    {
                        /*
                        using (Pen h = new Pen(Brushes.Green))
                        {
                            e.Graphics.DrawEllipse(h, x, y, 38, 38);
                        }*/
                        Piece = ITI.InterfaceUser.Properties.Resources.PionRoi;
                        Rect = new Rectangle(x, y, 38, 38);
                        g.DrawImage(Piece, Rect);

                    }
                    i++;
                    x = x + 42;
                }
                i = 0;
                j++;
                y = y + 42;
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
            
            int i = 0, j = 0;
            //int up = 0, down = 0, left = 0, right = 0;

            for (int y = 22; y < 490; y++)
            {
                for (int x = 21; x < 490; x++)
                {
                    if (e.X > x && e.X < x + 48 && e.Y > y && e.Y < y + 50)
                    {

                        if (_firstClick == false)
                        {
                            _pawnMoveX = i;
                            _pawnMoveY = j;
                            _firstClick = true;
                            m_positionSouris.Text = "x = " + _pawnMoveX + "y = " + _pawnMoveY;

                            _possibleMove = _partie.CanMove(_pawnMoveX, _pawnMoveY);
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
                            m_positionSouris.Text = "x = " + _pawnDestinationX + "y = " + _pawnDestinationY;

                            _allowMove = _partie.MovePawn(_pawnMoveX, _pawnMoveY, _pawnDestinationX, _pawnDestinationY);

                            if(_allowMove == true)
                            {
                                _endTurn = true;
                            }
                            else
                            {
                                _firstClick = false;
                                _allowMove = false;
                                pictureBox1.Refresh();
                            }
                        }

                        if (_endTurn == true)
                        {
                            _plateau = _partie.Tafl;
                            m_PlayerTurn.Refresh();
                            _endTurn = false;
                            _firstClick = false;
                            _allowMove = false;
                            pictureBox1.Refresh();
                        }
                        
                    }
                    i++;
                    x = x + 42;
                }
                i = 0;
                j++;
                y = y + 42;
            }
            
        }

        /// <summary>
        /// Show who is playing, 
        /// Will show other information after like : 
        /// number of pans alive ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_GameBoard_Load(object sender, EventArgs e)
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

        private void m_updateTurn_Click(object sender, EventArgs e)
        {
            /*
            _plateau[_pawnDestinationX, _pawnDestinationY] = _plateau[_pawnMoveX,_pawnMoveY];
            _plateau[_pawnMoveX, _pawnMoveY] = Pawn.None;
            */
            /*_allowMove = true;
            
            if (_endTurn == true)
            {
                _allowMove = _partie.MovePawn(_pawnMoveX, _pawnMoveY, _pawnDestinationX, _pawnDestinationY);
                _plateau = _partie.Tafl;

                if (_allowMove == true)
                {
                    m_PlayerTurn.Refresh();
                    _endTurn = false;
                    _checkMove = false;
                    _allowMove = false;
                    pictureBox1.Refresh();
                }
                else
                {
                    _checkMove = false;
                    _allowMove = false;
                }
            }*/

        }

    }
}
