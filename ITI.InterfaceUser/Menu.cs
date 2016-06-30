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
    public partial class Menu : Form
    {
        InterfaceOptions _interfaceOptions;

        Button m_ButtonPlay;
        Button m_ButtonRules;
        Button m_ButtonTutorial;
        Button m_ButtonLeaveGame;
        Button m_ButtonLanguages;

        Image _flag;
        Image _Play;
        Image _Rules;
        Image _Tutorial;
        Image _Leave;


        public Menu()
        {
            InitializeComponent();
            _interfaceOptions = new InterfaceOptions();

            _interfaceOptions.FormTitle();
            this.Text = _interfaceOptions.Title;
            this.Refresh();

            setMenuBoard();
            setMenuButtonLanguages();
        }

        private void setMenuBoard()
        {
            m_ButtonPlay = new Button();
            m_ButtonPlay.Location = new Point(300, 100);
            m_ButtonPlay.Size = new System.Drawing.Size(150, 75);
            m_ButtonPlay.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                PlayInterface Interface = new PlayInterface(_interfaceOptions);
                if (Interface.ShowDialog() == DialogResult.Cancel)
                {
                    Interface.Dispose();
                }
                this.Show();
            };
            this.Controls.Add(m_ButtonPlay);
            m_ButtonPlay.BringToFront();


            m_ButtonRules = new Button();
            m_ButtonRules.Location = new Point(300, 200);
            m_ButtonRules.Size = new System.Drawing.Size(150, 75);
            m_ButtonRules.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                HnefataflRules Rules = new HnefataflRules(_interfaceOptions);
                if (Rules.ShowDialog() == DialogResult.Cancel)
                {
                    Rules.Dispose();
                }
                this.Show();
            };
            this.Controls.Add(m_ButtonRules);
            m_ButtonRules.BringToFront();


            m_ButtonTutorial = new Button();
            m_ButtonTutorial.Location = new Point(300, 300);
            m_ButtonTutorial.Size = new System.Drawing.Size(150, 75);
            m_ButtonTutorial.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                Tutoriel playTutoriel = new Tutoriel(_interfaceOptions);
                if (playTutoriel.ShowDialog() == DialogResult.Cancel)
                {
                    playTutoriel.Dispose();
                }
                this.Show();
            };
            this.Controls.Add(m_ButtonTutorial);
            m_ButtonTutorial.BringToFront();


            m_ButtonLeaveGame = new Button();
            m_ButtonLeaveGame.Location = new Point(300, 400);
            m_ButtonLeaveGame.Size = new System.Drawing.Size(150, 75);
            m_ButtonLeaveGame.Click += delegate (object sender, EventArgs e)
            {
                Close();
            };
            this.Controls.Add(m_ButtonLeaveGame);
            m_ButtonLeaveGame.BringToFront();


            m_ButtonLanguages = new Button();
            m_ButtonLanguages.Location = new Point(725, 5);
            m_ButtonLanguages.Size = new System.Drawing.Size(25, 25);
            _flag = ITI.InterfaceUser.Properties.Resources.Drapeau_Français;
            m_ButtonLanguages.BackgroundImage = (Image)_flag;
            m_ButtonLanguages.BackgroundImageLayout = ImageLayout.Stretch;
            m_ButtonLanguages.Click += delegate (object sender, EventArgs e)
            {
                if (_interfaceOptions.Languages == true)
                {
                    _interfaceOptions.Languages = false;
                    _flag = ITI.InterfaceUser.Properties.Resources.Drapeau_Anglais;
                    m_ButtonLanguages.BackgroundImage = (Image)_flag;
                    m_ButtonLanguages.BackgroundImageLayout = ImageLayout.Stretch;
                    m_ButtonLanguages.Refresh();

                    _interfaceOptions.FormTitle();
                    this.Text = _interfaceOptions.Title;
                    this.Refresh();

                    setMenuButtonLanguages();
                }
                else
                {
                    _interfaceOptions.Languages = true;
                    _flag = ITI.InterfaceUser.Properties.Resources.Drapeau_Français;
                    m_ButtonLanguages.BackgroundImage = (Image)_flag;
                    m_ButtonLanguages.BackgroundImageLayout = ImageLayout.Stretch;
                    m_ButtonLanguages.Refresh();

                    _interfaceOptions.FormTitle();
                    this.Text = _interfaceOptions.Title;
                    this.Refresh();

                    setMenuButtonLanguages();
                }
            };
            this.Controls.Add(m_ButtonLanguages);
            m_ButtonLanguages.BringToFront();
        }

        private void setMenuButtonLanguages()
        {
            if (_interfaceOptions.Languages == true)
            {
                _Play = ITI.InterfaceUser.Properties.Resources.Jouer_php;
                m_ButtonPlay.BackgroundImage = (Image)_Play;
                m_ButtonPlay.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonPlay.Refresh();

                _Rules = ITI.InterfaceUser.Properties.Resources.Règles_du_jeu_php;
                m_ButtonRules.BackgroundImage = (Image)_Rules;
                m_ButtonRules.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonRules.Refresh();

                _Tutorial = ITI.InterfaceUser.Properties.Resources.Tutoriel_php;
                m_ButtonTutorial.BackgroundImage = (Image)_Tutorial;
                m_ButtonTutorial.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonTutorial.Refresh();

                _Leave = ITI.InterfaceUser.Properties.Resources.Quitter_php;
                m_ButtonLeaveGame.BackgroundImage = (Image)_Leave;
                m_ButtonLeaveGame.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonLeaveGame.Refresh();
            }

            if (_interfaceOptions.Languages == false)
            {
                _Play = ITI.InterfaceUser.Properties.Resources.Play;
                m_ButtonPlay.BackgroundImage = (Image)_Play;
                m_ButtonPlay.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonPlay.Refresh();

                _Rules = ITI.InterfaceUser.Properties.Resources.Rules;
                m_ButtonRules.BackgroundImage = (Image)_Rules;
                m_ButtonRules.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonRules.Refresh();

                _Tutorial = ITI.InterfaceUser.Properties.Resources.Tutorial;
                m_ButtonTutorial.BackgroundImage = (Image)_Tutorial;
                m_ButtonTutorial.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonTutorial.Refresh();

                _Leave = ITI.InterfaceUser.Properties.Resources.Leave;
                m_ButtonLeaveGame.BackgroundImage = (Image)_Leave;
                m_ButtonLeaveGame.BackgroundImageLayout = ImageLayout.Stretch;
                m_ButtonLeaveGame.Refresh();
            }
        }
    }
}
