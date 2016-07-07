using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Analyze
    {
       
        SimulationNode _father;
        SimulationNode _child;
        Freyja_Core _ctx;
        Game _game;

        IReadOnlyTafl _tafl;

        bool _studiedPawnOriginePositionLiberty;
        bool _checkIfStudiedPawnCanBeCaptureNextTurn;
        bool studiedGroupCanBeCaptured;

        bool _iaIsAtk;
        int _KingLostLiberty;
        int _positionStudiedPawnX;
        int _positionSutdiedPawnY;
        int _studiedPawnPositionOrigineLibertyScore;
        int _studiedPawnPositionDestinationLibertyScore;
        int _scoreCaptureTurn;

        int _atkCount;
        int _defCount;
        int _libertyGroupStudied;

        int _nbOfPawnInPatieUpLeftOfBoard;
        bool _bestMovedefUpRight;
        int _nbOfPawnInPatieUpRightOfBoard;
        bool _bestMovedefUpLeft;
        int _nbOfPawnInPatieDownLeftOfBoard;
        bool _bestMovedefDownRight;
        int _nbOfPawnInPatieDownRightOfBoard;
        bool _bestMovedefDownLeft;
        bool _positionKingUpLeft;
        bool _positionKingUpRight;
        bool _positionKingDownLeft;
        bool _positionKingDownRight;


        List<StudiedPawn> _createStudiedListGroup;

        //fonction d'appel analyse IA

        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;
        }

        internal SimulationNode UpdateAnalyze(SimulationNode father, SimulationNode child)
        {
            _game = new Game();
            _iaIsAtk = _ctx.Sensor.IsFreyjaAtk;
            _father = father;
            _child = child;
            _tafl = father.TaflStored;
            IASimuationAnalyse();

            //_child.Score++;
            return _child;
        }

        private void IASimuationAnalyse()
        {
            //THESE CREATE STACK OVERFLOW  !!
            //PawnDestinationFree(_father.OriginMove.destinationX, _father.OriginMove.destinationY);
            //PawnPositionFree(_father.OriginMove.sourceX, _father.OriginMove.sourceY);
            NumberOfPawnAtTheBeginningOfTheTurn();
            /*
            if (
               (_father.TaflStored[x, y] == Pawn.Attacker && _father.IsAtkPlay == false)
                || (_father.TaflStored[x, y] == Pawn.Defender && _father.IsAtkPlay == true)
                || (_father.TaflStored[x, y] == Pawn.King && _father.IsAtkPlay == true)
              ) throw new Exception(string.Format("try moved pawn {0} from [{1},{2}] at [{3},{4}] as atk = {5} ", _game.Tafl[_father.OriginMove.sourceX, _father.OriginMove.sourceY], _father.OriginMove.sourceX, _father.OriginMove.sourceY, _father.OriginMove.destinationX, _father.OriginMove.destinationY, _game.IsAtkPlaying));
              */
            //SHITTY LINE HERE !
            //_game.MovePawn(_father.OriginMove.sourceX, _father.OriginMove.sourceY, _father.OriginMove.destinationX, _father.OriginMove.destinationY);
            setScoreCapturePawn();

            if(_iaIsAtk == _father.IsAtkPlay)
            {
                _child.Score = _father.Score + setFinalScore();
            }else
            {
                _child.Score = _father.Score - setFinalScore();
            }
        }


        // Fonctions d'appel d'analyse et de score


        /// <summary>
        /// Check if the pawn is still free without moving
        /// </summary>
        /// <param name="PawnPositionOrigineX"></param>
        /// <param name="PawnPositionOrigineY"></param>
        /// <returns></returns>
        private bool PawnPositionFree(int PawnPositionOrigineX, int PawnPositionOrigineY)
        {
            _checkIfStudiedPawnCanBeCaptureNextTurn = false;

            if((_tafl[PawnPositionOrigineX, PawnPositionOrigineY] == Pawn.Attacker)
                || (_tafl[PawnPositionOrigineX, PawnPositionOrigineY] == Pawn.Defender))
            {
                _createStudiedListGroup = new List<StudiedPawn>();
                CheckUpStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY);
                CheckDownStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY);
                CheckLeftStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY);
                CheckRightStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY);
                _checkIfStudiedPawnCanBeCaptureNextTurn = CheckLibertyGroup();

            }
            else if(_tafl[PawnPositionOrigineX, PawnPositionOrigineY] == Pawn.King)
            {
                _KingLostLiberty = 0;

                if (CheckUpStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY) == true)
                {
                    _KingLostLiberty++;
                }
                if (CheckDownStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY) == true)
                {
                    _KingLostLiberty++;
                }
                if (CheckLeftStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY) == true)
                {
                    _KingLostLiberty++;
                }
                if (CheckRightStudiedPawn(PawnPositionOrigineX, PawnPositionOrigineY) == true)
                {
                    _KingLostLiberty++;
                }

                if(_KingLostLiberty < 2)
                {
                    
                }
            }
            

            if (_checkIfStudiedPawnCanBeCaptureNextTurn == true)
            {
                SetScoreStudiedPawnOrigineFree();
            }

            return false;
        }

        private bool PawnDestinationFree(int PawnDestinationX, int PawnDestinationY)
        {
            _checkIfStudiedPawnCanBeCaptureNextTurn = false;

            if((_tafl[PawnDestinationX, PawnDestinationY] == Pawn.Attacker)
                || (_tafl[PawnDestinationX, PawnDestinationY] == Pawn.Defender))
            {
                _createStudiedListGroup = new List<StudiedPawn>();
                CheckUpStudiedPawn(PawnDestinationX, PawnDestinationY);
                CheckDownStudiedPawn(PawnDestinationX, PawnDestinationY);
                CheckRightStudiedPawn(PawnDestinationX, PawnDestinationY);
                CheckLeftStudiedPawn(PawnDestinationX, PawnDestinationY);
                _checkIfStudiedPawnCanBeCaptureNextTurn = CheckLibertyGroup();
            }
            else if(_tafl[PawnDestinationX, PawnDestinationY] == Pawn.King)
            {
                _KingLostLiberty = 0;

                if (CheckUpStudiedPawn(PawnDestinationX, PawnDestinationY) == true)
                {
                    _KingLostLiberty++;
                }
                if (CheckDownStudiedPawn(PawnDestinationX, PawnDestinationY) == true)
                {
                    _KingLostLiberty++;
                }
                if (CheckLeftStudiedPawn(PawnDestinationX, PawnDestinationY) == true)
                {
                    _KingLostLiberty++;
                }
                if (CheckRightStudiedPawn(PawnDestinationX, PawnDestinationY) == true)
                {
                    _KingLostLiberty++;
                }

                if (_KingLostLiberty < 2)
                {
                    _studiedPawnPositionDestinationLibertyScore += 2;
                }
            }
            

            if (_checkIfStudiedPawnCanBeCaptureNextTurn == true)
            {
                StudiedPawn pawn = new StudiedPawn(PawnDestinationX, PawnDestinationY);
                
                SetScoreStudiedPawnDestinationFree(pawn);
            }
            return false;
        }


        //Fonctions de score

        private void setScoreCapturePawn()
        {
            if(_father.IsAtkPlay == true)
            {
                _scoreCaptureTurn = (_atkCount - _tafl.AttackerCount) * 2;
            }else
            {
                _scoreCaptureTurn = (_defCount - _tafl.DefenderCount) * 2;
            }
        }

        private void SetScoreStudiedPawnOrigineFree()
        {
            if(_father.IsAtkPlay == true) 
            {
                if(_atkCount <= _defCount)
                {
                    _studiedPawnPositionOrigineLibertyScore += 6;
                }else
                {
                    _studiedPawnPositionOrigineLibertyScore += 3;
                }
            }else
            {
                if(_defCount <= _atkCount)
                {
                    _studiedPawnPositionOrigineLibertyScore += 6;
                }else
                {
                    _studiedPawnPositionOrigineLibertyScore += 3;
                }
            }
        }

        private void SetScoreStudiedPawnDestinationFree(StudiedPawn pawn)
        {
            if (_father.IsAtkPlay == true)
            {
                if (_atkCount <= _defCount)
                {
                    _studiedPawnPositionDestinationLibertyScore += -10;
                }
                else
                {
                    _studiedPawnPositionDestinationLibertyScore += 3;
                }
                if((pawn.X <= ((_tafl.Width - 1) / 2)) && (pawn.Y <= ((_tafl.Height - 1) / 2)) && (_positionKingUpLeft = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
                else if ((pawn.X >= ((_tafl.Width - 1) / 2)) && (pawn.Y <= ((_tafl.Height - 1) / 2)) && (_positionKingUpRight = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
                else if ((pawn.X <= ((_tafl.Width - 1) / 2)) && (pawn.Y >= ((_tafl.Height - 1) / 2)) && (_positionKingDownLeft = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
                else if ((pawn.X >= ((_tafl.Width - 1) / 2)) && (pawn.Y >= ((_tafl.Height - 1) / 2)) && (_positionKingDownRight = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
            }
            else
            {
                if (_defCount <= _atkCount)
                {
                    _studiedPawnPositionDestinationLibertyScore += 6;
                }
                else
                {
                    _studiedPawnPositionDestinationLibertyScore += 3;
                }
                if ((pawn.X <= ((_tafl.Width - 1) / 2)) && (pawn.Y <= ((_tafl.Height - 1) / 2)) && (_bestMovedefUpLeft = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
                else if ((pawn.X >= ((_tafl.Width - 1) / 2)) && (pawn.Y <= ((_tafl.Height - 1) / 2)) && (_bestMovedefUpRight = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
                else if ((pawn.X <= ((_tafl.Width - 1) / 2)) && (pawn.Y >= ((_tafl.Height - 1) / 2)) && (_bestMovedefDownLeft = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
                else if ((pawn.X >= ((_tafl.Width - 1) / 2)) && (pawn.Y >= ((_tafl.Height - 1) / 2)) && (_bestMovedefDownRight = true))
                {
                    _studiedPawnPositionDestinationLibertyScore += 10;
                }
            }
        }

        private int setFinalScore()
        {
            int FinalScore = 0;

            FinalScore = _studiedPawnPositionDestinationLibertyScore + _studiedPawnPositionOrigineLibertyScore + _scoreCaptureTurn;

            return FinalScore;
        }



        /////////////////////////////////////// Fonctions d'analyse /////////////////////////////////////////////////


        //Create List of studied Pawn and study this list

        /// <summary>
        /// Create list of pawn base on pawn around studied pawn
        /// </summary>
        /// <param name="studiedPawnPositionX"></param>
        /// <param name="studiedPawnPositionY"></param>
        private void CreateFriendListPawn(int studiedPawnPositionX, int studiedPawnPositionY)        
        {
            // Check Up
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX, studiedPawnPositionY - 1])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY - 1);
                CheckFriendListPawnStocked(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX, studiedPawnPositionY - 1);
            }

            // Check Down
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX, studiedPawnPositionY + 1])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY + 1);
                CheckFriendListPawnStocked(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX, studiedPawnPositionY + 1);
            }

            // Check Left
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX - 1, studiedPawnPositionY])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX - 1, studiedPawnPositionY);
                CheckFriendListPawnStocked(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX - 1, studiedPawnPositionY);
            }

            // Check Right
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX + 1, studiedPawnPositionY])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX + 1, studiedPawnPositionY);
                CheckFriendListPawnStocked(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX + 1, studiedPawnPositionY);
            }
        }

        /// <summary>
        /// look if studied panw is already in the list, if not add it
        /// </summary>
        /// <param name="studiedPawn"></param>
        private void CheckFriendListPawnStocked(StudiedPawn studiedPawn)       
        {
            if (_createStudiedListGroup.Contains(studiedPawn)==false)
            {
                _createStudiedListGroup.Add(studiedPawn);
            }
        }
        
        /// <summary>
        /// check Liberty of a group of pawn
        /// </summary>
        /// <param name="Current"></param>
        private bool CheckLibertyGroup()
        {
            _libertyGroupStudied = 0;
            studiedGroupCanBeCaptured = false;
            int _countGroupPawn = 0;

            foreach (StudiedPawn studiedPawn in _createStudiedListGroup)
            {
                if (_tafl[studiedPawn.X, studiedPawn.Y - 1] == Pawn.None)
                {
                    _libertyGroupStudied++;
                }
                if (_tafl[studiedPawn.X, studiedPawn.Y + 1] == Pawn.None)
                {
                    _libertyGroupStudied++;
                }
                if (_tafl[studiedPawn.X - 1, studiedPawn.Y] == Pawn.None)
                {
                    _libertyGroupStudied++;
                }
                if (_tafl[studiedPawn.X + 1, studiedPawn.Y] == Pawn.None)
                {
                    _libertyGroupStudied++;
                }
                _countGroupPawn++;
            }

            if(_libertyGroupStudied < _countGroupPawn / 4)
            {
                return true;
            }
            return false;
        }


        //Check Around Pawn : CheckUp, CheckDown, CheckLeft, CheckRight

        /// <summary>
        /// Check Right if their is a enemy pawn. If it's true, check if studied pawn can be capture next turn
        /// </summary>
        /// <param name="studiedPawnPositionX"></param>
        /// <param name="studiedPawnPositionY"></param>
        /// <returns></returns>
        private bool CheckRightStudiedPawn(int studiedPawnPositionX, int studiedPawnPositionY)
        {
            _positionStudiedPawnX = studiedPawnPositionX;
            _positionSutdiedPawnY = studiedPawnPositionY;
            if (((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Attacker) && ((_tafl[studiedPawnPositionX + 1, studiedPawnPositionY] == Pawn.Defender) || (_tafl[studiedPawnPositionX + 1, studiedPawnPositionY] == Pawn.Wall)))
                || ((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Defender) && ((_tafl[studiedPawnPositionX + 1, studiedPawnPositionY] == Pawn.Attacker) || (_tafl[studiedPawnPositionX + 1, studiedPawnPositionY] == Pawn.Wall))))
            {
                _studiedPawnOriginePositionLiberty = false;
                if (_tafl[studiedPawnPositionX - 1, studiedPawnPositionY] == Pawn.None)
                {
                    if (CheckHorizontalAndVerticalCaptureStudiedPawn(studiedPawnPositionX - 1, studiedPawnPositionY) == true)
                    {
                        _checkIfStudiedPawnCanBeCaptureNextTurn = true;
                    }
                }
            }else if(_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX + 1, studiedPawnPositionY])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY);
                _createStudiedListGroup = new List<StudiedPawn>();
                _createStudiedListGroup.Add(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX, studiedPawnPositionY);
            }
            else
            {
                _studiedPawnOriginePositionLiberty = true;
            }

            return false;
        }

        /// <summary>
        /// Check Left if their is a enemy pawn. If it's true, check if studied pawn can be capture next turn
        /// </summary>
        /// <param name="studiedPawnPositionX"></param>
        /// <param name="studeidPawnPositionY"></param>
        /// <returns></returns>
        private bool CheckLeftStudiedPawn(int studiedPawnPositionX, int studiedPawnPositionY)
        {
            _positionStudiedPawnX = studiedPawnPositionX;
            _positionSutdiedPawnY = studiedPawnPositionY;

            if (((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Attacker) && ((_tafl[studiedPawnPositionX - 1, studiedPawnPositionY] == Pawn.Defender) || (_tafl[studiedPawnPositionX - 1, studiedPawnPositionY] == Pawn.Wall)))
                || ((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Defender) && ((_tafl[studiedPawnPositionX - 1, studiedPawnPositionY] == Pawn.Attacker) || (_tafl[studiedPawnPositionX - 1, studiedPawnPositionY] == Pawn.Wall))))
            {
                _studiedPawnOriginePositionLiberty = false;
                if (_tafl[studiedPawnPositionX + 1, studiedPawnPositionY] == Pawn.None)
                {
                    if (CheckHorizontalAndVerticalCaptureStudiedPawn(studiedPawnPositionX + 1, studiedPawnPositionY) == true)
                    {
                        _checkIfStudiedPawnCanBeCaptureNextTurn = true;
                    }
                }
            }
            else if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX - 1, studiedPawnPositionY])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY);
                _createStudiedListGroup = new List<StudiedPawn>();
                _createStudiedListGroup.Add(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX, studiedPawnPositionY);
            }
            else
            {
                _studiedPawnOriginePositionLiberty = true;
            }

            return false;
        }

        /// <summary>
        /// Check Down if their is a enemy pawn. If it's true, check if studied pawn can be capture next turn
        /// </summary>
        /// <param name="studiedPawnPositionX"></param>
        /// <param name="studiedPawnPositionY"></param>
        /// <returns></returns>
        private bool CheckDownStudiedPawn(int studiedPawnPositionX, int studiedPawnPositionY)
        {
            _positionStudiedPawnX = studiedPawnPositionX;
            _positionSutdiedPawnY = studiedPawnPositionY;

            if (((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Attacker) && ((_tafl[studiedPawnPositionX , studiedPawnPositionY + 1] == Pawn.Defender) || (_tafl[studiedPawnPositionX, studiedPawnPositionY + 1] == Pawn.Wall)))
                || ((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Defender) && ((_tafl[studiedPawnPositionX , studiedPawnPositionY + 1] == Pawn.Attacker) || (_tafl[studiedPawnPositionX , studiedPawnPositionY + 1] == Pawn.Wall))))
            {
                _studiedPawnOriginePositionLiberty = false;
                if (_tafl[studiedPawnPositionX, studiedPawnPositionY - 1] == Pawn.None)
                {
                    if (CheckHorizontalAndVerticalCaptureStudiedPawn(studiedPawnPositionX, studiedPawnPositionY - 1) == true)
                    {
                        _checkIfStudiedPawnCanBeCaptureNextTurn = true;
                    }
                }
            }
            else if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX, studiedPawnPositionY + 1])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY);
                _createStudiedListGroup = new List<StudiedPawn>();
                _createStudiedListGroup.Add(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX, studiedPawnPositionY);
            }
            else
            {
                _studiedPawnOriginePositionLiberty = true;
            }

            return false;
        }

        /// <summary>
        /// Check Up if their is a enemy pawn
        /// if true, check if studied pawn can be capture next turn
        /// </summary>
        /// <param name="studiedPawnPositionX"></param>
        /// <param name="studiedPawnPositionY"></param>
        /// <returns></returns>
        private bool CheckUpStudiedPawn(int studiedPawnPositionX, int studiedPawnPositionY)
        {
            _positionStudiedPawnX = studiedPawnPositionX;
            _positionSutdiedPawnY = studiedPawnPositionY;

            if (((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Attacker) && ((_tafl[studiedPawnPositionX, studiedPawnPositionY - 1] == Pawn.Defender) || (_tafl[studiedPawnPositionX, studiedPawnPositionY - 1] == Pawn.Wall)))
               || ((_tafl[studiedPawnPositionX, studiedPawnPositionY] == Pawn.Defender) && ((_tafl[studiedPawnPositionX, studiedPawnPositionY - 1] == Pawn.Attacker) || (_tafl[studiedPawnPositionX, studiedPawnPositionY - 1] == Pawn.Wall))))
            {
                _studiedPawnOriginePositionLiberty = false;
                if(_tafl[studiedPawnPositionX, studiedPawnPositionY + 1] == Pawn.None)
                {
                    if(CheckHorizontalAndVerticalCaptureStudiedPawn(studiedPawnPositionX, studiedPawnPositionY + 1) == true)
                    {
                        _checkIfStudiedPawnCanBeCaptureNextTurn = true;
                    }
                }
            }else if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX, studiedPawnPositionY - 1])
            {
                StudiedPawn studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY);
                _createStudiedListGroup = new List<StudiedPawn>();
                _createStudiedListGroup.Add(studiedPawn);
                CreateFriendListPawn(studiedPawnPositionX, studiedPawnPositionY);
            }else
            {
                _studiedPawnOriginePositionLiberty = true;
            }

            return false;
        }

        /// <summary>
        /// This fonction search on the horizontal line and vertical Line if their is an enemy pawn of studied Pawn.
        /// </summary>
        /// <param name="studiedPawnPositionX"></param>
        /// <param name="studiedPawnPositionY"></param>
        /// <returns></returns>
        private bool CheckHorizontalAndVerticalCaptureStudiedPawn(int studiedPawnPositionX, int studiedPawnPositionY)
        {
            for (int i = 0; i < _tafl.Width; i++)
            {
                if (((_tafl[i, studiedPawnPositionY] == Pawn.Defender) && (_tafl[_positionStudiedPawnX, _positionSutdiedPawnY] == Pawn.Attacker))
                    || ((_tafl[i, studiedPawnPositionY] == Pawn.Attacker) && (_tafl[_positionStudiedPawnX, _positionSutdiedPawnY] == Pawn.Defender)))
                {
                    if (PossiblePawnMove(i, studiedPawnPositionY, studiedPawnPositionX, studiedPawnPositionY) == false)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < _tafl.Height; i++)
            {
                if (((_tafl[studiedPawnPositionX, i] == Pawn.Defender) && (_tafl[_positionStudiedPawnX, _positionSutdiedPawnY] == Pawn.Attacker))
                    || ((_tafl[studiedPawnPositionX, i]) == Pawn.Attacker && (_tafl[_positionStudiedPawnX, _positionSutdiedPawnY] == Pawn.Defender)))
                {
                    if (PossiblePawnMove(studiedPawnPositionX, i, studiedPawnPositionX, studiedPawnPositionY) == true)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        /// <summary>
        /// Check if a pawn can move to taget square
        /// </summary>
        /// <param name="StudiedPawnPositionX"></param>
        /// <param name="StudiedPawnPositionY"></param>
        /// <param name="StudiedPawndestinationX"></param>
        /// <param name="StudiedPawndestinationY"></param>
        /// <returns></returns>
        private bool PossiblePawnMove(int StudiedPawnPositionX, int StudiedPawnPositionY, int StudiedPawndestinationX, int StudiedPawndestinationY)
        {
            int incrementJ = 0, incrementI = 0;

            if (StudiedPawnPositionX > StudiedPawndestinationX)
            {
                incrementI = -1;
            }
            if (StudiedPawnPositionX < StudiedPawndestinationX)
            {
                incrementI = 1;
            }
            if (StudiedPawnPositionY > StudiedPawndestinationY)
            {
                incrementJ = -1;
            }
            if (StudiedPawnPositionY < StudiedPawndestinationY)
            {
                incrementJ = 1;
            }

            for (int j = StudiedPawnPositionY; j != StudiedPawndestinationY; j += incrementJ)
            {
                for (int i = StudiedPawnPositionX; i != StudiedPawndestinationX; i += incrementI)
                {
                    
                    if (_tafl[i, j] != Pawn.None)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Set le nombre de pion , atk et def, au début du tour
        /// </summary>
        private void NumberOfPawnAtTheBeginningOfTheTurn()
        {
            _atkCount = _tafl.AttackerCount;
            _defCount = _tafl.DefenderCount;
        }

        private void CheckNumberOfPawnInPartOfBoard()
        {
            _bestMovedefDownLeft = false;
            _bestMovedefDownRight = false;
            _bestMovedefUpLeft = false;
            _bestMovedefUpRight = false;

            for(int y = 0; y < _tafl.Height; y++)
            {
                for(int x = 0; x < _tafl.Width; x++)
                {
                    if((x <= ((_tafl.Width - 1 / 2))) && (y <= ((_tafl.Height - 1) / 2)))
                    {
                        if(_father.IsAtkPlay == true)
                        {
                            if(_tafl[x, y] == Pawn.Defender)
                            {
                                _nbOfPawnInPatieUpLeftOfBoard += 1;
                            }
                            if(_tafl[x, y] == Pawn.King)
                            {
                                _nbOfPawnInPatieUpLeftOfBoard += 1;
                                _bestMovedefUpLeft = true;
                            }
                        }else
                        {
                            if(_tafl[x, y] == Pawn.Attacker)
                            {
                                _nbOfPawnInPatieUpLeftOfBoard += 1;
                            }
                        }
                    }

                    if ((x >= ((_tafl.Width - 1 / 2))) && (y <= ((_tafl.Height - 1) / 2)))
                    {
                        if (_father.IsAtkPlay == true)
                        {
                            if (_tafl[x, y] == Pawn.Defender)
                            {
                                _nbOfPawnInPatieUpRightOfBoard += 1;
                            }
                            if (_tafl[x, y] == Pawn.King)
                            {
                                _nbOfPawnInPatieUpRightOfBoard += 1;
                                _bestMovedefUpRight = true;
                            }
                        }
                        else
                        {
                            if (_tafl[x, y] == Pawn.Attacker)
                            {
                                _nbOfPawnInPatieUpRightOfBoard += 1;
                            }
                        }
                    }

                    if ((x <= ((_tafl.Width - 1 / 2))) && (y >= ((_tafl.Height - 1) / 2)))
                    {
                        if (_father.IsAtkPlay == true)
                        {
                            if (_tafl[x, y] == Pawn.Defender)
                            {
                                _nbOfPawnInPatieDownLeftOfBoard += 1;
                            }
                            if (_tafl[x, y] == Pawn.King)
                            {
                                _nbOfPawnInPatieDownLeftOfBoard += 1;
                                _bestMovedefDownLeft = true;
                            }
                        }
                        else
                        {
                            if (_tafl[x, y] == Pawn.Attacker)
                            {
                                _nbOfPawnInPatieDownLeftOfBoard += 1;
                            }
                        }
                    }

                    if ((x >= ((_tafl.Width - 1 / 2))) && (y >= ((_tafl.Height - 1) / 2)))
                    {
                        if (_father.IsAtkPlay == true)
                        {
                            if (_tafl[x, y] == Pawn.Defender)
                            {
                                _nbOfPawnInPatieDownRightOfBoard += 1;
                            }
                            if (_tafl[x, y] == Pawn.King)
                            {
                                _nbOfPawnInPatieDownRightOfBoard += 1;
                                _bestMovedefDownRight = true;
                            }
                        }
                        else
                        {
                            if (_tafl[x, y] == Pawn.Attacker)
                            {
                                _nbOfPawnInPatieDownRightOfBoard += 1;
                            }
                        }
                    }
                }
            }
            
            if((_nbOfPawnInPatieDownLeftOfBoard > _nbOfPawnInPatieDownRightOfBoard)
                && (_nbOfPawnInPatieDownLeftOfBoard > _nbOfPawnInPatieUpLeftOfBoard)
                && (_nbOfPawnInPatieDownLeftOfBoard > _nbOfPawnInPatieUpRightOfBoard))
            {
                _bestMovedefDownLeft = true;
            }
            else if((_nbOfPawnInPatieDownRightOfBoard > _nbOfPawnInPatieDownLeftOfBoard)
                        && (_nbOfPawnInPatieDownRightOfBoard > _nbOfPawnInPatieUpLeftOfBoard)
                         && (_nbOfPawnInPatieDownRightOfBoard > _nbOfPawnInPatieUpRightOfBoard))
            {
                _bestMovedefDownRight = true;
            }
            else if ((_nbOfPawnInPatieUpLeftOfBoard > _nbOfPawnInPatieDownRightOfBoard)
                   && (_nbOfPawnInPatieUpLeftOfBoard > _nbOfPawnInPatieDownLeftOfBoard)
                    && (_nbOfPawnInPatieUpLeftOfBoard > _nbOfPawnInPatieUpRightOfBoard))
            {
                _bestMovedefUpLeft = true;
            }
            else if ((_nbOfPawnInPatieUpRightOfBoard > _nbOfPawnInPatieDownRightOfBoard)
                        && (_nbOfPawnInPatieUpRightOfBoard > _nbOfPawnInPatieDownLeftOfBoard)
                         && (_nbOfPawnInPatieUpRightOfBoard > _nbOfPawnInPatieUpLeftOfBoard))
            {
                _bestMovedefUpRight = true;
            }

        }



    }
}
