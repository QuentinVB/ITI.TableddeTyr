using ITI.GameCore;
using ITI.TabledeTyr.Freyja;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Test
{
    [TestFixture]
    public class t05_Tests_Freyja
    {
        [Test]
        public void Freyja_create_IA()
        {
            //arrange
            Game sut = new Game();
            //Act
            Freyja_Core aiut = new Freyja_Core(sut,true);
            //Assert
            Assert.That(true, Is.EqualTo(true));
        }

    }
}
