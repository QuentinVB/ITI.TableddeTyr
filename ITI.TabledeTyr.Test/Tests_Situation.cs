using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ITI.GameCore;

namespace ITI.TabledeTyr.Test
{
    [TestFixture]
    public class t03_Tests_Situation
    {
        //Board for a standard 11*11 game [Hardcoded for IT1]
        #region Setting the board
        /*
         x 00 01 02 03 04 05 06 07 08 09 10 x
        00 -- -- -- 01 01 01 01 01 -- -- --
        01 -- -- -- -- -- 01 -- -- -- -- --
        02 -- -- -- -- -- -- -- -- -- -- --
        03 01 -- -- -- -- 10 -- -- -- -- 01
        04 01 -- -- -- 10 10 10 -- -- -- 01
        05 01 01 -- 10 10 11 10 10 -- 01 01
        06 01 -- -- -- 10 10 10 -- -- -- 01
        07 01 -- -- -- -- 10 -- -- -- -- 01
        08 -- -- -- -- -- -- -- -- -- -- --
        09 -- -- -- -- -- 01 -- -- -- -- --
        10 -- -- -- 01 01 01 01 01 -- -- --
        y
        */
        //Set the king and defenders
            #endregion

        //test : take a pawn
        [TestCase(5,4)]
        public void Situation_capture_pawn(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;

            do
            {
                if (i == 1) { pawnMovedX = 4; pawnMovedY = 1; pawnDestinationX = 4; pawnDestinationY = 3; }
                if (i == 2) { pawnMovedX = 3; pawnMovedY = 5; pawnDestinationX = 3; pawnDestinationY = 3; }

                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.GetTafl;
                }
                i++;
            } while (i<2);//MAIN LOOP
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.None));
        }
        //test : try moving pawn out of the tafl (4 cases : north, south, east, west)
        [TestCase(5, 4)]
        public void Situation_cannot_moving_pawn_out_of_the_tafl(int x, int y)
        {
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;
            
                pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = -1;
                
                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved;
            Assert.Throws<ArgumentOutOfRangeException>(() => pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY));

        }
        //test : cannot moving while not his turn !
        [TestCase(5, 4)]
        public void Game_turn_cannot_use_opposite_pawn(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;

            do
            {
                if (i == 1) { pawnMovedX = 3; pawnMovedY = 0; pawnDestinationX = 3; pawnDestinationY = 1; }
                if (i == 2) { pawnMovedX = 3; pawnMovedY = 1; pawnDestinationX = 3; pawnDestinationY = 0; }

                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                if (i == 2)
                {
                    Assert.Throws<ArgumentException>(() => pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY));
                }
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved;
                pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);

                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.GetTafl;
                }
                i++;
            } while (i < 2);//MAIN LOOP
            
        }
        //Game test if th king escapes
        [TestCase(10, 0)]
        public void Game_turn_escape_of_the_king(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;

            do
            {
                if (i == 1) { pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 1; }
                if (i == 2) { pawnMovedX = 6; pawnMovedY = 4; pawnDestinationX = 6; pawnDestinationY = 1; }
                if (i == 3) { pawnMovedX = 2; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 1; }
                if (i == 4) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 2; }
                if (i == 5) { pawnMovedX = 1; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 0; }
                if (i == 6) { pawnMovedX = 5; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 5; }
                if (i == 7) { pawnMovedX = 1; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 0; }
                if (i == 8) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 3; }
                if (i == 9) { pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 1; }
                if (i == 10) { pawnMovedX = 6; pawnMovedY = 3; pawnDestinationX = 9; pawnDestinationY = 3; }
                if (i == 11) { pawnMovedX = 2; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 1; }
                if (i == 12) { pawnMovedX = 9; pawnMovedY = 3; pawnDestinationX = 9; pawnDestinationY = 0; }
                if (i == 13) { pawnMovedX = 1; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 0; }
                if (i == 14) { pawnMovedX = 9; pawnMovedY = 0; pawnDestinationX = 10; pawnDestinationY = 0; }

                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.GetTafl;
                }
                i++;
            } while (i < 15);//MAIN LOOP
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.King));
        }
        //TODO
        //test : try moving beyond another pawn (4 cases : north by south, south by north, east by west, west by east)
        //test : cannot entering into a forteress (try each forteress from each angle, aka 8 try)
        //test : the king is on one of the forteress    
        //test : cannot moving while not his turn !
        //test : encircle the king and his servant (try simple case, 1 servant. Then 2, 3... Try the big one with all servant !)
        //test : moving non-king pawn across the throne
        //test : moving non-king pawn inside the throne
    }
}

