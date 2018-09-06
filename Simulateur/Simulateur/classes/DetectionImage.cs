using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.Util;
using System.Linq;
using Emgu.CV.UI;
using System.Drawing.Imaging;

namespace Simulateur.classes
{
    abstract class DetectionImage
    {
        //déclaration des variables et objet
        public ImageBox originalImageBox;
        public ImageBox detectionImageBox;
        public ImageBox fluxImageBox;
        public Label labelInfoDectionImage;

        public NumericUpDown numericX;
        public NumericUpDown numericY;
        public NumericUpDown numericWidth;
        public NumericUpDown numericHeight;

        public VideoCapture capture;
        public Mat frame;

        public int[,] board;

        public DetectionImage(Form1 form)
        {
            //récupération des composants WinForm
            originalImageBox = form.Controls.Find("originalImageBox", true).First() as ImageBox;
            detectionImageBox = form.Controls.Find("detectionImageBox", true).First() as ImageBox;
            labelInfoDectionImage = form.Controls.Find("labelInfoDectionImage", true).First() as Label;
            fluxImageBox = form.Controls.Find("fluxImageBox", true).First() as ImageBox;

            numericX = form.Controls.Find("numericX", true).First() as NumericUpDown;
            numericY = form.Controls.Find("numericY", true).First() as NumericUpDown;
            numericWidth = form.Controls.Find("numericWidth", true).First() as NumericUpDown;
            numericHeight = form.Controls.Find("numericHeight", true).First() as NumericUpDown;


            //initialisation des objets
            capture = new VideoCapture();
            capture.ImageGrabbed += ProcessFrame;
            frame = new Mat();


            capture.Start();
            board = new int[3, 3];
        }

        /// <summary>
        /// Fonction EmguCV permettant de récupérer le flux de la caméra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ProcessFrame(object sender, EventArgs arg)
        {
            capture.Retrieve(frame, 0);
            try
            {
                fluxImageBox.Image = frame;
            }
            catch { }
        }

        public abstract void Debug(); 
        
        public IImage modifImage()
        {
            //crop image
            IImage img = fluxImageBox.Image;
            Bitmap bmp = img.Bitmap;
            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            bmp = bmp.Clone(new Rectangle(Convert.ToInt32(numericX.Value), Convert.ToInt32(numericY.Value), Convert.ToInt32(numericWidth.Value), Convert.ToInt32(numericHeight.Value)), bmp.PixelFormat);
            img = new Image<Bgr, Byte>(bmp).Resize(400, 400, Emgu.CV.CvEnum.Inter.Linear, true);

            originalImageBox.Image = img;

            return img;
        }
    }
}
