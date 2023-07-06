namespace GestioneLuci
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
            this.btnAccendiSalaRiunione = new System.Windows.Forms.Button();
            this.btnAccendiUffici = new System.Windows.Forms.Button();
            this.btnSpegniMgazzino = new System.Windows.Forms.Button();
            this.btnSpegniUffici = new System.Windows.Forms.Button();
            this.btnSpegniTutto = new System.Windows.Forms.Button();
            this.btnAccendiSecondoPiano = new System.Windows.Forms.Button();
            this.btnAccendiMagazzino = new System.Windows.Forms.Button();
            this.btnDuplica = new System.Windows.Forms.Button();
            this.btnApplica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnNuovo = new System.Windows.Forms.Button();
            this.btnSovrascrivi = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.gcConfigurazioni = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configurazioniluciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gcConfigurazioniLuci = new DevExpress.XtraGrid.GridControl();
            this.gvConfigurazioni = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJson = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurazioniluciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioniLuci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurazioni)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccendiReception
            // 
            this.btnAccendiReception.Location = new System.Drawing.Point(19, 164);
            this.btnAccendiReception.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccendiReception.Name = "btnAccendiReception";
            this.btnAccendiReception.Size = new System.Drawing.Size(107, 34);
            this.btnAccendiReception.TabIndex = 36;
            this.btnAccendiReception.Text = "Accendi solo reception";
            this.btnAccendiReception.UseVisualStyleBackColor = true;
            this.btnAccendiReception.Click += new System.EventHandler(this.btnAccendiReception_Click);
            // 
            // btnSpegniSecondoPiano
            // 
            this.btnSpegniSecondoPiano.Location = new System.Drawing.Point(130, 50);
            this.btnSpegniSecondoPiano.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpegniSecondoPiano.Name = "btnSpegniSecondoPiano";
            this.btnSpegniSecondoPiano.Size = new System.Drawing.Size(107, 34);
            this.btnSpegniSecondoPiano.TabIndex = 32;
            this.btnSpegniSecondoPiano.Text = "Spegni 2\' piano";
            this.btnSpegniSecondoPiano.UseVisualStyleBackColor = true;
            this.btnSpegniSecondoPiano.Click += new System.EventHandler(this.btnSpegniSecondoPiano_Click);
            // 
            // btnSpegniReception
            // 
            this.btnSpegniReception.Location = new System.Drawing.Point(130, 164);
            this.btnSpegniReception.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpegniReception.Name = "btnSpegniReception";
            this.btnSpegniReception.Size = new System.Drawing.Size(107, 34);
            this.btnSpegniReception.TabIndex = 39;
            this.btnSpegniReception.Text = "Spegni solo reception";
            this.btnSpegniReception.UseVisualStyleBackColor = true;
            this.btnSpegniReception.Click += new System.EventHandler(this.btnSpegniReception_Click);
            // 
            // btnSpegniSalaRiunione
            // 
            this.btnSpegniSalaRiunione.Location = new System.Drawing.Point(130, 126);
            this.btnSpegniSalaRiunione.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpegniSalaRiunione.Name = "btnSpegniSalaRiunione";
            this.btnSpegniSalaRiunione.Size = new System.Drawing.Size(107, 34);
            this.btnSpegniSalaRiunione.TabIndex = 38;
            this.btnSpegniSalaRiunione.Text = "Spegni solo sala riunione";
            this.btnSpegniSalaRiunione.UseVisualStyleBackColor = true;
            this.btnSpegniSalaRiunione.Click += new System.EventHandler(this.btnSpegniSalaRiunione_Click);
            // 
            // btnAccendiTutto
            // 
            this.btnAccendiTutto.Location = new System.Drawing.Point(19, 12);
            this.btnAccendiTutto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccendiTutto.Name = "btnAccendiTutto";
            this.btnAccendiTutto.Size = new System.Drawing.Size(107, 34);
            this.btnAccendiTutto.TabIndex = 29;
            this.btnAccendiTutto.Text = "Accendi tutto";
            this.btnAccendiTutto.UseVisualStyleBackColor = true;
            this.btnAccendiTutto.Click += new System.EventHandler(this.btnAccendiTutto_Click);
            // 
            // btnAccendiSalaRiunione
            // 
            this.btnAccendiSalaRiunione.Location = new System.Drawing.Point(19, 126);
            this.btnAccendiSalaRiunione.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccendiSalaRiunione.Name = "btnAccendiSalaRiunione";
            this.btnAccendiSalaRiunione.Size = new System.Drawing.Size(107, 34);
            this.btnAccendiSalaRiunione.TabIndex = 35;
            this.btnAccendiSalaRiunione.Text = "Accendi solo sala riunione";
            this.btnAccendiSalaRiunione.UseVisualStyleBackColor = true;
            this.btnAccendiSalaRiunione.Click += new System.EventHandler(this.btnAccendiSalaRiunione_Click);
            // 
            // btnAccendiUffici
            // 
            this.btnAccendiUffici.Location = new System.Drawing.Point(19, 202);
            this.btnAccendiUffici.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccendiUffici.Name = "btnAccendiUffici";
            this.btnAccendiUffici.Size = new System.Drawing.Size(107, 34);
            this.btnAccendiUffici.TabIndex = 37;
            this.btnAccendiUffici.Text = "Accendi solo uffici";
            this.btnAccendiUffici.UseVisualStyleBackColor = true;
            this.btnAccendiUffici.Click += new System.EventHandler(this.btnAccendiUffici_Click);
            // 
            // btnSpegniMgazzino
            // 
            this.btnSpegniMgazzino.Location = new System.Drawing.Point(130, 88);
            this.btnSpegniMgazzino.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpegniMgazzino.Name = "btnSpegniMgazzino";
            this.btnSpegniMgazzino.Size = new System.Drawing.Size(107, 34);
            this.btnSpegniMgazzino.TabIndex = 33;
            this.btnSpegniMgazzino.Text = "Spegni magazzino";
            this.btnSpegniMgazzino.UseVisualStyleBackColor = true;
            this.btnSpegniMgazzino.Click += new System.EventHandler(this.btnSpegniMgazzino_Click);
            // 
            // btnSpegniUffici
            // 
            this.btnSpegniUffici.Location = new System.Drawing.Point(130, 202);
            this.btnSpegniUffici.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpegniUffici.Name = "btnSpegniUffici";
            this.btnSpegniUffici.Size = new System.Drawing.Size(107, 34);
            this.btnSpegniUffici.TabIndex = 40;
            this.btnSpegniUffici.Text = "Spegni solo uffici";
            this.btnSpegniUffici.UseVisualStyleBackColor = true;
            this.btnSpegniUffici.Click += new System.EventHandler(this.btnSpegniUffici_Click);
            // 
            // btnSpegniTutto
            // 
            this.btnSpegniTutto.Location = new System.Drawing.Point(130, 12);
            this.btnSpegniTutto.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpegniTutto.Name = "btnSpegniTutto";
            this.btnSpegniTutto.Size = new System.Drawing.Size(107, 34);
            this.btnSpegniTutto.TabIndex = 31;
            this.btnSpegniTutto.Text = "Spegni tutto";
            this.btnSpegniTutto.UseVisualStyleBackColor = true;
            this.btnSpegniTutto.Click += new System.EventHandler(this.btnSpegniTutto_Click);
            // 
            // btnAccendiSecondoPiano
            // 
            this.btnAccendiSecondoPiano.Location = new System.Drawing.Point(19, 50);
            this.btnAccendiSecondoPiano.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccendiSecondoPiano.Name = "btnAccendiSecondoPiano";
            this.btnAccendiSecondoPiano.Size = new System.Drawing.Size(107, 34);
            this.btnAccendiSecondoPiano.TabIndex = 30;
            this.btnAccendiSecondoPiano.Text = "Accendi 2\' piano";
            this.btnAccendiSecondoPiano.UseVisualStyleBackColor = true;
            this.btnAccendiSecondoPiano.Click += new System.EventHandler(this.btnAccendiSecondoPiano_Click);
            // 
            // btnAccendiMagazzino
            // 
            this.btnAccendiMagazzino.Location = new System.Drawing.Point(19, 88);
            this.btnAccendiMagazzino.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccendiMagazzino.Name = "btnAccendiMagazzino";
            this.btnAccendiMagazzino.Size = new System.Drawing.Size(107, 34);
            this.btnAccendiMagazzino.TabIndex = 34;
            this.btnAccendiMagazzino.Text = "Accendi magazzino";
            this.btnAccendiMagazzino.UseVisualStyleBackColor = true;
            this.btnAccendiMagazzino.Click += new System.EventHandler(this.btnAccendiMagazzino_Click);
            // 
            // btnDuplica
            // 
            this.btnDuplica.Location = new System.Drawing.Point(716, 309);
            this.btnDuplica.Margin = new System.Windows.Forms.Padding(2);
            this.btnDuplica.Name = "btnDuplica";
            this.btnDuplica.Size = new System.Drawing.Size(90, 33);
            this.btnDuplica.TabIndex = 51;
            this.btnDuplica.Text = "Duplica";
            this.btnDuplica.UseVisualStyleBackColor = true;
            this.btnDuplica.Click += new System.EventHandler(this.btnDuplica_Click);
            // 
            // btnApplica
            // 
            this.btnApplica.Location = new System.Drawing.Point(716, 8);
            this.btnApplica.Margin = new System.Windows.Forms.Padding(2);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(90, 33);
            this.btnApplica.TabIndex = 50;
            this.btnApplica.Text = "Metti in onda";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(716, 210);
            this.btnElimina.Margin = new System.Windows.Forms.Padding(2);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(90, 37);
            this.btnElimina.TabIndex = 49;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnNuovo
            // 
            this.btnNuovo.Location = new System.Drawing.Point(716, 112);
            this.btnNuovo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuovo.Name = "btnNuovo";
            this.btnNuovo.Size = new System.Drawing.Size(90, 33);
            this.btnNuovo.TabIndex = 48;
            this.btnNuovo.Text = "Nuova config";
            this.btnNuovo.UseVisualStyleBackColor = true;
            this.btnNuovo.Click += new System.EventHandler(this.btnNuovo_Click);
            // 
            // btnSovrascrivi
            // 
            this.btnSovrascrivi.Location = new System.Drawing.Point(716, 159);
            this.btnSovrascrivi.Margin = new System.Windows.Forms.Padding(2);
            this.btnSovrascrivi.Name = "btnSovrascrivi";
            this.btnSovrascrivi.Size = new System.Drawing.Size(90, 33);
            this.btnSovrascrivi.TabIndex = 47;
            this.btnSovrascrivi.Text = "Sovrascrivi";
            this.btnSovrascrivi.UseVisualStyleBackColor = true;
            this.btnSovrascrivi.Click += new System.EventHandler(this.btnSovrascrivi_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(716, 385);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(90, 33);
            this.btnSalva.TabIndex = 46;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            // 
            // gcConfigurazioni
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
            // configurazioniluciBindingSource
            // 
            this.configurazioniluciBindingSource.DataSource = typeof(GestioneLuci.configurazioni_luci);
            // 
            // gcConfigurazioniLuci
            // 
            this.gcConfigurazioniLuci.DataSource = this.configurazioniluciBindingSource;
            this.gcConfigurazioniLuci.Location = new System.Drawing.Point(242, 8);
            this.gcConfigurazioniLuci.MainView = this.gvConfigurazioni;
            this.gcConfigurazioniLuci.Name = "gcConfigurazioniLuci";
            this.gcConfigurazioniLuci.Size = new System.Drawing.Size(469, 539);
            this.gcConfigurazioniLuci.TabIndex = 52;
            this.gcConfigurazioniLuci.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConfigurazioni});
            // 
            // gvConfigurazioni
            // 
            this.gvConfigurazioni.Appearance.Row.Font = new System.Drawing.Font("Roboto", 28.25F);
            this.gvConfigurazioni.Appearance.Row.Options.UseFont = true;
            this.gvConfigurazioni.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colNome,
            this.colJson});
            this.gvConfigurazioni.GridControl = this.gcConfigurazioniLuci;
            this.gvConfigurazioni.Name = "gvConfigurazioni";
            this.gvConfigurazioni.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConfigurazioni.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConfigurazioni.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.gvConfigurazioni.OptionsMenu.EnableFooterMenu = false;
            this.gvConfigurazioni.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gvConfigurazioni.OptionsView.RowAutoHeight = true;
            this.gvConfigurazioni.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvConfigurazioni.OptionsView.ShowColumnHeaders = false;
            this.gvConfigurazioni.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvConfigurazioni.OptionsView.ShowGroupPanel = false;
            this.gvConfigurazioni.OptionsView.ShowIndicator = false;
            this.gvConfigurazioni.RowSeparatorHeight = 2;
            this.gvConfigurazioni.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNome, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            // 
            // frmComandi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 552);
            this.Controls.Add(this.gcConfigurazioniLuci);
            this.Controls.Add(this.btnDuplica);
            this.Controls.Add(this.btnApplica);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnNuovo);
            this.Controls.Add(this.btnSovrascrivi);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnAccendiReception);
            this.Controls.Add(this.btnSpegniSecondoPiano);
            this.Controls.Add(this.btnSpegniReception);
            this.Controls.Add(this.btnSpegniSalaRiunione);
            this.Controls.Add(this.btnAccendiTutto);
            this.Controls.Add(this.btnAccendiSalaRiunione);
            this.Controls.Add(this.btnAccendiUffici);
            this.Controls.Add(this.btnSpegniMgazzino);
            this.Controls.Add(this.btnSpegniUffici);
            this.Controls.Add(this.btnSpegniTutto);
            this.Controls.Add(this.btnAccendiSecondoPiano);
            this.Controls.Add(this.btnAccendiMagazzino);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(833, 664);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(833, 564);
            this.Name = "frmComandi";
            this.Text = "Configurazione";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComandi_FormClosing);
            this.Load += new System.EventHandler(this.frmComandi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurazioniluciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfigurazioniLuci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurazioni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccendiReception;
        private System.Windows.Forms.Button btnSpegniSecondoPiano;
        private System.Windows.Forms.Button btnSpegniReception;
        private System.Windows.Forms.Button btnSpegniSalaRiunione;
        private System.Windows.Forms.Button btnAccendiTutto;
        private System.Windows.Forms.Button btnAccendiSalaRiunione;
        private System.Windows.Forms.Button btnAccendiUffici;
        private System.Windows.Forms.Button btnSpegniMgazzino;
        private System.Windows.Forms.Button btnSpegniUffici;
        private System.Windows.Forms.Button btnSpegniTutto;
        private System.Windows.Forms.Button btnAccendiSecondoPiano;
        private System.Windows.Forms.Button btnAccendiMagazzino;
        private System.Windows.Forms.Button btnDuplica;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnNuovo;
        private System.Windows.Forms.Button btnSovrascrivi;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Timer timer3;
        private DevExpress.XtraGrid.GridControl gcConfigurazioni;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource configurazioniluciBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraGrid.GridControl gcConfigurazioniLuci;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConfigurazioni;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colJson;
    }
}