using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Simulateur.classes
{
    class Robot
    {
        Bluetooth bluetooth;
        readonly double TAILLEX;
        readonly double TAILLEY;
        const int BORDERSTARTX = 200;
        double[] position = new double[2];
        RadioButton cursor;
        bool bCursorUp;
        Graphics formGraphics;
        Bitmap tempSheet;
        Form1 form;


        public Robot(Form1 _form, int _SizeX, int _SizeY)
        {
            bluetooth = new Bluetooth(_form);
            bCursorUp = true;
            form = _form;
            TAILLEX = _SizeX;
            TAILLEY = _SizeY;

            formGraphics = form.CreateGraphics();
            tempSheet = new Bitmap(form.Width, form.Height);
            position[0] = -1;
            position[1] = -1;

            cursor = new RadioButton();
            cursor.Name = "cursor";
            cursor.Width = cursor.Height;
            form.Controls.Add(cursor);

            ResetPosition();
        }

        public bool MoveCursor(double X, double Y)
        {
            try
            {
                bluetooth.SendNextCoord(X, Y);

                X = Math.Round(X, 2);
                Y = Math.Round(Y, 2);
                if (X < 0.00 || X > TAILLEX || Y < 0.00 || Y > TAILLEY)
                {
                    return false;
                }
                if(position[0] == X && position[1] == Y)
                {
                    return true;
                }

                double[] StartPosition = new double[2] { position[0], position[1] };
                position[0] = X;
                position[1] = Y;

                cursor.Invoke(new MethodInvoker(delegate { cursor.Left = BORDERSTARTX + Convert.ToInt32(position[0]); cursor.Top = Convert.ToInt32(TAILLEY - position[1]); }));

                if (!bCursorUp)
                {
                    Graphics sheet = Graphics.FromImage(tempSheet);

                    Pen pen = new Pen(Color.Black);
                    sheet.DrawLine(pen, (float)(BORDERSTARTX + Convert.ToInt32(StartPosition[0] + (cursor.Width / 2))), (float)(TAILLEY - Convert.ToInt32(StartPosition[1] - (cursor.Height / 2))), (float)(BORDERSTARTX + Convert.ToInt32(position[0] + (cursor.Width / 2))), (float)(TAILLEY - Convert.ToInt32(position[1] - (cursor.Height / 2))));

                }

                formGraphics.DrawImageUnscaled(tempSheet, 0, 0);
                Application.DoEvents();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PenUp()
        {
            try
            {
                bluetooth.SendPenUp();

                bCursorUp = true;
                (form.Controls.Find("cursor", false).FirstOrDefault() as RadioButton).Checked = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PenDown()
        {
            try
            {
                bluetooth.SendPenDown();

                bCursorUp = false;
                (form.Controls.Find("cursor", false).FirstOrDefault() as RadioButton).Checked = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ResetPosition()
        {
            return MoveCursor(0.00, 0.00);
        }

        public bool RemoveDrawing()
        {
            try
            {
                formGraphics.Clear(SystemColors.Control);
                tempSheet = new Bitmap(form.Width, form.Height);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
