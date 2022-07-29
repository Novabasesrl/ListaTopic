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
using static ListaTopic.frmMappa;

//using static ListaTopic.Form1;


using System.Threading;

namespace ListaTopic
{
    public partial class frmMappa : Form
    {

        private double New_W = 0;
        private double New_H = 0;

        private bool m_bEvitaResize = false;
        //public string Percentuale;


        clsConn Conn;
        List<configurazioni_luci> Lista = new List<configurazioni_luci>();

        public frmMappa()
        {
            m_bEvitaResize = true;

            InitializeComponent();

            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;

            m_bEvitaResize = false;

            Conn = new clsConn();

        }

        private void frmMappa_Load(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            // prendere direttamente la brightness da MQTT?
            //

            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Test");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            // Rende la form appena carica a schermo intero 
            WindowState = FormWindowState.Maximized;

            //string json = JsonConvert.SerializeObject(DatiLuci);
            //List<Dati> DatiLuci = JsonConvert.DeserializeObject<List<Dati>>(ContenutoSerializzato);

            //ucLuceLedSalaRiunioni.SetLuminosità();


        }

        #region "Mqtt"
        MqttClient mqttClient;

        private List<Dati> DatiLuci = new List<Dati>();

        private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            if (e.Topic.EndsWith("config"))
            {
                string Testo;
                var Credenziali = new Dati
                {
                    name = "Luce Ascensore",
                    unique_id = "R2_FARETTI_ASCENSORE"
                };

                var message = Encoding.UTF8.GetString(e.Message);

                Testo = System.Text.Encoding.Default.GetString(e.Message);

                // Nome e unique_id 
                //Dati data = Serialize.Deserialize<Dati>(jsonString);


                // Stesso procedimento
                Testo = System.Text.Encoding.Default.GetString(e.Message);
                Dati dati = JsonConvert.DeserializeObject<Dati>(Testo);


                // Metto in lista 
                DatiLuci.Add(dati);
            }
            else if (e.Topic.EndsWith("state"))
            {
                var Credenziali = new Dati
                {
                    Curr_Brightness = 100,
                    Curr_State = "ON"
                };
                string Testo;

                var message = Encoding.UTF8.GetString(e.Message);

                Testo = System.Text.Encoding.Default.GetString(e.Message);
                Stato stato = JsonConvert.DeserializeObject<Stato>(Testo);

                string[] lst = e.Topic.Split('/');
                string id = lst[2];

                var luce = DatiLuci.FirstOrDefault(l => l.unique_id.Equals(id));
                if (luce != null)
                {
                    luce.Curr_State = stato.State;
                    luce.Curr_Brightness = stato.Brightness;
                }
                else
                {
                    Console.WriteLine(id);
                }

            }
        }


        public class Dati
        {
            public string name { get; set; }

            public string unique_id { get; set; }

            public override string ToString()
            {
                return name;
            }



            public int Curr_Brightness { get; set; }
            public string Curr_State { get; set; }

        }

        public class Stato
        {

            public int Brightness { get; set; }
            public string State { get; set; }

        }

        #endregion


