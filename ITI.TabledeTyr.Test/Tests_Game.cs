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
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];

            currentTafl = sut.GetTafl;
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.King));
        }
        
        [Test]
        public void Game_02_setting_first_turn_check_player()
        {
            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];

            currentTafl = sut.GetTafl;
            bool atkPlaying = sut.IsAtkPlaying;
            Assert.That(sut.IsAtkPlaying, Is.EqualTo(true));
        }
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
            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];

            currentTafl = sut.GetTafl;
            bool atkPlaying = sut.IsAtkPlaying;
            movableTafl = sut.CheckMove();
            pawnDestinations = sut.TryMove(2, 0);
            for (int i = 1; i <= 9; i++)
            {
                Assert.That(pawnDestinations[2, i], Is.EqualTo(true));
            }
            Assert.That(pawnDestinations[2, 10], Is.EqualTo(false));

        }
        //Game test allowMove
        [TestCase(3, 3)]
        public void Game_05_turn_allowMove(int x, int y)
        {
            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];

            currentTafl = sut.GetTafl;
            bool atkPlaying = sut.IsAtkPlaying;
            movableTafl = sut.CheckMove();
            pawnDestinations = sut.TryMove(3, 0);
            bool pawnMoved = sut.AllowMove(3, 0, x, y);
            currentTafl = sut.GetTafl;
            Assert.That(currentTafl[3, 0], Is.EqualTo(Pawn.None));
            Assert.That(currentTafl[3, 3], Is.EqualTo(Pawn.Attacker));

        }
        //Game test updateTurn
        [TestCase(3, 3)]
        public void Game_06_turn_updateTurn(int x, int y)
        {
            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];

            currentTafl = sut.GetTafl;
            bool atkPlaying = sut.IsAtkPlaying;
            movableTafl = sut.CheckMove();
            pawnDestinations = sut.TryMove(3, 0);
            bool pawnMoved = sut.AllowMove(3, 0, x, y);
            bool rsltTurn = sut.UpdateTurn();
            if (rsltTurn == false)
            {
                atkPlaying = sut.IsAtkPlaying;
            }
            else
            {
                currentTafl = sut.GetTafl;
            }
            currentTafl = sut.GetTafl;
            Assert.That(currentTafl[3, 0], Is.EqualTo(Pawn.None));
            Assert.That(currentTafl[3, 3], Is.EqualTo(Pawn.Attacker));

            Assert.That(sut.IsAtkPlaying, Is.EqualTo(false));
        }
        //complete turn
        [TestCase(2, 3)]
        public void Game_07_turn_complete_turn(int x, int y)
        {
            // L'interlocuteur demande l'Initialisation du jeu: 
            // - Le core créé le tafl, si l'interlocuteur lui a envoyé une configuration spéciale (taille,disposition des pièces) il en prendra compte dans sa création 
            // - Le core pose les pions dessus 
            // - Le core pose le isAttackerTurn à True 
            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            // L'interlocuteur récupère l'état du plateau 
            // - Le core lui envoie un Array de Pawn 
            currentTafl = sut.GetTafl;
            // DEBUT SEQUENCE DE TOUR 
            // L'interlocuteur appelle qui joue 
            // - Le core lui envoie True false basé sur IsAttackerTurn 
            bool atkPlaying = sut.IsAtkPlaying;
            Assert.That(sut.IsAtkPlaying, Is.EqualTo(true));

            // L'interlocuteur appelle checkMove pour savoir quels sont les pièces bougeable
            //  - le core lui envoie un Array de Pawn basé sur l'état du Tafl.     
            movableTafl = sut.CheckMove();
            Assert.That(movableTafl[2, 0], Is.EqualTo(true));
            // ACTION UTILISATEUR
            // L'interlocuteur sélectionne une pièce (directement dans les tests ou après un événement de l'utilisateur dans l'UI) 
            // L'interlocuteur appelle TryMove pour savoir les mouvements possible du pion sélectionné. 
            // - le core lui envoie un Array de Pawn correspondant aux mouvements possible basé sur l'état du Tafl 
            pawnDestinations = sut.TryMove(2, 0);
            for (int i = 1; i <= 9; i++)
            {
                Assert.That(pawnDestinations[2, i], Is.EqualTo(true));
            }
            Assert.That(pawnDestinations[2, 10], Is.EqualTo(false));
            //ACTION UTILISATEUR
            // -L'interlocuteur valide le mouvement en appellant AllowMove
            bool pawnMoved = sut.AllowMove(2, 0, x, y);
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
                currentTafl = sut.GetTafl;
            }
            Assert.That(currentTafl[2, 0], Is.EqualTo(Pawn.None));
            Assert.That(currentTafl[2, 3], Is.EqualTo(Pawn.Attacker));
            //L'interlocuteur recommence le séquence de Tour. 
            //FIN DE LA SÉQUENCE
            Assert.That(sut.IsAtkPlaying, Is.EqualTo(false));
        }
        
    }
}

