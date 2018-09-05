using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur.classes.dames
{
    public partial class PlayDames : Form
    {
        public PlayDames()
        {
            InitializeComponent();
        }

        Button[,] board = new Button[10, 10];
        Dames dames;
        Point pPieceToMove;
        public Menu _menu;

        private void PlayDames_Load(object sender, EventArgs e)
        {
            dames = new Dames();
            pPieceToMove = Point.Empty;

            int size = 500 / 10;
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Button cell = new Button();
                    cell.Height = size;
                    cell.Width = cell.Height;
                    cell.Left = cell.Width * x;
                    cell.Top = cell.Height * 10 - cell.Height * y;
                    cell.BackgroundImageLayout = ImageLayout.Stretch;
                    cell.FlatStyle = FlatStyle.Flat;

                    if ((x + y) % 2 == 0)
                    {
                        cell.BackColor = Color.FromArgb(196, 156, 92);
                        cell.Click += new EventHandler(Click);
                    }
                    else
                    {
                        cell.Enabled = false;
                        cell.BackColor = Color.FromArgb(214, 186, 123);
                    }

                    this.Controls.Add(cell);

                    board[x, y] = cell;
                }
            }

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (dames.GetBoard()[x, y] != null)
                    {
                        if (dames.GetBoard()[x, y].GetColor())
                        {
                            board[x, y].BackgroundImage = Image.FromFile(@"..\..\Images\JBlanc.png");
                        }
                        else
                        {
                            board[x, y].BackgroundImage = Image.FromFile(@"..\..\Images\JNoir.png");
                        }
                    }
                }
            }

            ShowMovablePieces();
        }

        private void ResetColors()
        {
            foreach (Button cell in board)
            {
                if (cell.BackColor == Color.White)
                {
                    cell.BackColor = Color.FromArgb(196, 156, 92);
                }
            }
        }

        private void ShowMovablePieces()
        {
            foreach (Point pieceLocation in dames.GetMovablePieces())
            {
                board[pieceLocation.X, pieceLocation.Y].BackColor = Color.White;
            }
        }

        private void ShowPieceMoves(Point _location)
        {
            Tree selectedPieceTree = dames.GetTree(_location);

            ResetColors();
            board[_location.X, _location.Y].BackColor = Color.White;

            foreach (Node child in selectedPieceTree.GetChildren())
            {
                board[child.GetPosition().X, child.GetPosition().Y].BackColor = Color.White;
            }
        }

        private void Click(object sender, EventArgs e)
        {
            Button btnClickedButton = sender as Button;
            Point pClickedLocation = Point.Empty;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (board[x, y] == btnClickedButton)
                    {
                        pClickedLocation = new Point(x, y);
                    }
                }
            }

            if (pClickedLocation != Point.Empty)
            {
                if (pPieceToMove == Point.Empty)
                {
                    if (PieceCanMove(pClickedLocation))
                    {
                        pPieceToMove = pClickedLocation;
                        ShowPieceMoves(pPieceToMove);
                    }
                }
                else
                {
                    if (pPieceToMove == pClickedLocation)
                    {
                        pPieceToMove = Point.Empty;
                        ResetColors();
                        ShowMovablePieces();
                    }
                    else
                    {
                        if (dames.MovePlayer(pPieceToMove, pClickedLocation))
                        {
                            Move(pPieceToMove, pClickedLocation);
                            ResetColors();
                            pPieceToMove = Point.Empty;

                            if (!dames.CanStillEat() && !(Check(true)))
                            {
                                IaPlay();
                            }

                            ShowMovablePieces();
                        }
                    }
                }
            }
        }

        private void IaPlay()
        {
            do
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                Point[] move = dames.MoveIA();

                Move(move[0], move[1]);

                Check(false);

            }
            while (dames.CanStillEat());
        }

        private bool Check(bool _color)
        {
            Point pUpgradedPiece = dames.CheckTransformation(_color);
            if (pUpgradedPiece != Point.Empty)
            {
                if (_color)
                {
                    board[pUpgradedPiece.X, pUpgradedPiece.Y].BackgroundImage = Image.FromFile(@"..\..\Images\JBlancReine.png");
                }
                else
                {
                    board[pUpgradedPiece.X, pUpgradedPiece.Y].BackgroundImage = Image.FromFile(@"..\..\Images\JNoirReine.png");
                }

            }

            switch (dames.Check())
            {
                case 1:
                case 2:
                    MessageBox.Show("fin de  la partie !!", "Fin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return true;
                default:
                    break;
            }
            return false;
        }

        private void Move(Point _location, Point _destination)
        {
            board[_destination.X, _destination.Y].BackgroundImage = board[_location.X, _location.Y].BackgroundImage;
            board[_location.X, _location.Y].BackgroundImage = null;

            if (dames.CanEat())
            {
                Point _deadLocation = dames.GetDeadPieceLocation();
                board[_deadLocation.X, _deadLocation.Y].BackgroundImage = null;
            }
        }

        private bool PieceCanMove(Point _location)
        {
            if (dames.GetMovablePieces().Contains(_location))
            {
                return true;
            }

            return false;
        }

        private void PlayDames_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._menu.Show();
        }
    }
}
