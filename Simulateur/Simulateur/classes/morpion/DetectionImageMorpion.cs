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

namespace Simulateur.classes.morpion
{
    class DetectionImageMorpion:DetectionImage
    {
        public DetectionImageMorpion(Form1 form) : base(form)
        {
            board = new int[3, 3];
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
            double circleAccumulatorThreshold = 95;//120->def, 80 -> OK
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

            originalImageBox.Image = img;

            #region draw triangles and rectangles

            Mat detctionImage = new Mat(img.Size, DepthType.Cv8U, 3);
            detctionImage.SetTo(new MCvScalar(0));


            RotatedRect box = new RotatedRect(new PointF(210, 210), new SizeF(110, 110), 0);
            CvInvoke.Polylines(detctionImage, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkOrange).MCvScalar, 2);

            #endregion

            #region draw circles

            foreach (CircleF circle in circles)
                CvInvoke.Circle(detctionImage, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Brown).MCvScalar, 2);

            detectionImageBox.Image = detctionImage;

            #endregion

            #region draw lines
            lines = filterCross(lines);

            foreach (LineSegment2D line in lines)
            {
                CvInvoke.Line(detctionImage, line.P1, line.P2, new Bgr(Color.Yellow).MCvScalar, 2);
            }

            #endregion

            int[,] cross = BoardCross(box, lines);
            drawBoard(cross);

            return cross;
        }


        /// <summary>
        /// permet de prendre une capture avec la caméra et retourne la position de la croix qui a changé
        /// </summary>
        /// <returns>un objet point contenant la position de la croix qui a changé</returns>
        public Point PrintScreen(int[,] _board)
        {
            IImage img = modifImage();

            int[,] tmp = PerformShapeDetection(img);

            return getChangeBoard(_board, tmp);
        }

        public override void Debug()
        {
            IImage img = modifImage();

            int[,] tmp = PerformShapeDetection(img);
        }

        /// <summary>
        /// test si le tableau analysé est identique, si c'est le cas retourne un point vide sinon on retourne la coordonnée qui a changé 
        /// </summary>
        /// <param name="_currentBoard">tableau 2d du plateau actuel</param>
        /// <param name="_detectedBoard">tableau 2d du plateau detecté </param>
        /// <returns>un objet point de la coordonée qui a changé, sinon retourne un point vide</returns>
        private Point getChangeBoard(int[,] _currentBoard, int[,] _detectedBoard)
        {
            int iCompteur = 0;
            Point temp = Point.Empty;
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (_currentBoard[i, j] == 0 && _detectedBoard[i, j] == 1)
                    {
                        iCompteur++;
                        temp = new Point(i, j);
                    }
                }
            }

            if (iCompteur == 1)
            {
                return temp;
            }

            return Point.Empty;
        }

        /// <summary>
        /// compte le nombre de croix dans un tableau 2d
        /// </summary>
        /// <param name="array">tableau 2 dimension</param>
        /// <returns>retourne le nombre de croix repéréré</returns>
        private int nbCross(int[,] array)
        {
            int cmpt = 0;

            foreach (int val in array)
            {
                if (val == 1)
                {
                    cmpt++;
                }
            }
            return cmpt;
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

        /// <summary>
        /// retourne le plateau final du morpion
        /// </summary>
        /// <param name="cross">tableau contenant la position des croix</param>
        /// <param name="round">tableau contenant la position des ronds</param>
        /// <returns>un tab 2d représentans l'etat du jeu</returns>
       /* private int[,] BoardComplete(int[,] cross, int[,] round)
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
        }*/

        

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
        /// retourne un tab 2 dimension contenant la position des croix sur la grille du morpion
        /// </summary>
        /// <param name="rect">rectangle du millieux de la grille du morpion</param>
        /// <param name="lines">tablau contenant les lignes formants les croix</param>
        /// <returns>un tableau 2d représentant la grille du morpion</returns>
        private int[,] BoardCross(RotatedRect rect, LineSegment2D[] lines)
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

                if (posX != -1 && posY != -1)
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
