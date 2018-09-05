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
using System.Runtime.InteropServices;

namespace Simulateur.classes.dames
{
    class DetectionImageDames : DetectionImage
    {
        public DetectionImageDames(Form1 form) : base(form)
        {
            board = new int[10, 10];
        }

        /// <summary>
        /// Méthode permettant la détection des carré, croix et ronds sur une image
        /// </summary>
        /// <param name="img">objet image de emguCV</param>
        protected int[,] PerformShapeDetection(IImage img)
        {
            //Convert the image to grayscale and filter out the noise
            UMat uimage = new UMat();
            CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

            //use image pyr to remove noise
            UMat pyrDown = new UMat();
            CvInvoke.PyrDown(uimage, pyrDown);
            CvInvoke.PyrUp(pyrDown, uimage);

            #region circle detection
            Stopwatch watch = Stopwatch.StartNew();
            double cannyThreshold = 180.0;//180 -> def
            double circleAccumulatorThreshold = 50;//120->def, 80 -> OK
            CircleF[] circles = CvInvoke.HoughCircles(uimage, HoughType.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, 5);

            watch.Stop();
            #endregion

            #region Canny and edge detection
            watch.Reset(); watch.Start();
            double cannyThresholdLinking = 120.0;
            UMat cannyEdges = new UMat();
            CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);

            LineSegment2D[] lines = CvInvoke.HoughLinesP(
                cannyEdges,
                1, //Distance resolution in pixel-related units 1
                Math.PI / 45.0, //Angle resolution measured in radians.
                10, //threshold 20
                10, //min Line width 30
                5); //gap between lines 10

            watch.Stop();
            #endregion

