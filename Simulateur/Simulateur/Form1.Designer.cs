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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.originalImageBox = new Emgu.CV.UI.ImageBox();
            this.detectionImageBox = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.labelInfoDectionImage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fluxImageBox = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerUpdateScreen = new System.Windows.Forms.Timer(this.components);
            this.gbInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
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
            this.gbInformations.Location = new System.Drawing.Point(14, 15);
            this.gbInformations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbInformations.Name = "gbInformations";
            this.gbInformations.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbInformations.Size = new System.Drawing.Size(225, 371);
            this.gbInformations.TabIndex = 1;
            this.gbInformations.TabStop = false;
            this.gbInformations.Text = "Informations";
            // 
            // cbxUseBluetooth
            // 
            this.cbxUseBluetooth.AutoSize = true;
            this.cbxUseBluetooth.Checked = true;
            this.cbxUseBluetooth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUseBluetooth.Location = new System.Drawing.Point(14, 86);
            this.cbxUseBluetooth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxUseBluetooth.Name = "cbxUseBluetooth";
            this.cbxUseBluetooth.Size = new System.Drawing.Size(156, 24);
            this.cbxUseBluetooth.TabIndex = 14;
            this.cbxUseBluetooth.Text = "Utiliser Bluetooth";
            this.cbxUseBluetooth.UseVisualStyleBackColor = true;
            // 
            // btnCursorDown
            // 
            this.btnCursorDown.Location = new System.Drawing.Point(14, 310);
            this.btnCursorDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCursorDown.Name = "btnCursorDown";
            this.btnCursorDown.Size = new System.Drawing.Size(126, 41);
            this.btnCursorDown.TabIndex = 5;
            this.btnCursorDown.Text = "Curseur bas";
            this.btnCursorDown.UseVisualStyleBackColor = true;
            this.btnCursorDown.Click += new System.EventHandler(this.btnCursorDown_Click);
            // 
            // lblSizeState
            // 
            this.lblSizeState.AutoSize = true;
            this.lblSizeState.Location = new System.Drawing.Point(127, 218);
            this.lblSizeState.Name = "lblSizeState";
            this.lblSizeState.Size = new System.Drawing.Size(0, 20);
            this.lblSizeState.TabIndex = 13;
            // 
            // btnCursorUp
            // 
            this.btnCursorUp.Location = new System.Drawing.Point(14, 261);
            this.btnCursorUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCursorUp.Name = "btnCursorUp";
            this.btnCursorUp.Size = new System.Drawing.Size(126, 41);
            this.btnCursorUp.TabIndex = 4;
            this.btnCursorUp.Text = "Curseur haut";
            this.btnCursorUp.UseVisualStyleBackColor = true;
            this.btnCursorUp.Click += new System.EventHandler(this.btnCursorUp_Click);
            // 
            // btnAppliquer
            // 
            this.btnAppliquer.Location = new System.Drawing.Point(14, 210);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.Size = new System.Drawing.Size(106, 30);
            this.btnAppliquer.TabIndex = 12;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.UseVisualStyleBackColor = true;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // lblMmY
            // 
            this.lblMmY.AutoSize = true;
            this.lblMmY.Location = new System.Drawing.Point(161, 172);
            this.lblMmY.Name = "lblMmY";
            this.lblMmY.Size = new System.Drawing.Size(35, 20);
            this.lblMmY.TabIndex = 11;
            this.lblMmY.Text = "mm";
            // 
            // lblMmX
            // 
            this.lblMmX.AutoSize = true;
            this.lblMmX.Location = new System.Drawing.Point(161, 131);
            this.lblMmX.Name = "lblMmX";
            this.lblMmX.Size = new System.Drawing.Size(35, 20);
            this.lblMmX.TabIndex = 10;
            this.lblMmX.Text = "mm";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(10, 172);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(68, 20);
            this.lblY.TabIndex = 9;
            this.lblY.Text = "Taille Y :";
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(88, 170);
            this.numY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.numY.Size = new System.Drawing.Size(66, 26);
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
            this.lblX.Location = new System.Drawing.Point(10, 131);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(68, 20);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "Taille X :";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(88, 129);
            this.numX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.numX.Size = new System.Drawing.Size(66, 26);
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
            this.lblBluetooth.Location = new System.Drawing.Point(10, 49);
            this.lblBluetooth.Name = "lblBluetooth";
            this.lblBluetooth.Size = new System.Drawing.Size(109, 20);
            this.lblBluetooth.TabIndex = 5;
            this.lblBluetooth.Text = "Non-connecté";
            // 
            // lblEtiquetteBluetooth
            // 
            this.lblEtiquetteBluetooth.AutoSize = true;
            this.lblEtiquetteBluetooth.Location = new System.Drawing.Point(10, 28);
            this.lblEtiquetteBluetooth.Name = "lblEtiquetteBluetooth";
            this.lblEtiquetteBluetooth.Size = new System.Drawing.Size(137, 20);
            this.lblEtiquetteBluetooth.TabIndex = 4;
            this.lblEtiquetteBluetooth.Text = "Status Bluetooth :";
            // 
            // originalImageBox
            // 
            this.originalImageBox.BackColor = System.Drawing.SystemColors.Control;
            this.originalImageBox.Location = new System.Drawing.Point(431, 74);
            this.originalImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(384, 216);
            this.originalImageBox.TabIndex = 2;
            this.originalImageBox.TabStop = false;
            // 
            // detectionImageBox
            // 
            this.detectionImageBox.BackColor = System.Drawing.SystemColors.Control;
            this.detectionImageBox.Location = new System.Drawing.Point(843, 75);
            this.detectionImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.detectionImageBox.Name = "detectionImageBox";
            this.detectionImageBox.Size = new System.Drawing.Size(384, 216);
            this.detectionImageBox.TabIndex = 5;
            this.detectionImageBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelInfoDectionImage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fluxImageBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.originalImageBox);
            this.groupBox1.Controls.Add(this.detectionImageBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 661);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1241, 313);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detection Image";
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrintScreen.Location = new System.Drawing.Point(994, 604);
            this.btnPrintScreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(255, 60);
            this.btnPrintScreen.TabIndex = 7;
            this.btnPrintScreen.Text = "Print Screen";
            this.btnPrintScreen.UseVisualStyleBackColor = false;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrintScreen_Click);
            // 
            // labelInfoDectionImage
            // 
            this.labelInfoDectionImage.AutoSize = true;
            this.labelInfoDectionImage.Location = new System.Drawing.Point(25, 1205);
            this.labelInfoDectionImage.Name = "labelInfoDectionImage";
            this.labelInfoDectionImage.Size = new System.Drawing.Size(18, 20);
            this.labelInfoDectionImage.TabIndex = 9;
            this.labelInfoDectionImage.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Flux en directe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 1166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Donnée percue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(840, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Detection des formes";
            // 
            // fluxImageBox
            // 
            this.fluxImageBox.Location = new System.Drawing.Point(21, 74);
            this.fluxImageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fluxImageBox.Name = "fluxImageBox";
            this.fluxImageBox.Size = new System.Drawing.Size(384, 216);
            this.fluxImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fluxImageBox.TabIndex = 2;
            this.fluxImageBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Image recu";
            // 
            // timerUpdateScreen
            // 
            this.timerUpdateScreen.Interval = 1000;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.btnPrintScreen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbInformations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Jeu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbInformations.ResumeLayout(false);
            this.gbInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectionImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluxImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbInformations;
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
        private System.Windows.Forms.Timer timerUpdateScreen;
    }
}

