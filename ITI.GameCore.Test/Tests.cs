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
        public void playing_with_tafl()
        {
            Assert.Throws<ArgumentException>(() => new Tafl(12, 35));
            Tafl t = new Tafl(13, 13);

            t[2, 2] = Pawn.Defender;
            Assert.That(t[2, 2], Is.EqualTo(Pawn.Attacker));

        }

        [TestCase(13, 13)]
        public void T01_ctor_initializes_the_game_correctly(byte width, byte height)
        {
            Game sut = new Game(width, height);

            Assert.That(sut.GetWidth, Is.EqualTo(width));
            Assert.That(sut.GetHeight, Is.EqualTo(height));
        }

        [TestCase(0, 3)]
        [TestCase(5, 0)]
        public void T02_ctor_with_invalid_args_should_throw_ArgumentException(byte width, byte height)
        {
            Assert.Throws<ArgumentException>(() => new Game(width, height));
        }
        [TestCase(13, 13)]
        public void T03_ctor_create_valid_tafl(byte width, byte height)
        {
            Game sut = new Game(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {  
                    Assert.That(sut.GetMap[i,j], Is.EqualTo(0));
                }
            }
        }
        //Forteress
                    /*
                     * if ( (i == 0 && j == 0) || (i == 0 && j == width - 1) ||  (i == height - 1 && j == 0)|| (i == height - 1 && j == width - 1))
                    {
                        Assert.That(sut.GetMap[i, j], Is.EqualTo(0));
                    }
                    */
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
