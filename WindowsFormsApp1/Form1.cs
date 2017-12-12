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
        Graphics myGraphics;

        int vitesse = 10;

        int posXi = 0, posYi = 0;
        int posDestX = 0, posDestY = 0;
        bool feutrePosBas = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                robot = new Robot(pnlSurface, pnlAxeX, pnlAxeY);
        }

        private void btnLauchCommand_Click(object sender, EventArgs e)
        {
            //Retour position départ
            if (cbxCommand.SelectedIndex == 4)
            {
                robot.RetourPositionDepart();
            }
            else if (cbxCommand.SelectedIndex == 1)//command position
            {
                //robot.Position(Convert.ToInt32(tbxPosX.Text), Convert.ToInt32(tbxPosY.Text));
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
            myGraphics = e.Graphics;
        }

        private void btnVitesse_Click(object sender, EventArgs e)
        {
            vitesse = Convert.ToInt32(tbxVitesse.Text);
            timerVitesse.Interval = vitesse;
        }

        private void timerVitesse_Tick(object sender, EventArgs e)
        {
            
            if(posDestX < robot.getCurrentPos()[0])
            {
                if (posDestX != posXi)
                {
                    posXi--;
                }
            }
            else if(posDestX > robot.getCurrentPos()[0])
            {
                if (posDestX != posXi)
                {
                    posXi++;
                }
            }


            if (posDestY < robot.getCurrentPos()[1])
            {
                if (posDestY != posYi)
                {
                    posYi--;
                }
            }
            else if (posDestY > robot.getCurrentPos()[1])
            {
                if (posDestY != posYi)
                {
                    posYi++;
                }
            }

            if((posDestX == robot.getCurrentPos()[0]) && (posDestY == robot.getCurrentPos()[1]))
            {
                timerVitesse.Stop();
            }

            if(feutrePosBas == true)
            {
                //PutPixel(myGraphics, posXi, posXi);
            }

            robot.Position(posXi, posYi);
        }
    }
}
