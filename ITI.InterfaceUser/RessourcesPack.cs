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
    public partial class RessourcesPack : Form
    {
        TextBox _loadNewPawnPicture;
        TextBox _loadNewSquarePicture;

        PictureBox _NewPawnPicture01;
        PictureBox _NewPawnPicture02;
        PictureBox _NewPawnPicture03;
        PictureBox _NewSquarePicture01;
        PictureBox _NewSquarePicture02;
        

        InterfaceOptions _interfaceOptions;
        public RessourcesPack(InterfaceOptions interfaceOptions)
        {
            InitializeComponent();
            _interfaceOptions = interfaceOptions;
            setRessourcesForm();
        }

        private void setRessourcesForm()
        {
            m_ButtonRessourcesRetourMenu.BackgroundImage = (Image)_interfaceOptions.ImageReturn;
            m_ButtonRessourcesRetourMenu.BackgroundImageLayout = ImageLayout.Stretch;

            _loadNewPawnPicture = new TextBox();
            _loadNewPawnPicture.Enabled = false;
            _loadNewPawnPicture.Location = new Point(this.Location.X + 200, this.Location.Y + 5);
            _loadNewPawnPicture.Size = new System.Drawing.Size(150, 50);
            if(_interfaceOptions.Languages == true)
            {
                _loadNewPawnPicture.Text = ("Changer le design des pions");
            }else
            {
                _loadNewPawnPicture.Text = ("Change Pawns' design");
            } 
            this.Controls.Add(_loadNewPawnPicture);
            _loadNewPawnPicture.BringToFront();


            _loadNewSquarePicture = new TextBox();
            _loadNewSquarePicture.Enabled = false;
            _loadNewSquarePicture.Location = new Point(this.Location.X + 25, this.Location.Y + 200);
            _loadNewSquarePicture.Size = new System.Drawing.Size(150, 50);
            if (_interfaceOptions.Languages == true)
            {
                _loadNewSquarePicture.Text = ("Changer le design du plateau");
            }
            else
            {
                _loadNewSquarePicture.Text = ("Change GameBoard's design");
            }
            this.Controls.Add(_loadNewSquarePicture);
            _loadNewSquarePicture.BringToFront();

            
            _NewPawnPicture01 = new PictureBox();
            _NewPawnPicture01.Location = new Point(this.Location.X + 200, this.Location.Y + 25);
            _NewPawnPicture01.Size = new System.Drawing.Size(150, 150);
            _NewPawnPicture01.BackgroundImage = (Image)_interfaceOptions.ImageDesignPawn01;
            _NewPawnPicture01.BackgroundImageLayout = ImageLayout.Stretch;
            _NewPawnPicture01.Click += delegate (object sender, EventArgs r)
            {
                _interfaceOptions.ImageAtkPawnDesignUse = ITI.InterfaceUser.Properties.Resources.AttackerChessPawn;
                _interfaceOptions.ImageDefPawnDesignUse = ITI.InterfaceUser.Properties.Resources.DefenderChessPawn;
                _interfaceOptions.ImageKingPawn = ITI.InterfaceUser.Properties.Resources.King;
                if (_interfaceOptions.Languages == true)
                {
                    MessageBox.Show("Le design des pions a été modifié !", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Pawns' design has been changed !", "Information", MessageBoxButtons.OK);
                }
            };
            this.Controls.Add(_NewPawnPicture01);
            _NewPawnPicture01.BringToFront();


            _NewPawnPicture02 = new PictureBox();
            _NewPawnPicture02.Location = new Point(this.Location.X + 400, this.Location.Y + 25);
            _NewPawnPicture02.Size = new System.Drawing.Size(150, 150);
            _NewPawnPicture02.BackgroundImage = (Image)_interfaceOptions.ImageDesignPawn02;
            _NewPawnPicture02.BackgroundImageLayout = ImageLayout.Stretch;
            _NewPawnPicture02.Click += delegate (object sender, EventArgs r)
            {
                _interfaceOptions.ImageAtkPawnDesignUse = ITI.InterfaceUser.Properties.Resources.AttackerDamePawn;
                _interfaceOptions.ImageDefPawnDesignUse = ITI.InterfaceUser.Properties.Resources.DefenderDamePawn;
                _interfaceOptions.ImageKingPawn = ITI.InterfaceUser.Properties.Resources.King;
                if (_interfaceOptions.Languages == true)
                {
                    MessageBox.Show("Le design des pions a été modifié !", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Pawns' design has been changed !", "Information", MessageBoxButtons.OK);
                }
            };
            this.Controls.Add(_NewPawnPicture02);
            _NewPawnPicture02.BringToFront();

            _NewPawnPicture03 = new PictureBox();
            _NewPawnPicture03.Location = new Point(this.Location.X + 15, this.Location.Y + 25);
            _NewPawnPicture03.Size = new System.Drawing.Size(150, 150);
            _NewPawnPicture03.BackgroundImage = (Image)_interfaceOptions.ImageDesignPawn03;
            _NewPawnPicture03.BackgroundImageLayout = ImageLayout.Stretch;
            _NewPawnPicture03.Click += delegate (object sender, EventArgs r)
            {
                _interfaceOptions.ImageAtkPawnDesignUse = ITI.InterfaceUser.Properties.Resources.atk;
                _interfaceOptions.ImageDefPawnDesignUse = ITI.InterfaceUser.Properties.Resources.def;
                _interfaceOptions.ImageKingPawn = ITI.InterfaceUser.Properties.Resources.Pawnking;
                if (_interfaceOptions.Languages == true)
                {
                    MessageBox.Show("Le design des pions a été modifié !", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Pawns' design has been changed !", "Information", MessageBoxButtons.OK);
                }
            };
            this.Controls.Add(_NewPawnPicture03);
            _NewPawnPicture03.BringToFront();


            _NewSquarePicture01 = new PictureBox();
            _NewSquarePicture01.Location = new Point(this.Location.X + 200, this.Location.Y + 200);
            _NewSquarePicture01.Size = new System.Drawing.Size(150, 150);
            _NewSquarePicture01.BackgroundImage = (Image)_interfaceOptions.ImageDesignGameBoard01;
            _NewSquarePicture01.BackgroundImageLayout = ImageLayout.Stretch;
            _NewSquarePicture01.Click += delegate (object sender, EventArgs r)
            {
                _interfaceOptions.ImageSquare = ITI.InterfaceUser.Properties.Resources.Case_en_bois;
                _interfaceOptions.ImageForbiddenSquare = ITI.InterfaceUser.Properties.Resources.CaseInterdite;
                _interfaceOptions.ImageSquareMvtPossible = ITI.InterfaceUser.Properties.Resources.Case_en_bois_effet;
                if (_interfaceOptions.Languages == true)
                {
                    MessageBox.Show("Le design du plateau a été modifié !", "Information", MessageBoxButtons.OK);
                }else
                {
                    MessageBox.Show("GameBoard's design has been changed !", "Information", MessageBoxButtons.OK);
                }
                
            };
            this.Controls.Add(_NewSquarePicture01);
            _NewSquarePicture01.BringToFront();


            _NewSquarePicture02 = new PictureBox();
            _NewSquarePicture02.Location = new Point(this.Location.X + 400, this.Location.Y + 200);
            _NewSquarePicture02.Size = new System.Drawing.Size(150, 150);
            _NewSquarePicture02.BackgroundImage = (Image)_interfaceOptions.ImageDesignGameBoard02;
            _NewSquarePicture02.BackgroundImageLayout = ImageLayout.Stretch;
            _NewSquarePicture02.Click += delegate (object sender, EventArgs r)
            {
                _interfaceOptions.ImageSquare = ITI.InterfaceUser.Properties.Resources.WhiteSquareGameBoard;
                _interfaceOptions.ImageForbiddenSquare = ITI.InterfaceUser.Properties.Resources.WhiteForbiddenSquareGameBoard;
                _interfaceOptions.ImageSquareMvtPossible = ITI.InterfaceUser.Properties.Resources.WhiteSquarepossibleGameBoard;
                if (_interfaceOptions.Languages == true)
                {
                    MessageBox.Show("Le design du plateau a été modifié !", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("GameBoard's design has been changed !", "Information", MessageBoxButtons.OK);
                }
            };
            this.Controls.Add(_NewSquarePicture02);
            _NewSquarePicture02.BringToFront();
        }
    }
}
