namespace Simulateur
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbInformations = new System.Windows.Forms.GroupBox();
            this.lblTailleRobotY = new System.Windows.Forms.Label();
            this.lblTailleRobotYText = new System.Windows.Forms.Label();
            this.lblTailleRobotX = new System.Windows.Forms.Label();
            this.tblTailleRobotX = new System.Windows.Forms.Label();
            this.btnTicTacToe = new System.Windows.Forms.Button();
            this.btnMaze = new System.Windows.Forms.Button();
            this.btnResetSheet = new System.Windows.Forms.Button();
            this.gbInformations.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformations
            // 
            this.gbInformations.Controls.Add(this.lblTailleRobotY);
            this.gbInformations.Controls.Add(this.lblTailleRobotYText);
            this.gbInformations.Controls.Add(this.lblTailleRobotX);
            this.gbInformations.Controls.Add(this.tblTailleRobotX);
            this.gbInformations.Location = new System.Drawing.Point(12, 12);
            this.gbInformations.Name = "gbInformations";
            this.gbInformations.Size = new System.Drawing.Size(200, 265);
            this.gbInformations.TabIndex = 1;
            this.gbInformations.TabStop = false;
            this.gbInformations.Text = "Informations";
            // 
            // lblTailleRobotY
            // 
            this.lblTailleRobotY.AutoSize = true;
            this.lblTailleRobotY.Location = new System.Drawing.Point(6, 88);
            this.lblTailleRobotY.Name = "lblTailleRobotY";
            this.lblTailleRobotY.Size = new System.Drawing.Size(0, 17);
            this.lblTailleRobotY.TabIndex = 3;
            // 
            // lblTailleRobotYText
            // 
            this.lblTailleRobotYText.AutoSize = true;
            this.lblTailleRobotYText.Location = new System.Drawing.Point(6, 71);
            this.lblTailleRobotYText.Name = "lblTailleRobotYText";
            this.lblTailleRobotYText.Size = new System.Drawing.Size(138, 17);
            this.lblTailleRobotYText.TabIndex = 2;
            this.lblTailleRobotYText.Text = "Taille robotXY en Y :";
            // 
            // lblTailleRobotX
            // 
            this.lblTailleRobotX.AutoSize = true;
            this.lblTailleRobotX.Location = new System.Drawing.Point(6, 43);
            this.lblTailleRobotX.Name = "lblTailleRobotX";
            this.lblTailleRobotX.Size = new System.Drawing.Size(0, 17);
            this.lblTailleRobotX.TabIndex = 1;
            // 
            // tblTailleRobotX
            // 
            this.tblTailleRobotX.AutoSize = true;
            this.tblTailleRobotX.Location = new System.Drawing.Point(6, 26);
            this.tblTailleRobotX.Name = "tblTailleRobotX";
            this.tblTailleRobotX.Size = new System.Drawing.Size(138, 17);
            this.tblTailleRobotX.TabIndex = 0;
            this.tblTailleRobotX.Text = "Taille robotXY en X :";
            // 
            // btnTicTacToe
            // 
            this.btnTicTacToe.Location = new System.Drawing.Point(21, 284);
            this.btnTicTacToe.Name = "btnTicTacToe";
            this.btnTicTacToe.Size = new System.Drawing.Size(93, 33);
            this.btnTicTacToe.TabIndex = 2;
            this.btnTicTacToe.Text = "Morpion";
            this.btnTicTacToe.UseVisualStyleBackColor = true;
            this.btnTicTacToe.Click += new System.EventHandler(this.btnTicTacToe_Click);
            // 
            // btnMaze
            // 
            this.btnMaze.Location = new System.Drawing.Point(21, 323);
            this.btnMaze.Name = "btnMaze";
            this.btnMaze.Size = new System.Drawing.Size(93, 33);
            this.btnMaze.TabIndex = 3;
            this.btnMaze.Text = "Labyrinthe";
            this.btnMaze.UseVisualStyleBackColor = true;
            this.btnMaze.Click += new System.EventHandler(this.btnMaze_Click);
            // 
            // btnResetSheet
            // 
            this.btnResetSheet.Location = new System.Drawing.Point(21, 362);
            this.btnResetSheet.Name = "btnResetSheet";
            this.btnResetSheet.Size = new System.Drawing.Size(191, 33);
            this.btnResetSheet.TabIndex = 4;
            this.btnResetSheet.Text = "Changement de feuille";
            this.btnResetSheet.UseVisualStyleBackColor = true;
            this.btnResetSheet.Click += new System.EventHandler(this.btnResetSheet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 558);
            this.Controls.Add(this.btnResetSheet);
            this.Controls.Add(this.btnMaze);
            this.Controls.Add(this.btnTicTacToe);
            this.Controls.Add(this.gbInformations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbInformations.ResumeLayout(false);
            this.gbInformations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbInformations;
        private System.Windows.Forms.Label lblTailleRobotY;
        private System.Windows.Forms.Label lblTailleRobotYText;
        private System.Windows.Forms.Label lblTailleRobotX;
        private System.Windows.Forms.Label tblTailleRobotX;
        private System.Windows.Forms.Button btnTicTacToe;
        private System.Windows.Forms.Button btnMaze;
        private System.Windows.Forms.Button btnResetSheet;
    }
}

