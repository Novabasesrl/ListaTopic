namespace ListaTopic
{
    partial class frmComandi
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
            this.components = new System.ComponentModel.Container();
            this.btnAccendiReception = new System.Windows.Forms.Button();
            this.btnSpegniSecondoPiano = new System.Windows.Forms.Button();
            this.btnSpegniReception = new System.Windows.Forms.Button();
            this.btnSpegniSalaRiunione = new System.Windows.Forms.Button();
            this.btnAccendiTutto = new System.Windows.Forms.Button();
            this.trbImpostaLuminositaTutto = new System.Windows.Forms.TrackBar();
            this.btnAccendiSalaRiunione = new System.Windows.Forms.Button();
            this.btnAccendiUffici = new System.Windows.Forms.Button();
            this.txtImpostaValoreTutteLuci = new System.Windows.Forms.TextBox();
            this.btnImpostaValoreTrb = new System.Windows.Forms.Button();
            this.btnSpegniMgazzino = new System.Windows.Forms.Button();
            this.btnSpegniUffici = new System.Windows.Forms.Button();
            this.btnSpegniTutto = new System.Windows.Forms.Button();
            this.btnAccendiSecondoPiano = new System.Windows.Forms.Button();
            this.btnAccendiTuttoLuminosita = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccendiMagazzino = new System.Windows.Forms.Button();
            this.btnDuplica = new System.Windows.Forms.Button();
            this.btnApplica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnNuovo = new System.Windows.Forms.Button();
            this.btnSovrascrivi = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnCarica = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.gcConfigurazioni = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.trbImpostaLuminositaTutto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccendiReception
            // 
            this.btnAccendiReception.Location = new System.Drawing.Point(260, 378);
            this.btnAccendiReception.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiReception.Name = "btnAccendiReception";
            this.btnAccendiReception.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiReception.TabIndex = 36;
            this.btnAccendiReception.Text = "Accendi solo reception";
            this.btnAccendiReception.UseVisualStyleBackColor = true;
            this.btnAccendiReception.Click += new System.EventHandler(this.btnAccendiReception_Click);
            // 
            // btnSpegniSecondoPiano
            // 
            this.btnSpegniSecondoPiano.Location = new System.Drawing.Point(260, 228);
            this.btnSpegniSecondoPiano.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniSecondoPiano.Name = "btnSpegniSecondoPiano";
            this.btnSpegniSecondoPiano.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniSecondoPiano.TabIndex = 32;
            this.btnSpegniSecondoPiano.Text = "Spegni 2\' piano";
            this.btnSpegniSecondoPiano.UseVisualStyleBackColor = true;
            this.btnSpegniSecondoPiano.Click += new System.EventHandler(this.btnSpegniSecondoPiano_Click);
            // 
            // btnSpegniReception
            // 
            this.btnSpegniReception.Location = new System.Drawing.Point(260, 528);
            this.btnSpegniReception.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniReception.Name = "btnSpegniReception";
            this.btnSpegniReception.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniReception.TabIndex = 39;
            this.btnSpegniReception.Text = "Spegni solo reception";
            this.btnSpegniReception.UseVisualStyleBackColor = true;
            this.btnSpegniReception.Click += new System.EventHandler(this.btnSpegniReception_Click);
            // 
            // btnSpegniSalaRiunione
            // 
            this.btnSpegniSalaRiunione.Location = new System.Drawing.Point(58, 528);
            this.btnSpegniSalaRiunione.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniSalaRiunione.Name = "btnSpegniSalaRiunione";
            this.btnSpegniSalaRiunione.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniSalaRiunione.TabIndex = 38;
            this.btnSpegniSalaRiunione.Text = "Spegni solo sala riunione";
            this.btnSpegniSalaRiunione.UseVisualStyleBackColor = true;
            this.btnSpegniSalaRiunione.Click += new System.EventHandler(this.btnSpegniSalaRiunione_Click);
            // 
            // btnAccendiTutto
            // 
            this.btnAccendiTutto.Location = new System.Drawing.Point(58, 78);
            this.btnAccendiTutto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiTutto.Name = "btnAccendiTutto";
            this.btnAccendiTutto.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiTutto.TabIndex = 29;
            this.btnAccendiTutto.Text = "Accendi tutto";
            this.btnAccendiTutto.UseVisualStyleBackColor = true;
            this.btnAccendiTutto.Click += new System.EventHandler(this.btnAccendiTutto_Click);
            // 
            // trbImpostaLuminositaTutto
            // 
            this.trbImpostaLuminositaTutto.Location = new System.Drawing.Point(62, 938);
            this.trbImpostaLuminositaTutto.Margin = new System.Windows.Forms.Padding(4);
            this.trbImpostaLuminositaTutto.Maximum = 101;
            this.trbImpostaLuminositaTutto.Name = "trbImpostaLuminositaTutto";
            this.trbImpostaLuminositaTutto.Size = new System.Drawing.Size(534, 90);
            this.trbImpostaLuminositaTutto.TabIndex = 28;
            this.trbImpostaLuminositaTutto.Value = 101;
            this.trbImpostaLuminositaTutto.ValueChanged += new System.EventHandler(this.trbImpostaLuminositaTutto_ValueChanged);
            // 
            // btnAccendiSalaRiunione
            // 
            this.btnAccendiSalaRiunione.Location = new System.Drawing.Point(58, 378);
            this.btnAccendiSalaRiunione.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiSalaRiunione.Name = "btnAccendiSalaRiunione";
            this.btnAccendiSalaRiunione.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiSalaRiunione.TabIndex = 35;
            this.btnAccendiSalaRiunione.Text = "Accendi solo sala riunione";
            this.btnAccendiSalaRiunione.UseVisualStyleBackColor = true;
            this.btnAccendiSalaRiunione.Click += new System.EventHandler(this.btnAccendiSalaRiunione_Click);
            // 
            // btnAccendiUffici
            // 
            this.btnAccendiUffici.Location = new System.Drawing.Point(456, 378);
            this.btnAccendiUffici.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiUffici.Name = "btnAccendiUffici";
            this.btnAccendiUffici.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiUffici.TabIndex = 37;
            this.btnAccendiUffici.Text = "Accendi solo uffici";
            this.btnAccendiUffici.UseVisualStyleBackColor = true;
            this.btnAccendiUffici.Click += new System.EventHandler(this.btnAccendiUffici_Click);
            // 
            // txtImpostaValoreTutteLuci
            // 
            this.txtImpostaValoreTutteLuci.Location = new System.Drawing.Point(98, 1084);
            this.txtImpostaValoreTutteLuci.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpostaValoreTutteLuci.Name = "txtImpostaValoreTutteLuci";
            this.txtImpostaValoreTutteLuci.Size = new System.Drawing.Size(244, 31);
            this.txtImpostaValoreTutteLuci.TabIndex = 42;
            // 
            // btnImpostaValoreTrb
            // 
            this.btnImpostaValoreTrb.Location = new System.Drawing.Point(368, 1055);
            this.btnImpostaValoreTrb.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpostaValoreTrb.Name = "btnImpostaValoreTrb";
            this.btnImpostaValoreTrb.Size = new System.Drawing.Size(140, 58);
            this.btnImpostaValoreTrb.TabIndex = 44;
            this.btnImpostaValoreTrb.Text = "Imposta";
            this.btnImpostaValoreTrb.UseVisualStyleBackColor = true;
            this.btnImpostaValoreTrb.Click += new System.EventHandler(this.btnImpostaValoreTrb_Click);
            // 
            // btnSpegniMgazzino
            // 
            this.btnSpegniMgazzino.Location = new System.Drawing.Point(456, 228);
            this.btnSpegniMgazzino.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniMgazzino.Name = "btnSpegniMgazzino";
            this.btnSpegniMgazzino.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniMgazzino.TabIndex = 33;
            this.btnSpegniMgazzino.Text = "Spegni magazzino";
            this.btnSpegniMgazzino.UseVisualStyleBackColor = true;
            this.btnSpegniMgazzino.Click += new System.EventHandler(this.btnSpegniMgazzino_Click);
            // 
            // btnSpegniUffici
            // 
            this.btnSpegniUffici.Location = new System.Drawing.Point(456, 528);
            this.btnSpegniUffici.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniUffici.Name = "btnSpegniUffici";
            this.btnSpegniUffici.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniUffici.TabIndex = 40;
            this.btnSpegniUffici.Text = "Spegni solo uffici";
            this.btnSpegniUffici.UseVisualStyleBackColor = true;
            this.btnSpegniUffici.Click += new System.EventHandler(this.btnSpegniUffici_Click);
            // 
            // btnSpegniTutto
            // 
            this.btnSpegniTutto.Location = new System.Drawing.Point(58, 228);
            this.btnSpegniTutto.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniTutto.Name = "btnSpegniTutto";
            this.btnSpegniTutto.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniTutto.TabIndex = 31;
            this.btnSpegniTutto.Text = "Spegni tutto";
            this.btnSpegniTutto.UseVisualStyleBackColor = true;
            this.btnSpegniTutto.Click += new System.EventHandler(this.btnSpegniTutto_Click);
            // 
            // btnAccendiSecondoPiano
            // 
            this.btnAccendiSecondoPiano.Location = new System.Drawing.Point(260, 78);
            this.btnAccendiSecondoPiano.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiSecondoPiano.Name = "btnAccendiSecondoPiano";
            this.btnAccendiSecondoPiano.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiSecondoPiano.TabIndex = 30;
            this.btnAccendiSecondoPiano.Text = "Accendi 2\' piano";
            this.btnAccendiSecondoPiano.UseVisualStyleBackColor = true;
            this.btnAccendiSecondoPiano.Click += new System.EventHandler(this.btnAccendiSecondoPiano_Click);
            // 
            // btnAccendiTuttoLuminosita
            // 
            this.btnAccendiTuttoLuminosita.Location = new System.Drawing.Point(214, 792);
            this.btnAccendiTuttoLuminosita.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiTuttoLuminosita.Name = "btnAccendiTuttoLuminosita";
            this.btnAccendiTuttoLuminosita.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiTuttoLuminosita.TabIndex = 41;
            this.btnAccendiTuttoLuminosita.Text = "Accendi tutto secondo piano";
            this.btnAccendiTuttoLuminosita.UseVisualStyleBackColor = true;
            this.btnAccendiTuttoLuminosita.Click += new System.EventHandler(this.btnAccendiTuttoLuminosita_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 898);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 43;
            this.label1.Text = "lable";
            // 
            // btnAccendiMagazzino
            // 
            this.btnAccendiMagazzino.Location = new System.Drawing.Point(456, 78);
            this.btnAccendiMagazzino.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiMagazzino.Name = "btnAccendiMagazzino";
            this.btnAccendiMagazzino.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiMagazzino.TabIndex = 34;
            this.btnAccendiMagazzino.Text = "Accendi magazzino";
            this.btnAccendiMagazzino.UseVisualStyleBackColor = true;
            this.btnAccendiMagazzino.Click += new System.EventHandler(this.btnAccendiMagazzino_Click);
            // 
            // btnDuplica
            // 
            this.btnDuplica.Location = new System.Drawing.Point(1453, 794);
            this.btnDuplica.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuplica.Name = "btnDuplica";
            this.btnDuplica.Size = new System.Drawing.Size(140, 63);
            this.btnDuplica.TabIndex = 51;
            this.btnDuplica.Text = "Duplica";
            this.btnDuplica.UseVisualStyleBackColor = true;
            this.btnDuplica.Click += new System.EventHandler(this.btnDuplica_Click);
            // 
            // btnApplica
            // 
            this.btnApplica.Location = new System.Drawing.Point(1453, 702);
            this.btnApplica.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(140, 63);
            this.btnApplica.TabIndex = 50;
            this.btnApplica.Text = "Applica";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(1453, 603);
            this.btnElimina.Margin = new System.Windows.Forms.Padding(4);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(140, 72);
            this.btnElimina.TabIndex = 49;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnNuovo
            // 
            this.btnNuovo.Location = new System.Drawing.Point(1453, 415);
            this.btnNuovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuovo.Name = "btnNuovo";
            this.btnNuovo.Size = new System.Drawing.Size(140, 63);
            this.btnNuovo.TabIndex = 48;
            this.btnNuovo.Text = "Nuovo";
            this.btnNuovo.UseVisualStyleBackColor = true;
            this.btnNuovo.Click += new System.EventHandler(this.btnNuovo_Click);
            // 
            // btnSovrascrivi
            // 
            this.btnSovrascrivi.Location = new System.Drawing.Point(1453, 505);
            this.btnSovrascrivi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSovrascrivi.Name = "btnSovrascrivi";
            this.btnSovrascrivi.Size = new System.Drawing.Size(140, 63);
            this.btnSovrascrivi.TabIndex = 47;
            this.btnSovrascrivi.Text = "Sovrascrivi";
            this.btnSovrascrivi.UseVisualStyleBackColor = true;
            this.btnSovrascrivi.Click += new System.EventHandler(this.btnSovrascrivi_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(1467, 13);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(140, 63);
            this.btnSalva.TabIndex = 46;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnCarica
            // 
            this.btnCarica.Location = new System.Drawing.Point(1303, 13);
            this.btnCarica.Margin = new System.Windows.Forms.Padding(4);
            this.btnCarica.Name = "btnCarica";
            this.btnCarica.Size = new System.Drawing.Size(140, 63);
            this.btnCarica.TabIndex = 45;
            this.btnCarica.Text = "Carica";
            this.btnCarica.UseVisualStyleBackColor = true;
            this.btnCarica.Click += new System.EventHandler(this.btnCarica_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // gcConfigurazioni
            // 
            // 
            // 
            // 
            this.gcConfigurazioni.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gcConfigurazioni.Location = new System.Drawing.Point(100, 100);
            this.gcConfigurazioni.MainView = this.gridView1;
            this.gcConfigurazioni.Margin = new System.Windows.Forms.Padding(6);
            this.gcConfigurazioni.Name = "gcConfigurazioni";
            this.gcConfigurazioni.Size = new System.Drawing.Size(1230, 385);
            this.gcConfigurazioni.TabIndex = 38;
            this.gcConfigurazioni.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcConfigurazioni;
            this.gridView1.Name = "gridView1";
            // 
            // frmComandi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1625, 1164);
            this.Controls.Add(this.btnDuplica);
            this.Controls.Add(this.btnApplica);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnNuovo);
            this.Controls.Add(this.btnSovrascrivi);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnCarica);
            this.Controls.Add(this.btnAccendiReception);
            this.Controls.Add(this.btnSpegniSecondoPiano);
            this.Controls.Add(this.btnSpegniReception);
            this.Controls.Add(this.btnSpegniSalaRiunione);
            this.Controls.Add(this.btnAccendiTutto);
            this.Controls.Add(this.trbImpostaLuminositaTutto);
            this.Controls.Add(this.btnAccendiSalaRiunione);
            this.Controls.Add(this.btnAccendiUffici);
            this.Controls.Add(this.txtImpostaValoreTutteLuci);
            this.Controls.Add(this.btnImpostaValoreTrb);
            this.Controls.Add(this.btnSpegniMgazzino);
            this.Controls.Add(this.btnSpegniUffici);
            this.Controls.Add(this.btnSpegniTutto);
            this.Controls.Add(this.btnAccendiSecondoPiano);
            this.Controls.Add(this.btnAccendiTuttoLuminosita);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccendiMagazzino);
            this.Name = "frmComandi";
            this.Text = "Comandi luci";
            this.Load += new System.EventHandler(this.frmComandi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbImpostaLuminositaTutto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccendiReception;
        private System.Windows.Forms.Button btnSpegniSecondoPiano;
        private System.Windows.Forms.Button btnSpegniReception;
        private System.Windows.Forms.Button btnSpegniSalaRiunione;
        private System.Windows.Forms.Button btnAccendiTutto;
        private System.Windows.Forms.TrackBar trbImpostaLuminositaTutto;
        private System.Windows.Forms.Button btnAccendiSalaRiunione;
        private System.Windows.Forms.Button btnAccendiUffici;
        private System.Windows.Forms.TextBox txtImpostaValoreTutteLuci;
        private System.Windows.Forms.Button btnImpostaValoreTrb;
        private System.Windows.Forms.Button btnSpegniMgazzino;
        private System.Windows.Forms.Button btnSpegniUffici;
        private System.Windows.Forms.Button btnSpegniTutto;
        private System.Windows.Forms.Button btnAccendiSecondoPiano;
        private System.Windows.Forms.Button btnAccendiTuttoLuminosita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccendiMagazzino;
        private System.Windows.Forms.Button btnDuplica;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnNuovo;
        private System.Windows.Forms.Button btnSovrascrivi;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCarica;
        private System.Windows.Forms.Timer timer3;
        private DevExpress.XtraGrid.GridControl gcConfigurazioni;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}