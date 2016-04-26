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
        [TestCase(10, 5)]
        public void T01_ctor_initializes_the_game_correctly(byte width, byte height)
        {
            Game sut = new Game(width, height);

            Assert.That(sut.GetWidth, Is.EqualTo(width));
            Assert.That(sut.GetHeight, Is.EqualTo(height));
        }
    }
}
