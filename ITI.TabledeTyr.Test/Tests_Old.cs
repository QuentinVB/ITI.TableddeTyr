using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ITI.GameCore;

namespace ITI.TabledeTyr.Test
{
    class Tests_Old
    {
        //Game test checkMove
        [Test]
        public void Game_03_turn_checkMove()
        {
            Game sut = new Game();
            bool[,] movableTafl = new bool[11, 11];
            movableTafl = sut.CheckMove();
            Assert.That(movableTafl[0, 0], Is.EqualTo(true));
            Assert.That(movableTafl[3, 0], Is.EqualTo(true));
            Assert.That(movableTafl[4, 0], Is.EqualTo(true));
            Assert.That(movableTafl[5, 0], Is.EqualTo(false));//unmovable
            Assert.That(movableTafl[6, 0], Is.EqualTo(true));
            Assert.That(movableTafl[7, 0], Is.EqualTo(true));
            Assert.That(movableTafl[5, 1], Is.EqualTo(true));
            Assert.That(movableTafl[0, 3], Is.EqualTo(true));
            Assert.That(movableTafl[0, 4], Is.EqualTo(true));
            Assert.That(movableTafl[0, 5], Is.EqualTo(false));//unmovable
            Assert.That(movableTafl[0, 6], Is.EqualTo(true));
            Assert.That(movableTafl[0, 7], Is.EqualTo(true));
            Assert.That(movableTafl[0, 8], Is.EqualTo(true));
            Assert.That(movableTafl[1, 5], Is.EqualTo(true));
            Assert.That(movableTafl[3, 10], Is.EqualTo(true));
            Assert.That(movableTafl[4, 10], Is.EqualTo(true));
            Assert.That(movableTafl[5, 10], Is.EqualTo(false));//unmovable
            Assert.That(movableTafl[6, 10], Is.EqualTo(true));
            Assert.That(movableTafl[7, 10], Is.EqualTo(true));
            Assert.That(movableTafl[5, 9], Is.EqualTo(true));
            Assert.That(movableTafl[10, 3], Is.EqualTo(true));
            Assert.That(movableTafl[10, 4], Is.EqualTo(true));
            Assert.That(movableTafl[10, 5], Is.EqualTo(false));//unmovable
            Assert.That(movableTafl[10, 6], Is.EqualTo(true));
            Assert.That(movableTafl[10, 7], Is.EqualTo(true));
            Assert.That(movableTafl[9, 5], Is.EqualTo(true));
            Assert.That(movableTafl[3, 5], Is.EqualTo(true));
            Assert.That(movableTafl[4, 4], Is.EqualTo(true));
            Assert.That(movableTafl[4, 5], Is.EqualTo(true));
            Assert.That(movableTafl[4, 6], Is.EqualTo(true));
            Assert.That(movableTafl[5, 3], Is.EqualTo(true));
            Assert.That(movableTafl[5, 4], Is.EqualTo(true));
            Assert.That(movableTafl[5, 5], Is.EqualTo(false));//unmovable
            Assert.That(movableTafl[5, 6], Is.EqualTo(true));
            Assert.That(movableTafl[5, 7], Is.EqualTo(true));
            Assert.That(movableTafl[6, 4], Is.EqualTo(true));
            Assert.That(movableTafl[6, 5], Is.EqualTo(true));
            Assert.That(movableTafl[6, 6], Is.EqualTo(true));
            Assert.That(movableTafl[7, 5], Is.EqualTo(true));
        }

        //Game test tryMove
        [Test]
        public void Game_04_turn_tryMove()
        {
            //arrange
            Game sut = new Game();
            bool[,] pawnDestinations = new bool[11, 11];

            //act
            pawnDestinations = sut.TryMove(2, 0);

            //assert
            for (int i = 1; i <= 9; i++)
            {
                Assert.That(pawnDestinations[2, i], Is.EqualTo(true));
            }
            Assert.That(pawnDestinations[2, 10], Is.EqualTo(false));

        }
    }
}
