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
    class DetectionImage
    {
        //déclaration des variables et objet
        ImageBox originalImageBox;
        ImageBox detectionImageBox;
        ImageBox fluxImageBox;
        Label labelInfoDectionImage;

        VideoCapture capture;
        Mat frame;

        public DetectionImage(Form1 form)
        {
            //récupération des composants WinForm
            originalImageBox = form.Controls.Find("originalImageBox", true).First() as ImageBox;
            detectionImageBox = form.Controls.Find("detectionImageBox", true).First() as ImageBox;
            labelInfoDectionImage = form.Controls.Find("labelInfoDectionImage", true).First() as Label;
            fluxImageBox = form.Controls.Find("fluxImageBox", true).First() as ImageBox;

            //initialisation des objets
            capture = new VideoCapture();
            capture.ImageGrabbed += ProcessFrame;
            frame = new Mat();
            capture.Start();

            Image<Bgr, Byte> imag = new Image<Bgr, byte>(@"C:\Users\romain.capocasa\Desktop\g1\Simulateur\Simulateur\test3.png").Resize(400, 400, Emgu.CV.CvEnum.Inter.Linear, true);
            PerformShapeDetection(imag);
        }

        /// <summary>
        /// Fonction EmguCV permettant de récupérer le flux de la caméra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ProcessFrame(object sender, EventArgs arg)
        {
            capture.Retrieve(frame, 0);
            fluxImageBox.Image = frame;
        }

        /// <summary>
        /// Méthode permettant la détection des carré, croix et ronds sur une image
        /// </summary>
        /// <param name="img">objet image de emguCV</param>
        public void PerformShapeDetection(IImage img)
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
            double circleAccumulatorThreshold = 90;//120->def, 80 -> OK
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
                20, //threshold 20
                35, //min Line width 30
                10); //gap between lines 10

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

            foreach (CircleF circle in circles)
                CvInvoke.Circle(detctionImage, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Brown).MCvScalar, 2);

            detectionImageBox.Image = detctionImage;

            #endregion

            #region draw lines
            lines = filterCross(lines);

            /////////////
            List<Point> test = new List<Point>();
            foreach(LineSegment2D fes in lines)
            {
                test.Add(calcCenterLine(fes));
            }
            ////////////

            //CvInvoke.Line(detctionImage, lines[3].P1, lines[3].P2, new Bgr(Color.White).MCvScalar, 2);
            foreach (LineSegment2D line in lines)
            {
                CvInvoke.Line(detctionImage, line.P1, line.P2, new Bgr(Color.Yellow).MCvScalar, 2);
            }

            #endregion

            if (boxList.Count != 0)
            {
                int[,] round = returnBoardRound(boxList[0], circles);
                int[,] cross = returnBoardCross(boxList[0], lines);
                int[,] board = returnBoard(cross, round);

                drawBoard(board);
            }
        }

        /// <summary>
        /// filtre tout les carrés détecté par le programme en ne gardant que les carrés parralélle à l'axe X
        /// </summary>
        /// <param name="rects">tableau de tout les rectangle détecté</param>
        /// <returns>tableau des rectangles filtrés</returns>
        private List<RotatedRect> filterSquare(List<RotatedRect> rects)
        {
            List<RotatedRect> tmp = new List<RotatedRect>();

            foreach(RotatedRect rect in rects)
            {
                if((rect.Angle > -10.0f && rect.Angle < 10.0f) || (rect.Angle < -80.0f && rect.Angle > -100.0f))
                {
                    tmp.Add(rect);
                }
            }

            return tmp;
        }

        /// <summary>
        /// dessine le plateau de jeu
        /// </summary>
        /// <param name="board">le plateau de jeu</param>
        private void drawBoard(int[,] board)
        {
            labelInfoDectionImage.Text = "";
            for (int i = 2; i >= 0; i--)
            {
                for (int j = 0; j <= 2; j++)
                {
                    switch (board[j, i])
                    {
                        case 0:
                            labelInfoDectionImage.Text += "   |";
                            break;
                        case 1:
                            labelInfoDectionImage.Text += "X|";
                            break;

                        case 2:
                            labelInfoDectionImage.Text += "O|";
                            break;
                    }
                }
                labelInfoDectionImage.Text += "\n";

            }
        }

        public void PrintScreen()
        {
            originalImageBox.Image = fluxImageBox.Image;
            PerformShapeDetection(originalImageBox.Image);
        }

        /// <summary>
        /// permet de detecter les ronds du jeu des dames sur un plateau
        /// </summary>
        /// <param name="rect">le 1er rectangle en haut a gauche du plateau</param>
        /// <param name="circles">tableau contenant les cercles détécté</param>
        /// <returns>un tab 2d indiquant l'etat du plateau des dames</returns>
        private int[,] returnBoardDames(RotatedRect rect, CircleF[] circles)
        {
            int[,] boardConfig = new int[10, 10]; 

            for(int i = 0;i <=10; i++)
            {
                for(int j = 0; j <= 10; j++)
                {
                    boardConfig[i, j] = 0;
                }
            }

            float boardEdge = rect.Size.Width;

            float boardX0 = rect.Center.X - (2 * rect.Size.Width);
            float boardY0 = rect.Center.Y - (2 * rect.Size.Height);

            int posX = -1;
            int posY = -1;

            for(int i = 0; i <= circles.Length;i++ )
            {
                posX = -1;
                posY = -1;

                for(int j = 0; j <= 9; j++)
                {
                    //X
                    if(circles[i].Center.X > boardX0 + (j * boardEdge) && circles[i].Center.X < boardX0 +  ((1 +j) * boardEdge))
                    {
                        posX = j;
                    }

                    //Y
                    if (circles[i].Center.Y > boardY0 + (j * boardEdge) && circles[i].Center.Y < boardY0 + ((1 + j) * boardEdge))
                    {
                        posY = 9 - j;
                    }
                }

                if(posX != -1 && posY != -1)
                {
                    boardConfig[posX, posY] = 1;
                }
            }

            return boardConfig;
        }

        /// <summary>
        /// retourne un tab 2 dimension contenant la position des ronds sur la grille du morpion
        /// </summary>
        /// <param name="rect">rectangle du millieux de la grille du morpion</param>
        /// <param name="circles">tablau contenant les ronds</param>
        /// <returns>un tableau 2d représentant la grille du morpion</returns>
        private int[,] returnBoardRound(RotatedRect rect, CircleF[] circles)
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
        /// Filtre les lignes du tableau passé en paramétre pour retourner uniquement les croix
        /// </summary>
        /// <param name="lines">tableau contenant toutes les lignes détectés</param>
        /// <returns>un tableau contenant les croix</returns>
        private LineSegment2D[] filterCross(LineSegment2D[] lines)
        {
            List<LineSegment2D> listLines = new List<LineSegment2D>();
            //List<double> gradients = new List<double>();

            for (int i = 0; i < lines.Length; i++)
            {
                double gradient = calcGradient(lines[i].P1, lines[i].P2);
                //gradients.Add(gradient);
                if (gradient >= 0.5 && gradient <= 1.0)
                {
                    listLines.Add(lines[i]);
                }
            }


            LineSegment2D[] array = listLines.ToArray();
            return array;
        }

        /// <summary>
        /// retourne le plateau final du morpion
        /// </summary>
        /// <param name="cross">tableau contenant la position des croix</param>
        /// <param name="round">tableau contenant la position des ronds</param>
        /// <returns>un tab 2d représentans l'etat du jeu</returns>
        private int[,] returnBoard(int[,] cross, int[,] round)
        {
            int[,] board = new int[3, 3];

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    int isCross = cross[i, j];
                    int isRound = round[i, j];

                    if (isCross != 0 && isRound == 0)
                    {
                        board[i, j] = 1;
                    }
                    else if (isRound != 0 && isCross == 0)
                    {
                        board[i, j] = 2;
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
            }

            return board;
        }

        /// <summary>
        /// retourne un tab 2 dimension contenant la position des croix sur la grille du morpion
        /// </summary>
        /// <param name="rect">rectangle du millieux de la grille du morpion</param>
        /// <param name="lines">tablau contenant les lignes formants les croix</param>
        /// <returns>un tableau 2d représentant la grille du morpion</returns>
        private int[,] returnBoardCross(RotatedRect rect, LineSegment2D[] lines)
        {
            int[,] boardConfig = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; ;

            float boardEdge = rect.Size.Width;

            float boardX0 = rect.Center.X - (boardEdge / 2) - boardEdge;
            float boardY0 = rect.Center.Y - (boardEdge / 2) - boardEdge;

            int posX = -1;
            int posY = -1;

            List<int[]> posCross = new List<int[]>();

            for (int i = 0; i < lines.Length; i++)
            {
                Point centerLine = calcCenterLine(lines[i]);
                posX = -1;
                posY = -1;

                //X
                if (centerLine.X > boardX0 && centerLine.X < (boardX0 + boardEdge))
                {
                    posX = 0;
                }

                if ((centerLine.X > boardX0 + boardEdge && centerLine.X < boardX0 + (2 * boardEdge)))
                {
                    posX = 1;
                }

                if ((centerLine.X > boardX0 + (2 * boardEdge) && centerLine.X < boardX0 + (3 * boardEdge)))
                {
                    posX = 2;
                }

                //Y
                if (centerLine.Y > boardY0 && centerLine.Y < (boardY0 + boardEdge))
                {
                    posY = 2;
                }

                if ((centerLine.Y > boardY0 + boardEdge && centerLine.Y < boardY0 + (2 * boardEdge)))
                {
                    posY = 1;
                }

                if ((centerLine.Y > boardY0 + (2 * boardEdge) && centerLine.Y < boardY0 + (3 * boardEdge)))
                {
                    posY = 0;
                }

                if(posX != -1 && posY != -1)
                {
                    boardConfig[posX, posY] = 1;
                }

            }

            return boardConfig;
        }

        /// <summary>
        /// Calcule la pente de la droite passant par les 2 points passé en parametre
        /// </summary>
        /// <param name="p1">1er point</param>
        /// <param name="p2">2eme point</param>
        /// <returns>la pente de la droite</returns>
        private double calcGradient(Point p1, Point p2)
        {
            if ((p2.X - p1.X) != 0)
            {
                return (Convert.ToDouble(p2.Y) - p1.Y) / (p2.X - p1.X);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Calcule les coordonnées du centre d'une ligne
        /// </summary>
        /// <param name="line">un objet ligne</param>
        /// <returns>la corrdonnée du centre de la ligne</returns>
        private Point calcCenterLine(LineSegment2D line)
        {
            int X = Convert.ToInt32(0.5 * (line.P2.X + line.P1.X));
            int Y = Convert.ToInt32(0.5 * (line.P2.Y + line.P1.Y));

            return new Point(X, Y);
        }
    }
}
