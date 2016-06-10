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
        internal int _childScore = 0;

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

            if(_isAtkPlaying == true)
            {
                // checkCapture revoie le nb de capture
                blockOtherPawn(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
                PawnFreeScore(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
                if (_childScore == -1)
                {
                    // retourner à l'IA que le move est inutile / dangereux
                }
            }
            else
            {
                PawnFreeScore(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
                if(_childScore == -1)
                {
                    // retourner à l'IA que le move est inutile / dangereux
                }
                // checkCapture
                blockOtherPawn(_father.ThisMove.sourceX, _father.ThisMove.sourceY);
            }

            return child;
        }

        internal bool blockOtherPawn(int x, int y)
        {

            return false;
        }


        //A faire : 
        // ajouter la recherche derrière un allié
        // grosso modo faire la check capture de ce pion exemple core
        internal void PawnFreeScore(int x, int y)
        {
            if (isFree(x, y) == false && _isAtkPlaying == false)
            {
                _childScore = _childScore - 1;
            }
            if(isFree(x, y) == false && _isAtkPlaying == true /* && nombre d'attaquants < nb de défenseur*/ )
            {
                _childScore = _childScore -1;
            }
        }


        // il faut implémenter la recherche de groupe 
        // si a droite du pion il y a un allié, il faut check la liberté de cette allié aussi
        internal bool isFree(int x, int y)
        {
            int studiedPawnIsfree = 4;
            bool up, down, left, right;

            if( up = CheckUp(x, y) == true)
            {
                studiedPawnIsfree--;
            }
            if (down = CheckDown(x, y) == true)
            {
                studiedPawnIsfree--;
            }
            if (left = CheckLeft(x, y) == true)
            {
                studiedPawnIsfree--;
            }
            if (right = CheckRight(x, y) == true)
            {
                studiedPawnIsfree--;
            }

            if((studiedPawnIsfree >= 2)
                || (_plateau[x, y] == Pawn.King && studiedPawnIsfree > 1))
            {
                if(up == true && left && true)
                {
                    return false;
                }
                if(left == true && down == true)
                {
                    return false;
                }
                if (down == true && right == true)
                {
                    return false;
                }
                if (right == true && up == true)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private void isFreePawnAroundStudiedPawn()
        {

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

    }
}
