﻿using System;
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

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fes = new Form1();
            this.Hide();
            fes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fes = new Form1();
            this.Hide();
            fes.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fes = new Form1();
            this.Hide();
            fes.Show();
        }
    }
}
