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
    public class t02_Tests_Game
    {
        //game : first turn test
        [TestCase(5, 5)]
        public void Game_01_setting_first_turn_check_king_presence(int x, int y)
        {
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.King));
        }
        //Game test check player
        [Test]
        public void Game_02_setting_first_turn_check_player()
        {
            Game sut = new Game();
            bool atkPlaying = sut.IsAtkPlaying;
            Assert.That(sut.IsAtkPlaying, Is.EqualTo(true));
        }
        //Game test canMove
        [TestCase(3, 0, 0, 4, 2, 0)]
        [TestCase(5, 5, 0, 0, 0, 0)]
        [TestCase(0, 5, 0, 0, 0, 0)]
        [TestCase(9, 5, 5, 5, 1, 0)]
        [TestCase(6, 4, 3, 0, 0, 3)]
        [TestCase(4, 10, 3, 0, 0, 0)]
        [TestCase(4, 0, 0, 3, 0, 0)]
        [TestCase(0, 4, 0, 0, 0, 0)]
        public void Game_03_turn_canMove_number(int x, int y, int up, int down, int left, int right)
        {
            Game sut = new Game();
            var testTafl = sut.Tafl;
            PossibleMove testedMove = sut.CanMove(x, y);
            Assert.That(testedMove.Up, Is.EqualTo(up));
            Assert.That(testedMove.Down, Is.EqualTo(down));
            Assert.That(testedMove.Left, Is.EqualTo(left));
            Assert.That(testedMove.Right, Is.EqualTo(right));
        }
        [TestCase(7,5)]
        [TestCase(4,4)]
        public void Game_03_turn_canMove_List(int x, int y)
        {
            Game sut = new Game();
            var testTafl = sut.Tafl;
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            if (x == 7 && y == 5) { 
                StudiedPawn sp1 = new StudiedPawn(7,4); pawnList.Add(sp1);
                StudiedPawn sp2 = new StudiedPawn(7,3); pawnList.Add(sp2);
                StudiedPawn sp3 = new StudiedPawn(7,2); pawnList.Add(sp3);
                StudiedPawn sp4 = new StudiedPawn(7,1); pawnList.Add(sp4);
                StudiedPawn sp5 = new StudiedPawn(7,6); pawnList.Add(sp5);
                StudiedPawn sp6 = new StudiedPawn(7,7); pawnList.Add(sp6);
                StudiedPawn sp7 = new StudiedPawn(7,8); pawnList.Add(sp7);
                StudiedPawn sp8 = new StudiedPawn(7,9); pawnList.Add(sp8);
                StudiedPawn sp9 = new StudiedPawn(8,5); pawnList.Add(sp9);
            }
            else if (x == 4 && y == 4)
            {
                StudiedPawn sp1 = new StudiedPawn(4, 3); pawnList.Add(sp1);
                StudiedPawn sp2 = new StudiedPawn(4, 2); pawnList.Add(sp2);
                StudiedPawn sp3 = new StudiedPawn(4, 1); pawnList.Add(sp3);
                StudiedPawn sp4 = new StudiedPawn(3, 4); pawnList.Add(sp4);
                StudiedPawn sp5 = new StudiedPawn(2, 4); pawnList.Add(sp5);
                StudiedPawn sp6 = new StudiedPawn(1, 4); pawnList.Add(sp6);
            }

            PossibleMove testedMove = new PossibleMove(x, y, pawnList, testTafl[x, y]);
            PossibleMove bla = sut.CanMove(x, y);
            Assert.That(bla, Is.EqualTo(testedMove));
        }
        [Test]
        public void Game_03_turn_canMove_throne()
        {
            //arrange
            //setting tafl
            TaflBasic tut = new TaflBasic(11, 11);
            tut[7, 5] = Pawn.Attacker;
            //Setting game
            Game sut = new Game(tut, true);
            //setting pawnlist
            List<StudiedPawn> pawnList = new List<StudiedPawn>();
            StudiedPawn sp1 = new StudiedPawn(7, 4); pawnList.Add(sp1);
            StudiedPawn sp2 = new StudiedPawn(7, 3); pawnList.Add(sp2);
            StudiedPawn sp3 = new StudiedPawn(7, 2); pawnList.Add(sp3);
            StudiedPawn sp4 = new StudiedPawn(7, 1); pawnList.Add(sp4);
            StudiedPawn sp5 = new StudiedPawn(7, 0); pawnList.Add(sp5);
            StudiedPawn sp6 = new StudiedPawn(7, 6); pawnList.Add(sp6);
            StudiedPawn sp7 = new StudiedPawn(7, 7); pawnList.Add(sp7);
            StudiedPawn sp8 = new StudiedPawn(7, 8); pawnList.Add(sp8);
            StudiedPawn sp9 = new StudiedPawn(7, 9); pawnList.Add(sp9);
            StudiedPawn sp10 = new StudiedPawn(7, 10); pawnList.Add(sp10);
            StudiedPawn sp11 = new StudiedPawn(8, 5); pawnList.Add(sp11);
            StudiedPawn sp12 = new StudiedPawn(9, 5); pawnList.Add(sp12);
            StudiedPawn sp13 = new StudiedPawn(10, 5); pawnList.Add(sp13);
            StudiedPawn sp14 = new StudiedPawn(6, 5); pawnList.Add(sp14);
            //NO 5:5 !
            StudiedPawn sp15 = new StudiedPawn(4, 5); pawnList.Add(sp15);
            StudiedPawn sp16 = new StudiedPawn(3, 5); pawnList.Add(sp16);
            StudiedPawn sp17 = new StudiedPawn(2, 5); pawnList.Add(sp17);
            StudiedPawn sp18 = new StudiedPawn(1, 5); pawnList.Add(sp18);
            StudiedPawn sp19 = new StudiedPawn(0, 5); pawnList.Add(sp19);

            PossibleMove match = new PossibleMove(7, 5, pawnList, tut[7, 5]);

            //Act
            PossibleMove testedMove = sut.CanMove(7,5);

            //assert
            Assert.That(testedMove.Up, Is.EqualTo(match));
        }
        //Game test MovePawn
        [TestCase(3, 3)]
        [TestCase(1, 0)]
        public void Game_04_turn_MovePawn(int x, int y)
        {
            //arrange
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            //act
            bool pawnMoved = sut.MovePawn(3, 0, x, y);
            //assert
            currentTafl = sut.Tafl;
            Assert.That(currentTafl[3, 0], Is.EqualTo(Pawn.None));
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.Attacker));
        }
        //Game test updateTurn
        [TestCase(3, 3)]
        public void Game_05_turn_updateTurn(int x, int y)
        {
            //arrange
            Game sut = new Game();
            var currentTafl = sut.Tafl;
            //Act            
            bool atkPlaying = sut.IsAtkPlaying;

            bool pawnMoved = sut.MovePawn(3, 0, x, y);
            bool rsltTurn = sut.UpdateTurn();
            if (rsltTurn == false)
            {
                atkPlaying = sut.IsAtkPlaying;
            }
            else
            {
                currentTafl = sut.Tafl;
            }
            //assert
            currentTafl = sut.Tafl;
            Assert.That(currentTafl[3, 0], Is.EqualTo(Pawn.None));
            Assert.That(currentTafl[3, 3], Is.EqualTo(Pawn.Attacker));

            Assert.That(sut.IsAtkPlaying, Is.EqualTo(false));
        }
        //complete turn
        [TestCase(3, 0,3,4)]
        public void Game_06_turn_complete_turn(int x, int y, int x2, int y2)
        {
            // L'interlocuteur demande l'Initialisation du jeu: 
            // - Le core créé le tafl, si l'interlocuteur lui a envoyé une configuration spéciale (taille,disposition des pièces) il en prendra compte dans sa création 
            // - Le core pose les pions dessus 
            // - Le core pose le isAttackerTurn à True 
            Game sut = new Game();
            var currentTafl = sut.Tafl;          
            // L'interlocuteur récupère l'état du plateau 
            // - Le core lui envoie un Array de Pawn             
            // DEBUT SEQUENCE DE TOUR 
            // L'interlocuteur appelle qui joue 
            // - Le core lui envoie True false basé sur IsAttackerTurn 
            bool atkPlaying = sut.IsAtkPlaying;
            Assert.That(sut.IsAtkPlaying, Is.EqualTo(true));
            // ACTION UTILISATEUR
            // L'interlocuteur sélectionne une pièce (directement dans les tests ou après un événement de l'utilisateur dans l'UI) 
            /*
             * PossibleMove testedMove = new PossibleMove(x, y, 0, 4, 3, 0, currentTafl[x, y]);
            Assert.That(sut.CanMove(x, y), Is.EqualTo(testedMove));
            */
            //ACTION UTILISATEUR
            // -L'interlocuteur valide le mouvement en appellant Movepawn
            bool pawnMoved = sut.MovePawn(x, y, x2, y2);
            // - Le core déplace le pion sur le tafl et appelle checkCapture pour vérifier les éventuelles captures(l'encerclement du roi) et les résout. L'interlocuteur appelle updateTurn pour finir le tour.
            // - Le core appelle CheckVictoryCondition
            // - CheckVictoryCondition vérifie si le roi à été pris en appellant le tafl Si c'est le cas il renvoie True à update turn
            // - checkVictoryCondition vérifie si le roi est dans une forteresse.Si c'est le cas il renvoie True à update turn. 
            // - Le core renvoie false à L'interlocuteur via update turn si il y a un gagnant. Sinon il switch le IsAttackerTurn et envoie True à L'interlocuteur. 
            bool rsltTurn = sut.UpdateTurn();
            if (rsltTurn == false)
            {
                //il vérifie qui est la dernière personne à avoir joué(IsAttackerTurn), sors de la boucle et l'annonce comme vainqueur.
                atkPlaying = sut.IsAtkPlaying;
                //break;
            }
            // Si l'interlocuteur n' as pas reçu false il récupère l'état du plateau 
            // - Le core lui envoie un Array de Pawn
            else
            {
                currentTafl = sut.Tafl;
            }
            //L'interlocuteur recommence le séquence de Tour. 
            //FIN DE LA SÉQUENCE
            //assert
            currentTafl = sut.Tafl;
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.None));
            Assert.That(currentTafl[x2, y2], Is.EqualTo(Pawn.Attacker));
            
            Assert.That(sut.IsAtkPlaying, Is.EqualTo(false));
        }
        
    }
}

