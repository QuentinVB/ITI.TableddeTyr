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

        Game _game;
        List<StudiedPawn> _friendListGroup;
        StudiedPawn _studiedPawn;
        internal IReadOnlyTafl _tafl;
        bool _pawnIsFree = true;
        int _destinationOriginePawnX = 0;
        int _destinationOriginePawnY = 0;
        int _GroupLiberty = 0;
        int _score = 0;
        int _nbPawn = 0;
        int _nbPawnCaptureScore = 0;
        int _nbNextTurnCapture = 0;
        bool _isIaATk;


        Freyja_Core _ctx;

        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;            
        }
        
        internal SimulationNode UpdateAnalyze(SimulationNode father, SimulationNode child)
        {
            _game = new Game();
            _isIaATk = _ctx.Sensor.IsFreyjaAtk;
            _father = father;
            _child = child;
            _tafl = father.TaflStored;
            _friendListGroup = new List<StudiedPawn>();

            checkIfMovedPawnIsStillFree(_father._originalMove.destinationX, _father._originalMove.destinationY);
            if(_score == -1)
            {
                _child.Score = _score;
                return _child;
            }
            setNumberOfPawn();
            _game.MovePawn(_father.OriginMove.sourceX, _father.OriginMove.sourceY, _father.OriginMove.destinationX, _father.OriginMove.destinationY);
            NumberPawnCapture();
            setScoreChild();


            return _child;
        }

        private void checkNextTurnCapture(int destX, int destY)
        {

            #region Check Up Next Capture
            if ((_tafl[destX, destY] == Pawn.Defender && _tafl[destX, destY - 1] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX, destY - 1] == Pawn.Defender))
            {
                if (_tafl[destX, destY - 2] == Pawn.None)  // check au dessus du pion ciblé si il la case est vide
                {
                    _destinationOriginePawnX = destX;
                    _destinationOriginePawnY = destY - 1;
                    checkOpposantPawnOnHorizontalLine(destX, destY - 2);
                    checkOpposantPawnOnVerticalLine(destX, destY - 2);
                    if(_pawnIsFree == false)
                    {
                        _nbNextTurnCapture++;
                    }
                }
            }
            #endregion

            #region Check Down Next Capture
            if ((_tafl[destX, destY] == Pawn.Defender && _tafl[destX, destY + 1] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX, destY + 1] == Pawn.Defender))
            {
                if (_tafl[destX, destY + 2] == Pawn.None)  // check en dessous du pion ciblé si il la case est vide
                {
                    _destinationOriginePawnX = destX;
                    _destinationOriginePawnY = destY + 1;
                    checkOpposantPawnOnHorizontalLine(destX, destY + 2);
                    checkOpposantPawnOnVerticalLine(destX, destY + 2);
                    if (_pawnIsFree == false)
                    {
                        _nbNextTurnCapture++;
                    }
                }
            }
            #endregion

            #region Check Left Next Capture
            if ((_tafl[destX, destY] == Pawn.Defender && _tafl[destX - 1, destY] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX - 1, destY] == Pawn.Defender))
            {
                if (_tafl[destX - 2, destY] == Pawn.None)  // check à gauche du pion ciblé si il la case est vide
                {
                    _destinationOriginePawnX = destX - 1;
                    _destinationOriginePawnY = destY;
                    checkOpposantPawnOnHorizontalLine(destX - 2, destY);
                    checkOpposantPawnOnVerticalLine(destX - 2, destY);
                    if (_pawnIsFree == false)
                    {
                        _nbNextTurnCapture++;
                    }
                }
            }
            #endregion

            #region Check Right Next Capture
            if ((_tafl[destX, destY] == Pawn.Defender && _tafl[destX + 1, destY] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX + 1, destY] == Pawn.Defender))
            {
                if (_tafl[destX + 2, destY] == Pawn.None)  // check à droite du pion ciblé si il la case est vide
                {
                    _destinationOriginePawnX = destX + 1;
                    _destinationOriginePawnY = destY;
                    checkOpposantPawnOnHorizontalLine(destX + 2, destY);
                    checkOpposantPawnOnVerticalLine(destX + 2, destY);
                    if (_pawnIsFree == false)
                    {
                        _nbNextTurnCapture++;
                    }
                }
            }
            #endregion

        }

        private void checkIfMovedPawnIsStillFree(int destX, int destY)
        {
            _pawnIsFree = true;

            if((_tafl[destX, destY] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Defender))
            {
                checkAroundPawn(destX, destY);
            }
            if (_tafl[destX, destY] == Pawn.King)
            {
                if(CheckAroundKing(destX, destY) == true)
                {
                    _score += -1;
                }
            }
        }

        private bool CheckAroundKing(int destX, int destY)
        {
            int countKingSimpleLiberty = 4;
            int countKingSimpleLibertyUp = 0;
            int countKingSimpleLibertyDown = 0;
            int countKingSimpleLibertyLeft = 0;
            int countKingSimpleLibertyRight = 0;


            if ((_tafl[destX, destY - 1] == Pawn.Wall) || (_tafl[destX, destY - 1] == Pawn.Attacker))
            {
                countKingSimpleLibertyUp = -1;
            }
            if (_tafl[destX, destY - 1] == Pawn.None)
            {
                checkOpposantPawnOnHorizontalLine(destX, destY - 1);
                checkOpposantPawnOnVerticalLine(destX, destY - 1);
                if (_pawnIsFree == false)
                {
                    countKingSimpleLibertyUp = -1;
                }
            }
            if (_tafl[destX, destY - 1] == Pawn.Defender)
            {
                createListePawn(destX, destY);
                if (checkCaptureGroup() == true)
                {
                    countKingSimpleLibertyRight = -1;
                }
            }


            if ((_tafl[destX, destY + 1] == Pawn.Wall) || (_tafl[destX, destY + 1] == Pawn.Attacker))
            {
                countKingSimpleLibertyDown = -1;
            }
            if (_tafl[destX, destY + 1] == Pawn.None)
            {
                checkOpposantPawnOnHorizontalLine(destX, destY + 1);
                checkOpposantPawnOnVerticalLine(destX, destY + 1);
                if (_pawnIsFree == false)
                {
                    countKingSimpleLibertyDown = -1;
                }
            }
            if (_tafl[destX, destY + 1] == Pawn.Defender)
            {
                createListePawn(destX, destY);
                if (checkCaptureGroup() == true)
                {
                    countKingSimpleLibertyRight = -1;
                }
            }


            if ((_tafl[destX -1, destY] == Pawn.Wall) || (_tafl[destX -1, destY] == Pawn.Attacker))
            {
                countKingSimpleLibertyLeft = -1;
            }
            if (_tafl[destX - 1, destY] == Pawn.None)
            {
                checkOpposantPawnOnHorizontalLine(destX - 1, destY);
                checkOpposantPawnOnVerticalLine(destX - 1, destY);
                if (_pawnIsFree == false)
                {
                    countKingSimpleLibertyLeft = -1;
                }
            }
            if (_tafl[destX - 1, destY] == Pawn.Defender)
            {
                createListePawn(destX, destY);
                if (checkCaptureGroup() == true)
                {
                    countKingSimpleLibertyRight = -1;
                }
            }


            if ((_tafl[destX + 1, destY] == Pawn.Wall) || (_tafl[destX + 1, destY] == Pawn.Attacker))
            {
                countKingSimpleLibertyRight = -1;
            }
            if (_tafl[destX + 1, destY] == Pawn.None)
            {
                checkOpposantPawnOnHorizontalLine(destX + 1, destY);
                checkOpposantPawnOnVerticalLine(destX + 1, destY);
                if (_pawnIsFree == false)
                {
                    countKingSimpleLibertyRight = -1;
                }
            }
            if(_tafl[destX + 1, destY] == Pawn.Defender)
            {
                createListePawn(destX, destY);
                if(checkCaptureGroup() == true)
                {
                    countKingSimpleLibertyRight = -1;
                }
            }

            countKingSimpleLiberty = countKingSimpleLibertyUp + countKingSimpleLibertyDown + countKingSimpleLibertyLeft + countKingSimpleLibertyRight;

            if (countKingSimpleLiberty >= 2)
            {
                return false;
            }
            if(countKingSimpleLiberty == 1)
            {
                return true;
            }

            return true;
        }

        private void checkAroundPawn(int destX, int destY)
        {
            // check Up
            if ((_tafl[destX, destY - 1] == Pawn.Wall)      // check si au dessus de lui il ya un mur ou un pion adverse
                || (_tafl[destX, destY] == Pawn.Defender && _tafl[destX, destY - 1] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX, destY - 1] == Pawn.Defender))
            {
                if (_tafl[destX, destY + 1] == Pawn.None)  // check si en dessous de lui la case est vide
                {
                    _destinationOriginePawnX = destX;
                    _destinationOriginePawnY = destY;
                    checkOpposantPawnOnHorizontalLine(destX, destY + 1);
                    checkOpposantPawnOnVerticalLine(destX, destY + 1);
                    if ((_pawnIsFree == false) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                    {
                        _score += -1;
                    }
                    if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                        && (_tafl.AttackerCount <= _tafl.DefenderCount))
                    {
                        _score += -1;
                    }
                }
            }
            if(_tafl[destX, destY - 1] == _tafl[destX, destY])
            {
                createListePawn(destX, destY);
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                {
                    _score += -1;
                }
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                    && (_tafl.AttackerCount <= _tafl.DefenderCount))
                {
                    _score += -1;
                }
            }

            // check Down
            if ((_tafl[destX, destY + 1] == Pawn.Wall)      // check si en dessous de lui il ya un mur ou un pion adverse
                || (_tafl[destX, destY] == Pawn.Defender && _tafl[destX, destY + 1] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX, destY + 1] == Pawn.Defender))
            {
                if (_tafl[destX, destY - 1] == Pawn.None)  // check si au dessus de lui la case est vide
                {
                    _destinationOriginePawnX = destX;
                    _destinationOriginePawnY = destY;
                    checkOpposantPawnOnHorizontalLine(destX, destY - 1);
                    checkOpposantPawnOnVerticalLine(destX, destY - 1);
                    if ((_pawnIsFree == false) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                    {
                        _score += -1;
                    }
                    if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                        && (_tafl.AttackerCount <= _tafl.DefenderCount))
                    {
                        _score += -1;
                    }
                }
            }
            if (_tafl[destX, destY + 1] == _tafl[destX, destY])
            {
                createListePawn(destX, destY);
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                {
                    _score += -1;
                }
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                    && (_tafl.AttackerCount <= _tafl.DefenderCount))
                {
                    _score += -1;
                }
            }

            // check Left
            if ((_tafl[destX - 1, destY] == Pawn.Wall)      // check si en dessous de lui il ya un mur ou un pion adverse
                || (_tafl[destX, destY] == Pawn.Defender && _tafl[destX - 1, destY] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX - 1, destY] == Pawn.Defender))
            {
                if (_tafl[destX + 1, destY] == Pawn.None)  // check si au dessus de lui la case est vide
                {
                    _destinationOriginePawnX = destX;
                    _destinationOriginePawnY = destY;
                    checkOpposantPawnOnHorizontalLine(destX + 1, destY);
                    checkOpposantPawnOnVerticalLine(destX + 1, destY);
                    if ((_pawnIsFree == false) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                    {
                        _score += -1;
                    }
                    if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                        && (_tafl.AttackerCount <= _tafl.DefenderCount))
                    {
                        _score += -1;
                    }
                }
            }
            if (_tafl[destX - 1, destY] == _tafl[destX, destY])
            {
                createListePawn(destX, destY);
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                {
                    _score += -1;
                }
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                    && (_tafl.AttackerCount <= _tafl.DefenderCount))
                {
                    _score += -1;
                }
            }

            // check Right
            if ((_tafl[destX + 1, destY] == Pawn.Wall)      // check si en dessous de lui il ya un mur ou un pion adverse
                || (_tafl[destX, destY] == Pawn.Defender && _tafl[destX + 1, destY] == Pawn.Attacker)
                || (_tafl[destX, destY] == Pawn.Attacker && _tafl[destX + 1, destY] == Pawn.Defender))
            {
                if (_tafl[destX - 1, destY] == Pawn.None)  // check si au dessus de lui la case est vide
                {
                    _destinationOriginePawnX = destX;
                    _destinationOriginePawnY = destY;
                    checkOpposantPawnOnHorizontalLine(destX - 1, destY);
                    checkOpposantPawnOnVerticalLine(destX - 1, destY);
                    if ((_pawnIsFree == false) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                    {
                        _score += -1;
                    }
                    if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                        && (_tafl.AttackerCount <= _tafl.DefenderCount))
                    {
                        _score += -1;
                    }
                }
            }
            if (_tafl[destX + 1, destY] == _tafl[destX, destY])
            {
                createListePawn(destX, destY);
                if((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                {
                    _score += -1;
                }
                if ((checkCaptureGroup() == true) && (_tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                    && (_tafl.AttackerCount <= _tafl.DefenderCount))
                {
                    _score += -1;
                }
            }
        }

        private void checkOpposantPawnOnHorizontalLine(int positionStudiedCaseX, int positionStudiedCaseY)
        {
            _pawnIsFree = false;

            for (int i = 0; i < _tafl.Width; i++)
            {
                if((_tafl[i, positionStudiedCaseY] == Pawn.Defender && _tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                    || (_tafl[i, positionStudiedCaseY] == Pawn.Attacker && _tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                {
                    if(PossibleMovePawn(i, positionStudiedCaseY, positionStudiedCaseX, positionStudiedCaseY) == false)
                    {
                        _pawnIsFree = true;
                    }
                }
            }
        }

        private void checkOpposantPawnOnVerticalLine(int positionStudiedCaseX, int positionStudiedCaseY)
        {
            _pawnIsFree = false;

            for (int i = 0; i < _tafl.Width; i++)
            {
                if ((_tafl[positionStudiedCaseX, i] == Pawn.Defender && _tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Attacker)
                    || (_tafl[positionStudiedCaseX, i] == Pawn.Attacker && _tafl[_destinationOriginePawnX, _destinationOriginePawnY] == Pawn.Defender))
                {
                    if(PossibleMovePawn(positionStudiedCaseX, i, positionStudiedCaseX, positionStudiedCaseY) == true)
                    {
                        _pawnIsFree = false;
                    }
                }
            }
        }           
       
        private bool PossibleMovePawn(int StudiedPawnPositionX, int StudiedPawnPositionY, int StudiedPawndestinationX, int StudiedPawndestinationY)     // vérifier si un pion peut se déplacer vers une autre case
        {
            int incrementJ = 0;
            int incrementI = 0;

            for (int j = StudiedPawnPositionY; j != StudiedPawndestinationY; j += incrementJ)
            {
                for (int i = StudiedPawnPositionX; i != StudiedPawndestinationX; i += incrementI)
                {
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
                    if (_tafl[i, j] != Pawn.None)
                    {
                        return true;
                    }
                }
            }
            return false;
        }   

        private bool checkCaptureGroup()        // vérifier si un groupe se fait capturer
        {
            foreach (StudiedPawn _studiedPawn in _friendListGroup)
            {
                checkPawnInGroupLiberty(_studiedPawn);
            }

            if (_GroupLiberty >= 2)
            {
                return false;
            }

            return true;
        }

        private void checkPawnInGroupLiberty(StudiedPawn Current)    // vérifier la libérté d'un pion dans un groupe
        {
            int StudiedPawnPositionX = Current.X;
            int StudiedPawnPositionY = Current.Y;

            if (_tafl[StudiedPawnPositionX, StudiedPawnPositionY - 1] == Pawn.None)
            {
                _GroupLiberty++;
            }
            if (_tafl[StudiedPawnPositionX, StudiedPawnPositionY + 1] == Pawn.None)
            {
                _GroupLiberty++;
            }
            if (_tafl[StudiedPawnPositionX - 1, StudiedPawnPositionY] == Pawn.None)
            {
                _GroupLiberty++;
            }
            if (_tafl[StudiedPawnPositionX + 1, StudiedPawnPositionY] == Pawn.None)
            {
                _GroupLiberty++;
            }
        }

        private void createListePawn(int studiedPawnPositionX, int studiedPawnPositionY)        // Creer la liste de pions à étudiés
        {
            _studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY);
            _friendListGroup.Add(_studiedPawn);

            // Check Up
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX, studiedPawnPositionY - 1])
            {
                checkListPawnStocked(studiedPawnPositionX, studiedPawnPositionY - 1);
            }

            // Check Down
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX, studiedPawnPositionY + 1])
            {
                checkListPawnStocked(studiedPawnPositionX, studiedPawnPositionY + 1);
            }

            // Check Left
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX - 1, studiedPawnPositionY])
            {
                checkListPawnStocked(studiedPawnPositionX - 1, studiedPawnPositionY);
            }

            // Check Right
            if (_tafl[studiedPawnPositionX, studiedPawnPositionY] == _tafl[studiedPawnPositionX + 1, studiedPawnPositionY])
            {
                checkListPawnStocked(studiedPawnPositionX + 1, studiedPawnPositionY);
            }
        }       

        private void checkListPawnStocked(int studiedPawnPositionX, int studiedPawnPositionY)       // vérifier si pion fait déja partie de la liste
        {
            _studiedPawn = new StudiedPawn(studiedPawnPositionX, studiedPawnPositionY);
            if(!_friendListGroup.Contains(_studiedPawn))
            {
                _friendListGroup.Add(_studiedPawn);
            }
        }   

        private void NumberPawnCapture()
        {
            if (_tafl[_father._originalMove.destinationX, _father._originalMove.destinationY] == Pawn.Attacker)
            {
                _nbPawnCaptureScore = (_nbPawn - _tafl.AttackerCount) * 2;
            }
            if ((_tafl[_father._originalMove.destinationX, _father._originalMove.destinationY] == Pawn.Defender)
                || (_tafl[_father._originalMove.destinationX, _father._originalMove.destinationY] == Pawn.King))
            {
                _nbPawnCaptureScore = (_nbPawn - _tafl.DefenderCount + 1) * 2 ;
            }

        }       //chercher le nombre de pion capturé après déplacement du pion

        private void setNumberOfPawn()
        {
            if(_tafl[_father._originalMove.destinationX, _father._originalMove.destinationY] == Pawn.Attacker)
            {
                _nbPawn = _tafl.AttackerCount;
            }
            if((_tafl[_father._originalMove.destinationX, _father._originalMove.destinationY] == Pawn.Defender)
                || (_tafl[_father._originalMove.destinationX, _father._originalMove.destinationY] == Pawn.King))
            {
                _nbPawn = _tafl.DefenderCount + 1;
            }
        }       // cherche le nombre de pion sur le plateau au début du tour

        private void setScoreChild()        // set le score de l'analyse au child
        {
            if(_father.IsAtkPlay == _isIaATk)
            {
                _child.Score = _score + _nbPawnCaptureScore + _nbNextTurnCapture + _father.Score;
            }else
            {
                _child.Score = _father.Score - _nbPawnCaptureScore - _nbNextTurnCapture - _score;
            }
                
        }       


       

    }
}