            #region Find triangles and rectangles
            watch.Reset(); watch.Start();
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                        {
                            if (approxContour.Size == 3) //The contour has 3 vertices, it is a triangle
                            {
                                Point[] pts = approxContour.ToArray();
                                triangleList.Add(new Triangle2DF(
                                    pts[0],
                                    pts[1],
                                    pts[2]
                                    ));
                            }
                            else if (approxContour.Size == 4) //The contour has 4 vertices.
                            {
                                #region determine if all the angles in the contour are within [80, 100] degree
                                bool isRectangle = true;
                                Point[] pts = approxContour.ToArray();
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                for (int j = 0; j < edges.Length; j++)
                                {
                                    double angle = Math.Abs(
                                        edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                    if (angle < 80 || angle > 100)
                                    {
                                        isRectangle = false;
                                        break;
                                    }
                                }
                                #endregion

                                if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                            }
                        }
                    }
                }
            }

            watch.Stop();
            #endregion

            originalImageBox.Image = img;

            #region draw triangles and rectangles

            Mat detctionImage = new Mat(img.Size, DepthType.Cv8U, 3);
            detctionImage.SetTo(new MCvScalar(0));

            boxList = filterSquare(boxList);
            foreach (RotatedRect box in boxList)
            {
                CvInvoke.Polylines(detctionImage, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkOrange).MCvScalar, 2);
            }

            #endregion

            #region draw circles

            circles = filterRound(circles);

            foreach (CircleF circle in circles)
                CvInvoke.Circle(detctionImage, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Green).MCvScalar, 2);

            detectionImageBox.Image = detctionImage;

            #endregion

            //return BoardDames(new RotatedRect(), circles);
            return new int[10, 10];
        }


        /// <summary>
        /// retourne un tab 2 dimension contenant la position des ronds sur la grille du morpion
        /// </summary>
        /// <param name="rect">rectangle du millieux de la grille du morpion</param>
        /// <param name="circles">tablau contenant les ronds</param>
        /// <returns>un tableau 2d représentant la grille du morpion</returns>
        private int[,] BoardRound(RotatedRect rect, CircleF[] circles)
        {
            int[,] boardConfig = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; ;

            float boardEdge = rect.Size.Width;

            float boardX0 = rect.Center.X - (boardEdge / 2) - boardEdge;
            float boardY0 = rect.Center.Y - (boardEdge / 2) - boardEdge;

            int posX = -1;
            int posY = -1;

            for (int i = 0; i < circles.Length; i++)
            {
                posX = -1;
                posY = -1;

                //X
                if (circles[i].Center.X > boardX0 && circles[i].Center.X < boardX0 + boardEdge)
                {
                    posX = 0;
                }

                if ((circles[i].Center.X > boardX0 + boardEdge && circles[i].Center.X < boardX0 + (2 * boardEdge)))
                {
                    posX = 1;
                }

                if ((circles[i].Center.X > boardX0 + (2 * boardEdge) && circles[i].Center.X < boardX0 + (3 * boardEdge)))
                {
                    posX = 2;
                }

                //Y
                if (circles[i].Center.Y > boardY0 && circles[i].Center.Y < (boardY0 + boardEdge))
                {
                    posY = 2;
                }

                if ((circles[i].Center.Y > boardY0 + boardEdge && circles[i].Center.Y < boardY0 + (2 * boardEdge)))
                {
                    posY = 1;
                }

                if ((circles[i].Center.Y > boardY0 + (2 * boardEdge) && circles[i].Center.Y < boardY0 + (3 * boardEdge)))
                {
                    posY = 0;
                }

                if (posX != -1 && posY != -1)
                {
                    boardConfig[posX, posY] = 2;
                }
            }
            return boardConfig;
        }

        /// <summary>
        /// permet de prendre une capture avec la caméra et retourne la position de la croix qui a changé
        /// </summary>
        /// <returns>un objet point contenant la position de la croix qui a changé</returns>
        public Point PrintScreen(int[,] _board)
        {
            IImage img = modifImage();

            int[,] tmp = PerformShapeDetection(img);

            return Point.Empty;
        }

        public override void Debug()
        {
            IImage img = modifImage();

            int[,] tmp = PerformShapeDetection(img);
        }

        /// <summary>
        /// filtre tout les carrés détecté par le programme en ne gardant que les carrés parralélle à l'axe X
        /// </summary>
        /// <param name="rects">tableau de tout les rectangle détecté</param>
        /// <returns>tableau des rectangles filtrés</returns>
        private List<RotatedRect> filterSquare(List<RotatedRect> rects)
        {
            List<RotatedRect> tmp = new List<RotatedRect>();

            foreach (RotatedRect rect in rects)
            {
                if ((rect.Angle > -10.0f && rect.Angle < 10.0f) || (rect.Angle < -80.0f && rect.Angle > -100.0f))
                {
                    tmp.Add(rect);
                }
            }

            return tmp;
        }

        private CircleF[] filterRound(CircleF[] circles)
        {
            List<CircleF> listCircles = new List<CircleF>();

            foreach(CircleF circle in circles)
            {
                if(circle.Radius < 20.0f )
                {
                    listCircles.Add(circle);
                }
            }
            return listCircles.ToArray();
        }

        /// <summary>
        /// permet de detecter les ronds du jeu des dames sur un plateau
        /// </summary>
        /// <param name="rect">le 1er rectangle en haut a gauche du plateau</param>
        /// <param name="circles">tableau contenant les cercles détécté</param>
        /// <returns>un tab 2d indiquant l'etat du plateau des dames</returns>
        private int[,] BoardDames(RotatedRect rect, CircleF[] circles)
        {
            int[,] boardConfig = new int[10, 10];

            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    boardConfig[i, j] = 0;
                }
            }

            float boardEdge = rect.Size.Width;

            float boardX0 = rect.Center.X - (2 * rect.Size.Width);
            float boardY0 = rect.Center.Y - (2 * rect.Size.Height);

            int posX = -1;
            int posY = -1;

            for (int i = 0; i <= circles.Length; i++)
            {
                posX = -1;
                posY = -1;

                for (int j = 0; j <= 9; j++)
                {
                    //X
                    if (circles[i].Center.X > boardX0 + (j * boardEdge) && circles[i].Center.X < boardX0 + ((1 + j) * boardEdge))
                    {
                        posX = j;
                    }

                    //Y
                    if (circles[i].Center.Y > boardY0 + (j * boardEdge) && circles[i].Center.Y < boardY0 + ((1 + j) * boardEdge))
                    {
                        posY = 9 - j;
                    }
                }

                if (posX != -1 && posY != -1)
                {
                    boardConfig[posX, posY] = 1;
                }
            }

            return boardConfig;
        }
    }
}
