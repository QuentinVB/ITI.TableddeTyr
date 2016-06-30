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
    public partial class HnefataflRules : Form
    {
        InterfaceOptions _interfaceOptions;

        Button _board;
        Image board;
        Button _pawn;
        Image pawn;
        Button _capturePawn;
        Image capturePawn;
        Button _victoryCondition;
        Image victoryCondition;

        public HnefataflRules(InterfaceOptions interfaceOptions)
        {
            InitializeComponent();
            _interfaceOptions = interfaceOptions;

            _interfaceOptions.FormTitle();
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            setRulesBoard();
            m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Initialisation_d_un_plateau;
        }

        private void setRulesBoard()
        {
            setLanguages();

            _board = new Button();
            _board.Location = new Point(this.Location.X, this.Location.Y + 25);
            _board.Size = new System.Drawing.Size(200, 75);
            _board.BackgroundImage = (Image)board;
            _board.BackgroundImageLayout = ImageLayout.Stretch;
            _board.Click += delegate (object sender, EventArgs e)
            {
                m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Initialisation_d_un_plateau;
                m_RichTextBoxRules.Refresh();
            };
            this.Controls.Add(_board);
            _board.BringToFront();



            _pawn = new Button();
            _pawn.Location = new Point(this.Location.X, this.Location.Y + 125);
            _pawn.Size = new System.Drawing.Size(200, 75);
            _pawn.BackgroundImage = (Image)pawn;
            _pawn.BackgroundImageLayout = ImageLayout.Stretch;
            _pawn.Click += delegate (object sender, EventArgs e)
            {
                m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_pions;
                m_RichTextBoxRules.Refresh();
            };
            this.Controls.Add(_pawn);
            _pawn.BringToFront();



            _capturePawn = new Button();
            _capturePawn.Location = new Point(this.Location.X, this.Location.Y + 225);
            _capturePawn.Size = new System.Drawing.Size(200, 75);
            _capturePawn.BackgroundImage = (Image)capturePawn;
            _capturePawn.BackgroundImageLayout = ImageLayout.Stretch;
            _capturePawn.Click += delegate (object sender, EventArgs e)
            {
                m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_différentes_types_de_captures;
            };
            this.Controls.Add(_capturePawn);
            _capturePawn.BringToFront();



            _victoryCondition = new Button();
            _victoryCondition.Location = new Point(this.Location.X, this.Location.Y + 325);
            _victoryCondition.Size = new System.Drawing.Size(200, 75);
            _victoryCondition.BackgroundImage = (Image)victoryCondition;
            _victoryCondition.BackgroundImageLayout = ImageLayout.Stretch;
            _victoryCondition.Click += delegate (object sender, EventArgs e)
            {
                m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_conditions_de_victoires;
            };
            this.Controls.Add(_victoryCondition);
            _victoryCondition.BringToFront();
        }

        private void setLanguages()
        {
            if (_interfaceOptions.Languages == true)
            {
                board = ITI.InterfaceUser.Properties.Resources.Leplateau;
                pawn = ITI.InterfaceUser.Properties.Resources.LesPions;
                capturePawn = ITI.InterfaceUser.Properties.Resources.Lescaptures;
                victoryCondition = ITI.InterfaceUser.Properties.Resources.Conditionsdevictoires;
            }
            else
            {
                board = ITI.InterfaceUser.Properties.Resources.Board;
                pawn = ITI.InterfaceUser.Properties.Resources.Pawns;
                capturePawn = ITI.InterfaceUser.Properties.Resources.CapturesPawns;
                victoryCondition = ITI.InterfaceUser.Properties.Resources.VictoryCondition;
            }

        }
        
    }
}