        private void frmMappa_Resize(object sender, EventArgs e)
        {
            if (m_bEvitaResize) return;

            double W = New_W;
            double H = New_H;
            
            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;

            // traformare i funzione!

            // ------------------------- LUCI SALA RIUNIONI ---------------------------------

            ResizeUserControl(ucLuceLedSalaRiunioni, W, H);
            ResizeUserControl(ucLuceLampadario, W, H);
            ResizeUserControl(ucLuceCucina, W, H);
            ResizeUserControl(ucFarettiAurelio, W, H);
            ResizeUserControl(ucScrivaniaAurelio, W, H);
            ResizeUserControl(ucClaudioSopra, W, H);
            ResizeUserControl(ucClaudioSotto1, W, H);
            ResizeUserControl(ucClaudioSotto2, W, H);


            // ------------------------- LUCI UFFICIO TECNICO ---------------------------

            ResizeUserControl(ucFarettiUffici12, W, H);
            ResizeUserControl(ucFarettiUffici34, W, H);
            ResizeUserControl(ucScrivaniaGianluca, W, H);
            ResizeUserControl(ucScrivaniaMattia, W, H);
            ResizeUserControl(ucScrivaniaPaolo, W, H);


            // --------------------------- LUCI RECEPTION -------------------------------

            ResizeUserControl(ucLedReception, W, H);
            ResizeUserControl(ucScrivaniaAnna, W, H);
            ResizeUserControl(ucScrivaniaDoraSopra, W, H);
            ResizeUserControl(ucScrivaniaDoraSotto, W, H);
            ResizeUserControl(ucScrivaniaDoraSotto2, W, H);
            ResizeUserControl(ucFarettiLedReception, W, H);
            ResizeUserControl(ucLuceAscensore, W, H);
            ResizeUserControl(ucLuceSalaQuadro, W, H);
            ResizeUserControl(ucFioriera, W, H);
            ResizeUserControl(ucLuceLedScale, W, H);



            // ---------------------------- LUCI BAGNO --------------------------------------

            ResizeUserControl(ucLuceAntiBagno, W, H);
            ResizeUserControl(ucLuceBagno, W, H);
            ResizeUserControl(ucLuceSpecchioBagno, W, H);
            ResizeUserControl(ucLuceFuoriBagno, W, H);
            ResizeUserControl(ucSpecchioAntiBagno, W, H);


        }


        private void ResizeUserControl(UserControl us, double W, double H)
        {
            double X = us.Location.X;
            double Y = us.Location.Y;

            double New_X = (New_W / W) * X;
            double New_Y = (New_H / H) * Y;

            us.Location = new Point((int)New_X, (int)New_Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        #region "Sala riunioni"
        private void ucLuceLedSalaRiunioni_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A002";
            TopicSalaRiunioni += "/set";


            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();

            ucLuceLedSalaRiunioni.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucLuceLedSalaRiunioni.SetImmagine(Immagine);
        }

        private void ucLuceLampadario_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A011";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            //Percentuale = frm.Percentuale;
            ucLuceLampadario.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucLuceLampadario.SetImmagine(Immagine);

        }

        private void ucLuceCucina_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A018";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceCucina.SetLuminosità(frm.Percentuale);

