namespace WindowsFormsApp1
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
            this.pnlSurface = new System.Windows.Forms.Panel();
            this.pnlAxeX = new System.Windows.Forms.Panel();
            this.pnlAxeY = new System.Windows.Forms.Panel();
            this.cbxCommand = new System.Windows.Forms.ComboBox();
            this.tbxPosX = new System.Windows.Forms.TextBox();
            this.tbxPosY = new System.Windows.Forms.TextBox();
            this.btnLauchCommand = new System.Windows.Forms.Button();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.tbxVitesse = new System.Windows.Forms.TextBox();
            this.btnVitesse = new System.Windows.Forms.Button();
            this.timerVitesse = new System.Windows.Forms.Timer(this.components);
            this.pnlSurface.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSurface
            // 
            this.pnlSurface.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlSurface.Controls.Add(this.pnlAxeX);
            this.pnlSurface.Controls.Add(this.pnlAxeY);
            this.pnlSurface.Location = new System.Drawing.Point(58, 44);
            this.pnlSurface.Name = "pnlSurface";
            this.pnlSurface.Size = new System.Drawing.Size(320, 388);
            this.pnlSurface.TabIndex = 0;
            // 
            // pnlAxeX
            // 
            this.pnlAxeX.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlAxeX.Location = new System.Drawing.Point(124, 66);
            this.pnlAxeX.Name = "pnlAxeX";
            this.pnlAxeX.Size = new System.Drawing.Size(13, 53);
            this.pnlAxeX.TabIndex = 0;
            // 
            // pnlAxeY
            // 
            this.pnlAxeY.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlAxeY.Location = new System.Drawing.Point(0, 84);
            this.pnlAxeY.Name = "pnlAxeY";
            this.pnlAxeY.Size = new System.Drawing.Size(320, 13);
            this.pnlAxeY.TabIndex = 0;
            // 
            // cbxCommand
            // 
            this.cbxCommand.FormattingEnabled = true;
            this.cbxCommand.Items.AddRange(new object[] {
            "Initialisation du robot",
            "Position",
            "Feutre en position haute",
            "Feutre en position basse",
            "Retour position départ"});
            this.cbxCommand.Location = new System.Drawing.Point(58, 472);
            this.cbxCommand.Name = "cbxCommand";
            this.cbxCommand.Size = new System.Drawing.Size(175, 21);
            this.cbxCommand.TabIndex = 1;
            this.cbxCommand.SelectedIndexChanged += new System.EventHandler(this.cbxCommand_SelectedIndexChanged);
            // 
            // tbxPosX
            // 
            this.tbxPosX.Enabled = false;
            this.tbxPosX.Location = new System.Drawing.Point(274, 473);
            this.tbxPosX.Name = "tbxPosX";
            this.tbxPosX.Size = new System.Drawing.Size(49, 20);
            this.tbxPosX.TabIndex = 2;
            // 
            // tbxPosY
            // 
            this.tbxPosY.Enabled = false;
            this.tbxPosY.Location = new System.Drawing.Point(329, 473);
            this.tbxPosY.Name = "tbxPosY";
            this.tbxPosY.Size = new System.Drawing.Size(49, 20);
            this.tbxPosY.TabIndex = 3;
            // 
            // btnLauchCommand
            // 
            this.btnLauchCommand.Location = new System.Drawing.Point(58, 510);
            this.btnLauchCommand.Name = "btnLauchCommand";
            this.btnLauchCommand.Size = new System.Drawing.Size(320, 41);
            this.btnLauchCommand.TabIndex = 4;
            this.btnLauchCommand.Text = "Lauch Command";
            this.btnLauchCommand.UseVisualStyleBackColor = true;
            this.btnLauchCommand.Click += new System.EventHandler(this.btnLauchCommand_Click);
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(55, 575);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(50, 13);
            this.lblVitesse.TabIndex = 5;
            this.lblVitesse.Text = "Vitesse : ";
            // 
            // tbxVitesse
            // 
            this.tbxVitesse.Location = new System.Drawing.Point(95, 572);
            this.tbxVitesse.Name = "tbxVitesse";
            this.tbxVitesse.Size = new System.Drawing.Size(100, 20);
            this.tbxVitesse.TabIndex = 6;
            // 
            // btnVitesse
            // 
            this.btnVitesse.Location = new System.Drawing.Point(201, 570);
            this.btnVitesse.Name = "btnVitesse";
            this.btnVitesse.Size = new System.Drawing.Size(177, 23);
            this.btnVitesse.TabIndex = 7;
            this.btnVitesse.Text = "Set Vitesse";
            this.btnVitesse.UseVisualStyleBackColor = true;
            this.btnVitesse.Click += new System.EventHandler(this.btnVitesse_Click);
            // 
            // timerVitesse
            // 
            this.timerVitesse.Tick += new System.EventHandler(this.timerVitesse_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 600);
            this.Controls.Add(this.btnVitesse);
            this.Controls.Add(this.tbxVitesse);
            this.Controls.Add(this.lblVitesse);
            this.Controls.Add(this.btnLauchCommand);
            this.Controls.Add(this.tbxPosY);
            this.Controls.Add(this.tbxPosX);
            this.Controls.Add(this.cbxCommand);
            this.Controls.Add(this.pnlSurface);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulateur";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.pnlSurface.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSurface;
        private System.Windows.Forms.ComboBox cbxCommand;
        private System.Windows.Forms.TextBox tbxPosX;
        private System.Windows.Forms.TextBox tbxPosY;
        private System.Windows.Forms.Button btnLauchCommand;
        private System.Windows.Forms.Panel pnlAxeY;
        private System.Windows.Forms.Panel pnlAxeX;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.TextBox tbxVitesse;
        private System.Windows.Forms.Button btnVitesse;
        private System.Windows.Forms.Timer timerVitesse;
    }
}

