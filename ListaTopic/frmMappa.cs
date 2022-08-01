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
            Form1 frm = InitForm1();


            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Test");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            // Rende la form a schermo intero 
            WindowState = FormWindowState.Maximized;

            //GestisciLuce(((ucBottoneLuce)sender).Tag.ToString(), (ucBottoneLuce)sender);

        }


        private Form1 InitForm1()
        {
            Form1 f = new Form1();
            f.Init(mqttClient, DatiLuci, Lista);
            return f;
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

        #endregion


        private void frmMappa_Resize(object sender, EventArgs e)
        {
            if (m_bEvitaResize) return;

            double W = New_W;
            double H = New_H;
            
            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;

            // ------------------------- LUCI SALA RIUNIONI ---------------------------------

            ResizeUserControl(ucLuceLedSalaRiunioni, W, H);
            ucLuceLedSalaRiunioni.Tag = "D2_A002";

            ResizeUserControl(ucLuceLampadario, W, H);
            ucLuceLampadario.Tag = "R2_A011";

            ResizeUserControl(ucLuceCucina, W, H);
            ucLuceCucina.Tag = "R2_A018";

            ResizeUserControl(ucFarettiAurelio, W, H);
            ucFarettiAurelio.Tag = "R2_A009";

            ResizeUserControl(ucScrivaniaAurelio, W, H);
            ucScrivaniaAurelio.Tag = "D2_A008";

            ResizeUserControl(ucClaudioSopra, W, H);
            ucClaudioSopra.Tag = "D2_A015";

            ResizeUserControl(ucClaudioSotto1, W, H);
            ucClaudioSotto1.Tag = "D2_A016";

            ResizeUserControl(ucClaudioSotto2, W, H);
            ucClaudioSotto2.Tag = "D2_A017";

            ResizeUserControl(ucFarettiClaudio, W, H);
            ucFarettiClaudio.Tag = "R2_A010";


            // ------------------------- LUCI UFFICIO TECNICO ---------------------------

            ResizeUserControl(ucFarettiUffici12, W, H);
            ucFarettiUffici12.Tag = "D2_A009";

            ResizeUserControl(ucFarettiUffici34, W, H);
            ucFarettiUffici34.Tag = "D2_A010";

            ResizeUserControl(ucScrivaniaGianluca, W, H);
            ucScrivaniaGianluca.Tag = "D2_A003";

            ResizeUserControl(ucScrivaniaMattia, W, H);
            ucScrivaniaMattia.Tag = "D2_A005";

            ResizeUserControl(ucScrivaniaPaolo, W, H);
            ucScrivaniaPaolo.Tag = "D2_A004";



            // --------------------------- LUCI RECEPTION -------------------------------

            ResizeUserControl(ucLedReception, W, H);
            ucLedReception.Tag = "D2_A001";

            ResizeUserControl(ucLuciScrivaniaStampanteAnna, W, H);
            ucLuciScrivaniaStampanteAnna.Tag = "R2_A017";

            ResizeUserControl(ucScrivaniaAnna, W, H);
            ucScrivaniaAnna.Tag = "D2_A013";

            ResizeUserControl(ucScrivaniaDoraSopra, W, H);
            ucScrivaniaDoraSopra.Tag = "D2_A018";

            ResizeUserControl(ucScrivaniaDoraSotto, W, H);
            ucScrivaniaDoraSotto.Tag = "D2_A019";

            ResizeUserControl(ucScrivaniaDoraSotto2, W, H);
            ucScrivaniaDoraSotto2.Tag = "D2_A020";

            ResizeUserControl(ucFarettiLedReception, W, H);
            ucFarettiLedReception.Tag = "R2_A019";

            ResizeUserControl(ucLuceAscensore, W, H);
            ucLuceAscensore.Tag = "R2_A012";

            ResizeUserControl(ucLuceSalaQuadro, W, H);
            ucLuceSalaQuadro.Tag = "R2_A014";

            ResizeUserControl(ucFioriera, W, H);
            ucFioriera.Tag = "R2_A016";

            ResizeUserControl(ucLuceLedScale, W, H);
            ucLuceLedScale.Tag = "D2_A006";




            // ---------------------------- LUCI BAGNO --------------------------------------

            ResizeUserControl(ucLuceAntiBagno, W, H);
            ucLuceAntiBagno.Tag = "R2_A020";

            ResizeUserControl(ucLuceBagno, W, H);
            ucLuceBagno.Tag = "R2_A021";

            ResizeUserControl(ucLuceSpecchioBagno, W, H);
            ucLuceSpecchioBagno.Tag = "R2_A022";

            ResizeUserControl(ucLuceFuoriBagno, W, H);
            ucLuceFuoriBagno.Tag = "R2_A024";

            ResizeUserControl(ucSpecchioAntiBagno, W, H);
            ucSpecchioAntiBagno.Tag = "R2_A023";
        }


        private void ResizeUserControl(UserControl us, double W, double H)
        {
            double X = us.Location.X;
            double Y = us.Location.Y;

            double New_X = (New_W / W) * X;
            double New_Y = (New_H / H) * Y;

            us.Location = new Point((int)New_X, (int)New_Y);
        }



        private void ucLuceLampadario_Click(object sender, EventArgs e)
        {
            GestisciLuce(((ucBottoneLuce)sender).Tag.ToString(), (ucBottoneLuce)sender);
        }

        private void GestisciLuce(string NomeUniqueId, ucBottoneLuce ucBottone)
        {
            string TopicSalaRiunioni = $"homeassistant/light/{NomeUniqueId}";
            TopicSalaRiunioni += "/set";

            Form1 frm = InitForm1();
            frm.TopicSpecifico = TopicSalaRiunioni;

            frm.ShowDialog();
            //Percentuale = frm.Percentuale;

            string Stato;
            Stato = frm.StatoLuce;

            Dati dato = DatiLuci.Where(a => a.unique_id == (NomeUniqueId)).FirstOrDefault();

            frm.Luce = dato.Curr_State;
            bool Immagine = false;

            if (Stato == "ON")
            {
                Immagine = true;
            }
            else
            {
                Immagine = false;
            }

            ucBottone.SetLuminosità(frm.Percentuale);
            ucBottone.SetImmagine(Immagine);
        }

        
    }
}
