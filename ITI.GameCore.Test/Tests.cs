using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ITI.GameCore.Test
{
    [TestFixture]
    public class Tests
    {
        /// 0 : 00 : empty,
        /// 1 : 01 : atk : attacker,
        /// 2 : 10 : def : defensor,
        /// 3 : 11 : kig : king
        /*
        public void playing_with_tafl()
        {
            Assert.Throws<ArgumentException>(() => new TaflBasic(12, 35));
            TaflBasic t = new TaflBasic(13, 13);

            t[2, 2] = Pawn.Defender;
            Assert.That(t[2, 2], Is.EqualTo(Pawn.Attacker));
        }
        */
        [TestCase(0, 3)]
        [TestCase(5, 0)]
        [TestCase(2, 3)]
        [TestCase(9, 6)]
        public void Tafl_ctor_with_invalid_args_should_throw_ArgumentException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new TaflBasic(width, height));
        }

        [TestCase(13, 13)]
        public void Tafl_ctor_initializes_the_tafl_correctly(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width,height);

            Assert.That(sut.Width, Is.EqualTo(width));
            Assert.That(sut.Height, Is.EqualTo(height));
        }

        [TestCase(9, 6)]
        [TestCase(7, 7)]
        [TestCase(11, 11)]
        [TestCase(13, 13)]
        [TestCase(15, 15)]
        public void Tafl_check_non_presence_of_pawn_at_fortress_square(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width, height);

            int i;
            int j;

            i = 0;
            j = 0;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = width;
            j = 0;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = 0;
            j = height;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = width;
            j = height;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
        }

        [TestCase(11, 11)]
        public void Tafl_create_a_board_and_pawns(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width, height);
            /*
             X 01 02 03 04 05 06 07 08 09 10 11 x
            01 -- -- 01 01 01 01 01 01 01 -- --
            02 -- -- -- -- -- 01 -- -- -- -- --
            03 01 -- -- -- -- -- -- -- -- -- 01
            04 01 -- -- -- -- 10 -- -- -- -- 01
            05 01 -- -- -- 10 10 10 -- -- -- 01
            06 01 01 -- 10 10 11 10 10 -- 01 01
            07 01 -- -- -- 10 10 10 -- -- -- 01
            08 01 -- -- -- -- 10 -- -- -- -- 01
            09 01 -- -- -- -- -- -- -- -- -- 01
            10 -- -- -- -- -- 01 -- -- -- -- --
            11 -- -- 01 01 01 01 01 01 01 -- --
            y

            */
            sut[6, 6] = Pawn.King;

            sut[6, 4]=  Pawn.Defender;
            sut[5, 5] = Pawn.Defender;
            sut[6, 5] = Pawn.Defender;
            sut[7, 5] = Pawn.Defender;
            sut[4, 6] = Pawn.Defender;
            sut[5, 6] = Pawn.Defender;
            sut[7, 6] = Pawn.Defender;
            sut[8, 6] = Pawn.Defender;
            sut[5, 7] = Pawn.Defender;
            sut[6, 7] = Pawn.Defender;
            sut[7, 7] = Pawn.Defender;
            sut[6, 8] = Pawn.Defender;
            //north line
            sut[3, 1] = Pawn.Attacker;
            sut[4, 1] = Pawn.Attacker;
            sut[5, 1] = Pawn.Attacker;
            sut[6, 1] = Pawn.Attacker;
            sut[7, 1] = Pawn.Attacker;
            sut[8, 1] = Pawn.Attacker;
            sut[9, 1] = Pawn.Attacker;
            sut[6, 2] = Pawn.Attacker;
            //south line
            sut[3, 11] = Pawn.Attacker;
            sut[4, 11] = Pawn.Attacker;
            sut[5, 11] = Pawn.Attacker;
            sut[6, 11] = Pawn.Attacker;
            sut[7, 11] = Pawn.Attacker;
            sut[8, 11] = Pawn.Attacker;
            sut[9, 11] = Pawn.Attacker;
            sut[6, 10] = Pawn.Attacker;
            //west line
            sut[1, 3] = Pawn.Attacker;
            sut[1, 4] = Pawn.Attacker;
            sut[1, 5] = Pawn.Attacker;
            sut[1, 6] = Pawn.Attacker;
            sut[1, 7] = Pawn.Attacker;
            sut[1, 8] = Pawn.Attacker;
            sut[1, 9] = Pawn.Attacker;
            sut[2, 6] = Pawn.Attacker;
            //east line
            sut[11, 3] = Pawn.Attacker;
            sut[11, 4] = Pawn.Attacker;
            sut[11, 5] = Pawn.Attacker;
            sut[11, 6] = Pawn.Attacker;
            sut[11, 7] = Pawn.Attacker;
            sut[11, 8] = Pawn.Attacker;
            sut[11, 9] = Pawn.Attacker;
            sut[10, 6] = Pawn.Attacker;

            //check the king
            Assert.That(sut[6, 6], Is.EqualTo(Pawn.King));

            //check the attacker
            //north line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[i, 1], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[6, 2], Is.EqualTo(Pawn.Attacker));

            //south line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[i, 11], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[6, 10], Is.EqualTo(Pawn.Attacker));

            //west line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[1, i], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[2, 6], Is.EqualTo(Pawn.Attacker));

            //east line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[11, i], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[10,6], Is.EqualTo(Pawn.Attacker));

            //check defender squares
            Assert.That(sut[6, 4], Is.EqualTo(Pawn.Defender));
            
            for (int i = 5; i <= 7; i++)
            {
                Assert.That(sut[i, 5], Is.EqualTo(Pawn.Defender));
            }

            for (int i = 4; i <= 8; i++)
            {
                Assert.That(sut[i, 6], Is.EqualTo(Pawn.Defender));
            }

            for (int i = 5; i <= 7; i++)
            {
                Assert.That(sut[i, 7], Is.EqualTo(Pawn.Defender));
            }
            Assert.That(sut[6, 8], Is.EqualTo(Pawn.Defender));

        }

        [TestCase(11, 11)]
        public void Game(int width, int height)
        {
            Game sut = new Game(width, height);

            sut._tafl[3,2] = Pawn.Defender;
            sut.AllowMove(3, 2, 3, 8);

            Assert.That(sut._tafl[3, 8], Is.EqualTo(Pawn.Defender));

        }
        //test : move piece on another case
        //test : try moving piece out of the tafl (4 cases : north, south, east, west)
        //test : try moving beyond another piece (4 cases : north by south, south by north, east by west, west by east)
        //test : cannot entering into a forteress (try each forteress from each angle, aka 8 try)
        //test : cannot moving while not his turn !
        //test : take a piece
        //test : encircle the king and his servant (try simple case, 1 servant. Then 2, 3... Try the big one with all servant !)
        //test : the king is on one of the forteress
        //test : 
    }
}
