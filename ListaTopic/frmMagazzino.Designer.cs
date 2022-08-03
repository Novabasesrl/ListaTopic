namespace ListaTopic
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPianoSuperiore = new System.Windows.Forms.Button();
            this.btnPianoInferiore = new System.Windows.Forms.Button();
            this.ucLuceLaboratorio = new ListaTopic.ucBottoneLuce();
            this.ucLuceServer = new ListaTopic.ucBottoneLuce();
            this.ucLuceCorridoioMagazzino = new ListaTopic.ucBottoneLuce();
            this.ucLuceBagnoMagazzino = new ListaTopic.ucBottoneLuce();
            this.ucLuceMagazzino = new ListaTopic.ucBottoneLuce();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1729, 1128);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnPianoSuperiore
            // 
            this.btnPianoSuperiore.BackColor = System.Drawing.Color.White;
            this.btnPianoSuperiore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPianoSuperiore.BackgroundImage")));
            this.btnPianoSuperiore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPianoSuperiore.Location = new System.Drawing.Point(1549, 308);
            this.btnPianoSuperiore.Name = "btnPianoSuperiore";
            this.btnPianoSuperiore.Size = new System.Drawing.Size(76, 70);
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
            this.btnPianoInferiore.Location = new System.Drawing.Point(1549, 412);
            this.btnPianoInferiore.Name = "btnPianoInferiore";
            this.btnPianoInferiore.Size = new System.Drawing.Size(76, 70);
            this.btnPianoInferiore.TabIndex = 8;
            this.btnPianoInferiore.UseVisualStyleBackColor = false;
            this.btnPianoInferiore.Click += new System.EventHandler(this.btnPianoInferiore_Click);
            // 
            // ucLuceLaboratorio
            // 
            this.ucLuceLaboratorio.BackColor = System.Drawing.Color.White;
            this.ucLuceLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceLaboratorio.Location = new System.Drawing.Point(298, 412);
            this.ucLuceLaboratorio.Margin = new System.Windows.Forms.Padding(6);
            this.ucLuceLaboratorio.Name = "ucLuceLaboratorio";
            this.ucLuceLaboratorio.Size = new System.Drawing.Size(62, 87);
            this.ucLuceLaboratorio.TabIndex = 6;
            this.ucLuceLaboratorio.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceServer
            // 
            this.ucLuceServer.BackColor = System.Drawing.Color.White;
            this.ucLuceServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceServer.Location = new System.Drawing.Point(805, 273);
            this.ucLuceServer.Margin = new System.Windows.Forms.Padding(6);
            this.ucLuceServer.Name = "ucLuceServer";
            this.ucLuceServer.Size = new System.Drawing.Size(62, 87);
            this.ucLuceServer.TabIndex = 5;
            this.ucLuceServer.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceCorridoioMagazzino
            // 
            this.ucLuceCorridoioMagazzino.BackColor = System.Drawing.Color.White;
            this.ucLuceCorridoioMagazzino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceCorridoioMagazzino.Location = new System.Drawing.Point(1232, 969);
            this.ucLuceCorridoioMagazzino.Margin = new System.Windows.Forms.Padding(6);
            this.ucLuceCorridoioMagazzino.Name = "ucLuceCorridoioMagazzino";
            this.ucLuceCorridoioMagazzino.Size = new System.Drawing.Size(62, 87);
            this.ucLuceCorridoioMagazzino.TabIndex = 4;
            this.ucLuceCorridoioMagazzino.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceBagnoMagazzino
            // 
            this.ucLuceBagnoMagazzino.BackColor = System.Drawing.Color.White;
            this.ucLuceBagnoMagazzino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceBagnoMagazzino.Location = new System.Drawing.Point(1371, 758);
            this.ucLuceBagnoMagazzino.Margin = new System.Windows.Forms.Padding(6);
            this.ucLuceBagnoMagazzino.Name = "ucLuceBagnoMagazzino";
            this.ucLuceBagnoMagazzino.Size = new System.Drawing.Size(62, 87);
            this.ucLuceBagnoMagazzino.TabIndex = 3;
            this.ucLuceBagnoMagazzino.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // ucLuceMagazzino
            // 
            this.ucLuceMagazzino.BackColor = System.Drawing.Color.White;
            this.ucLuceMagazzino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLuceMagazzino.Location = new System.Drawing.Point(311, 918);
            this.ucLuceMagazzino.Margin = new System.Windows.Forms.Padding(6);
            this.ucLuceMagazzino.Name = "ucLuceMagazzino";
            this.ucLuceMagazzino.Size = new System.Drawing.Size(62, 87);
            this.ucLuceMagazzino.TabIndex = 2;
            this.ucLuceMagazzino.Click += new System.EventHandler(this.ucLuceMagazzino_Click);
            // 
            // frmMagazzino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1729, 1128);
            this.Controls.Add(this.btnPianoInferiore);
            this.Controls.Add(this.btnPianoSuperiore);
            this.Controls.Add(this.ucLuceLaboratorio);
            this.Controls.Add(this.ucLuceServer);
            this.Controls.Add(this.ucLuceCorridoioMagazzino);
            this.Controls.Add(this.ucLuceBagnoMagazzino);
            this.Controls.Add(this.ucLuceMagazzino);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMagazzino";
            this.Text = "frmMagazzino";
            this.Load += new System.EventHandler(this.frmMagazzino_Load);
            this.Resize += new System.EventHandler(this.frmMagazzino_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ucBottoneLuce ucLuceMagazzino;
        private ucBottoneLuce ucLuceBagnoMagazzino;
        private ucBottoneLuce ucLuceCorridoioMagazzino;
        private ucBottoneLuce ucLuceServer;
        private ucBottoneLuce ucLuceLaboratorio;
        private System.Windows.Forms.Button btnPianoSuperiore;
        private System.Windows.Forms.Button btnPianoInferiore;
    }
}