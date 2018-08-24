using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur.classes.dames
{
    class PlayDames
    {
        GroupBox gbDames;
        Dames dames;
        Form1 form;
        Button[,] pieces;
        Robot robotXY;
        const int CELLNUMBER = 10;
        const int BORDERSTARTX = 200;
        readonly int iGridSize;
        readonly int iCellSize;

        public PlayDames(Form1 _form, Robot _robot, double _width, double _height)
        {
            form = _form;
            robotXY = _robot;
            dames = new Dames();

            if(_width <= _height)
            {
                iGridSize = Convert.ToInt32(_width);
            }
            else
            {
                iGridSize = Convert.ToInt32(_height);
            }
            iCellSize = iGridSize / CELLNUMBER;

            CreateInterface();
            DrawGrid();

            //MessageBox.Show("Veuillez changer la tête du robot et placer les jetons sur les pions", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PlacePion();
        }

        private void DrawGrid()
        {
            for(int compteur = 0; compteur <= CELLNUMBER; compteur++)
            {
                robotXY.MoveCursor(0, compteur * iCellSize);
                robotXY.PenDown();
                robotXY.MoveCursor(iGridSize, compteur * iCellSize);
                robotXY.PenUp();
            }

            for (int compteur = 0; compteur <= CELLNUMBER; compteur++)
            {
                robotXY.MoveCursor(compteur * iCellSize, 0);
                robotXY.PenDown();
                robotXY.MoveCursor(compteur * iCellSize, iGridSize);
                robotXY.PenUp();
            }

            robotXY.ResetPosition();
        }

        private void PlacePion()
        {
            pieces = new Button[CELLNUMBER,CELLNUMBER];
            Pion[,] board = dames.GetBoard();

            for(int y = 0; y < CELLNUMBER; y++)
            {
                for(int x = 0; x < CELLNUMBER; x++)
                {
                    if(board[x, y] != null)
                    {
                        Button temp = new Button();
                        temp.Height = iCellSize - 1;
                        temp.Width = temp.Height;
                        temp.Top = iGridSize + 13 - (y + 1) * iCellSize;
                        temp.Left = BORDERSTARTX + 13 + x * iCellSize;


                        if(board[x, y].GetColor())
                        {
                            temp.BackColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            temp.BackColor = System.Drawing.Color.Black;
                        }
                        pieces[x, y] = temp;
                        form.Controls.Add(temp);
                    }
                }
            }
        }

        private void CreateInterface()
        {
            gbDames = new GroupBox();
            gbDames.Name = "gbDames";
            gbDames.Text = "Dames";
            gbDames.Top = 420;
            gbDames.Left = 10;
            gbDames.Width = 150;
            gbDames.Height = 150;

            NumericUpDown num = new NumericUpDown();
            num.Name = "numFromX";
            num.Width = 50;
            num.Left = 10;
            num.Top = 20;
            num.Maximum = 9;
            gbDames.Controls.Add(num);

            num = new NumericUpDown();
            num.Name = "numFromY";
            num.Width = 50;
            num.Left = 10;
            num.Top = 43;
            num.Maximum = 9;
            gbDames.Controls.Add(num);

            num = new NumericUpDown();
            num.Name = "numToX";
            num.Width = 50;
            num.Left = 10;
            num.Top = 70;
            num.Maximum = 9;
            gbDames.Controls.Add(num);

            num = new NumericUpDown();
            num.Name = "numToY";
            num.Width = 50;
            num.Left = 10;
            num.Top = 93;
            num.Maximum = 9;
            gbDames.Controls.Add(num);

            Button btn = new Button();
            btn.Name = "btnPlace";
            btn.Text = "Déplacer";
            btn.Left = 9;
            btn.Top = 120;
            btn.Click += new EventHandler(Place);
            gbDames.Controls.Add(btn);

            form.Controls.Add(gbDames);
        }

        private void Place(Object sender, EventArgs e)
        {
            NumericUpDown temp = gbDames.Controls.Find("numFromX", true)[0] as NumericUpDown;
            int FromX = Convert.ToInt32(temp.Value);

            temp = gbDames.Controls.Find("numFromY", true)[0] as NumericUpDown;
            int FromY = Convert.ToInt32(temp.Value);

            temp = gbDames.Controls.Find("numToX", true)[0] as NumericUpDown;
            int ToX = Convert.ToInt32(temp.Value);

            temp = gbDames.Controls.Find("numToY", true)[0] as NumericUpDown;
            int ToY = Convert.ToInt32(temp.Value);

            if((ToX + ToY) % 2 == 0)
            {
                if (pieces[FromX, FromY] != null && pieces[ToX, ToY] == null)
                {
                    MoveButton(FromX, FromY, ToX, ToY);
                }
            }
        }

        private void MovePiece(Robot robotXY, int iFromX, int iFromY, int iToX, int iToY)
        {
            robotXY.MoveCursor(iFromX * iCellSize, iFromY * iCellSize);
            robotXY.PenDown();
            robotXY.MoveCursor(iToX * iCellSize, iToY * iCellSize);

            MoveButton(iFromX, iFromY, iToX, iToY);

            robotXY.PenUp();
            robotXY.ResetPosition();
        }

        private void MoveButton(int iFromX, int iFromY, int iToX, int iToY)
        {
            pieces[iFromX, iFromY].Left = BORDERSTARTX + 13 + iToX * iCellSize;
            pieces[iFromX, iFromY].Top = iGridSize + 13 - (iToY + 1) * iCellSize;
            pieces[iToX, iToY] = pieces[iFromX, iFromY];
            pieces[iFromX, iFromY] = null;

 
        }

        public void Remove()
        {
            foreach(Button btn in pieces)
            {
                if(btn != null)
                {
                    form.Controls.Remove(btn);
                }
            }

            form.Controls.Remove(gbDames);
        }
    }
}
