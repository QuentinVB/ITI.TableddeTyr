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
    public class Tests
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
            i = width;
            j = 0;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = 0;
            j = height;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
            i = width;
            j = height;
            Assert.That(sut[i, j], Is.EqualTo(Pawn.None));
        }

        [TestCase(11, 11)]
        public void Tafl_create_a_board_and_pawns(int width, int height)
        {
            TaflBasic sut = new TaflBasic(width, height);
            /*
             x 01 02 03 04 05 06 07 08 09 10 11 x
            01 -- -- 01 01 01 01 01 01 01 -- --
            02 -- -- -- -- -- 01 -- -- -- -- --
            03 01 -- -- -- -- -- -- -- -- -- 01
            04 01 -- -- -- -- 10 -- -- -- -- 01
            05 01 -- -- -- 10 10 10 -- -- -- 01
            06 01 01 -- 10 10 11 10 10 -- 01 01
            07 01 -- -- -- 10 10 10 -- -- -- 01
            08 01 -- -- -- -- 10 -- -- -- -- 01
            09 01 -- -- -- -- -- -- -- -- -- 01
            10 -- -- -- -- -- 01 -- -- -- -- --
            11 -- -- 01 01 01 01 01 01 01 -- --
            y

            */
            #region setting pawns
            sut[6, 6] = Pawn.King;

            sut[6, 4] = Pawn.Defender;
            sut[5, 5] = Pawn.Defender;
            sut[6, 5] = Pawn.Defender;
            sut[7, 5] = Pawn.Defender;
            sut[4, 6] = Pawn.Defender;
            sut[5, 6] = Pawn.Defender;
            sut[7, 6] = Pawn.Defender;
            sut[8, 6] = Pawn.Defender;
            sut[5, 7] = Pawn.Defender;
            sut[6, 7] = Pawn.Defender;
            sut[7, 7] = Pawn.Defender;
            sut[6, 8] = Pawn.Defender;
            //north line
            sut[3, 1] = Pawn.Attacker;
            sut[4, 1] = Pawn.Attacker;
            sut[5, 1] = Pawn.Attacker;
            sut[6, 1] = Pawn.Attacker;
            sut[7, 1] = Pawn.Attacker;
            sut[8, 1] = Pawn.Attacker;
            sut[9, 1] = Pawn.Attacker;
            sut[6, 2] = Pawn.Attacker;
            //south line
            sut[3, 11] = Pawn.Attacker;
            sut[4, 11] = Pawn.Attacker;
            sut[5, 11] = Pawn.Attacker;
            sut[6, 11] = Pawn.Attacker;
            sut[7, 11] = Pawn.Attacker;
            sut[8, 11] = Pawn.Attacker;
            sut[9, 11] = Pawn.Attacker;
            sut[6, 10] = Pawn.Attacker;
            //west line
            sut[1, 3] = Pawn.Attacker;
            sut[1, 4] = Pawn.Attacker;
            sut[1, 5] = Pawn.Attacker;
            sut[1, 6] = Pawn.Attacker;
            sut[1, 7] = Pawn.Attacker;
            sut[1, 8] = Pawn.Attacker;
            sut[1, 9] = Pawn.Attacker;
            sut[2, 6] = Pawn.Attacker;
            //east line
            sut[11, 3] = Pawn.Attacker;
            sut[11, 4] = Pawn.Attacker;
            sut[11, 5] = Pawn.Attacker;
            sut[11, 6] = Pawn.Attacker;
            sut[11, 7] = Pawn.Attacker;
            sut[11, 8] = Pawn.Attacker;
            sut[11, 9] = Pawn.Attacker;
            sut[10, 6] = Pawn.Attacker;
            #endregion
            #region checking pawns
            //check the king
            Assert.That(sut[6, 6], Is.EqualTo(Pawn.King));

            //check the attacker
            //north line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[i, 1], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[6, 2], Is.EqualTo(Pawn.Attacker));

            //south line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[i, 11], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[6, 10], Is.EqualTo(Pawn.Attacker));

            //west line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[1, i], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[2, 6], Is.EqualTo(Pawn.Attacker));

            //east line
            for (int i = 3; i <= 9; i++)
            {
                Assert.That(sut[11, i], Is.EqualTo(Pawn.Attacker));
            }
            Assert.That(sut[10, 6], Is.EqualTo(Pawn.Attacker));

            //check defender squares
            Assert.That(sut[6, 4], Is.EqualTo(Pawn.Defender));

            for (int i = 5; i <= 7; i++)
            {
                Assert.That(sut[i, 5], Is.EqualTo(Pawn.Defender));
            }

            for (int i = 4; i <= 8; i++)
            {
                Assert.That(sut[i, 6], Is.EqualTo(Pawn.Defender));
            }

            for (int i = 5; i <= 7; i++)
            {
                Assert.That(sut[i, 7], Is.EqualTo(Pawn.Defender));
            }
            Assert.That(sut[6, 8], Is.EqualTo(Pawn.Defender));
            #endregion
        }

        //test : try moving pawn out of the tafl (4 cases : north, south, east, west)
        [TestCase(3, -4)]
        [TestCase(3, 14)]
        [TestCase(13, 2)]
        [TestCase(-7, 2)]
        public void Tafl_creating_piece_out_of_the_tafl_should_throw_arg_exc(int left, int up)
        {
            TaflBasic sut = new TaflBasic(11, 11);

            sut[3, 2] = Pawn.Attacker;

            Assert.Throws<ArgumentOutOfRangeException>(() => sut[left, up] = Pawn.Attacker);
        }

        public void Game_setting_first_turn()
        {

        }

        [TestCase(2, 3)]
        public void Game_setting_complete_turn(int x,int y)
        {
            // L'interlocuteur demande l'Initialisation du jeu: 
            // - Le core créé le tafl, si l'interlocuteur lui a envoyé une configuration spéciale (taille,disposition des pièces) il en prendra compte dans sa création 
            // - Le core pose les pions dessus 
            // - Le core pose le isAttackerTurn à True 
            Game sut = new Game();
            Pawn[,] currentTafl = new Pawn[10, 10];
            bool[,] movableTafl = new bool[10, 10];
            bool[,] pawnDestinations = new bool[10, 10];
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
            Assert.That(movableTafl[2,0], Is.EqualTo(true));
            // ACTION UTILISATEUR
            // L'interlocuteur sélectionne une pièce (directement dans les tests ou après un événement de l'utilisateur dans l'UI) 
            // L'interlocuteur appelle TryMove pour savoir les mouvements possible du pion sélectionné. 
            // - le core lui envoie un Array de Pawn correspondant aux mouvements possible basé sur l'état du Tafl 
            pawnDestinations = sut.TryMove(2,0);
            for (int i = 1; i <= 9; i++)
            {
                Assert.That(pawnDestinations[2, i], Is.EqualTo(true));
            }
            Assert.That(pawnDestinations[2, 10], Is.EqualTo(false));
            //ACTION UTILISATEUR
            // -L'interlocuteur valide le mouvement en appellant AllowMove
            bool pawnMoved = sut.AllowMove(2, 0, x , y);
            // - Le core déplace le pion sur le tafl et appelle checkCapture pour vérifier les éventuelles captures(l'encerclement du roi) et les résout. L'interlocuteur appelle updateTurn pour finir le tour.
            // - Le core appelle CheckVictoryCondition
            // - CheckVictoryCondition vérifie si le roi à été pris en appellant le tafl Si c'est le cas il renvoie True à update turn
            // - checkVictoryCondition vérifie si le roi est dans une forteresse.Si c'est le cas il renvoie True à update turn. 
            // - Le core renvoie false à L'interlocuteur via update turn si il y a un gagnant. Sinon il switch le IsAttackerTurn et envoie True à L'interlocuteur. 
            bool rsltTurn = sut.UpdateTurn();
            if(rsltTurn==false)
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
        //test : move pawn on another case
        //test : try moving pawn out of the tafl (4 cases : north, south, east, west)
        //test : try moving beyond another pawn (4 cases : north by south, south by north, east by west, west by east)
        //test : cannot entering into a forteress (try each forteress from each angle, aka 8 try)
        //test : take a pawn
        //test : the king is on one of the forteress    
        //test : cannot moving while not his turn !
        //test : encircle the king and his servant (try simple case, 1 servant. Then 2, 3... Try the big one with all servant !)
        //test : moving non-king pawn across the throne
        //test : moving non-king pawn inside the throne
    }
}

