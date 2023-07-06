namespace GestioneLuci
{
    partial class frmGestioneSinglaLuce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestioneSinglaLuce));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblLuminosita = new System.Windows.Forms.Label();
            this.trbLuminosita = new DevExpress.XtraEditors.TrackBarControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSpegnimi = new System.Windows.Forms.PictureBox();
            this.btnAccendimi = new System.Windows.Forms.PictureBox();
            this.imgAcceso = new System.Windows.Forms.PictureBox();
            this.imgSpento = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSpegnimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccendimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAcceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSpento)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblLuminosita
            // 
            this.lblLuminosita.Font = new System.Drawing.Font("Roboto", 28F);
            this.lblLuminosita.Location = new System.Drawing.Point(6, 88);
            this.lblLuminosita.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLuminosita.Name = "lblLuminosita";
            this.lblLuminosita.Size = new System.Drawing.Size(276, 46);
            this.lblLuminosita.TabIndex = 43;
            this.lblLuminosita.Text = "100";
            this.lblLuminosita.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trbLuminosita
            // 
            this.trbLuminosita.EditValue = 1;
            this.trbLuminosita.Location = new System.Drawing.Point(6, 31);
            this.trbLuminosita.Name = "trbLuminosita";
            this.trbLuminosita.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trbLuminosita.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.trbLuminosita.Properties.Maximum = 100;
            this.trbLuminosita.Properties.Minimum = 1;
            this.trbLuminosita.Properties.ShowLabels = true;
            this.trbLuminosita.Properties.ShowValueToolTip = true;
            this.trbLuminosita.Properties.SmallChange = 5;
            this.trbLuminosita.Properties.TickFrequency = 10;
            this.trbLuminosita.Properties.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbLuminosita.Size = new System.Drawing.Size(275, 45);
            this.trbLuminosita.TabIndex = 51;
            this.toolTip1.SetToolTip(this.trbLuminosita, "Cambia intensità");
            this.trbLuminosita.Value = 1;
            this.trbLuminosita.EditValueChanged += new System.EventHandler(this.trackBarControl1_EditValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trbLuminosita);
            this.groupBox1.Controls.Add(this.lblLuminosita);
            this.groupBox1.Location = new System.Drawing.Point(6, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 147);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intensità";
            // 
            // btnSpegnimi
            // 
            this.btnSpegnimi.Image = global::GestioneLuci.Properties.Resources.acceso1;
            this.btnSpegnimi.Location = new System.Drawing.Point(12, 12);
            this.btnSpegnimi.Name = "btnSpegnimi";
            this.btnSpegnimi.Size = new System.Drawing.Size(182, 79);
            this.btnSpegnimi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSpegnimi.TabIndex = 54;
            this.btnSpegnimi.TabStop = false;
            this.btnSpegnimi.Click += new System.EventHandler(this.btnSpegnimi_Click);
            // 
            // btnAccendimi
            // 
            this.btnAccendimi.Image = global::GestioneLuci.Properties.Resources.spento;
            this.btnAccendimi.Location = new System.Drawing.Point(12, 12);
            this.btnAccendimi.Name = "btnAccendimi";
            this.btnAccendimi.Size = new System.Drawing.Size(182, 79);
            this.btnAccendimi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAccendimi.TabIndex = 55;
            this.btnAccendimi.TabStop = false;
            this.btnAccendimi.Click += new System.EventHandler(this.btnAccendimi_Click);
            // 
            // imgAcceso
            // 
            this.imgAcceso.Image = global::GestioneLuci.Properties.Resources.lightbulb_on;
            this.imgAcceso.Location = new System.Drawing.Point(212, 12);
            this.imgAcceso.Name = "imgAcceso";
            this.imgAcceso.Size = new System.Drawing.Size(81, 79);
            this.imgAcceso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAcceso.TabIndex = 56;
            this.imgAcceso.TabStop = false;
            // 
            // imgSpento
            // 
            this.imgSpento.Image = global::GestioneLuci.Properties.Resources.lightbulb;
            this.imgSpento.Location = new System.Drawing.Point(211, 12);
            this.imgSpento.Name = "imgSpento";
            this.imgSpento.Size = new System.Drawing.Size(81, 79);
            this.imgSpento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSpento.TabIndex = 57;
            this.imgSpento.TabStop = false;
            // 
            // frmGestioneSinglaLuce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(304, 252);
            this.Controls.Add(this.imgSpento);
            this.Controls.Add(this.imgAcceso);
            this.Controls.Add(this.btnAccendimi);
            this.Controls.Add(this.btnSpegnimi);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGestioneSinglaLuce";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto Luce";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLuminosita)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSpegnimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccendimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAcceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSpento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblLuminosita;
        private DevExpress.XtraEditors.TrackBarControl trbLuminosita;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox btnSpegnimi;
        private System.Windows.Forms.PictureBox btnAccendimi;
        private System.Windows.Forms.PictureBox imgAcceso;
        private System.Windows.Forms.PictureBox imgSpento;
    }
}

