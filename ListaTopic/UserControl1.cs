using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ListaTopic.Form1;
using System.Threading;

namespace ListaTopic
{
    public partial class ucBottoneLuce : UserControl
    {

        public ucBottoneLuce()
        {
            InitializeComponent();

        }

        private void ucBottoneLuce_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }

        private void lblLuminiosità_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }

        public void SetLuminosità(int Luminosita)
        {
            lblLuminiosità.Text = Luminosita + "%";
        }

        public void SetImmagine(bool Acceso)
        {
            if (Acceso == true)
            {
                this.pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("Resources\\LampadinaAccesa.jpg");
            }
            else
            {
                this.pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("Resources\\LampadinaSpenta.jpg");
            }
        }








    }
}
