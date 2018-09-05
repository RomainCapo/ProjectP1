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

namespace Simulateur.classes.maze
{
    class DetectionImageMaze:DetectionImage
    {
        public DetectionImageMaze(Form1 form):base(form)
        {
            board = new int[10, 10];
        }

        /// <summary>
        /// Méthode permettant la détection des carré, croix et ronds sur une image
        /// </summary>
        /// <param name="img">objet image de emguCV</param>
        protected override int[,] PerformShapeDetection(IImage img)
        {  
            return new int[3, 3];
        }


        /// <summary>
        /// permet de prendre une capture avec la caméra et retourne la position de la croix qui a changé
        /// </summary>
        /// <returns>un objet point contenant la position de la croix qui a changé</returns>
        public void PrintScreen(int[,] _board)
        {
            IImage img = modifImage();

            int[,] tmp = PerformShapeDetection(img);
        }

        public override void debug()
        {
            IImage img = modifImage();

            int[,] tmp = PerformShapeDetection(img);
        }
    }
}
