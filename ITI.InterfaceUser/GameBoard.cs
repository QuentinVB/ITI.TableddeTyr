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
        IReadOnlyTafl _tafl;
        Freyja_Core Freyja;
        Game _partie;
        PossibleMove _possibleMove;
        InterfaceOptions _interfaceOptions;
        List<StudiedPawn> _studiedPossibleMove;

        PictureBox _playerTurn;

        TextBox _nbAtk;
        TextBox _nbDef;

        bool _IAAtk = false;
        bool _IADef = false;
        bool _firstClick = false;
        bool _endTurn = false;
        public int _pawnMoveX;
        public int _pawnMoveY;
        public int _pawnDestinationX;
        public int _pawnDestinationY;
        int[,] _mvtPossible;


        public m_GameBoard(InterfaceOptions interfaceOptions, bool iAATK, bool IADef)
        {
            InitializeComponent();
            _interfaceOptions = interfaceOptions;
            _IAAtk = iAATK;
            _IADef = IADef;
            
            Game partie = new Game();
            _partie = partie;
            _tafl = partie.Tafl;
            setIa();
            
            setGameBoardTools();
        }

        private void setIa()
        {
            if (_IAAtk == true)
            {
                Freyja = new Freyja_Core(_partie, _IAAtk);
                IATurn();
            }
            if (_IADef == true)
            {
                Freyja = new Freyja_Core(_partie, !_IADef);
            }
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            m_GameBoardPictureBoxTafl.BackColor = Color.Black;
            Rectangle Rect;
            Graphics Draw = e.Graphics;

            updateInfomations();
            
            int y = _interfaceOptions.RectanglePositionY;

            for (int j = 0; j < _interfaceOptions.BoardHeight; j++)
            {
                int x = _interfaceOptions.RectanglePositionX;

                for (int i = 0; i < _interfaceOptions.BoardWidth; i++)
                {
                    if (((i == 0) && (j == 0))
                            || ((i == _interfaceOptions.BoardWidth - 1) && (j == _interfaceOptions.BoardHeight - 1))
                            || ((i == _interfaceOptions.BoardWidth - 1) && (j == 0))
                            || ((i == 0) && (j == _interfaceOptions.BoardHeight - 1))
                            || ((i == ((_interfaceOptions.BoardWidth - 1) / 2)) && (j == ((_interfaceOptions.BoardHeight - 1) / 2))))
                    {
                        Rect = new Rectangle(x, y, _interfaceOptions.RectangleWidth, _interfaceOptions.RectangleHeight);
                        Draw.DrawImage(_interfaceOptions.ImageForbiddenSquare, Rect);
                    }
                    else
                    {
                        Rect = new Rectangle(x, y, _interfaceOptions.RectangleWidth, _interfaceOptions.RectangleHeight);
                        Draw.DrawImage(_interfaceOptions.ImageSquare, Rect);
                    }
                    
                    if(_mvtPossible[i, j] == 1) 
                    {
                        Rect = new Rectangle(x, y, _interfaceOptions.RectangleWidth, _interfaceOptions.RectangleHeight);
                        Draw.DrawImage(_interfaceOptions.ImageSquareMvtPossible, Rect);  
                    } 

                    if (_tafl[i, j] == GameCore.Pawn.Attacker)
                    {
                        Draw.DrawImage(_interfaceOptions.ImageAtkPawn, Rect);
                    }
                    if (_tafl[i, j] == GameCore.Pawn.Defender)
                    {
                        Draw.DrawImage(_interfaceOptions.ImageDefPawn, Rect);
                    }
                    if (_tafl[i, j] == GameCore.Pawn.King)
                    {
                        Draw.DrawImage(_interfaceOptions.ImageKingPawn, Rect);
                    }
                    x = x + _interfaceOptions.NextRectanglePositionX;
                }
                y = y + _interfaceOptions.NextRectanglePositionY;
            }
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int y = _interfaceOptions.RectanglePositionY;

            for (int j = 0; j < _interfaceOptions.BoardHeight; j++)
            {
                int x = _interfaceOptions.RectanglePositionX;

                for (int i = 0; i < _interfaceOptions.BoardWidth; i++)
                {
                    if (e.X > x && e.X < x + _interfaceOptions.RectangleWidth && e.Y > y && e.Y < y + _interfaceOptions.RectangleHeight)
                    {
                        if (_firstClick == false)
                        {
                            _pawnMoveX = i;
                            _pawnMoveY = j;

                            if ((_tafl[_pawnMoveX, _pawnMoveY] != 0) &&
                                    ((_tafl[_pawnMoveX, _pawnMoveY] == Pawn.Attacker) && (_partie.IsAtkPlaying == true))
                                    || ((_tafl[_pawnMoveX, _pawnMoveY] == Pawn.Defender) && (_partie.IsAtkPlaying == false))
                                    || ((_tafl[_pawnMoveX, _pawnMoveY] == Pawn.King) && (_partie.IsAtkPlaying == false))
                                    )
                            {
                                _firstClick = true;
                                _possibleMove = _partie.CanMove(_pawnMoveX, _pawnMoveY);
                                resetHelpPlayer();
                                showHelpPlayer(_pawnMoveX, _pawnMoveY);
                                m_GameBoardPictureBoxTafl.Refresh();
                                
                            }
                        }
                        else
                        {
                            _pawnDestinationX = i;
                            _pawnDestinationY = j;

                            if ((_tafl[_pawnDestinationX, _pawnDestinationY] != _tafl[_pawnMoveX, _pawnMoveY])
                                && (_tafl[_pawnDestinationX, _pawnDestinationY] == Pawn.None)
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
                                    m_GameBoardPictureBoxTafl.Refresh();
                                    j = _interfaceOptions.BoardHeight - 1;
                                    break;
                                }
                            }else
                            {
                                _firstClick = false;
                                resetHelpPlayer();
                                m_GameBoardPictureBoxTafl.Refresh();
                                j = _interfaceOptions.BoardHeight - 1;
                                break;
                            }
                        }

                        if (_endTurn == true)
                        {
                            _tafl = _partie.Tafl;  
                            if((_partie.UpdateTurn() == false)
                                || (_tafl.HasKing == false))
                            {
                                showVictory();

                            }else
                            {
                                _endTurn = false;
                                _firstClick = false;
                                resetHelpPlayer();
                                m_GameBoardPictureBoxTafl.Refresh();
                                j = _interfaceOptions.BoardHeight - 1;
                                break;
                            }
                            
                        }
                        
                    }
                    x = x + _interfaceOptions.NextRectanglePositionX;
                }
                y = y + _interfaceOptions.NextRectanglePositionY;
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
                || (_tafl.HasKing == false))
                {
                    showVictory();

                }
            }
        }

        private void updateInfomations()
        {
            // Update number of pawn on the board show to the player
            _nbAtk.Text = ("Le nombre d'attaquant est de :  " + _tafl.AttackerCount);
            _nbDef.Text = ("Le nombre de défenseur est de : " + _tafl.DefenderCount);

            // Update playerTurn
            if(_partie.IsAtkPlaying == true)
            {
                _playerTurn.Image = (Image)_interfaceOptions.ImageAtkPawn;
                _playerTurn.Refresh();
            }else
            {
                _playerTurn.Image = (Image)_interfaceOptions.ImageDefPawn;
                _playerTurn.Refresh();
            }
            
        }

        private void showVictory()
        {
            if((_IAAtk == true && _partie.IsAtkPlaying == true) || (_IADef == true && _partie.IsAtkPlaying == false))
            {
                PictureBox finDelaPartie = new PictureBox();
                finDelaPartie.Location = new Point(0, 0);
                finDelaPartie.Size = new System.Drawing.Size(750, 400);
                finDelaPartie.Image = (Image)_interfaceOptions.ImageIaVictory;
                finDelaPartie.SizeMode = PictureBoxSizeMode.StretchImage;
                m_GameBoardPictureBoxTafl.Hide();
                _nbAtk.Hide();
                _nbDef.Hide();
                _playerTurn.Hide();
                finDelaPartie.BringToFront();
                this.Controls.Add(finDelaPartie);
            }else
            {
                PictureBox finDelaPartie = new PictureBox();
                finDelaPartie.Location = new Point(0, 0);
                finDelaPartie.Size = new System.Drawing.Size(750, 400);
                finDelaPartie.Image = (Image)_interfaceOptions.ImagePlayerVictory;
                finDelaPartie.SizeMode = PictureBoxSizeMode.StretchImage;
                m_GameBoardPictureBoxTafl.Hide();
                _nbAtk.Hide();
                _nbDef.Hide();
                _playerTurn.Hide();
                finDelaPartie.BringToFront();
                this.Controls.Add(finDelaPartie);
            }
        }

        private void resetHelpPlayer()
        {
            for(int j = 0; j < _interfaceOptions.BoardHeight; j++)
            {
                for(int i = 0; i < _interfaceOptions.BoardWidth; i++)
                {
                    _mvtPossible[i, j] = 0;
                }
            }
        }

        private void showHelpPlayer(int pawnLocationX, int pawnLocationY)
        {
            int x = 0, y = 0;
            _studiedPossibleMove = new List<StudiedPawn>();

            _studiedPossibleMove = _possibleMove.FreeSquares;

            foreach (StudiedPawn _studiedPawn in _studiedPossibleMove)
            {
                x = _studiedPawn.X;
                y = _studiedPawn.Y;
                _mvtPossible[x, y] = 1;
            }
        }
        
        private void setGameBoardTools()
        {
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            _interfaceOptions.setPictureBox(_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight);
            _mvtPossible = new int[_interfaceOptions.BoardWidth, _interfaceOptions.BoardHeight];

            _playerTurn = new PictureBox();
            _playerTurn.Location = new Point(this.Location.X + 550, this.Location.Y + 25);
            _playerTurn.Image = (Image)_interfaceOptions.ImageAtkPawn;
            _playerTurn.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(_playerTurn);


            _nbAtk = new TextBox();
            _nbAtk.Text = "Nombre d'atk est de " + _tafl.AttackerCount;
            _nbAtk.Location = new Point(this.Location.X + 530, this.Location.Y + 200);
            _nbAtk.Size = new System.Drawing.Size(200, 75);
            this.Controls.Add(_nbAtk);
            _nbAtk.BringToFront();

            _nbDef = new TextBox();
            _nbDef.Text = "Nombre de def est de " + _tafl.DefenderCount;
            _nbDef.Location = new Point(this.Location.X + 530, this.Location.Y + 100);
            _nbDef.Size = new System.Drawing.Size(200, 75);
            this.Controls.Add(_nbDef);
            _nbDef.BringToFront();
        }

    }
}
