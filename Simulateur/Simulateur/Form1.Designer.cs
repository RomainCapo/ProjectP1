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
            this.components = new System.ComponentModel.Container();
            this.gbInformations = new System.Windows.Forms.GroupBox();
            this.cbxUseBluetooth = new System.Windows.Forms.CheckBox();
            this.btnCursorDown = new System.Windows.Forms.Button();
            this.lblSizeState = new System.Windows.Forms.Label();
            this.btnCursorUp = new System.Windows.Forms.Button();
            this.btnAppliquer = new System.Windows.Forms.Button();
            this.lblMmY = new System.Windows.Forms.Label();
            this.lblMmX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lblBluetooth = new System.Windows.Forms.Label();
            this.lblEtiquetteBluetooth = new System.Windows.Forms.Label();
            this.btnTicTacToe = new System.Windows.Forms.Button();
            this.btnMaze = new System.Windows.Forms.Button();
            this.gbGames = new System.Windows.Forms.GroupBox();
            this.btnDames = new System.Windows.Forms.Button();
            this.originalImageBox = new Emgu.CV.UI.ImageBox();
            this.detectionImageBox = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelInfoDectionImage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fluxImageBox = new Emgu.CV.UI.ImageBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.gbInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.gbGames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectionImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluxImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInformations
            // 
            this.gbInformations.Controls.Add(this.cbxUseBluetooth);
            this.gbInformations.Controls.Add(this.btnCursorDown);
            this.gbInformations.Controls.Add(this.lblSizeState);
            this.gbInformations.Controls.Add(this.btnCursorUp);
            this.gbInformations.Controls.Add(this.btnAppliquer);
            this.gbInformations.Controls.Add(this.lblMmY);
            this.gbInformations.Controls.Add(this.lblMmX);
            this.gbInformations.Controls.Add(this.lblY);
            this.gbInformations.Controls.Add(this.numY);
            this.gbInformations.Controls.Add(this.lblX);
            this.gbInformations.Controls.Add(this.numX);
            this.gbInformations.Controls.Add(this.lblBluetooth);
            this.gbInformations.Controls.Add(this.lblEtiquetteBluetooth);
            this.gbInformations.Location = new System.Drawing.Point(12, 12);
            this.gbInformations.Name = "gbInformations";
            this.gbInformations.Size = new System.Drawing.Size(200, 297);
            this.gbInformations.TabIndex = 1;
            this.gbInformations.TabStop = false;
            this.gbInformations.Text = "Informations";
            // 
            // cbxUseBluetooth
            // 
            this.cbxUseBluetooth.AutoSize = true;
            this.cbxUseBluetooth.Checked = true;
            this.cbxUseBluetooth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUseBluetooth.Location = new System.Drawing.Point(12, 69);
            this.cbxUseBluetooth.Name = "cbxUseBluetooth";
            this.cbxUseBluetooth.Size = new System.Drawing.Size(137, 21);
            this.cbxUseBluetooth.TabIndex = 14;
            this.cbxUseBluetooth.Text = "Utiliser Bluetooth";
            this.cbxUseBluetooth.UseVisualStyleBackColor = true;
            // 
            // btnCursorDown
            // 
            this.btnCursorDown.Location = new System.Drawing.Point(12, 248);
            this.btnCursorDown.Name = "btnCursorDown";
            this.btnCursorDown.Size = new System.Drawing.Size(112, 33);
            this.btnCursorDown.TabIndex = 5;
            this.btnCursorDown.Text = "Curseur bas";
            this.btnCursorDown.UseVisualStyleBackColor = true;
            this.btnCursorDown.Click += new System.EventHandler(this.btnCursorDown_Click);
            // 
            // lblSizeState
            // 
            this.lblSizeState.AutoSize = true;
            this.lblSizeState.Location = new System.Drawing.Point(113, 174);
            this.lblSizeState.Name = "lblSizeState";
            this.lblSizeState.Size = new System.Drawing.Size(0, 17);
            this.lblSizeState.TabIndex = 13;
            // 
            // btnCursorUp
            // 
            this.btnCursorUp.Location = new System.Drawing.Point(12, 209);
            this.btnCursorUp.Name = "btnCursorUp";
            this.btnCursorUp.Size = new System.Drawing.Size(112, 33);
            this.btnCursorUp.TabIndex = 4;
            this.btnCursorUp.Text = "Curseur haut";
            this.btnCursorUp.UseVisualStyleBackColor = true;
            this.btnCursorUp.Click += new System.EventHandler(this.btnCursorUp_Click);
            // 
            // btnAppliquer
            // 
            this.btnAppliquer.Location = new System.Drawing.Point(12, 168);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.Size = new System.Drawing.Size(94, 24);
            this.btnAppliquer.TabIndex = 12;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.UseVisualStyleBackColor = true;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // lblMmY
            // 
            this.lblMmY.AutoSize = true;
            this.lblMmY.Location = new System.Drawing.Point(143, 138);
            this.lblMmY.Name = "lblMmY";
            this.lblMmY.Size = new System.Drawing.Size(30, 17);
            this.lblMmY.TabIndex = 11;
            this.lblMmY.Text = "mm";
            // 
            // lblMmX
            // 
            this.lblMmX.AutoSize = true;
            this.lblMmX.Location = new System.Drawing.Point(143, 105);
            this.lblMmX.Name = "lblMmX";
            this.lblMmX.Size = new System.Drawing.Size(30, 17);
            this.lblMmX.TabIndex = 10;
            this.lblMmX.Text = "mm";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(9, 138);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(63, 17);
            this.lblY.TabIndex = 9;
            this.lblY.Text = "Taille Y :";
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(78, 136);
            this.numY.Maximum = new decimal(new int[] {
            388,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(59, 22);
            this.numY.TabIndex = 8;
            this.numY.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(9, 105);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(63, 17);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "Taille X :";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(78, 103);
            this.numX.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(59, 22);
            this.numX.TabIndex = 6;
            this.numX.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // lblBluetooth
            // 
            this.lblBluetooth.AutoSize = true;
            this.lblBluetooth.Location = new System.Drawing.Point(9, 39);
            this.lblBluetooth.Name = "lblBluetooth";
            this.lblBluetooth.Size = new System.Drawing.Size(97, 17);
            this.lblBluetooth.TabIndex = 5;
            this.lblBluetooth.Text = "Non-connecté";
            // 
            // lblEtiquetteBluetooth
            // 
            this.lblEtiquetteBluetooth.AutoSize = true;
            this.lblEtiquetteBluetooth.Location = new System.Drawing.Point(9, 22);
            this.lblEtiquetteBluetooth.Name = "lblEtiquetteBluetooth";
            this.lblEtiquetteBluetooth.Size = new System.Drawing.Size(120, 17);
            this.lblEtiquetteBluetooth.TabIndex = 4;
            this.lblEtiquetteBluetooth.Text = "Status Bluetooth :";
            // 
            // btnTicTacToe
            // 
            this.btnTicTacToe.Location = new System.Drawing.Point(6, 21);
            this.btnTicTacToe.Name = "btnTicTacToe";
            this.btnTicTacToe.Size = new System.Drawing.Size(93, 33);
            this.btnTicTacToe.TabIndex = 2;
            this.btnTicTacToe.Text = "Morpion";
            this.btnTicTacToe.UseVisualStyleBackColor = true;
            this.btnTicTacToe.Click += new System.EventHandler(this.btnTicTacToe_Click);
            // 
            // btnMaze
            // 
            this.btnMaze.Location = new System.Drawing.Point(6, 60);
            this.btnMaze.Name = "btnMaze";
            this.btnMaze.Size = new System.Drawing.Size(93, 33);
            this.btnMaze.TabIndex = 3;
            this.btnMaze.Text = "Labyrinthe";
            this.btnMaze.UseVisualStyleBackColor = true;
            this.btnMaze.Click += new System.EventHandler(this.btnMaze_Click);
            // 
            // gbGames
            // 
            this.gbGames.Controls.Add(this.btnDames);
            this.gbGames.Controls.Add(this.btnTicTacToe);
            this.gbGames.Controls.Add(this.btnMaze);
            this.gbGames.Location = new System.Drawing.Point(12, 315);
            this.gbGames.Name = "gbGames";
            this.gbGames.Size = new System.Drawing.Size(200, 140);
            this.gbGames.TabIndex = 4;
            this.gbGames.TabStop = false;
            this.gbGames.Text = "Jeux";
            // 
            // btnDames
            // 
            this.btnDames.Location = new System.Drawing.Point(6, 99);
            this.btnDames.Name = "btnDames";
            this.btnDames.Size = new System.Drawing.Size(93, 33);
            this.btnDames.TabIndex = 4;
            this.btnDames.Text = "Dames";
            this.btnDames.UseVisualStyleBackColor = true;
            this.btnDames.Click += new System.EventHandler(this.btnDames_Click);
            // 
            // originalImageBox
            // 
            this.originalImageBox.BackColor = System.Drawing.SystemColors.Control;
            this.originalImageBox.Location = new System.Drawing.Point(19, 360);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(510, 263);
            this.originalImageBox.TabIndex = 2;
            this.originalImageBox.TabStop = false;
            // 
            // detectionImageBox
            // 
            this.detectionImageBox.BackColor = System.Drawing.SystemColors.Control;
            this.detectionImageBox.Location = new System.Drawing.Point(19, 655);
            this.detectionImageBox.Name = "detectionImageBox";
            this.detectionImageBox.Size = new System.Drawing.Size(510, 263);
            this.detectionImageBox.TabIndex = 5;
            this.detectionImageBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrintScreen);
            this.groupBox1.Controls.Add(this.labelInfoDectionImage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fluxImageBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.originalImageBox);
            this.groupBox1.Controls.Add(this.detectionImageBox);
            this.groupBox1.Location = new System.Drawing.Point(1376, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 1026);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detection Image";
            // 
            // labelInfoDectionImage
            // 
            this.labelInfoDectionImage.AutoSize = true;
            this.labelInfoDectionImage.Location = new System.Drawing.Point(22, 964);
            this.labelInfoDectionImage.Name = "labelInfoDectionImage";
            this.labelInfoDectionImage.Size = new System.Drawing.Size(46, 17);
            this.labelInfoDectionImage.TabIndex = 9;
            this.labelInfoDectionImage.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 933);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Donnée percue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 635);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Detection des formes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Image recu";
            // 
            // fluxImageBox
            // 
            this.fluxImageBox.Location = new System.Drawing.Point(19, 59);
            this.fluxImageBox.Name = "fluxImageBox";
            this.fluxImageBox.Size = new System.Drawing.Size(510, 263);
            this.fluxImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fluxImageBox.TabIndex = 2;
            this.fluxImageBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Flux en directe";
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.Location = new System.Drawing.Point(268, 933);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(227, 48);
            this.btnPrintScreen.TabIndex = 7;
            this.btnPrintScreen.Text = "Print Screen";
            this.btnPrintScreen.UseVisualStyleBackColor = true;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrintScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1892, 1092);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbGames);
            this.Controls.Add(this.gbInformations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbInformations.ResumeLayout(false);
            this.gbInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.gbGames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectionImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluxImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbInformations;
        private System.Windows.Forms.Button btnTicTacToe;
        private System.Windows.Forms.Button btnMaze;
        private System.Windows.Forms.Label lblEtiquetteBluetooth;
        private System.Windows.Forms.Label lblBluetooth;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Button btnAppliquer;
        private System.Windows.Forms.Label lblMmY;
        private System.Windows.Forms.Label lblMmX;
        private System.Windows.Forms.Label lblSizeState;
        private System.Windows.Forms.Button btnCursorUp;
        private System.Windows.Forms.Button btnCursorDown;
        private System.Windows.Forms.CheckBox cbxUseBluetooth;
        private System.Windows.Forms.GroupBox gbGames;
        private System.Windows.Forms.Button btnDames;
        private Emgu.CV.UI.ImageBox originalImageBox;
        private Emgu.CV.UI.ImageBox detectionImageBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfoDectionImage;
        private System.Windows.Forms.Label label3;
        private Emgu.CV.UI.ImageBox fluxImageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrintScreen;
    }
}

