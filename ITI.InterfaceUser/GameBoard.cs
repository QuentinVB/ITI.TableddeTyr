using ITI.GameCore;
using ITI.TabledeTyr.Freyja;
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
        IReadOnlyTafl _plateau;
        Freyja_Core Freyja;
        Game _partie;
        PossibleMove _possibleMove;
        InterfaceOptions _interfaceOptions;
        List<StudiedPawn> _studiedPossibleMove;
        StudiedPawn _studiedPawn;


        bool _firstClick = false;
        bool _endTurn = false;
        public int _pawnMoveX;
        public int _pawnMoveY;
        public int _pawnDestinationX;
        public int _pawnDestinationY;
        int _height;
        int _width;

        // Bool pour l'utilisation de l'IA
        bool _IAAtk = false;
        bool _IADef = false;

        //Variable pour création de plateau
        int _rectanglePositionX;
        int _rectanglePositionY;
        int _rectangleWidth;
        int _rectangleHeight;
        int _nextRectanglePositionX;
        int _nextRectanglePositionY;
        //
        
        int[,] _mvtPossible;

        //lié au pseudoCore
        int _AtkCount = 0;
        int _DefCount = 0;
        //

        // Outil implémenter
        PictureBox _playerTurn;

        TextBox _nbAtk;
        TextBox _nbDef;

        Image playerTurn;
        //


        /// <summary>
        /// Call the form m_GameBoard
        /// test : I hard put the position of the pawn 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public m_GameBoard(InterfaceOptions interfaceOptions, bool iAATK, bool IADef)
        {
            InitializeComponent();
            _interfaceOptions = interfaceOptions;

            _interfaceOptions.FormTitle();
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            _height = _interfaceOptions.Height;
            _width = _interfaceOptions.Width;

            _IAAtk = iAATK;
            _IADef = IADef;


            Game partie = new Game();
            _partie = partie;
            _plateau = partie.Tafl;


            setGameBoardTools();
            setGameBoardInformation();

            _mvtPossible = new int[_width, _height];


            // Appel et création de l'IA
            if (_IAAtk == true)
            {
                Freyja = new Freyja_Core(partie, _IAAtk);
                IATurn();
            }
            if(_IADef == true)
            {
                Freyja = new Freyja_Core(partie, !_IADef);
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

        /// <summary>
        /// This function look the Itafl states and show the position of the pawn on the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
            
            Image Piece;
            Image Case;
            Image caseInterdite;
            Image mvtPiecePossible;
            

            Rectangle Rect;

            Graphics Pawn = e.Graphics;
            Graphics Board = e.Graphics;

            updateInfomations();

            Case = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            caseInterdite = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            mvtPiecePossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            pictureBox1.BackColor = Color.Black;

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
                    
                    if(_mvtPossible[i, j] == 1)     //////////////  pseudo Core
                    {
                        Rect = new Rectangle(x, y, _rectangleWidth, _rectangleHeight);      //////////////  pseudo Core
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
                    x = x + _nextRectanglePositionX;
                }
                y = y + _nextRectanglePositionY;
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
                x = _rectanglePositionX;

                for (int i = 0; i < _width; i++)
                {
                    if (e.X > x && e.X < x + _rectangleWidth && e.Y > y && e.Y < y + _rectangleHeight)
                    {
                        if (_firstClick == false)
                        {
                            _pawnMoveX = i;
                            _pawnMoveY = j;
                            if ((_plateau[_pawnMoveX, _pawnMoveY] != 0) &&
                                    ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.Attacker) && (_partie.IsAtkPlaying == true))
                                    || ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.Defender) && (_partie.IsAtkPlaying == false))
                                    || ((_plateau[_pawnMoveX, _pawnMoveY] == Pawn.King) && (_partie.IsAtkPlaying == false))
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
                                    pictureBox1.Refresh();
                                    j = _height - 1;
                                    break;
                                }
                            }else
                            {
                                _firstClick = false;
                                pictureBox1.Refresh();
                                j = _height - 1;
                                break;
                            }
                        }

                        if (_endTurn == true)
                        {
                            _plateau = _partie.Tafl;  
                            if((_partie.UpdateTurn() == false)
                                || (_plateau.HasKing == false))
                            {
                                showVictory();

                            }else
                            {
                                _endTurn = false;
                                _firstClick = false;
                                pictureBox1.Refresh();
                                j = _height - 1;
                                break;
                            }
                            
                        }
                        
                    }
                    x = x + _nextRectanglePositionX;
                }
                y = y + _nextRectanglePositionY;
            }
            IATurn();
        }

        private void IATurn()
        {
            if ((_IAAtk == true && _partie.IsAtkPlaying == true) || (_IADef == true && _partie.IsAtkPlaying == false))
            {
                // envoyer l'état du tafl à l'IA
                Freyja.UpdateSensor(_partie);
                Freyja.UpdateFreyja();
                // récupérer le mouvement effectuer par L'IA
                Move iaMove = Freyja.UpdateEffector();
                // appeler move pawn avec les corrodnnées données par l'iA
                _pawnMoveX = iaMove.sourceX;
                _pawnMoveY = iaMove.sourceY;
                _pawnDestinationX = iaMove.destinationX;
                _pawnDestinationY = iaMove.destinationY;
                //vérifiez si la parie est fini.
                _partie.MovePawn(_pawnMoveX, _pawnMoveY, _pawnDestinationX, _pawnDestinationY);
                if ((_partie.UpdateTurn() == false)
                || (_plateau.HasKing == false))
                {
                    showVictory();

                }
            }
        }

        private void updateInfomations()
        {
            // Update number of pawn on the board show to the player
            _AtkCount = _plateau.AttackerCount;
            _DefCount = _plateau.DefenderCount;
            _nbAtk.Text = ("Le nombre d'attaquant est de :  " + _AtkCount);
            _nbDef.Text = ("Le nombre de défenseur est de : " + _DefCount);

            // Update playerTurn
            if(_partie.IsAtkPlaying == true)
            {
                playerTurn = ITI.InterfaceUser.Properties.Resources.PionNoir;
                _playerTurn.Image = (Image)playerTurn;
                _playerTurn.Refresh();
            }else
            {
                playerTurn = ITI.InterfaceUser.Properties.Resources.PionBlanc;
                _playerTurn.Image = (Image)playerTurn;
                _playerTurn.Refresh();
            }
            
        }

        private void showVictory()
        {
            if((_IAAtk == true && _partie.IsAtkPlaying == true) || (_IADef == true && _partie.IsAtkPlaying == false))
            {
                PictureBox finDelaPartie = new PictureBox();
                Image endGame;
                endGame = ITI.InterfaceUser.Properties.Resources.Victoire;
                finDelaPartie.Location = new Point(0, 0);
                finDelaPartie.Size = new System.Drawing.Size(750, 400);
                finDelaPartie.Image = (Image)endGame;
                finDelaPartie.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Hide();
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
                _nbAtk.Hide();
                _nbDef.Hide();
                finDelaPartie.BringToFront();
                this.Controls.Add(finDelaPartie);
            }
        }

        private void showHelpPlayer(int pawnLocationX, int pawnLocationY)
        {
            int x = 0, y = 0;
            _studiedPossibleMove = new List<StudiedPawn>();
            _studiedPawn = new StudiedPawn();

            _studiedPossibleMove = _possibleMove.FreeSquares;

            foreach (StudiedPawn _studiedPawn in _studiedPossibleMove)
            {
                x = _studiedPawn.X;
                y = _studiedPawn.Y;
                _mvtPossible[x, y] = 1;
            }
        }

        private void resethelpplayer()
        {
            for(int j = 0; j < _interfaceOptions.Height; j++)
            {
                for(int i = 0; i < _interfaceOptions.Width; i++)
                {
                    _mvtPossible[i, j] = 0;
                }
            }
        }
        
        private void setGameBoardTools()
        {
            _playerTurn = new PictureBox();
            playerTurn = ITI.InterfaceUser.Properties.Resources.PionNoir;
            _playerTurn.Location = new Point(this.Location.X + 550, this.Location.Y + 25);
            _playerTurn.Image = (Image)playerTurn;
            _playerTurn.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_playerTurn);


            _nbAtk = new TextBox();
            _nbAtk.Text = "Nombre d'atk est de " + _AtkCount;
            _nbAtk.Location = new Point(this.Location.X + 530, this.Location.Y + 200);
            _nbAtk.Size = new System.Drawing.Size(200, 75);
            this.Controls.Add(_nbAtk);
            _nbAtk.BringToFront();

            _nbDef = new TextBox();
            _nbDef.Text = "Nombre de def est de " + _DefCount;
            _nbDef.Location = new Point(this.Location.X + 530, this.Location.Y + 100);
            _nbDef.Size = new System.Drawing.Size(200, 75);
            this.Controls.Add(_nbDef);
            _nbDef.BringToFront();

        }

    }
}
