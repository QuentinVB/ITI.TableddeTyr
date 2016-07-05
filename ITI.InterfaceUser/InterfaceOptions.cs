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
        Image AtkPawnDesignUse;
        Image DefPawnDesignUse;
        Image KingPawnDesignUse;

        Image Square;
        Image ForbiddenSquare;
        Image SquareMvtPossible;

        Image Return;

        //GameBoard Form
        Image IaVictory;
        Image PlayerVictory;
        
        //HnefataflRules Form
        Image RulesBoard;
        Image RulesPawn;
        Image RulesCheckCaptures;
        Image RulesVictory;

        //Menu Form
        Image RessourcesPack;
        Image Play;
        Image Rules;
        Image Tutorial;
        Image LeaveGame;
        Image LanguagesGame;

        //PlayInterface Form
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

        //CreateBoard Form
        Image save;
        Image cancelSave;
        Image confirmSave;
        Image insertAtkPawn;
        Image insertDefPawn;
        Image removePawn;

        //RessourcesPack Form
        Image DesignPawn01;
        Image DesignPawn02;
        Image DesignGameBoard01;
        Image DesignGameBoard02;


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
            AtkPawnDesignUse = ITI.InterfaceUser.Properties.Resources.AttackerChessPawn;
            DefPawnDesignUse = ITI.InterfaceUser.Properties.Resources.DefenderChessPawn;
            IaVictory = ITI.InterfaceUser.Properties.Resources.Victoire;
            PlayerVictory = ITI.InterfaceUser.Properties.Resources.Victoire;
            Square = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            ForbiddenSquare = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
            SquareMvtPossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
            KingPawnDesignUse = ITI.InterfaceUser.Properties.Resources.King;
            RessourcesPack = ITI.InterfaceUser.Properties.Resources.paramètres;
            DesignPawn01 = ITI.InterfaceUser.Properties.Resources.ChessPawn;
            DesignPawn02 = ITI.InterfaceUser.Properties.Resources.DamePawn;
            DesignGameBoard01 = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
            DesignGameBoard02 = ITI.InterfaceUser.Properties.Resources.WhiteSquareGameBoard;


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
                PlayerVsIa = ITI.InterfaceUser.Properties.Resources.JoueurVsIA;
                PlayAttacker = ITI.InterfaceUser.Properties.Resources.Attaquant;
                PlayDefender = ITI.InterfaceUser.Properties.Resources.Défenseur;
                save = ITI.InterfaceUser.Properties.Resources.sauvegarder;
                cancelSave = ITI.InterfaceUser.Properties.Resources.annulersauvegarde;
                confirmSave = ITI.InterfaceUser.Properties.Resources.confirmersauvegarde;
                insertAtkPawn = ITI.InterfaceUser.Properties.Resources.insererattaquant;
                insertDefPawn = ITI.InterfaceUser.Properties.Resources.insererdefenseur;
                removePawn = ITI.InterfaceUser.Properties.Resources.retirerpion;

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
                PlayerVsPlayer = ITI.InterfaceUser.Properties.Resources.JoueurVSJoueur;
                PlayerVsIa = ITI.InterfaceUser.Properties.Resources.JoueurVsIA;
                PlayAttacker = ITI.InterfaceUser.Properties.Resources.Attaquant;
                PlayDefender = ITI.InterfaceUser.Properties.Resources.Défenseur;
                save = ITI.InterfaceUser.Properties.Resources.saveboard;
                cancelSave = ITI.InterfaceUser.Properties.Resources.cancelsave;
                confirmSave = ITI.InterfaceUser.Properties.Resources.confirmsave;
                insertAtkPawn = ITI.InterfaceUser.Properties.Resources.insertattacker;
                insertDefPawn = ITI.InterfaceUser.Properties.Resources.insertdefender;
                removePawn = ITI.InterfaceUser.Properties.Resources.removepawn;
            }
        }

        public Image ImageDesignPawn01
        {
            get { return DesignPawn01; }
        }

        public Image ImageDesignPawn02
        {
            get { return DesignPawn02; }
        }
        
        public Image ImageDesignGameBoard01
        {
            get { return DesignGameBoard01; }
        }

        public Image ImageDesignGameBoard02
        {
            get { return DesignGameBoard02; }
        }

        public Image ImageRessourcesPack
        {
            get { return RessourcesPack; }
        }
        
        public Image ImageInsertAtkPawn
        {
            get { return insertAtkPawn; }
        }

        public Image ImageInsertDefPawn
        {
            get { return insertDefPawn; }
        }

        public Image ImageRemovePawn
        {
            get { return removePawn; }
        }

        public Image ImageSave
        {
            get { return save; }
        }

        public Image ImageCancelSave
        {
            get { return cancelSave; }
        }

        public Image ImageConfirmSave
        {
            get { return confirmSave; }
        }

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

        public Image ImageAtkPawnDesignUse
        {
            get { return AtkPawnDesignUse; }
            set { AtkPawnDesignUse = value; }
        }

        public Image ImageDefPawnDesignUse
        {
            get { return DefPawnDesignUse; }
            set { DefPawnDesignUse = value; }
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
            set { Square = value; }
        }

        public Image ImageForbiddenSquare
        {
            get { return ForbiddenSquare; }
            set { ForbiddenSquare = value; }
        }

        public Image ImageSquareMvtPossible
        {
            get { return SquareMvtPossible;}
            set { SquareMvtPossible = value; }
        }

        public Image ImageKingPawn
        {
            get { return KingPawnDesignUse; }
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



        // Fonctions qui permettent d'implémenter un plateau dans chaque form de l'interface où ces informations sont nécéssaires.
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
