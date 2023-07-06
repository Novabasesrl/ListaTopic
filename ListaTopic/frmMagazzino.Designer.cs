namespace GestioneLuci
{
    partial class frmMagazzino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMagazzino));
            this.pbSfondo = new System.Windows.Forms.PictureBox();
            this.btnPianoSuperiore = new System.Windows.Forms.Button();
            this.btnPianoInferiore = new System.Windows.Forms.Button();
            this.ucLuceLaboratorio = new GestioneLuci.ucBottoneLuce();
            this.ucLuceServer = new GestioneLuci.ucBottoneLuce();
            this.ucLuceCorridoioMagazzino = new GestioneLuci.ucBottoneLuce();
            this.ucLuceBagnoMagazzino = new GestioneLuci.ucBottoneLuce();
            this.ucLuceMagazzino = new GestioneLuci.ucBottoneLuce();
            ((System.ComponentModel.ISupportInitialize)(this.pbSfondo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSfondo
            // 
            this.pbSfondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSfondo.BackgroundImage")));
            this.pbSfondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSfondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSfondo.Location = new System.Drawing.Point(0, 0);
            this.pbSfondo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbSfondo.Name = "pbSfondo";
            this.pbSfondo.Size = new System.Drawing.Size(864, 552);
            this.pbSfondo.TabIndex = 1;
            this.pbSfondo.TabStop = false;
            // 
            // btnPianoSuperiore
            // 
            this.btnPianoSuperiore.BackColor = System.Drawing.Color.White;
            this.btnPianoSuperiore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPianoSuperiore.BackgroundImage")));
            this.btnPianoSuperiore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPianoSuperiore.Location = new System.Drawing.Point(774, 214);
            this.btnPianoSuperiore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPianoSuperiore.Name = "btnPianoSuperiore";
            this.btnPianoSuperiore.Size = new System.Drawing.Size(38, 36);
            this.btnPianoSuperiore.TabIndex = 7;
            this.btnPianoSuperiore.UseVisualStyleBackColor = false;
            this.btnPianoSuperiore.Click += new System.EventHandler(this.btnPianoSuperiore_Click);
            // 
            // btnPianoInferiore
            // 
            this.btnPianoInferiore.BackColor = System.Drawing.Color.White;
            this.btnPianoInferiore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPianoInferiore.BackgroundImage")));
            this.btnPianoInferiore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPianoInferiore.Enabled = false;
            this.btnPianoInferiore.Location = new System.Drawing.Point(774, 279);
            this.btnPianoInferiore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPianoInferiore.Name = "btnPianoInferiore";
            this.btnPianoInferiore.Size = new System.Drawing.Size(38, 36);
            this.btnPianoInferiore.TabIndex = 8;
            this.btnPianoInferiore.UseVisualStyleBackColor = false;
            this.btnPianoInferiore.Click += new System.EventHandler(this.btnPianoInferiore_Click);
            // 
            // ucLuceLaboratorio
            // 
            this.ucLuceLaboratorio.BackColor = System.Drawing.Color.White;
            this.ucLuceLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceLaboratorio.Location = new System.Drawing.Point(149, 214);
            this.ucLuceLaboratorio.Name = "ucLuceLaboratorio";
            this.ucLuceLaboratorio.Size = new System.Drawing.Size(32, 46);
            this.ucLuceLaboratorio.TabIndex = 6;
            this.ucLuceLaboratorio.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceServer
            // 
            this.ucLuceServer.BackColor = System.Drawing.Color.White;
            this.ucLuceServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceServer.Location = new System.Drawing.Point(402, 142);
            this.ucLuceServer.Name = "ucLuceServer";
            this.ucLuceServer.Size = new System.Drawing.Size(32, 46);
            this.ucLuceServer.TabIndex = 5;
            this.ucLuceServer.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceCorridoioMagazzino
            // 
            this.ucLuceCorridoioMagazzino.BackColor = System.Drawing.Color.White;
            this.ucLuceCorridoioMagazzino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceCorridoioMagazzino.Location = new System.Drawing.Point(616, 504);
            this.ucLuceCorridoioMagazzino.Name = "ucLuceCorridoioMagazzino";
            this.ucLuceCorridoioMagazzino.Size = new System.Drawing.Size(32, 46);
            this.ucLuceCorridoioMagazzino.TabIndex = 4;
            this.ucLuceCorridoioMagazzino.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceBagnoMagazzino
            // 
            this.ucLuceBagnoMagazzino.BackColor = System.Drawing.Color.White;
            this.ucLuceBagnoMagazzino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceBagnoMagazzino.Location = new System.Drawing.Point(686, 394);
            this.ucLuceBagnoMagazzino.Name = "ucLuceBagnoMagazzino";
            this.ucLuceBagnoMagazzino.Size = new System.Drawing.Size(32, 46);
            this.ucLuceBagnoMagazzino.TabIndex = 3;
            this.ucLuceBagnoMagazzino.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceMagazzino
            // 
            this.ucLuceMagazzino.BackColor = System.Drawing.Color.White;
            this.ucLuceMagazzino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceMagazzino.Location = new System.Drawing.Point(156, 477);
            this.ucLuceMagazzino.Name = "ucLuceMagazzino";
            this.ucLuceMagazzino.Size = new System.Drawing.Size(32, 46);
            this.ucLuceMagazzino.TabIndex = 2;
            this.ucLuceMagazzino.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // frmMagazzino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 552);
            this.Controls.Add(this.btnPianoInferiore);
            this.Controls.Add(this.btnPianoSuperiore);
            this.Controls.Add(this.ucLuceLaboratorio);
            this.Controls.Add(this.ucLuceServer);
            this.Controls.Add(this.ucLuceCorridoioMagazzino);
            this.Controls.Add(this.ucLuceBagnoMagazzino);
            this.Controls.Add(this.ucLuceMagazzino);
            this.Controls.Add(this.pbSfondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMagazzino";
            this.Text = "Magazzino";
            this.Load += new System.EventHandler(this.frmMagazzino_Load);
            this.Resize += new System.EventHandler(this.frmMagazzino_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbSfondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSfondo;
        private ucBottoneLuce ucLuceMagazzino;
        private ucBottoneLuce ucLuceBagnoMagazzino;
        private ucBottoneLuce ucLuceCorridoioMagazzino;
        private ucBottoneLuce ucLuceServer;
        private ucBottoneLuce ucLuceLaboratorio;
        private System.Windows.Forms.Button btnPianoSuperiore;
        private System.Windows.Forms.Button btnPianoInferiore;
    }
}