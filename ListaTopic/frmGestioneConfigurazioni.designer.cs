namespace GestioneLuci
{
    partial class frmGestioneConfigurazioni
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtConfigurazione = new System.Windows.Forms.TextBox();
            this.txtValoreLuminosita = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnSalvaConfigurazione = new System.Windows.Forms.Button();
            this.btnImpostaLuminosita = new System.Windows.Forms.Button();
            this.btnAccendi = new System.Windows.Forms.Button();
            this.btnCaricaFileConfigurazione = new System.Windows.Forms.Button();
            this.btnSpegni = new System.Windows.Forms.Button();
            this.lblLuminosita = new System.Windows.Forms.Label();
            this.btnEliminaConfigurazione = new System.Windows.Forms.Button();
            this.trbLuminosita = new System.Windows.Forms.TrackBar();
            this.configurazioniluciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurazioniluciBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtConfigurazione
            // 
            this.txtConfigurazione.Enabled = false;
            this.txtConfigurazione.Location = new System.Drawing.Point(424, 374);
            this.txtConfigurazione.Name = "txtConfigurazione";
            this.txtConfigurazione.Size = new System.Drawing.Size(237, 20);
            this.txtConfigurazione.TabIndex = 49;
            // 
            // txtValoreLuminosita
            // 
            this.txtValoreLuminosita.Location = new System.Drawing.Point(39, 413);
            this.txtValoreLuminosita.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValoreLuminosita.Name = "txtValoreLuminosita";
            this.txtValoreLuminosita.Size = new System.Drawing.Size(124, 20);
            this.txtValoreLuminosita.TabIndex = 48;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 7);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(449, 212);
            this.listBox2.TabIndex = 42;
            // 
            // btnSalvaConfigurazione
            // 
            this.btnSalvaConfigurazione.Location = new System.Drawing.Point(424, 306);
            this.btnSalvaConfigurazione.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalvaConfigurazione.Name = "btnSalvaConfigurazione";
            this.btnSalvaConfigurazione.Size = new System.Drawing.Size(82, 48);
            this.btnSalvaConfigurazione.TabIndex = 45;
            this.btnSalvaConfigurazione.Text = "Salva";
            this.btnSalvaConfigurazione.UseVisualStyleBackColor = true;
            this.btnSalvaConfigurazione.Click += new System.EventHandler(this.btnSalvaConfigurazione_Click);
            // 
            // btnImpostaLuminosita
            // 
            this.btnImpostaLuminosita.Location = new System.Drawing.Point(172, 405);
            this.btnImpostaLuminosita.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImpostaLuminosita.Name = "btnImpostaLuminosita";
            this.btnImpostaLuminosita.Size = new System.Drawing.Size(70, 33);
            this.btnImpostaLuminosita.TabIndex = 44;
            this.btnImpostaLuminosita.Text = "Imposta";
            this.btnImpostaLuminosita.UseVisualStyleBackColor = true;
            this.btnImpostaLuminosita.Click += new System.EventHandler(this.btnImpostaLuminosita_Click);
            // 
            // btnAccendi
            // 
            this.btnAccendi.Enabled = false;
            this.btnAccendi.Location = new System.Drawing.Point(6, 228);
            this.btnAccendi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAccendi.Name = "btnAccendi";
            this.btnAccendi.Size = new System.Drawing.Size(82, 34);
            this.btnAccendi.TabIndex = 40;
            this.btnAccendi.Text = "Accendi";
            this.btnAccendi.UseVisualStyleBackColor = true;
            this.btnAccendi.Click += new System.EventHandler(this.btnAccendi_Click);
            // 
            // btnCaricaFileConfigurazione
            // 
            this.btnCaricaFileConfigurazione.Location = new System.Drawing.Point(510, 305);
            this.btnCaricaFileConfigurazione.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCaricaFileConfigurazione.Name = "btnCaricaFileConfigurazione";
            this.btnCaricaFileConfigurazione.Size = new System.Drawing.Size(82, 48);
            this.btnCaricaFileConfigurazione.TabIndex = 46;
            this.btnCaricaFileConfigurazione.Text = "Carica file";
            this.btnCaricaFileConfigurazione.UseVisualStyleBackColor = true;
            this.btnCaricaFileConfigurazione.Click += new System.EventHandler(this.btnCaricaFileConfigurazione_Click);
            // 
            // btnSpegni
            // 
            this.btnSpegni.Enabled = false;
            this.btnSpegni.Location = new System.Drawing.Point(102, 228);
            this.btnSpegni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSpegni.Name = "btnSpegni";
            this.btnSpegni.Size = new System.Drawing.Size(82, 34);
            this.btnSpegni.TabIndex = 41;
            this.btnSpegni.Text = "Spegni";
            this.btnSpegni.UseVisualStyleBackColor = true;
            this.btnSpegni.Click += new System.EventHandler(this.btnSpegni_Click);
            // 
            // lblLuminosita
            // 
            this.lblLuminosita.AutoSize = true;
            this.lblLuminosita.Location = new System.Drawing.Point(50, 316);
            this.lblLuminosita.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLuminosita.Name = "lblLuminosita";
            this.lblLuminosita.Size = new System.Drawing.Size(29, 13);
            this.lblLuminosita.TabIndex = 43;
            this.lblLuminosita.Text = "lable";
            // 
            // btnEliminaConfigurazione
            // 
            this.btnEliminaConfigurazione.Location = new System.Drawing.Point(596, 305);
            this.btnEliminaConfigurazione.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminaConfigurazione.Name = "btnEliminaConfigurazione";
            this.btnEliminaConfigurazione.Size = new System.Drawing.Size(112, 48);
            this.btnEliminaConfigurazione.TabIndex = 47;
            this.btnEliminaConfigurazione.Text = "Elimina configurazione";
            this.btnEliminaConfigurazione.UseVisualStyleBackColor = true;
            this.btnEliminaConfigurazione.Click += new System.EventHandler(this.btnEliminaConfigurazione_Click);
            // 
            // trbLuminosita
            // 
            this.trbLuminosita.Location = new System.Drawing.Point(23, 353);
            this.trbLuminosita.Maximum = 101;
            this.trbLuminosita.Name = "trbLuminosita";
            this.trbLuminosita.Size = new System.Drawing.Size(278, 45);
            this.trbLuminosita.TabIndex = 50;
            this.trbLuminosita.ValueChanged += new System.EventHandler(this.trbLuminosita_ValueChanged);
            // 
            // configurazioniluciBindingSource
            // 
            this.configurazioniluciBindingSource.DataSource = typeof(GestioneLuci.configurazioni_luci);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmGestioneConfigurazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 552);
            this.Controls.Add(this.txtConfigurazione);
            this.Controls.Add(this.txtValoreLuminosita);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btnSalvaConfigurazione);
            this.Controls.Add(this.btnImpostaLuminosita);
            this.Controls.Add(this.btnAccendi);
            this.Controls.Add(this.btnCaricaFileConfigurazione);
            this.Controls.Add(this.btnSpegni);
            this.Controls.Add(this.lblLuminosita);
            this.Controls.Add(this.btnEliminaConfigurazione);
            this.Controls.Add(this.trbLuminosita);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmGestioneConfigurazioni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione luci";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurazioniluciBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.BindingSource configurazioniluciBindingSource;
        private System.Windows.Forms.TextBox txtConfigurazione;
        private System.Windows.Forms.TextBox txtValoreLuminosita;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnSalvaConfigurazione;
        private System.Windows.Forms.Button btnImpostaLuminosita;
        private System.Windows.Forms.Button btnAccendi;
        private System.Windows.Forms.Button btnCaricaFileConfigurazione;
        private System.Windows.Forms.Button btnSpegni;
        private System.Windows.Forms.Label lblLuminosita;
        private System.Windows.Forms.Button btnEliminaConfigurazione;
        private System.Windows.Forms.TrackBar trbLuminosita;
        private System.Windows.Forms.Timer timer2;
    }
}

