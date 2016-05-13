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
        public int[,] _plateau;
        bool XX = false;
        bool endTurn = false;

        int X, XXX, Y, YYY;
        

        /// <summary>
        /// Call the form m_GameBoard
        /// test : I hard put the position of the pawn 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public m_GameBoard(int width, int height)
        {
            InitializeComponent();
            #region hardcode
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

            //vérifiez les conditions de victoire
            // si victoire affichez la victoire
            //sinon : pictureBox1.Refresh();
            // m_PlayerTurn.Refresh();

            for (int y = 22; y < 490; y++)
            {
                for (int x = 21; x < 490; x++)
                {

                    if (_plateau[i, j] == 1)
                    {
                        using (Pen g = new Pen(Brushes.DarkBlue))
                        {
                            e.Graphics.DrawEllipse(g, x, y, 38, 38);
                        }
                    }
                    if (_plateau[i, j] == 2)
                    {
                        using (Pen a = new Pen(Brushes.White))
                        {
                            e.Graphics.DrawEllipse(a, x, y, 38, 38);
                        }
                    }
                    if (_plateau[i, j] == 3)
                    {
                        using (Pen h = new Pen(Brushes.Green))
                        {
                            e.Graphics.DrawEllipse(h, x, y, 38, 38);
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
        /// For the moment, This function give the x, y of the board.
        /// After, it will give x, y to the gamecore to communicate the pawn's position the user
        /// wants to move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            int i = 0, j = 0;

            for (int y = 22; y < 490; y++)
            {
                for (int x = 21; x < 490; x++)
                {
                    if (e.X > x && e.X < x + 48 && e.Y > y && e.Y < y + 50)
                    {
                        //m_positionSouris.Text = "x = " + i + " y = " + j;

                        // check move
                        if(XX == false)
                        {
                            //checkMove (i, j)
                            // if true,
                            X = i;
                            Y = j;
                            XX = true;
                        }else
                        {
                            // AllowMove (i,j)
                            // if true,
                            XXX = i;
                            YYY = j;
                            endTurn = true;
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
            
            /*if (_ATKTurn == true)
            {
                m_PlayerTurn.Text = "c'est au tour de l'attaquant";
            }
            else
            {
                m_PlayerTurn.Text = "C'est au tour du défenseur";
            }*/
            m_PlayerTurn.Text = "C'est au tour de :";
        }

        private void m_updateTurn_Click(object sender, EventArgs e)
        {
            _plateau[XXX, YYY] = _plateau[X,Y];
            _plateau[X, Y] = 0;

            if(endTurn == true)
            {
                m_positionSouris.Text = "x = " + XX;
                pictureBox1.Refresh();
                m_PlayerTurn.Refresh();
            }
            XX = false;
            endTurn = false;

        }

    }
}
