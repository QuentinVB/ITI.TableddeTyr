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
        [Test]
        public void Freyja_updateSensor()
        {
            //arrange
            Game sut = new Game();
            Freyja_Core aiut = new Freyja_Core(sut, true);
            //Act
            aiut.UpdateSensor(sut);
            //Assert
            Assert.That(aiut.Monitor.Sensor_ActiveGame, Is.SameAs(sut));
            Assert.That(aiut.Monitor.Sensor_IsFreyjaAtk, Is.EqualTo(true));
            Assert.That(aiut.Monitor.Sensor_IsAtkPlaying, Is.EqualTo(true));
            Assert.That(aiut.Monitor.Sensor_ActiveTafl[5,5], Is.EqualTo(Pawn.King));
        }
        [Test]
        public void Freyja_Decision()
        {
            //arrange
            Game sut = new Game();         
            Move tested = new Move(0,0,0,0);
            //Act
            Freyja_Core aiut = new Freyja_Core(sut, true);
            //Assert
            Assert.That(aiut.Monitor.Decision, Is.EqualTo(tested));
        }
        [Test]
        public void Freyja_updateEffector()
        {
            //arrange
            Game sut = new Game();           
            Move result;
            //Act
            Freyja_Core aiut = new Freyja_Core(sut, true);
            //Assert
            Assert.Throws<ArgumentException>(() => result = aiut.Monitor.Effector_MoveResult);
        }
        [Test]
        public void Freyja_updateSimulation()
        {
            //arrange
            Game sut = new Game();
            Freyja_Core aiut = new Freyja_Core(sut, true);
            //Act
            aiut.UpdateFreyja();
            //Assert
            Assert.That(true, Is.EqualTo(true));
        }
        [TestCase(3,0,true)]
        [TestCase(9,5,true)]
        [TestCase(5,5,false)]
        [TestCase(3,5,false)]
        public void Freyja_IsfriendlyTool(int x, int y, bool match)
        {
            //arrange
            Game sut = new Game();
            Freyja_Core aiut = new Freyja_Core(sut, true);
            //Act
            bool result = AnalyzeToolbox.IsFriendly(sut.Tafl[x, y], aiut.Monitor.Sensor_IsFreyjaAtk);
            //Assert
            Assert.That(result, Is.EqualTo(match));
        }
    }
}
