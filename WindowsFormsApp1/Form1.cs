using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Robot robot;
        int vitesse = 10;

        int posDestX = 0, posDestY = 0;
        bool feutrePosBas = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            robot = new Robot(pnlSurface, pnlAxeX, pnlAxeY);//Instanciation du robot
        }

        private void btnLauchCommand_Click(object sender, EventArgs e)
        {
            //selectionne la commande en fonction du choix de la liste déroulante
            if (cbxCommand.SelectedIndex == 4)//Retour position départ
            {
                robot.RetourPositionDepart();
            }
            else if (cbxCommand.SelectedIndex == 1)//command position
            {
                posDestX = Convert.ToInt32(tbxPosX.Text);
                posDestY = Convert.ToInt32(tbxPosY.Text);
                timerVitesse.Start();
            }
            else if (cbxCommand.SelectedIndex == 3)//feutre position basse
            {
                feutrePosBas = true;
            }
            else if(cbxCommand.SelectedIndex == 2)//feutre position haute
            {
                feutrePosBas = false;
            }
        }

        private void cbxCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxCommand.SelectedIndex == 1)
            {
                tbxPosX.Enabled = true;
                tbxPosY.Enabled = true;
            }
            else
            {
                tbxPosX.Enabled = false;
                tbxPosY.Enabled = false;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //myGraphics = e.Graphics;
        }

        private void btnVitesse_Click(object sender, EventArgs e)
        {
            vitesse = Convert.ToInt32(tbxVitesse.Text);
            timerVitesse.Interval = vitesse;
        }

        //Decommenter pour le dessin d'un cercle
        //int centerX = 50, centerY = 50, radius = 30;

        private void timerVitesse_Tick(object sender, EventArgs e)
        {
            robot.Position(posDestX, posDestY, timerVitesse);//deplace les bras du robot

            //Decommenter pour le dessin d'un cercle
            /*for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double angle = i * System.Math.PI / 180;
                int x = (int)(centerX + radius * System.Math.Cos(angle));
                int y = (int)(centerY + radius * System.Math.Sin(angle));

                robot.Position(x, y, timerVitesse);
            }*/
        }
    }
}
