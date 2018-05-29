using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur.formes
{
    public partial class MenuTicTacToe : Form
    {
        
        public MenuTicTacToe()
        {
            InitializeComponent();
        }

        private void MenuTicTacToe_Load(object sender, EventArgs e)
        {
            cbxDiff.SelectedIndex = 0;
            cbxTour.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            Form1 f1 = new Form1("Tic-Tac-Toe", cbxDiff.SelectedIndex, cbxDiff.SelectedIndex);
            f1.Show();
            menu.Close();
            this.Close();
        }
    }
}
