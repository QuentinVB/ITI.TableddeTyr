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

        List<StudiedPawn> _friendListGroup;
        StudiedPawn _studiedPawn;
        internal IReadOnlyTafl _tafl;
        bool _pawnIsFree = true;
        int _destinationOriginePawnX = 0;
        int _destinationOriginePawnY = 0;
        int _GroupLiberty = 0;
        int _score = 0;


        int _studiedPawnFree = 0;
        int _studiedPawnBlock;
        int totalScore = 0;
        

        Move studiedPawn;

        bool _isAtkPlaying;
        Freyja_Core _ctx;

        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;            
        }
        
        internal SimulationNode UpdateAnalyze(SimulationNode father, SimulationNode child)
        {

            _father = father;
            _child = child;
            _tafl = father.TaflStored;
            _isAtkPlaying = father._isAtkPlaying;
            _friendListGroup = new List<StudiedPawn>();
            checkIfMovedPawnIsStillFree(_father._originalMove.destinationX, _father._originalMove.destinationY);
            // check capture

            _child.Score = _score;
            return _child;
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






        /////////////////////////////////////////////
        private void setScore()
        {
            if (_isAtkPlaying == true)
            {
                // checkCapture revoie le nb de capture
                _studiedPawnBlock = blockOtherPawn(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
                _studiedPawnFree = isFreeoptimise(_father.ThisMove.sourceX, _father.ThisMove.sourceY);


                totalScore = _studiedPawnBlock + _studiedPawnFree;
                if (totalScore <= 0)
                {
                    // retourner à l'IA que le move est inutile / dangereux
                }
            }
            else
            {
                _studiedPawnFree = isFreeoptimise(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
                if (_studiedPawnFree == -1)
                {
                    // retourner à l'IA que le move est inutile / dangereux
                }
                else
                {
                    // checkCapture
                    _studiedPawnBlock = blockOtherPawn(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
                }

                totalScore = _studiedPawnBlock + _studiedPawnFree;
                if (totalScore <= 0)
                {
                    // retourner à l'IA que le move est inutile / dangereux
                }
            }
        }

        internal int blockOtherPawn(int x, int y)
        {
            int temp = 0;
            int nbPawnBlock = 0;

            temp = isFree(x - 1, y);
            if(temp > 0 && temp <= 2)
            {
                nbPawnBlock++;
            }
            temp = isFree(x + 1, y);
            if (temp > 0 && temp <= 2)
            {
                nbPawnBlock++;
            }
            temp = isFree(x, y - 1);
            if (temp > 0 && temp <= 2)
            {
                nbPawnBlock++;
            }
            temp = isFree(x, y + 1);
            if (temp > 0 && temp <= 2)
            {
                nbPawnBlock++;
            }

            return nbPawnBlock;
        }
        
        internal int isFreeoptimise(int x, int y)
        {
            int total = 0;
            int temp;
            Pawn studiedPawn = _tafl[x, y];
            List<StudiedPawn> studiedListPawn = new List<StudiedPawn>();

            // check up
            if (!CheckWalls(x, y - 1))
            {
                if(_tafl[x, y - 1] != Pawn.None)
                {
                    if (IsFriendly(studiedPawn, x, y - 1))
                    {
                        studiedListPawn = new List<StudiedPawn>();
                        GetGroup(x, y - 1, studiedListPawn);
                        temp = GroupIsFree(studiedListPawn, total);
                        total = total + temp;
                    }
                    else
                    {
                        total--;
                    }
                }else if(_tafl[x, y - 1] == Pawn.None)
                {
                    total++;
                }
            }else
            {
                total--;
            }

            // check down
            if (!CheckWalls(x, y + 1))
            {
                if (_tafl[x, y + 1] != Pawn.None)
                {
                    if (IsFriendly(studiedPawn, x, y + 1))
                    {
                        studiedListPawn = new List<StudiedPawn>();
                        GetGroup(x, y + 1, studiedListPawn);
                        temp = GroupIsFree(studiedListPawn, total);
                        total = temp + total;
                    }
                    else
                    {
                        total--;
                    }
                }
                else if (_tafl[x, y + 1] == Pawn.None)
                {
                    total++;
                }
            }
            else
            {
                total--;
            }

            // check left
            if (!CheckWalls(x - 1, y))
            {
                if (_tafl[x - 1, y] != Pawn.None)
                {
                    if (IsFriendly(studiedPawn, x - 1, y))
                    {
                        studiedListPawn = new List<StudiedPawn>();
                        GetGroup(x - 1, y, studiedListPawn);
                        temp = GroupIsFree(studiedListPawn, total);
                        total = temp + total;
                    }
                    else
                    {
                        total--;
                    }
                }
                else if (_tafl[x - 1, y] == Pawn.None)
                {
                    total++;
                }
            }
            else
            {
                total--;
            }

            // check right
            if (!CheckWalls(x + 1, y))
            {
                if (_tafl[x + 1, y] != Pawn.None)
                {
                    if (IsFriendly(studiedPawn, x + 1, y))
                    {
                        studiedListPawn = new List<StudiedPawn>();
                        GetGroup(x + 1, y, studiedListPawn);
                        temp = GroupIsFree(studiedListPawn, total);
                        total = total + temp;
                    }
                    else
                    {
                        total--;
                    }
                }
                else if (_tafl[x + 1, y] == Pawn.None)
                {
                    total++;
                }
            }
            else
            {
                total--;
            }

            return total;
        }

        internal int GroupIsFree(List<StudiedPawn> pawnList, int total)
        {
            foreach (StudiedPawn current in pawnList)
            {
                if (_tafl[current.X, current.Y - 1] != Pawn.None)
                {
                    total--;
                }else
                {
                    total++;
                }
                if (_tafl[current.X, current.Y + 1] != Pawn.None)
                {
                    total--;
                }
                else
                {
                    total++;
                }
                if (_tafl[current.X - 1, current.Y] != Pawn.None)
                {
                    total--;
                }
                else
                {
                    total++;
                }
                if (_tafl[current.X + 1, current.Y] != Pawn.None)
                {
                    total--;
                }
                else
                {
                    total++;
                }
            }

            return total;
        }
    
        internal int isFree(int x, int y)
        {
            int pawnFree = 4;

            if (_tafl[x - 1, y] != Pawn.None)
            {
                pawnFree--;
            }
            if (_tafl[x + 1, y] != Pawn.None)
            {
                pawnFree--;
            }
            if (_tafl[x, y - 1] != Pawn.None)
            {
                pawnFree--;
            }
            if (_tafl[x, y + 1] != Pawn.None)
            {
                pawnFree--;
            }

            return pawnFree;
        }


        ///// code core 

        internal bool CheckUp(int x, int y)
        {
            if (y - 1 < 0 || _tafl[x, y - 1] != Pawn.None) return false;
            if (_tafl[x, y - 1] == Pawn.None) return true;
            return false;
        }
        internal bool CheckDown(int x, int y)
        {
            if (y + 1 >= _tafl.Height || _tafl[x, y + 1] != Pawn.None) return false;
            if (_tafl[x, y + 1] == Pawn.None) return true;
            return false;
        }
        internal bool CheckLeft(int x, int y)
        {
            if (x - 1 < 0 || _tafl[x - 1, y] != Pawn.None) return false;
            if (_tafl[x - 1, y] == Pawn.None) return true;
            return false;
        }
        internal bool CheckRight(int x, int y)
        {
            if (x + 1 >= _tafl.Width || _tafl[x + 1, y] != Pawn.None) return false;
            if (_tafl[x + 1, y] == Pawn.None) return true;
            return false;
        }
        internal bool CheckWalls(int x, int y)
        {
            if ((_tafl[x, y] == Pawn.Wall)
                || (x == 0 && y == 0)  //Top left corner
                || (x == 0 && y == _tafl.Height - 1) //Bot left corner
                || (x == _tafl.Width - 1 && y == 0)  //top right corner
                || (x == _tafl.Width - 1 && y == _tafl.Height - 1)  //Bot right corner
                || (x == (_tafl.Width - 1) / 2 && y == (_tafl.Height - 1) / 2 && (_tafl[((_tafl.Width - 1) / 2), ((_tafl.Height - 1) / 2)]) == Pawn.None)//Throne only if empty
                ) return true;
            return false;
        }
        internal bool IsFriendly(Pawn target, int x, int y)
        {
            if (target == Pawn.Attacker && _tafl[x, y] == Pawn.Attacker) return true;
            if ((target == Pawn.Defender || target == Pawn.King) && (_tafl[x, y] == Pawn.Defender || _tafl[x, y] == Pawn.King)) return true;
            return false;
        }
        internal void GetGroup(int x, int y, List<StudiedPawn> pawnList)
        {
            StudiedPawn Current = new StudiedPawn(x, y);
            if (!pawnList.Contains(Current))
            {
                pawnList.Add(Current);
                if (IsFriendly(_tafl[x, y], x, y - 1)) GetGroup(x, y - 1, pawnList);
                if (IsFriendly(_tafl[x, y], x, y + 1)) GetGroup(x, y + 1, pawnList);
                if (IsFriendly(_tafl[x, y], x - 1, y)) GetGroup(x - 1, y, pawnList);
                if (IsFriendly(_tafl[x, y], x + 1, y)) GetGroup(x + 1, y, pawnList);
            }
        }

    }
}
