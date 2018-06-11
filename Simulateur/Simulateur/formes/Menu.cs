using Simulateur.formes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuTicTacToe mttt = new MenuTicTacToe();
            mttt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1("Maze",0, 0);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
