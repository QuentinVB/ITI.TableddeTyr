using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ITI.GameCore;

namespace ITI.TabledeTyr.Test
{
    public class Tests_Game
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
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];

            currentTafl = sut.GetTafl;
            bool atkPlaying = sut.IsAtkPlaying;
            movableTafl = sut.CheckMove();
            Assert.That(movableTafl[2, 0], Is.EqualTo(true));
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

        //test : take a pawn
        [TestCase(5,4)]
        public void Game_turn_capture_pawn(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;

            do
            {
                if (i == 1) { pawnMovedX = 5; pawnMovedY = 1; pawnDestinationX = 5; pawnDestinationY = 4; }
                if (i == 2) { pawnMovedX = 4; pawnMovedY = 6; pawnDestinationX = 4; pawnDestinationY = 4; }

                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.GetTafl;
                }
                i++;
            } while (i<2);//MAIN LOOP
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.None));
        }
        //test : try moving pawn out of the tafl (4 cases : north, south, east, west)
        [TestCase(5, 4)]
        public void Game_turn_cannot_moving_pawn_out_of_the_tafl(int x, int y)
        {
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;
            
                pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = -1;
                
                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved;
            Assert.Throws<ArgumentOutOfRangeException>(() => pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY));

        }
        //test : cannot moving while not his turn !
        [TestCase(5, 4)]
        public void Game_turn_cannot_use_opposite_pawn(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;

            do
            {
                if (i == 1) { pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 1; }
                if (i == 2) { pawnMovedX = 2; pawnMovedY = 1; pawnDestinationX = 3; pawnDestinationY = 1; }

                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.GetTafl;
                }
                i++;
            } while (i < 2);//MAIN LOOP
            
        }
        //Game test if th king escapes
        [TestCase(10, 0)]
        public void Game_turn_escape_of_the_king(int x, int y)
        {
            int i = 1;
            int pawnMovedX = 0;
            int pawnMovedY = 0;
            int pawnDestinationX = 0;
            int pawnDestinationY = 0;

            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[11, 11];
            bool[,] movableTafl = new bool[11, 11];
            bool[,] pawnDestinations = new bool[11, 11];
            currentTafl = sut.GetTafl;

            do
            {
                if (i == 1) { pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 1; }
                if (i == 2) { pawnMovedX = 6; pawnMovedY = 4; pawnDestinationX = 6; pawnDestinationY = 1; }
                if (i == 3) { pawnMovedX = 2; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 1; }
                if (i == 4) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 2; }
                if (i == 5) { pawnMovedX = 1; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 0; }
                if (i == 6) { pawnMovedX = 5; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 5; }
                if (i == 7) { pawnMovedX = 1; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 0; }
                if (i == 8) { pawnMovedX = 6; pawnMovedY = 5; pawnDestinationX = 6; pawnDestinationY = 3; }
                if (i == 9) { pawnMovedX = 2; pawnMovedY = 0; pawnDestinationX = 2; pawnDestinationY = 1; }
                if (i == 10) { pawnMovedX = 6; pawnMovedY = 3; pawnDestinationX = 9; pawnDestinationY = 3; }
                if (i == 11) { pawnMovedX = 2; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 1; }
                if (i == 12) { pawnMovedX = 9; pawnMovedY = 3; pawnDestinationX = 9; pawnDestinationY = 0; }
                if (i == 13) { pawnMovedX = 1; pawnMovedY = 1; pawnDestinationX = 1; pawnDestinationY = 0; }
                if (i == 14) { pawnMovedX = 9; pawnMovedY = 0; pawnDestinationX = 10; pawnDestinationY = 0; }

                bool atkPlaying = sut.IsAtkPlaying;
                movableTafl = sut.CheckMove();
                pawnDestinations = sut.TryMove(pawnMovedX, pawnMovedY);
                bool pawnMoved = sut.AllowMove(pawnMovedX, pawnMovedY, pawnDestinationX, pawnDestinationY);
                if (sut.UpdateTurn() == false)
                {
                    atkPlaying = sut.IsAtkPlaying;
                    break;
                }
                else
                {
                    currentTafl = sut.GetTafl;
                }
                i++;
            } while (i < 15);//MAIN LOOP
            Assert.That(currentTafl[x, y], Is.EqualTo(Pawn.King));
        }
        //test : try moving beyond another pawn (4 cases : north by south, south by north, east by west, west by east)
        //test : cannot entering into a forteress (try each forteress from each angle, aka 8 try)
        //test : the king is on one of the forteress    
        //test : cannot moving while not his turn !
        //test : encircle the king and his servant (try simple case, 1 servant. Then 2, 3... Try the big one with all servant !)
        //test : moving non-king pawn across the throne
        //test : moving non-king pawn inside the throne
    }
}

