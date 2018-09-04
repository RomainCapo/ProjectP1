using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using OpenCvSharp;
using Mat = OpenCvSharp.Mat;
using Point = OpenCvSharp.Point;

namespace Simulateur.classes.maze
{
    class DetectionImageMaze:DetectionImage
    {
        public DetectionImageMaze(Form1 form):base(form)
        {
        }

        /// <summary>
        /// Méthode permettant la détection des carré, croix et ronds sur une image
        /// </summary>
        /// <param name="img">objet image de emguCV</param>
        protected void PerformShapeDetection()
        {
            Mat src = Cv2.ImRead(@"C:\Users\romain.capocasa\Desktop\g1\Simulateur\Simulateur\bin\Debug\lol.png");

            Mat bw = new Mat();
            Cv2.CvtColor(src, bw, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(bw, bw, 10, 255, ThresholdTypes.BinaryInv);

            Point[][] contours;
            HierarchyIndex[] a;
            Cv2.FindContours(bw, out contours, out a, RetrievalModes.External, ContourApproximationModes.ApproxNone);

            if (contours.Length != 2)
            {
                MessageBox.Show("not a perfect maze");
            }

            Mat path = Mat.Zeros(src.Size(), MatType.CV_8UC1);
            Cv2.DrawContours(path, contours, 0, Scalar.White, -1);

            Mat kernel = Mat.Ones(21, 21, MatType.CV_8UC1);
            Cv2.Dilate(path, path, kernel);

            Mat erode = new Mat();
            Cv2.Erode(path, erode, kernel);

            Cv2.Absdiff(path, erode, path);

            Mat[] channels;
            Cv2.Split(src, out channels);
            channels[0] &= ~path;
            channels[1] &= ~path;
            channels[2] |= path;

            Mat dst = new Mat();
            Cv2.Merge(channels, dst);
            Cv2.ImShow("solution", dst);

            Cv2.WaitKey(0);
        }


        /// <summary>
        /// permet de prendre une capture avec la caméra et retourne la position de la croix qui a changé
        /// </summary>
        /// <returns>un objet point contenant la position de la croix qui a changé</returns>
        public void PrintScreen()
        {
            //crop image
            IImage img = fluxImageBox.Image;
            Bitmap bmp = img.Bitmap;
            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            bmp = bmp.Clone(new Rectangle(Convert.ToInt32(numericX.Value), Convert.ToInt32(numericY.Value), Convert.ToInt32(numericWidth.Value), Convert.ToInt32(numericHeight.Value)), bmp.PixelFormat);

            if (File.Exists(@"C:\lol.png"))
            {
                File.Delete(@"C:\lol.png");
            }
            bmp.Save(@"lol.png");

            PerformShapeDetection();
        }

        public override void debug()
        {
            modifImage();
        }
    }
}
