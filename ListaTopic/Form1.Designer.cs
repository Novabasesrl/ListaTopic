namespace ListaTopic
{
    partial class Form1
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
            this.btnAccendi = new System.Windows.Forms.Button();
            this.btnSpegni = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lblLuminosita = new System.Windows.Forms.Label();
            this.btnImpostaLuminosita = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAccendiTutto = new System.Windows.Forms.Button();
            this.btnAccendiSecondoPiano = new System.Windows.Forms.Button();
            this.btnSpegniSecondoPiano = new System.Windows.Forms.Button();
            this.btnSpegniTutto = new System.Windows.Forms.Button();
            this.btnAccendiMagazzino = new System.Windows.Forms.Button();
            this.btnSpegniMgazzino = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnAccendiUffici = new System.Windows.Forms.Button();
            this.btnAccendiReception = new System.Windows.Forms.Button();
            this.btnAccendiSalaRiunione = new System.Windows.Forms.Button();
            this.btnSpegniUffici = new System.Windows.Forms.Button();
            this.btnSpegniReception = new System.Windows.Forms.Button();
            this.btnSpegniSalaRiunione = new System.Windows.Forms.Button();
            this.btnAccendiTuttoLuminosita = new System.Windows.Forms.Button();
            this.btnImpostaValoreTrb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImpostaValoreTutteLuci = new System.Windows.Forms.TextBox();
            this.trbImpostaLuminositaTutto = new System.Windows.Forms.TrackBar();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnEliminaConfigurazione = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.txtValoreLuminosita = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.gcConfigurazioni = new DevExpress.XtraGrid.GridControl();
            this.configurazioniluciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvConfigurazioni = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtConfigurazione = new System.Windows.Forms.TextBox();
            this.btnApplica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnNuovo = new System.Windows.Forms.Button();
            this.btnSovrascrivi = new System.Windows.Forms.Button();
            this.trbLuminosita = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDuplica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trbImpostaLuminositaTutto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurazioniluciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccendi
            // 
            this.btnAccendi.Location = new System.Drawing.Point(58, 454);
            this.btnAccendi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendi.Name = "btnAccendi";
            this.btnAccendi.Size = new System.Drawing.Size(164, 65);
            this.btnAccendi.TabIndex = 1;
            this.btnAccendi.Text = "Accendi";
            this.btnAccendi.UseVisualStyleBackColor = true;
            this.btnAccendi.Click += new System.EventHandler(this.btnAccendi_Click);
            // 
            // btnSpegni
            // 
            this.btnSpegni.Location = new System.Drawing.Point(246, 454);
            this.btnSpegni.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegni.Name = "btnSpegni";
            this.btnSpegni.Size = new System.Drawing.Size(164, 65);
            this.btnSpegni.TabIndex = 2;
            this.btnSpegni.Text = "Spegni";
            this.btnSpegni.UseVisualStyleBackColor = true;
            this.btnSpegni.Click += new System.EventHandler(this.btnSpegni_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(58, 29);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(894, 404);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // lblLuminosita
            // 
            this.lblLuminosita.AutoSize = true;
            this.lblLuminosita.Location = new System.Drawing.Point(145, 623);
            this.lblLuminosita.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLuminosita.Name = "lblLuminosita";
            this.lblLuminosita.Size = new System.Drawing.Size(58, 25);
            this.lblLuminosita.TabIndex = 6;
            this.lblLuminosita.Text = "lable";
            // 
            // btnImpostaLuminosita
            // 
            this.btnImpostaLuminosita.Location = new System.Drawing.Point(390, 794);
            this.btnImpostaLuminosita.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpostaLuminosita.Name = "btnImpostaLuminosita";
            this.btnImpostaLuminosita.Size = new System.Drawing.Size(140, 63);
            this.btnImpostaLuminosita.TabIndex = 7;
            this.btnImpostaLuminosita.Text = "Imposta";
            this.btnImpostaLuminosita.UseVisualStyleBackColor = true;
            this.btnImpostaLuminosita.Click += new System.EventHandler(this.btnImpostaLuminosita_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAccendiTutto
            // 
            this.btnAccendiTutto.Location = new System.Drawing.Point(1054, 29);
            this.btnAccendiTutto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiTutto.Name = "btnAccendiTutto";
            this.btnAccendiTutto.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiTutto.TabIndex = 8;
            this.btnAccendiTutto.Text = "Accendi tutto";
            this.btnAccendiTutto.UseVisualStyleBackColor = true;
            this.btnAccendiTutto.Click += new System.EventHandler(this.btnAccendiTutto_Click);
            // 
            // btnAccendiSecondoPiano
            // 
            this.btnAccendiSecondoPiano.Location = new System.Drawing.Point(1256, 29);
            this.btnAccendiSecondoPiano.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiSecondoPiano.Name = "btnAccendiSecondoPiano";
            this.btnAccendiSecondoPiano.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiSecondoPiano.TabIndex = 9;
            this.btnAccendiSecondoPiano.Text = "Accendi 2\' piano";
            this.btnAccendiSecondoPiano.UseVisualStyleBackColor = true;
            this.btnAccendiSecondoPiano.Click += new System.EventHandler(this.btnAccendiSecondoPiano_Click);
            // 
            // btnSpegniSecondoPiano
            // 
            this.btnSpegniSecondoPiano.Location = new System.Drawing.Point(1256, 179);
            this.btnSpegniSecondoPiano.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniSecondoPiano.Name = "btnSpegniSecondoPiano";
            this.btnSpegniSecondoPiano.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniSecondoPiano.TabIndex = 11;
            this.btnSpegniSecondoPiano.Text = "Spegni 2\' piano";
            this.btnSpegniSecondoPiano.UseVisualStyleBackColor = true;
            this.btnSpegniSecondoPiano.Click += new System.EventHandler(this.btnSpegniSecondoPiano_Click);
            // 
            // btnSpegniTutto
            // 
            this.btnSpegniTutto.Location = new System.Drawing.Point(1054, 179);
            this.btnSpegniTutto.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniTutto.Name = "btnSpegniTutto";
            this.btnSpegniTutto.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniTutto.TabIndex = 10;
            this.btnSpegniTutto.Text = "Spegni tutto";
            this.btnSpegniTutto.UseVisualStyleBackColor = true;
            this.btnSpegniTutto.Click += new System.EventHandler(this.btnSpegniTutto_Click);
            // 
            // btnAccendiMagazzino
            // 
            this.btnAccendiMagazzino.Location = new System.Drawing.Point(1452, 29);
            this.btnAccendiMagazzino.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiMagazzino.Name = "btnAccendiMagazzino";
            this.btnAccendiMagazzino.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiMagazzino.TabIndex = 13;
            this.btnAccendiMagazzino.Text = "Accendi magazzino";
            this.btnAccendiMagazzino.UseVisualStyleBackColor = true;
            this.btnAccendiMagazzino.Click += new System.EventHandler(this.btnAccendiMagazzino_Click);
            // 
            // btnSpegniMgazzino
            // 
            this.btnSpegniMgazzino.Location = new System.Drawing.Point(1452, 179);
            this.btnSpegniMgazzino.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniMgazzino.Name = "btnSpegniMgazzino";
            this.btnSpegniMgazzino.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniMgazzino.TabIndex = 12;
            this.btnSpegniMgazzino.Text = "Spegni magazzino";
            this.btnSpegniMgazzino.UseVisualStyleBackColor = true;
            this.btnSpegniMgazzino.Click += new System.EventHandler(this.btnSpegniMgazzino_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnAccendiUffici
            // 
            this.btnAccendiUffici.Location = new System.Drawing.Point(1452, 329);
            this.btnAccendiUffici.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiUffici.Name = "btnAccendiUffici";
            this.btnAccendiUffici.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiUffici.TabIndex = 19;
            this.btnAccendiUffici.Text = "Accendi solo uffici";
            this.btnAccendiUffici.UseVisualStyleBackColor = true;
            this.btnAccendiUffici.Click += new System.EventHandler(this.btnAccendiUffici_Click);
            // 
            // btnAccendiReception
            // 
            this.btnAccendiReception.Location = new System.Drawing.Point(1256, 329);
            this.btnAccendiReception.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiReception.Name = "btnAccendiReception";
            this.btnAccendiReception.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiReception.TabIndex = 18;
            this.btnAccendiReception.Text = "Accendi solo reception";
            this.btnAccendiReception.UseVisualStyleBackColor = true;
            this.btnAccendiReception.Click += new System.EventHandler(this.btnAccendiReception_Click);
            // 
            // btnAccendiSalaRiunione
            // 
            this.btnAccendiSalaRiunione.Location = new System.Drawing.Point(1054, 329);
            this.btnAccendiSalaRiunione.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiSalaRiunione.Name = "btnAccendiSalaRiunione";
            this.btnAccendiSalaRiunione.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiSalaRiunione.TabIndex = 17;
            this.btnAccendiSalaRiunione.Text = "Accendi solo sala riunione";
            this.btnAccendiSalaRiunione.UseVisualStyleBackColor = true;
            this.btnAccendiSalaRiunione.Click += new System.EventHandler(this.btnAccendiSalaRiunione_Click);
            // 
            // btnSpegniUffici
            // 
            this.btnSpegniUffici.Location = new System.Drawing.Point(1452, 479);
            this.btnSpegniUffici.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniUffici.Name = "btnSpegniUffici";
            this.btnSpegniUffici.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniUffici.TabIndex = 22;
            this.btnSpegniUffici.Text = "Spegni solo uffici";
            this.btnSpegniUffici.UseVisualStyleBackColor = true;
            this.btnSpegniUffici.Click += new System.EventHandler(this.btnSpegniUffici_Click);
            // 
            // btnSpegniReception
            // 
            this.btnSpegniReception.Location = new System.Drawing.Point(1256, 479);
            this.btnSpegniReception.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniReception.Name = "btnSpegniReception";
            this.btnSpegniReception.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniReception.TabIndex = 21;
            this.btnSpegniReception.Text = "Spegni solo reception";
            this.btnSpegniReception.UseVisualStyleBackColor = true;
            this.btnSpegniReception.Click += new System.EventHandler(this.btnSpegniReception_Click);
            // 
            // btnSpegniSalaRiunione
            // 
            this.btnSpegniSalaRiunione.Location = new System.Drawing.Point(1054, 479);
            this.btnSpegniSalaRiunione.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpegniSalaRiunione.Name = "btnSpegniSalaRiunione";
            this.btnSpegniSalaRiunione.Size = new System.Drawing.Size(164, 65);
            this.btnSpegniSalaRiunione.TabIndex = 20;
            this.btnSpegniSalaRiunione.Text = "Spegni solo sala riunione";
            this.btnSpegniSalaRiunione.UseVisualStyleBackColor = true;
            this.btnSpegniSalaRiunione.Click += new System.EventHandler(this.btnSpegniSalaRiunione_Click);
            // 
            // btnAccendiTuttoLuminosita
            // 
            this.btnAccendiTuttoLuminosita.Location = new System.Drawing.Point(1264, 654);
            this.btnAccendiTuttoLuminosita.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccendiTuttoLuminosita.Name = "btnAccendiTuttoLuminosita";
            this.btnAccendiTuttoLuminosita.Size = new System.Drawing.Size(164, 65);
            this.btnAccendiTuttoLuminosita.TabIndex = 23;
            this.btnAccendiTuttoLuminosita.Text = "Accendi tutto secondo piano";
            this.btnAccendiTuttoLuminosita.UseVisualStyleBackColor = true;
            this.btnAccendiTuttoLuminosita.Click += new System.EventHandler(this.btnAccendiTuttoLuminosita_Click);
            // 
            // btnImpostaValoreTrb
            // 
            this.btnImpostaValoreTrb.Location = new System.Drawing.Point(1418, 917);
            this.btnImpostaValoreTrb.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpostaValoreTrb.Name = "btnImpostaValoreTrb";
            this.btnImpostaValoreTrb.Size = new System.Drawing.Size(140, 58);
            this.btnImpostaValoreTrb.TabIndex = 27;
            this.btnImpostaValoreTrb.Text = "Imposta";
            this.btnImpostaValoreTrb.UseVisualStyleBackColor = true;
            this.btnImpostaValoreTrb.Click += new System.EventHandler(this.btnImpostaValoreTrb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1154, 760);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "lable";
            // 
            // txtImpostaValoreTutteLuci
            // 
            this.txtImpostaValoreTutteLuci.Location = new System.Drawing.Point(1148, 946);
            this.txtImpostaValoreTutteLuci.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpostaValoreTutteLuci.Name = "txtImpostaValoreTutteLuci";
            this.txtImpostaValoreTutteLuci.Size = new System.Drawing.Size(244, 31);
            this.txtImpostaValoreTutteLuci.TabIndex = 25;
            // 
            // trbImpostaLuminositaTutto
            // 
            this.trbImpostaLuminositaTutto.Location = new System.Drawing.Point(1112, 800);
            this.trbImpostaLuminositaTutto.Margin = new System.Windows.Forms.Padding(4);
            this.trbImpostaLuminositaTutto.Maximum = 101;
            this.trbImpostaLuminositaTutto.Name = "trbImpostaLuminositaTutto";
            this.trbImpostaLuminositaTutto.Size = new System.Drawing.Size(534, 90);
            this.trbImpostaLuminositaTutto.TabIndex = 4;
            this.trbImpostaLuminositaTutto.Value = 101;
            this.trbImpostaLuminositaTutto.ValueChanged += new System.EventHandler(this.trbImpostaLuminositaTutto_ValueChanged);
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 917);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 92);
            this.button1.TabIndex = 30;
            this.button1.Text = "Salva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(263, 915);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 92);
            this.button2.TabIndex = 31;
            this.button2.Text = "Carica file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnEliminaConfigurazione
            // 
            this.btnEliminaConfigurazione.Location = new System.Drawing.Point(641, 917);
            this.btnEliminaConfigurazione.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminaConfigurazione.Name = "btnEliminaConfigurazione";
            this.btnEliminaConfigurazione.Size = new System.Drawing.Size(224, 92);
            this.btnEliminaConfigurazione.TabIndex = 32;
            this.btnEliminaConfigurazione.Text = "Elimina configurazione";
            this.btnEliminaConfigurazione.UseVisualStyleBackColor = true;
            this.btnEliminaConfigurazione.Click += new System.EventHandler(this.btnEliminaConfigurazione_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(42, 21);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 63);
            this.button3.TabIndex = 36;
            this.button3.Text = "carica";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtValoreLuminosita
            // 
            this.txtValoreLuminosita.Location = new System.Drawing.Point(123, 810);
            this.txtValoreLuminosita.Margin = new System.Windows.Forms.Padding(4);
            this.txtValoreLuminosita.Name = "txtValoreLuminosita";
            this.txtValoreLuminosita.Size = new System.Drawing.Size(244, 31);
            this.txtValoreLuminosita.TabIndex = 37;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(206, 21);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 63);
            this.button4.TabIndex = 39;
            this.button4.Text = "salva";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // gcConfigurazioni
            // 
            this.gcConfigurazioni.DataSource = this.configurazioniluciBindingSource;
            // 
            // 
            // 
            this.gcConfigurazioni.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gcConfigurazioni.Location = new System.Drawing.Point(100, 100);
            this.gcConfigurazioni.MainView = this.gvConfigurazioni;
            this.gcConfigurazioni.Margin = new System.Windows.Forms.Padding(6);
            this.gcConfigurazioni.Name = "gcConfigurazioni";
            this.gcConfigurazioni.Size = new System.Drawing.Size(1230, 385);
            this.gcConfigurazioni.TabIndex = 38;
            this.gcConfigurazioni.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConfigurazioni});
            this.gcConfigurazioni.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // configurazioniluciBindingSource
            // 
            this.configurazioniluciBindingSource.DataSource = typeof(ListaTopic.configurazioni_luci);
            // 
            // gvConfigurazioni
            // 
            this.gvConfigurazioni.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colNome,
            this.colJson});
            this.gvConfigurazioni.GridControl = this.gcConfigurazioni;
            this.gvConfigurazioni.Name = "gvConfigurazioni";
            this.gvConfigurazioni.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConfigurazioni.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConfigurazioni.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.gvConfigurazioni.OptionsMenu.EnableFooterMenu = false;
            this.gvConfigurazioni.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gvConfigurazioni.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvConfigurazioni.OptionsView.RowAutoHeight = true;
            this.gvConfigurazioni.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvConfigurazioni.OptionsView.ShowFooter = true;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 0;
            // 
            // colJson
            // 
            this.colJson.FieldName = "Json";
            this.colJson.Name = "colJson";
            this.colJson.Visible = true;
            this.colJson.VisibleIndex = 1;
            // 
            // txtConfigurazione
            // 
            this.txtConfigurazione.Enabled = false;
            this.txtConfigurazione.Location = new System.Drawing.Point(91, 1049);
            this.txtConfigurazione.Margin = new System.Windows.Forms.Padding(6);
            this.txtConfigurazione.Name = "txtConfigurazione";
            this.txtConfigurazione.Size = new System.Drawing.Size(470, 31);
            this.txtConfigurazione.TabIndex = 38;
            // 
            // btnApplica
            // 
            this.btnApplica.Location = new System.Drawing.Point(1614, 308);
            this.btnApplica.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(140, 63);
            this.btnApplica.TabIndex = 43;
            this.btnApplica.Text = "Applica";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(1614, 209);
            this.btnElimina.Margin = new System.Windows.Forms.Padding(4);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(140, 72);
            this.btnElimina.TabIndex = 42;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnNuovo
            // 
            this.btnNuovo.Location = new System.Drawing.Point(1614, 21);
            this.btnNuovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuovo.Name = "btnNuovo";
            this.btnNuovo.Size = new System.Drawing.Size(140, 63);
            this.btnNuovo.TabIndex = 41;
            this.btnNuovo.Text = "Nuovo";
            this.btnNuovo.UseVisualStyleBackColor = true;
            this.btnNuovo.Click += new System.EventHandler(this.btnNuovo_Click);
            // 
            // btnSovrascrivi
            // 
            this.btnSovrascrivi.Location = new System.Drawing.Point(1614, 111);
            this.btnSovrascrivi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSovrascrivi.Name = "btnSovrascrivi";
            this.btnSovrascrivi.Size = new System.Drawing.Size(140, 63);
            this.btnSovrascrivi.TabIndex = 40;
            this.btnSovrascrivi.Text = "Sovrascrivi";
            this.btnSovrascrivi.UseVisualStyleBackColor = true;
            this.btnSovrascrivi.Click += new System.EventHandler(this.btnSovrascrivi_Click);
            // 
            // trbLuminosita
            // 
            this.trbLuminosita.Location = new System.Drawing.Point(91, 694);
            this.trbLuminosita.Margin = new System.Windows.Forms.Padding(6);
            this.trbLuminosita.Maximum = 101;
            this.trbLuminosita.Name = "trbLuminosita";
            this.trbLuminosita.Size = new System.Drawing.Size(828, 90);
            this.trbLuminosita.TabIndex = 39;
            this.trbLuminosita.ValueChanged += new System.EventHandler(this.trbLuminosita_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2740, 1171);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.txtConfigurazione);
            this.tabPage1.Controls.Add(this.txtValoreLuminosita);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.btnAccendiReception);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnSpegniSecondoPiano);
            this.tabPage1.Controls.Add(this.btnImpostaLuminosita);
            this.tabPage1.Controls.Add(this.btnSpegniReception);
            this.tabPage1.Controls.Add(this.btnAccendi);
            this.tabPage1.Controls.Add(this.btnSpegniSalaRiunione);
            this.tabPage1.Controls.Add(this.btnAccendiTutto);
            this.tabPage1.Controls.Add(this.trbImpostaLuminositaTutto);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btnSpegni);
            this.tabPage1.Controls.Add(this.btnAccendiSalaRiunione);
            this.tabPage1.Controls.Add(this.lblLuminosita);
            this.tabPage1.Controls.Add(this.btnAccendiUffici);
            this.tabPage1.Controls.Add(this.txtImpostaValoreTutteLuci);
            this.tabPage1.Controls.Add(this.btnImpostaValoreTrb);
            this.tabPage1.Controls.Add(this.btnSpegniMgazzino);
            this.tabPage1.Controls.Add(this.btnSpegniUffici);
            this.tabPage1.Controls.Add(this.btnSpegniTutto);
            this.tabPage1.Controls.Add(this.btnAccendiSecondoPiano);
            this.tabPage1.Controls.Add(this.btnAccendiTuttoLuminosita);
            this.tabPage1.Controls.Add(this.btnEliminaConfigurazione);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.trbLuminosita);
            this.tabPage1.Controls.Add(this.btnAccendiMagazzino);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2724, 1124);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gestione luci";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1708, 1018);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(202, 92);
            this.button5.TabIndex = 40;
            this.button5.Text = "Vai alla mappa";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDuplica);
            this.tabPage2.Controls.Add(this.gcConfigurazioni);
            this.tabPage2.Controls.Add(this.btnApplica);
            this.tabPage2.Controls.Add(this.btnElimina);
            this.tabPage2.Controls.Add(this.btnNuovo);
            this.tabPage2.Controls.Add(this.btnSovrascrivi);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2724, 1124);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sql";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDuplica
            // 
            this.btnDuplica.Location = new System.Drawing.Point(1614, 400);
            this.btnDuplica.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuplica.Name = "btnDuplica";
            this.btnDuplica.Size = new System.Drawing.Size(140, 63);
            this.btnDuplica.TabIndex = 44;
            this.btnDuplica.Text = "Duplica";
            this.btnDuplica.UseVisualStyleBackColor = true;
            this.btnDuplica.Click += new System.EventHandler(this.btnDuplica_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2740, 1171);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione luci";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbImpostaLuminositaTutto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurazioniluciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAccendi;
        private System.Windows.Forms.Button btnSpegni;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label lblLuminosita;
        private System.Windows.Forms.Button btnImpostaLuminosita;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAccendiTutto;
        private System.Windows.Forms.Button btnAccendiSecondoPiano;
        private System.Windows.Forms.Button btnSpegniSecondoPiano;
        private System.Windows.Forms.Button btnSpegniTutto;
        private System.Windows.Forms.Button btnAccendiMagazzino;
        private System.Windows.Forms.Button btnSpegniMgazzino;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnAccendiUffici;
        private System.Windows.Forms.Button btnAccendiReception;
        private System.Windows.Forms.Button btnAccendiSalaRiunione;
        private System.Windows.Forms.Button btnSpegniUffici;
        private System.Windows.Forms.Button btnSpegniReception;
        private System.Windows.Forms.Button btnSpegniSalaRiunione;
        private System.Windows.Forms.Button btnAccendiTuttoLuminosita;
        private System.Windows.Forms.Button btnImpostaValoreTrb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImpostaValoreTutteLuci;
        private System.Windows.Forms.TrackBar trbImpostaLuminositaTutto;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEliminaConfigurazione;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource configurazioniluciBindingSource;
        private DevExpress.XtraGrid.GridControl gcConfigurazioni;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConfigurazioni;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colJson;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtValoreLuminosita;
        private System.Windows.Forms.TextBox txtConfigurazione;
        private System.Windows.Forms.TrackBar trbLuminosita;
        private System.Windows.Forms.Button btnNuovo;
        private System.Windows.Forms.Button btnSovrascrivi;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDuplica;
        private System.Windows.Forms.Button button5;
    }
}

