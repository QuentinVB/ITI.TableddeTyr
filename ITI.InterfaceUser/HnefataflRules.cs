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
        Button _pawn;
        Button _capturePawn;
        Button _victoryCondition;

        public HnefataflRules(InterfaceOptions interfaceOptions)
        {
            InitializeComponent();
            _interfaceOptions = interfaceOptions;
            
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            setRulesBoard();
            m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Initialisation_d_un_plateau;
        }

        private void setRulesBoard()
        {

            _board = new Button();
            _board.Location = new Point(this.Location.X, this.Location.Y + 25);
            _board.Size = new System.Drawing.Size(200, 75);
            _board.BackgroundImage = (Image)_interfaceOptions.ImageRulesBoard;
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
            _pawn.BackgroundImage = (Image)_interfaceOptions.ImageRulesPawn;
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
            _capturePawn.BackgroundImage = (Image)_interfaceOptions.ImageRulesPawn;
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
            _victoryCondition.BackgroundImage = (Image)_interfaceOptions.ImageRulesVictory;
            _victoryCondition.BackgroundImageLayout = ImageLayout.Stretch;
            _victoryCondition.Click += delegate (object sender, EventArgs e)
            {
                m_RichTextBoxRules.Text = ITI.InterfaceUser.Properties.Resources.Les_conditions_de_victoires;
            };
            this.Controls.Add(_victoryCondition);
            _victoryCondition.BringToFront();


            m_ButtonReturn.BackgroundImage = (Image)_interfaceOptions.ImageReturn;
            m_ButtonReturn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        
        
    }
}
