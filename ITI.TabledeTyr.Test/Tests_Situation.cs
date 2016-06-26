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
        y*/
        #endregion
        //test : take a pawn
        [TestCase(4, 3)]
        public void Situation_move_pawn(int x, int y)
        {
            //Arrange
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            var currentTafl = sut.Tafl;     
            bool atkPlaying;
            bool pawnMoved;
            //act
            do
            {
                if (i == 1) { pawnMovedX = 4; pawnMovedY = 0; pawnDestinationX = 4; pawnDestinationY = 3; }
               
                atkPlaying = sut.IsAtkPlaying;

                pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);

                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.Tafl;
                }
                i++;
            } while (i <= 1);//MAIN LOOP
            //assert
            currentTafl = sut.Tafl;
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.Attacker));
        }
        //test : take a pawn
        [TestCase(4,3,4,0,4,3,3,5,3,3)]
        [TestCase(7,0,3,0,3,1,7,5,7,1)]
        public void Situation_capture_pawn(int x, int y, int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD)
        {
            //Arrange
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            var currentTafl = sut.Tafl;        
            bool atkPlaying;
            bool pawnMoved;
            //act
            do
            {
                if (i == 1) { pawnMovedX = xA; pawnMovedY = yA; pawnDestinationX = xB; pawnDestinationY = yB; }
                if (i == 2) { pawnMovedX = xC; pawnMovedY = yC; pawnDestinationX = xD; pawnDestinationY = yD; }

                atkPlaying = sut.IsAtkPlaying;

                pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);

                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.Tafl;
                }
                i++;
            } while (i<=2);//MAIN LOOP
            //assert
            currentTafl = sut.Tafl;
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.None));
        }
        //test : try moving pawn out of the tafl (4 cases : north, south, east, west)
        [TestCase(5, 4)]
        public void Situation_cannot_moving_pawn_out_of_the_tafl(int x, int y)
        {
            //arrange
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            var currentTafl = sut.Tafl;
            bool pawnMoved;
            //act    
            pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = -1;
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY));

        }
        //test : cannot moving while not his turn !
        [Test]
        public void Situation_cannot_use_opposite_pawn()
        {
            //arrange
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            var currentTafl = sut.Tafl;
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            bool atkPlaying;
            bool pawnMoved;

            do
            {
                if (i == 1) { pawnMovedX = 3; pawnMovedY = 0; pawnDestinationX = 3; pawnDestinationY = 1; }
                if (i == 2) { pawnMovedX = 3; pawnMovedY = 1; pawnDestinationX = 3; pawnDestinationY = 0; }

                atkPlaying = sut.IsAtkPlaying;

                if (i == 2)
                {
                    Assert.Throws<ArgumentException>(() => pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY));
                    break;
                }
                else { 
                pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                }

                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.Tafl;
                }
                i++;
            } while (i <= 2);//MAIN LOOP
            
        }
        //Game test if the king escapes
        [TestCase(10, 0)]
        public void Situation_escape_of_the_king(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            var currentTafl = sut.Tafl;
            bool atkPlaying;
            bool pawnMoved;         
            do
            {
                if (i == 1) { pawnMovedX = 3; pawnMovedY = 0; pawnDestinationX = 3; pawnDestinationY = 1; }//Atk
                if (i == 2) { pawnMovedX = 6; pawnMovedY = 4; pawnDestinationX = 6; pawnDestinationY = 1; }
                if (i == 3) { pawnMovedX = 3; pawnMovedY = 1; pawnDestinationX = 3; pawnDestinationY = 0; }//Atk
                if (i == 4) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 2; }
                if (i == 5) { pawnMovedX = 3; pawnMovedY = 0; pawnDestinationX = 3; pawnDestinationY = 1; }//Atk
                if (i == 6) { pawnMovedX = 5; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 5; }
                if (i == 7) { pawnMovedX = 3; pawnMovedY = 1; pawnDestinationX = 3; pawnDestinationY = 0; }//Atk
                if (i == 8) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 3; }
                if (i == 9) { pawnMovedX = 3; pawnMovedY = 0; pawnDestinationX = 3; pawnDestinationY = 1; }//Atk
                if (i == 10) { pawnMovedX = 6; pawnMovedY = 3; pawnDestinationX = 9; pawnDestinationY = 3; }
                if (i == 11) { pawnMovedX = 3; pawnMovedY = 1; pawnDestinationX = 3; pawnDestinationY = 0; }//Atk
                if (i == 12) { pawnMovedX = 9; pawnMovedY = 3; pawnDestinationX = 9; pawnDestinationY = 0; }
                if (i == 13) { pawnMovedX = 3; pawnMovedY = 0; pawnDestinationX = 3; pawnDestinationY = 1; }//Atk
                if (i == 14) { pawnMovedX = 9; pawnMovedY = 0; pawnDestinationX = 10; pawnDestinationY = 0; }
                atkPlaying = sut.IsAtkPlaying;               
                pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                if (i == 14) Assert.That(sut.UpdateTurn, Is.EqualTo(false));
                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.Tafl;
                }
                i++;
            } while (i <= 14);//MAIN LOOP
            currentTafl = sut.Tafl;
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.King));
        }
        //test : cannot entering into a forteress (try each forteress from each angle), try move should answer false
        [TestCase(3, 0, 0, 0)]
        [TestCase(7, 0, 10, 0)]
        [TestCase(3, 10, 0, 10)]
        [TestCase(7, 10, 10, 10)]
        public void Situation_cannot_enter_into_each_forteress(int x, int y,int x2, int y2)
        {
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            bool atkPlaying;
            bool pawnMoved;
            atkPlaying = sut.IsAtkPlaying;
            pawnMoved = sut.MovePawn(x, y, x2, y2);
            Assert.That(pawnMoved, Is.EqualTo(false));
        }
        /*
        [TestCase(3, 0, 0, 4, 2, 0)]
        [TestCase(7, 0, 0, 4, 0, 2)]
        [TestCase(3, 10, 4, 0, 2, 0)]
        [TestCase(7, 10, 4, 0, 0, 2)]
        public void Situation_canMove_ignore_each_forteress(int x, int y, int up,int down,int left,int right)
        {
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            PossibleMove testedMove = new PossibleMove(x, y, up, down, left, right,currentTafl[x, y]);
            Assert.That(sut.CanMove(x, y), Is.EqualTo(testedMove));
        }
        */
        [TestCase(5, 5, false)]
        [TestCase(5, 0, false)]
        [TestCase(5, 3, true)]
        [TestCase(0, 3, true)]
        [TestCase(6, 6, true)]
        public void Situation_canMove_isFree(int x, int y,bool answer)
        {
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            PossibleMove testedMove = sut.CanMove(x, y);
            Assert.That(testedMove.IsFree, Is.EqualTo(answer));
        }
        //test : cannot moving non-king pawn on the throne but across it's fine
        [TestCase(5,5)]
        [TestCase(3,5)]
        public void Situation_moving_non_king_across_throne(int x,int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;
            int atkY = 0;
            int atkX1 = 3;
            int atkX2 = 2;


            Game sut = new Game();
            var currentTafl = sut.Tafl;

            do
            {
               
                if (i%2==1) { pawnMovedX = atkX1; pawnMovedY = atkY; pawnDestinationX = atkX2; pawnDestinationY = atkY; atkX1 = atkX1 == 3 ? 2 : 3; atkX2 = atkX2 == 2 ? 3 : 2; }//Atk
                if (i == 2) { pawnMovedX = 3; pawnMovedY = 5; pawnDestinationX = 3; pawnDestinationY = 9; }
                if (i == 4) { pawnMovedX = 4; pawnMovedY = 5; pawnDestinationX = 2; pawnDestinationY = 5; }
                if (i == 6) { pawnMovedX = 2; pawnMovedY = 5; pawnDestinationX = 2; pawnDestinationY = 1; }
                if (i == 8) { pawnMovedX = 5; pawnMovedY = 5; pawnDestinationX = 2; pawnDestinationY = 5; }
                if (i == 10) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = x; pawnDestinationY = y; }


                bool atkPlaying = sut.IsAtkPlaying;
                bool pawnMoved;
                if (i == 10 && x==5)
                {
                    
                    pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                    Assert.That(pawnMoved, Is.EqualTo(false));
                }
                else if (i == 10 && x == 3)
                {
                     sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                }
                else
                {
                    pawnMoved = sut.MovePawn(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                }

                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.Tafl;
                }
                i++;
                
            } while (i <= 10);//MAIN LOOP
        }
        //test : cannot moving pawn across existing pawn
        [TestCase(4,0,2,0)]
        public void Situation_moving_across_existing_pawn(int x, int y, int x2, int y2)
        {
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            bool atkPlaying = sut.IsAtkPlaying;
            currentTafl = sut.Tafl;
            Assert.That(sut.MovePawn(x, y, x2, y2), Is.EqualTo(false));
        }
        //Game test if the king is captured
        [Test]
        public void Situation_capture_of_the_king()
        {
           //Arrange
            TaflBasic taflut = new TaflBasic(11, 11);

            taflut[5, 5] = Pawn.King;
            taflut[5, 4] = Pawn.Defender;
            taflut[6, 4] = Pawn.Defender;
            taflut[6, 5] = Pawn.Defender;
            taflut[6, 6] = Pawn.Defender;
            taflut[4, 5] = Pawn.Defender;
            taflut[4, 6] = Pawn.Defender;
            taflut[5, 6] = Pawn.Defender;

            taflut[4, 1] = Pawn.Attacker;

            taflut[5, 3] = Pawn.Attacker;
            taflut[6, 3] = Pawn.Attacker;
            taflut[7, 4] = Pawn.Attacker;
            taflut[7, 5] = Pawn.Attacker;
            taflut[7, 6] = Pawn.Attacker;
            taflut[3, 5] = Pawn.Attacker;
            taflut[3, 6] = Pawn.Attacker;
            taflut[4, 7] = Pawn.Attacker;
            taflut[5, 7] = Pawn.Attacker;
            taflut[6, 7] = Pawn.Attacker;

            Game sut = new Game(taflut,true);
            var currentTafl = sut.Tafl;
            bool atkPlaying;
            bool pawnMoved;
            atkPlaying = sut.IsAtkPlaying;
            //Act
            pawnMoved = sut.MovePawn(4, 1, 4,4);               
            if (sut.UpdateTurn() == false)
            {
                atkPlaying = sut.IsAtkPlaying;
            }
            else
            {
                currentTafl = sut.Tafl;
            }
            currentTafl = sut.Tafl;
            //assert
            Assert.That(currentTafl[5, 5], Is.EqualTo(Pawn.None));
        }
        //TODO
        //canMove new gen
    }
}

