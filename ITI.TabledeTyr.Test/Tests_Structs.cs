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
    public class t04_Tests_Structs
    {
        [TestCase(0, 0)]
        [TestCase(10, 0)]
        [TestCase(0, 10)]
        [TestCase(5, 5)]
        public void PossibleMove_ctor(int x, int y)
        {
            //arrange
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
           //Act
            PossibleMove sut = new PossibleMove(x, y, pawnList, Pawn.Attacker);
            //Assert
            Assert.That(sut.X, Is.EqualTo(x));
            Assert.That(sut.Y, Is.EqualTo(y));
        }
        [TestCase(0, 0, Pawn.King)]
        [TestCase(0, 0, Pawn.Defender)]
        public void PossibleMove_value(int x, int y,Pawn value)
        {
            //arrange
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            StudiedPawn sp1 = new StudiedPawn(7, 4); pawnList.Add(sp1);
            StudiedPawn sp2 = new StudiedPawn(7, 3); pawnList.Add(sp2);
            //act
            PossibleMove sut = new PossibleMove(x, y, pawnList, value);
            //assert
            Assert.That(sut.Value, Is.EqualTo(value));
        }
        [TestCase(0, 0)]
        public void PossibleMove_isFree(int x, int y)
        {
            //arrage
            Pawn value = Pawn.King;
            List<StudiedPawn> pawnList = new List<StudiedPawn>();           
            //act
            PossibleMove sut = new PossibleMove(x, y, pawnList, value);
            //assert
            Assert.That(sut.IsFree, Is.EqualTo(false));
        }
        [TestCase(5, 5)]
        public void PossibleMove_up(int x, int y)
        {
            //arrage
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            StudiedPawn sp1 = new StudiedPawn(x, y - 1); pawnList.Add(sp1);
            StudiedPawn sp2 = new StudiedPawn(x, y - 2); pawnList.Add(sp2);
            //act
            PossibleMove sut = new PossibleMove(x, y, pawnList, Pawn.King);
            //assert
            Assert.That(sut.Up, Is.EqualTo(2));
            Assert.That(sut.Down, Is.EqualTo(0));
            Assert.That(sut.Left, Is.EqualTo(0));
            Assert.That(sut.Right, Is.EqualTo(0));
        }
        [TestCase(5, 5)]
        public void PossibleMove_down(int x, int y)
        {
            //arrage
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            StudiedPawn sp1 = new StudiedPawn(x, y + 1); pawnList.Add(sp1);
            StudiedPawn sp2 = new StudiedPawn(x, y + 2); pawnList.Add(sp2);
            //act
            PossibleMove sut = new PossibleMove(x, y, pawnList, Pawn.King);
            //assert
            Assert.That(sut.Up, Is.EqualTo(0));
            Assert.That(sut.Down, Is.EqualTo(2));
            Assert.That(sut.Left, Is.EqualTo(0));
            Assert.That(sut.Right, Is.EqualTo(0));
        }
        [TestCase(5, 5)]
        public void PossibleMove_left(int x, int y)
        {
            //arrage
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            StudiedPawn sp1 = new StudiedPawn(x-1, y); pawnList.Add(sp1);
            StudiedPawn sp2 = new StudiedPawn(x-2, y); pawnList.Add(sp2);
            //act
            PossibleMove sut = new PossibleMove(x, y, pawnList, Pawn.King);
            //assert
            Assert.That(sut.Up, Is.EqualTo(0));
            Assert.That(sut.Down, Is.EqualTo(0));
            Assert.That(sut.Left, Is.EqualTo(2));
            Assert.That(sut.Right, Is.EqualTo(0));
        }
        [TestCase(5, 5)]
        public void PossibleMove_right(int x, int y)
        {
            //arrage
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            StudiedPawn sp1 = new StudiedPawn(x + 1, y); pawnList.Add(sp1);
            StudiedPawn sp2 = new StudiedPawn(x + 2, y); pawnList.Add(sp2);
            //act
            PossibleMove sut = new PossibleMove(x, y, pawnList, Pawn.King);
            //assert
            Assert.That(sut.Up, Is.EqualTo(0));
            Assert.That(sut.Down, Is.EqualTo(0));
            Assert.That(sut.Left, Is.EqualTo(0));
            Assert.That(sut.Right, Is.EqualTo(2));
        }

    }
}
