using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.InterfaceUser
{
    public partial class InterfaceOptions : Form
    {
        Image AtkTurn;
        Image DefTurn;
        Image KingPawn;
        Image IaVictory;
        Image PlayerVictory;
        Image Square;
        Image ForbiddenSquare;
        Image SquareMvtPossible;
        Image RulesBoard;
        Image RulesPawn;
        Image RulesCheckCaptures;
        Image RulesVictory;
        Image Return;
        Image Play;
        Image Rules;
        Image Tutorial;
        Image LeaveGame;
        Image LanguagesGame;
        Image Board7x7;
        Image Board9x9;
        Image Board11x11;
        Image Board13x13;
        Image CreateBoard;
        Image LoadBoard;
        Image PlayerVsPlayer;
        Image PlayerVsIa;
        Image PlayAttacker;
        Image PlayDefender;



        public int _rectanglePositionX;
        public int _rectanglePositionY;
        public int _rectangleWidth;
        public int _rectangleHeight;
        public int _nextRectanglePositionX;
        public int _nextRectanglePositionY;
        int _width = 7;
        int _height = 7;
        string _roadTaflSave = @"C:\Users\ELISABETH Guillaume\Documents\ITI.TabledeTyr\ITI.InterfaceUser\bin\Debug\TaflBoardCreate";
        public bool _frenchLanguages = true;
        public string _formTitle;

        public InterfaceOptions()
        {
            setEverythingInCorrectLanguages();
        }

        public void setEverythingInCorrectLanguages()
        {
            AtkTurn = ITI.InterfaceUser.Properties.Resources.PionNoir;
            DefTurn = ITI.InterfaceUser.Properties.Resources.PionBlanc;
            IaVictory = ITI.InterfaceUser.Properties.Resources.Victoire;
            PlayerVictory = ITI.InterfaceUser.Properties.Resources.Victoire;
            Square = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            ForbiddenSquare = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            SquareMvtPossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            KingPawn = ITI.InterfaceUser.Properties.Resources.PionRoi;
            


            if (_frenchLanguages == true)
            {
                RulesBoard = ITI.InterfaceUser.Properties.Resources.Leplateau;
                RulesCheckCaptures = ITI.InterfaceUser.Properties.Resources.Lescaptures;
                RulesPawn = ITI.InterfaceUser.Properties.Resources.LesPions;
                RulesVictory = ITI.InterfaceUser.Properties.Resources.Conditionsdevictoires;
                Play = ITI.InterfaceUser.Properties.Resources.Jouer_php;
                Rules = ITI.InterfaceUser.Properties.Resources.Règles_du_jeu_php;
                Tutorial = ITI.InterfaceUser.Properties.Resources.Tutoriel_php;
                LeaveGame = ITI.InterfaceUser.Properties.Resources.Quitter_php;
                Return = ITI.InterfaceUser.Properties.Resources.Retour;
                LanguagesGame = ITI.InterfaceUser.Properties.Resources.Drapeau_Anglais;
                Board7x7 = ITI.InterfaceUser.Properties.Resources.plateau7x7;
                Board9x9 = ITI.InterfaceUser.Properties.Resources.plateau9x9;
                Board11x11 = ITI.InterfaceUser.Properties.Resources.plateau11x11;
                Board13x13 = ITI.InterfaceUser.Properties.Resources.plateau13x13;
                CreateBoard = ITI.InterfaceUser.Properties.Resources.Créer_un_plateau;
                LoadBoard = ITI.InterfaceUser.Properties.Resources.ChargerPlateau;
                PlayerVsPlayer = ITI.InterfaceUser.Properties.Resources.JoueurVSJoueur;
                PlayerVsIa = ITI.InterfaceUser.Properties.Resources.JoueurVSIa;
                PlayAttacker = ITI.InterfaceUser.Properties.Resources.Jouer_attaquant;
                PlayDefender = ITI.InterfaceUser.Properties.Resources.JouerDefenseur;

            }
            else
            {
                RulesBoard = ITI.InterfaceUser.Properties.Resources.Board;
                RulesCheckCaptures = ITI.InterfaceUser.Properties.Resources.CapturesPawns;
                RulesPawn = ITI.InterfaceUser.Properties.Resources.Pawns;
                RulesVictory = ITI.InterfaceUser.Properties.Resources.VictoryCondition;
                Play = ITI.InterfaceUser.Properties.Resources.Play;
                Rules = ITI.InterfaceUser.Properties.Resources.Rules;
                Tutorial = ITI.InterfaceUser.Properties.Resources.Tutorial;
                LeaveGame = ITI.InterfaceUser.Properties.Resources.Leave;
                Return = ITI.InterfaceUser.Properties.Resources.Return;
                LanguagesGame = ITI.InterfaceUser.Properties.Resources.Drapeau_Français;
                Board7x7 = ITI.InterfaceUser.Properties.Resources.Board7x7;
                Board9x9 = ITI.InterfaceUser.Properties.Resources.Board9x9;
                Board11x11 = ITI.InterfaceUser.Properties.Resources.Board11x11;
                Board13x13 = ITI.InterfaceUser.Properties.Resources.Board13x13;
                CreateBoard = ITI.InterfaceUser.Properties.Resources.CreateBoard;
                LoadBoard = ITI.InterfaceUser.Properties.Resources.LoadBoard;
                PlayerVsPlayer = ITI.InterfaceUser.Properties.Resources.PlayerVSPlayer;
                PlayerVsIa = ITI.InterfaceUser.Properties.Resources.PlayerVSIA;
                PlayAttacker = ITI.InterfaceUser.Properties.Resources.PlayAttacker;
                PlayDefender = ITI.InterfaceUser.Properties.Resources.PlayDefender;
            }
        }
        /*
        public Image Image
        {
            get { return; }
        }*/

        public Image ImageBoard7x7
        {
            get { return Board7x7; }
        }

        public Image ImageBoard9x9
        {
            get { return Board9x9; }
        }

        public Image ImageBoard11x11
        {
            get { return Board11x11; }
        }

        public Image ImageBoard13x13
        {
            get { return Board13x13; }
        }

        public Image ImageCreateBoard
        {
            get { return CreateBoard; }
        }

        public Image ImageLoadBoard
        {
            get { return LoadBoard; }
        }

        public Image ImagePlayerVsPlayer
        {
            get { return PlayerVsPlayer; }
        }

        public Image ImagePlayerVsIa
        {
            get { return PlayerVsIa; }
        }

        public Image ImagePlayAttacker
        {
            get { return PlayAttacker; }
        }

        public Image ImagePlayDefender
        {
            get { return PlayDefender; }
        }

        public Image ImageLanguagesGame
        {
            get { return LanguagesGame; }
        }

        public Image ImageLeave
        {
            get { return LeaveGame; }
        }

        public Image ImageTutorial
        {
            get { return Tutorial; }
        }

        public Image ImageRules
        {
            get { return Rules; }
        }

        public Image ImagePlay
        {
            get { return Play; }
        }

        public Image ImageAtkTurn
        {
            get { return AtkTurn; }
        }

        public Image ImageDefTurn
        {
            get { return DefTurn; }
        }

        public Image ImageIaVictory
        {
            get { return IaVictory; }
        }

        public Image ImagePlayerVictory
        {
            get { return PlayerVictory; }
        }

        public Image ImageSquare
        {
            get { return Square; }
        }

        public Image ImageForbiddenSquare
        {
            get { return ForbiddenSquare; }
        }

        public Image ImageSquareMvtPossible
        {
            get { return SquareMvtPossible;}
        }

        public Image ImageKingPawn
        {
            get { return KingPawn; }
        }

        public Image ImageRulesBoard
        {
            get { return RulesBoard; }
        }

        public Image ImageRulesCheckCaptures
        {
            get { return RulesCheckCaptures; }
        }

        public Image ImageRulesPawn
        {
            get { return RulesPawn; }
        }

        public Image ImageRulesVictory
        {
            get { return RulesVictory; }
        }

        public Image ImageReturn
        {
            get { return Return; }
        }


        public void setPictureBox(int width, int height)
        {
            #region variable création plateau

            if (width == 7)
            {
                _rectanglePositionX = 3;
                _rectangleWidth = 70;
                _nextRectanglePositionX = 73;
            }
            if (width == 9)
            {
                _rectanglePositionX = 6;
                _rectangleWidth = 53;
                _nextRectanglePositionX = 56;
            }
            if (width == 11)
            {
                _rectanglePositionX = 5;
                _rectangleWidth = 43;
                _nextRectanglePositionX = 46;
            }
            if (width == 13)
            {
                _rectanglePositionX = 5;
                _rectangleWidth = 36;
                _nextRectanglePositionX = 39;
            }
            if (width == 15)
            {
                _rectanglePositionX = 4;
                _rectangleWidth = 31;
                _nextRectanglePositionX = 34;
            }

            if (height == 7)
            {
                _rectanglePositionY = 3;
                _rectangleHeight = 70;
                _nextRectanglePositionY = 73;
            }
            if (height == 9)
            {
                _rectanglePositionY = 6;
                _rectangleHeight = 53;
                _nextRectanglePositionY = 56;
            }
            if (height == 11)
            {
                _rectanglePositionY = 5;
                _rectangleHeight = 43;
                _nextRectanglePositionY = 46;
            }
            if (height == 13)
            {
                _rectanglePositionY = 5;
                _rectangleHeight = 36;
                _nextRectanglePositionY = 39;
            }
            if (height == 15)
            {
                _rectanglePositionY = 4;
                _rectangleHeight = 31;
                _nextRectanglePositionY = 34;

            }
            #endregion
        }

        public string Title
        {
            get
            {
                if (_frenchLanguages == true)
                {
                    _formTitle = ("LA TABLE DE TYR");

                }
                else
                {
                    _formTitle = ("TYR'S TABLE");
                }
                return _formTitle;
            }
        }

        public string RoadTaflSave
        {
            get { return _roadTaflSave; }
        }

        public int BoardWidth
        {
            get { return _width; }
            set { _width = value; }
        }

        public int BoardHeight
        {
            get { return _height; }
            set { _height = value; }
        }

        public int RectanglePositionX
        {
            get { return _rectanglePositionX; }
        }

        public int RectanglePositionY
        {
            get { return _rectanglePositionY; }
        }

        public int RectangleWidth
        {
            get { return _rectangleWidth; }
        }

        public int RectangleHeight
        {
            get { return _rectangleHeight; }
        }

        public int NextRectanglePositionX
        {
            get { return _nextRectanglePositionX; }
        }

        public int NextRectanglePositionY
        {
            get { return _nextRectanglePositionY; }
        }

        public bool Languages
        {
            get { return _frenchLanguages; }
            set { _frenchLanguages = value; }

        }
    }
}
