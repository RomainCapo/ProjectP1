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

        //int posXi = 0, posYi = 0;
        int posDestX = 0, posDestY = 0;
        bool feutrePosBas = false;

        /*void DrawCircle(PaintEventArgs e, int radius, int centerX, int centerY)
        {
            Graphics myGraphics = e.Graphics;
            //myGraphics.Clear(Color.White);

            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double angle = i * System.Math.PI / 180;
                int x = (int)(centerX + radius * System.Math.Cos(angle));
                int y = (int)(centerY + radius * System.Math.Sin(angle));

                PutPixel(myGraphics, x, y, Color.Red);
                //System.Threading.Thread.Sleep(5); // If you want to draw circle very slowly.
            }
            myGraphics.Dispose();
        }*/

        /*void DrawCross(PaintEventArgs e, int width, int topX, int topY)
        {
            Graphics myGraphics = e.Graphics;
            //myGraphics.Clear(Color.White);

            for (int i = 0; i <= width; i++)
            {
                PutPixel(myGraphics, topX + i, topY + i, Color.White);
                System.Threading.Thread.Sleep(30);
            }
            for (int j = width; j >= 0; j--)
            {
                PutPixel(myGraphics, topX + j, topY + (width - j), Color.White);
                System.Threading.Thread.Sleep(30);
            }
        }*/

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

        int centerX = 50, centerY = 50, radius = 30;

        private void timerVitesse_Tick(object sender, EventArgs e)
        {
               // robot.Position(posDestX, posDestY, timerVitesse);

            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double angle = i * System.Math.PI / 180;
                int x = (int)(centerX + radius * System.Math.Cos(angle));
                int y = (int)(centerY + radius * System.Math.Sin(angle));

                robot.Position(x, y, timerVitesse);
                System.Threading.Thread.Sleep(2); // If you want to draw circle very slowly.
            }
        }
    }
}