            //Percentuale = frm.Percentuale;
            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucLuceCucina.SetImmagine(Immagine);
        }

        private void ucFarettiAurelio_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A009";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucFarettiAurelio.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucFarettiAurelio.SetImmagine(Immagine);
        }

        private void ucScrivaniaAurelio_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A008";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaAurelio.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaAurelio.SetImmagine(Immagine);
        }

        private void ucFarettiClaudio_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A010";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucFarettiClaudio.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucFarettiClaudio.SetImmagine(Immagine);
        }

        private void ucClaudioSopra_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A015";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucClaudioSopra.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucClaudioSopra.SetImmagine(Immagine);

        }

        private void ucClaudioSotto1_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A016";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucClaudioSotto1.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucClaudioSotto1.SetImmagine(Immagine);
        }

        private void ucClaudioSotto2_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A017";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucClaudioSotto2.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucClaudioSotto2.SetImmagine(Immagine);
        }


        #endregion


        #region "Ufficio Tecnico"

        private void ucFarettiUffici12_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A009";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucFarettiUffici12.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucFarettiUffici12.SetImmagine(Immagine);

        }

        private void ucFarettiUffici34_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A010";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucFarettiUffici34.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucFarettiUffici34.SetImmagine(Immagine);

        }

        private void ucScrivaniaGianluca_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A003";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaGianluca.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaGianluca.SetImmagine(Immagine);
        }

        private void ucScrivaniaMattia_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A005";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaMattia.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaMattia.SetImmagine(Immagine);
        }

        private void ucScrivaniaPaolo_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A004";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaPaolo.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaPaolo.SetImmagine(Immagine);
        }


        #endregion


        #region "Reception"
        private void ucLedReception_Click(object sender, EventArgs e)
        {

            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A001";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLedReception.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucLedReception.SetImmagine(Immagine);
        }

        private void ucScrivaniaAnna_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A013";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaAnna.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaAnna.SetImmagine(Immagine);
        }

        private void ucScrivaniaDoraSopra_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A018";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaDoraSopra.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaDoraSopra.SetImmagine(Immagine);
        }

        private void ucScrivaniaDoraSotto_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A019";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaDoraSotto.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaDoraSotto.SetImmagine(Immagine);
        }

        private void ucScrivaniaDoraSotto2_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A020";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucScrivaniaDoraSotto2.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucScrivaniaDoraSotto2.SetImmagine(Immagine);
        }

        private void ucFarettiLedReception_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A019";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucFarettiLedReception.SetLuminosità(frm.Percentuale);

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucFarettiLedReception.SetImmagine(Immagine);
        }

        private void ucLuceAscensore_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A012";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;
            ucLuceAscensore.SetLuminosità(frm.Percentuale);

            frm.ShowDialog();

            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucLuceAscensore.SetImmagine(Immagine);
        }

        private void ucLuceSalaQuadro_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A014";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceSalaQuadro.SetLuminosità(frm.Percentuale);


            string Stato;
            Stato = frm.StatoLuce;

            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucLuceSalaQuadro.SetImmagine(Immagine);
        }

        private void ucFioriera_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A016";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucFioriera.SetLuminosità(frm.Percentuale);
        }

        private void ucLuceLedScale_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/D2_A006";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceLedScale.SetLuminosità(frm.Percentuale);
        }
        #endregion


        #region "Bagno
        private void ucLuceAntiBagno_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A020";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceAntiBagno.SetLuminosità(frm.Percentuale);

            //Percentuale = frm.Percentuale;
        }

        private void ucLuceBagno_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A021";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceBagno.SetLuminosità(frm.Percentuale);

            //Percentuale = frm.Percentuale;
        }

        private void ucLuceSpecchioBagno_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A022";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceSpecchioBagno.SetLuminosità(frm.Percentuale);

            //Percentuale = frm.Percentuale;
        }

        private void ucLuceFuoriBagno_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A024";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucLuceFuoriBagno.SetLuminosità(frm.Percentuale);

            //Percentuale = frm.Percentuale;
        }

        private void ucSpecchioAntiBagno_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;

            TopicSalaRiunioni = "homeassistant/light/R2_A023";
            TopicSalaRiunioni += "/set";

            Form1 frm = new Form1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            ucSpecchioAntiBagno.SetLuminosità(frm.Percentuale);

            //Percentuale = frm.Percentuale;
        }




        #endregion


        #region "bagno magazzino"
        //string TopicSalaRiunioni;

        //TopicSalaRiunioni = "homeassistant/light/R1_A053";
        //TopicSalaRiunioni += "/set";

        //Form1 frm = new Form1();
        //frm.TopicSpecifico = TopicSalaRiunioni;

        //frm.ShowDialog(); 
        ////Percentuale = frm.Percentuale;
        //ucBagnoMagazzino.SetLuminosità(frm.Percentuale);
        //
        //
//        string Stato;
//        Stato = frm.StatoLuce;

//            bool Immagine = false;

//            if (Stato == "ON")
//            {
//                Immagine = true;
//            }
//            else
//            {
//                Immagine = false;
//            }

//ucLuceLedSalaRiunioni.SetImmagine(Immagine);
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (listBox2.SelectedIndex != -1)
            //{
            //    //string json = JsonConvert.SerializeObject(DatiLuci);
            //    //List<Dati> DatiLuci = JsonConvert.DeserializeObject<List<Dati>>(ContenutoSerializzato);


            //    string Topic;
            //    string Messaggio;
            //    Messaggio = "{\"brightness\": " + trbLuminosita.Value +
            //        ",\"state\": \"ON\"} ";
            //    Topic = "homeassistant/light/";
            //    Topic += (listBox2.SelectedItem as Dati).unique_id;
            //    Topic += "/set";
            //    if (mqttClient != null && mqttClient.IsConnected)
            //    {
            //        mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            //    }
            //    timer1.Stop();

            //    timer2.Enabled = true;
            //}
            //else
            //{
            //    string Topic;
            //    string Messaggio;
            //    Messaggio = "{\"brightness\": " + trbLuminosita.Value +
            //        ",\"state\": \"ON\"} ";
            //    Topic = TopicSpecifico;
            //    if (mqttClient != null && mqttClient.IsConnected)
            //    {
            //        mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            //    }
            //    timer1.Stop();

            //    timer2.Enabled = true;
            //}
        }

        
    }
}
