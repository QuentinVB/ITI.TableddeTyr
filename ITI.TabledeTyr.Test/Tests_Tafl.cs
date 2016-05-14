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
    public class t01_Tests_Tafl
    {
        /// 0 : 00 : empty,
        /// 1 : 01 : atk : attacker,
        /// 2 : 10 : def : defensor,
        /// 3 : 11 : kig : king
        //not even
        [TestCase(7, 6)]
        [TestCase(7, 8)]
        [TestCase(7, 10)]
        [TestCase(7, 12)]
        [TestCase(7, 22)]
        public void Tafl_ctor_width_with_even_args_should_throw_ArgumentException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new TaflBasic(width, height));
        }
        [TestCase(6, 7)]
        [TestCase(8, 7)]
        [TestCase(10, 7)]
        [TestCase(12, 7)]
        [TestCase(22, 7)]
        public void Tafl_ctor_height_with_even_args_should_throw_ArgumentException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new TaflBasic(width, height));
        }
        //4<n<16
        [TestCase(3, 7)]
        [TestCase(4, 7)]
        [TestCase(17, 7)]
        [TestCase(21, 7)]
        public void Tafl_ctor_width_with_invalid_args_should_throw_ArgumentOutOfRangeException(int width, int height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TaflBasic(width, height));
        }
        [TestCase(7, 3)]
        [TestCase(7, 4)]
        [TestCase(7, 17)]
        [TestCase(7, 21)]
        public void Tafl_ctor_height_with_invalid_args_should_throw_ArgumentOutOfRangeException(int width, int height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TaflBasic(width, height));
        }

        [TestCase(13, 13)]
        public void Tafl_ctor_initializes_the_tafl_correctly(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width, height);

            Assert.That(sut.Width, Is.EqualTo(width));
            Assert.That(sut.Height, Is.EqualTo(height));
        }

        [TestCase(11, 11)]
        public void Tafl_check_non_presence_of_pawn_at_fortress_square(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width, height);

            int i;
            int j;

            i = 0;
            j = 0;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = width-1;
            j = 0;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = 0;
            j = height-1;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = width-1;
            j = height-1;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
        }

        [TestCase(11, 11)]
        public void Tafl_create_a_board_and_pawns(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width, height);
            /*
             x 00 01 02 03 04 05 06 07 08 09 10 x
            00 -- -- 01 01 01 01 01 01 01 -- --
            01 -- -- -- -- -- 01 -- -- -- -- --
            02 01 -- -- -- -- -- -- -- -- -- 01
            03 01 -- -- -- -- 10 -- -- -- -- 01
            04 01 -- -- -- 10 10 10 -- -- -- 01
            05 01 01 -- 10 10 11 10 10 -- 01 01
            06 01 -- -- -- 10 10 10 -- -- -- 01
            07 01 -- -- -- -- 10 -- -- -- -- 01
            08 01 -- -- -- -- -- -- -- -- -- 01
            09 -- -- -- -- -- 01 -- -- -- -- --
            10 -- -- 01 01 01 01 01 01 01 -- --
            y

            */
            #region setting pawns
            sut[5, 5] = Pawn.King;

            sut[5, 3] = Pawn.Defender;
            sut[4, 4] = Pawn.Defender;
            sut[5, 4] = Pawn.Defender;
            sut[6, 4] = Pawn.Defender;
            sut[3, 5] = Pawn.Defender;
            sut[4, 5] = Pawn.Defender;
            sut[6, 5] = Pawn.Defender;
            sut[7, 5] = Pawn.Defender;
            sut[4, 6] = Pawn.Defender;
            sut[5, 6] = Pawn.Defender;
            sut[6, 6] = Pawn.Defender;
            sut[5, 7] = Pawn.Defender;
            //north line
            sut[2, 0] = Pawn.Attacker;
            sut[3, 0] = Pawn.Attacker;
            sut[4, 0] = Pawn.Attacker;
            sut[5, 0] = Pawn.Attacker;
            sut[6, 0] = Pawn.Attacker;
            sut[7, 0] = Pawn.Attacker;
            sut[8, 0] = Pawn.Attacker;
            sut[5, 1] = Pawn.Attacker;
            //south line
            sut[2, 10] = Pawn.Attacker;
            sut[3, 10] = Pawn.Attacker;
            sut[4, 10] = Pawn.Attacker;
            sut[5, 10] = Pawn.Attacker;
            sut[6, 10] = Pawn.Attacker;
            sut[7, 10] = Pawn.Attacker;
            sut[8, 10] = Pawn.Attacker;
            sut[5, 9] = Pawn.Attacker;
            //west line
            sut[0, 2] = Pawn.Attacker;
            sut[0, 3] = Pawn.Attacker;
            sut[0, 4] = Pawn.Attacker;
            sut[0, 5] = Pawn.Attacker;
            sut[0, 6] = Pawn.Attacker;
            sut[0, 7] = Pawn.Attacker;
            sut[0, 8] = Pawn.Attacker;
            sut[1, 5] = Pawn.Attacker;
            //east line
            sut[10, 2] = Pawn.Attacker;
            sut[10, 3] = Pawn.Attacker;
            sut[10, 4] = Pawn.Attacker;
            sut[10, 5] = Pawn.Attacker;
            sut[10, 6] = Pawn.Attacker;
            sut[10, 7] = Pawn.Attacker;
            sut[10, 8] = Pawn.Attacker;
            sut[9, 5] = Pawn.Attacker;
            #endregion
            #region checking pawns
            //check the king
            Assert.That(sut[5, 5], Is.EqualTo(Pawn.King));

            //check the attacker
            //north line
            for (int i = 2; i <= 8; i++)
            {
                Assert.That(sut[i, 0], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[5, 1], Is.EqualTo(Pawn.Attacker));

            //south line
            for (int i = 2; i <= 8; i++)
            {
                Assert.That(sut[i, 10], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[5, 9], Is.EqualTo(Pawn.Attacker));

            //west line
            for (int i = 2; i <= 8; i++)
            {
                Assert.That(sut[0, i], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[1, 5], Is.EqualTo(Pawn.Attacker));

            //east line
            for (int i = 2; i <= 8; i++)
            {
                Assert.That(sut[10, i], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[9, 5], Is.EqualTo(Pawn.Attacker));

            //check defender squares
            Assert.That(sut[5, 3], Is.EqualTo(Pawn.Defender));

            for (int i = 4; i <= 6; i++)
            {
                Assert.That(sut[i, 4], Is.EqualTo(Pawn.Defender));
            }

            Assert.That(sut[3, 5], Is.EqualTo(Pawn.Defender));
            Assert.That(sut[4, 5], Is.EqualTo(Pawn.Defender));
            Assert.That(sut[6, 5], Is.EqualTo(Pawn.Defender));
            Assert.That(sut[7, 5], Is.EqualTo(Pawn.Defender));


            for (int i = 4; i <= 6; i++)
            {
                Assert.That(sut[i, 6], Is.EqualTo(Pawn.Defender));
            }
            Assert.That(sut[5, 7], Is.EqualTo(Pawn.Defender));
            #endregion
        }

        //test : try moving pawn out of the tafl (4 cases : north, south, east, west)
        [TestCase(3, -4)]
        [TestCase(3, 14)]
        [TestCase(13, 2)]
        [TestCase(-7, 2)]
        public void Tafl_creating_piece_out_of_the_tafl_should_throw_arg_out_of_range_exc(int left, int up)
        {
            TaflBasic sut = new TaflBasic(11, 11);

            sut[3, 2] = Pawn.Attacker;

            Assert.Throws<ArgumentOutOfRangeException>(() => sut[left, up] = Pawn.Attacker);
        }

    }
}
