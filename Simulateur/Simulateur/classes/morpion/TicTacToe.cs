using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.classes.morpion
{
    class TicTacToe
    {
        int[,] tblGrid = new int[3, 3];
        DetectionImage di;

        public TicTacToe(DetectionImage _di)
        {
            di = _di;

            for(int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    tblGrid[x, y] = 0;
                }
            }
        }

        public int[,] getGrid()
        {
            return tblGrid;
        }

        public Point PlaceCross()
        {
            return di.PrintScreen();
        }

        public void PlaceCicle(Point pCell)
        {
            tblGrid[pCell.X, pCell.Y] = 2;
        }

        public int CheckGrid()
        {
            //Déclaration des variables locales
            string totx = "";
            string toty = "";
            string totd1 = "";
            string totd2 = "";

            //Parcourt toute la grille
            for (int x = 0; x < Math.Sqrt(tblGrid.Length); x++)
            {
                for (int y = 0; y < Math.Sqrt(tblGrid.Length); y++)
                {
                    //Ajoute le contenu des cases
                    totx += Convert.ToString(tblGrid[x, y]); // horizontale
                    toty += Convert.ToString(tblGrid[y, x]); // verticale

                    //Vérifie si c'est une case de diagonale
                    if (x == y)
                    {
                        //Ajoute la case
                        totd1 += Convert.ToString(tblGrid[x, y]); // diagonale
                    }

                    //Vérifie si c'est une case de diagonale
                    if (x + y == 2)
                    {
                        //Ajoute la case
                        totd2 += Convert.ToString(tblGrid[x, y]); // diagonale
                    }
                }

                //marque la fin de ligne/colonne dans la chaine
                totx += ";";
                toty += ";";
            }

            //Vérifie si qqn a gagné
            if (totx.Contains("111") || toty.Contains("111") || totd1.Contains("111") || totd2.Contains("111"))
            {
                //Affiche que le joueur a gagné
                return 1;
            }
            else if (totx.Contains("222") || toty.Contains("222") || totd1.Contains("222") || totd2.Contains("222"))
            {
                //Affiche que l'IA a gagné
                return 2;
            }

            return 0;
        }
    }
}
