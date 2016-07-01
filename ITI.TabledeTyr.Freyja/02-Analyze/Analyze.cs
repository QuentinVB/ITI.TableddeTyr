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
        //Game _play;

        internal IReadOnlyTafl _plateau;
        int _studiedPawnFree = 0;
        int _studiedPawnBlock;
        int totalScore = 0;

        Move _studiedPawn;

        bool _isAtkPlaying;
        Freyja_Core _ctx;
        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;            
        }
        
        internal SimulationNode UpdateAnalyze(SimulationNode father, SimulationNode child)
        {
            //_play = new Game();

            _father = father;
            _child = child;
            _plateau = father.TaflStored;
            _isAtkPlaying = father._isAtkPlaying;

            //BYPASS FOR TESTING REMOVE QUICKLY !
            child.Score += 1;
            //ENDBYPASS 
            return child;
        }

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
            Pawn studiedPawn = _plateau[x, y];
            List<StudiedPawn> studiedListPawn = new List<StudiedPawn>();

            // check up
            if (!CheckWalls(x, y - 1))
            {
                if(_plateau[x, y - 1] != Pawn.None)
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
                }else if(_plateau[x, y - 1] == Pawn.None)
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
                if (_plateau[x, y + 1] != Pawn.None)
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
                else if (_plateau[x, y + 1] == Pawn.None)
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
                if (_plateau[x - 1, y] != Pawn.None)
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
                else if (_plateau[x - 1, y] == Pawn.None)
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
                if (_plateau[x + 1, y] != Pawn.None)
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
                else if (_plateau[x + 1, y] == Pawn.None)
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
                if (_plateau[current.X, current.Y - 1] != Pawn.None)
                {
                    total--;
                }else
                {
                    total++;
                }
                if (_plateau[current.X, current.Y + 1] != Pawn.None)
                {
                    total--;
                }
                else
                {
                    total++;
                }
                if (_plateau[current.X - 1, current.Y] != Pawn.None)
                {
                    total--;
                }
                else
                {
                    total++;
                }
                if (_plateau[current.X + 1, current.Y] != Pawn.None)
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

            if (_plateau[x - 1, y] != Pawn.None)
            {
                pawnFree--;
            }
            if (_plateau[x + 1, y] != Pawn.None)
            {
                pawnFree--;
            }
            if (_plateau[x, y - 1] != Pawn.None)
            {
                pawnFree--;
            }
            if (_plateau[x, y + 1] != Pawn.None)
            {
                pawnFree--;
            }

            return pawnFree;
        }


        ///// code core 

        internal bool CheckUp(int x, int y)
        {
            if (y - 1 < 0 || _plateau[x, y - 1] != Pawn.None) return false;
            if (_plateau[x, y - 1] == Pawn.None) return true;
            return false;
        }
        internal bool CheckDown(int x, int y)
        {
            if (y + 1 >= _plateau.Height || _plateau[x, y + 1] != Pawn.None) return false;
            if (_plateau[x, y + 1] == Pawn.None) return true;
            return false;
        }
        internal bool CheckLeft(int x, int y)
        {
            if (x - 1 < 0 || _plateau[x - 1, y] != Pawn.None) return false;
            if (_plateau[x - 1, y] == Pawn.None) return true;
            return false;
        }
        internal bool CheckRight(int x, int y)
        {
            if (x + 1 >= _plateau.Width || _plateau[x + 1, y] != Pawn.None) return false;
            if (_plateau[x + 1, y] == Pawn.None) return true;
            return false;
        }
        internal bool CheckWalls(int x, int y)
        {
            if ((_plateau[x, y] == Pawn.Wall)
                || (x == 0 && y == 0)  //Top left corner
                || (x == 0 && y == _plateau.Height - 1) //Bot left corner
                || (x == _plateau.Width - 1 && y == 0)  //top right corner
                || (x == _plateau.Width - 1 && y == _plateau.Height - 1)  //Bot right corner
                || (x == (_plateau.Width - 1) / 2 && y == (_plateau.Height - 1) / 2 && (_plateau[((_plateau.Width - 1) / 2), ((_plateau.Height - 1) / 2)]) == Pawn.None)//Throne only if empty
                ) return true;
            return false;
        }
        internal bool IsFriendly(Pawn target, int x, int y)
        {
            if (target == Pawn.Attacker && _plateau[x, y] == Pawn.Attacker) return true;
            if ((target == Pawn.Defender || target == Pawn.King) && (_plateau[x, y] == Pawn.Defender || _plateau[x, y] == Pawn.King)) return true;
            return false;
        }
        internal void GetGroup(int x, int y, List<StudiedPawn> pawnList)
        {
            StudiedPawn Current = new StudiedPawn(x, y);
            if (!pawnList.Contains(Current))
            {
                pawnList.Add(Current);
                if (IsFriendly(_plateau[x, y], x, y - 1)) GetGroup(x, y - 1, pawnList);
                if (IsFriendly(_plateau[x, y], x, y + 1)) GetGroup(x, y + 1, pawnList);
                if (IsFriendly(_plateau[x, y], x - 1, y)) GetGroup(x - 1, y, pawnList);
                if (IsFriendly(_plateau[x, y], x + 1, y)) GetGroup(x + 1, y, pawnList);
            }
        }

    }
}
