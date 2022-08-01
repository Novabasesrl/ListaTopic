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
using static ListaTopic.frmComandi;
using System.Threading;



namespace ListaTopic
{
    public partial class frmComandi : Form
    {

        clsConn Conn;
        List<configurazioni_luci> Lista = new List<configurazioni_luci>();

        public frmComandi()
        {
            InitializeComponent();
            Conn = new clsConn();

        }


        public string TopicSpecifico;
        public int Percentuale;
        public string StatoLuce;
        public string Luce;

        private void frmComandi_Load(object sender, EventArgs e)
        {
            //   mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived -= MqttClient_MqttMsgPublishReceived;
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            //  mqttClient.Connect("Test");
            //   mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });


            // Luminosita per tutto il secondo piano

            // The Maximum property sets the value of the track bar when
            // the slider is all the way to the right.
            trbImpostaLuminositaTutto.Maximum = 101;

            // The TickFrequency property establishes how many positions
            // are between each tick-mark.
            trbImpostaLuminositaTutto.TickFrequency = 10;

            // The LargeChange property sets how many positions to move
            // if the bar is clicked on either side of the slider.
            trbImpostaLuminositaTutto.LargeChange = 1;

            // The SmallChange property sets how many positions to move
            // if the keyboard arrows are used to move the slider.
            trbImpostaLuminositaTutto.SmallChange = 2;


            WindowState = FormWindowState.Maximized;

            
        }



        //public void Init(MqttClient _mqttClient, List<Dati> _DatiLuci, List<configurazioni_luci> _ConfigLuci)
        //{
        //    mqttClient = _mqttClient;
        //    DatiLuci = _DatiLuci;
        //    Lista = _ConfigLuci;
        //    listBox2.Items.Clear();
        //    foreach (Dati ilDato in DatiLuci) listBox2.Items.Add(ilDato);
        //}


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


        #region "Accendi"
        private void btnAccendiTutto_Click(object sender, EventArgs e)
        {
            string TopicCorridioio;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicCorridioio = "homeassistant/light/R1_A052";
            TopicCorridioio += "/set";

            string TopicBagnoMagazzino;
            TopicBagnoMagazzino = "homeassistant/light/R1_A053";
            TopicBagnoMagazzino += "/set";

            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_A049";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_A050";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_A051";
            TopicServer += "/set";

            string TopicDali;
            TopicDali = "homeassistant/light/D2_A255";
            TopicDali += "/set";

            string TopicRele;
            TopicRele = "homeassistant/light/P2_A251";
            TopicRele += "/set";

            
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicBagnoMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnAccendiSecondoPiano_Click(object sender, EventArgs e)
        {
            string TopicDali;
            string TopicRele;
            
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicDali = "homeassistant/light/D2_A255";
            TopicRele = "homeassistant/light/P2_A251";

            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;


            TopicDali += "/set";
            TopicRele += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));

            }
        }

        private void btnAccendiMagazzino_Click(object sender, EventArgs e)
        {
            string TopicCorridioio;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicCorridioio = "homeassistant/light/R1_A052";
            TopicCorridioio += "/set";
            // bagno
            // R1_A053

            string TopicBagnoMagazzino;
            TopicBagnoMagazzino = "homeassistant/light/R1_A053";
            TopicBagnoMagazzino += "/set";

            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_A049";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_A050";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_A051";
            TopicServer += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicBagnoMagazzino, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnAccendiSalaRiunione_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicSalaRiunioni = "homeassistant/light/D2_A002";
            TopicSalaRiunioni += "/set";


            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_A011";
            TopicPareteLucernario += "/set";

            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_A018";
            TopicCucina += "/set";

            string TopicFarettiAurelio;
            TopicFarettiAurelio = "homeassistant/light/R2_A009";
            TopicFarettiAurelio += "/set";


            string TopicScrivaniaAurelio;
            TopicScrivaniaAurelio = "homeassistant/light/D2_A008";
            TopicScrivaniaAurelio += "/set";

            string TopicClaudioSopra;
            TopicClaudioSopra = "homeassistant/light/D2_A015";
            TopicClaudioSopra += "/set";

            string TopicClaudioSotto;
            TopicClaudioSotto = "homeassistant/light/D2_A016";
            TopicClaudioSotto += "/set";

            string TopicClaudioSotto2;
            TopicClaudioSotto2 = "homeassistant/light/D2_A017";
            TopicClaudioSotto2 += "/set";


            string TopicFarettiClaudio;
            TopicFarettiClaudio = "homeassistant/light/R2_A010";
            TopicFarettiClaudio += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicSalaRiunioni, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicScrivaniaAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSopra, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiClaudio, Encoding.UTF8.GetBytes(Messaggio));
            }

        }


        private void btnAccendiReception_Click(object sender, EventArgs e)
        {
            string TopicBarraLedReception;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicBarraLedReception = "homeassistant/light/D2_A001";
            TopicBarraLedReception += "/set";
            

            string LuciScrivaniaStampanteAnna;
            LuciScrivaniaStampanteAnna = "homeassistant/light/R2_A017";
            LuciScrivaniaStampanteAnna += "/set";

            string LuciScrivaniaAnna;
            LuciScrivaniaAnna = "homeassistant/light/D2_A013";
            LuciScrivaniaAnna += "/set";

            string ScrivaniaDoraSopra;
            ScrivaniaDoraSopra = "homeassistant/light/D2_A018";
            ScrivaniaDoraSopra += "/set";

            string ScrivaniaDoraSotto;
            ScrivaniaDoraSotto = "homeassistant/light/D2_A019";
            ScrivaniaDoraSotto += "/set";

            string ScrivaniaDoraSotto2;
            ScrivaniaDoraSotto2 = "homeassistant/light/D2_A020";
            ScrivaniaDoraSotto2 += "/set";


            string FarettiLedReception;
            FarettiLedReception = "homeassistant/light/R2_A019";
            FarettiLedReception += "/set";

            string LuceAscensore;
            LuceAscensore = "homeassistant/light/R2_A012";
            LuceAscensore += "/set";

            string LuceSalaQuadro;
            LuceSalaQuadro = "homeassistant/light/R2_A014";
            LuceSalaQuadro += "/set";

            string LuceFioriera;
            LuceFioriera = "homeassistant/light/R2_A016";
            LuceFioriera += "/set";

            string LuceLedScale;
            LuceLedScale = "homeassistant/light/D2_A006";
            LuceLedScale += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicBarraLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaStampanteAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(ScrivaniaDoraSopra, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(ScrivaniaDoraSotto, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(ScrivaniaDoraSotto2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(FarettiLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceAscensore, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceFioriera, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceLedScale, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnAccendiUffici_Click(object sender, EventArgs e)
        {
            // TopicFarettiMattiaPaolo
            string TopicFaretti12;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicFaretti12 = "homeassistant/light/D2_A009";
            TopicFaretti12 += "/set";

            // TopicFarettiGianluca
            string TopicFarett34;
            TopicFarett34 = "homeassistant/light/D2_A010";
            TopicFarett34 += "/set";


            string TopicGianluca;
            
            TopicGianluca = "homeassistant/light/D2_A003";
            TopicGianluca += "/set";


            string TopicMattia;
            TopicMattia = "homeassistant/light/D2_A005";
            TopicMattia += "/set";

            string TopicPaolo;
            TopicPaolo = "homeassistant/light/D2_A004";
            TopicPaolo += "/set";

            


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicFaretti12, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarett34, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicGianluca, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMattia, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPaolo, Encoding.UTF8.GetBytes(Messaggio));
                
            }
        }


        #endregion


        #region "Spegni"
        private void btnSpegniTutto_Click(object sender, EventArgs e)
        {
            string TopicCorridioio;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicCorridioio = "homeassistant/light/R1_A052";
            TopicCorridioio += "/set";

            string TopicBagnoMagazzino;
            TopicBagnoMagazzino = "homeassistant/light/R1_A053";
            TopicBagnoMagazzino += "/set";

            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_A049";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_A050";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_A051";
            TopicServer += "/set";

            string TopicDali;
            TopicDali = "homeassistant/light/D2_A255";
            TopicDali += "/set";

            string TopicRele;
            TopicRele = "homeassistant/light/P2_A251";
            TopicRele += "/set";


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicBagnoMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniSecondoPiano_Click(object sender, EventArgs e)
        {
            string TopicDali;
            string TopicRele;

            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicDali = "homeassistant/light/D2_A255";
            TopicRele = "homeassistant/light/P2_A251";

            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;


            TopicDali += "/set";
            TopicRele += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));

            }
        }

        private void btnSpegniMgazzino_Click(object sender, EventArgs e)
        {
            string TopicCorridioio;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicCorridioio = "homeassistant/light/R1_A052";
            TopicCorridioio += "/set";
            // bagno
            // R1_A053

            string TopicBagnoMagazzino;
            TopicBagnoMagazzino = "homeassistant/light/R1_A053";
            TopicBagnoMagazzino += "/set";

            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_A049";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_A050";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_A051";
            TopicServer += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicBagnoMagazzino, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniSalaRiunione_Click(object sender, EventArgs e)
        {
            string TopicSalaRiunioni;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicSalaRiunioni = "homeassistant/light/D2_A002";
            TopicSalaRiunioni += "/set";


            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_A011";
            TopicPareteLucernario += "/set";

            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_A018";
            TopicCucina += "/set";

            string TopicFarettiAurelio;
            TopicFarettiAurelio = "homeassistant/light/R2_A009";
            TopicFarettiAurelio += "/set";


            string TopicScrivaniaAurelio;
            TopicScrivaniaAurelio = "homeassistant/light/D2_A008";
            TopicScrivaniaAurelio += "/set";

            string TopicClaudioSopra;
            TopicClaudioSopra = "homeassistant/light/D2_A015";
            TopicClaudioSopra += "/set";

            string TopicClaudioSotto;
            TopicClaudioSotto = "homeassistant/light/D2_A016";
            TopicClaudioSotto += "/set";

            string TopicClaudioSotto2;
            TopicClaudioSotto2 = "homeassistant/light/D2_A017";
            TopicClaudioSotto2 += "/set";


            string TopicFarettiClaudio;
            TopicFarettiClaudio = "homeassistant/light/R2_A010";
            TopicFarettiClaudio += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicSalaRiunioni, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicScrivaniaAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSopra, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiClaudio, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniReception_Click(object sender, EventArgs e)
        {
            string TopicBarraLedReception;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicBarraLedReception = "homeassistant/light/D2_A001";
            TopicBarraLedReception += "/set";


            string LuciScrivaniaStampanteAnna;
            LuciScrivaniaStampanteAnna = "homeassistant/light/R2_A017";
            LuciScrivaniaStampanteAnna += "/set";

            string LuciScrivaniaAnna;
            LuciScrivaniaAnna = "homeassistant/light/D2_A013";
            LuciScrivaniaAnna += "/set";

            string ScrivaniaDoraSopra;
            ScrivaniaDoraSopra = "homeassistant/light/D2_A018";
            ScrivaniaDoraSopra += "/set";

            string ScrivaniaDoraSotto;
            ScrivaniaDoraSotto = "homeassistant/light/D2_A019";
            ScrivaniaDoraSotto += "/set";

            string ScrivaniaDoraSotto2;
            ScrivaniaDoraSotto2 = "homeassistant/light/D2_A020";
            ScrivaniaDoraSotto2 += "/set";


            string FarettiLedReception;
            FarettiLedReception = "homeassistant/light/R2_A019";
            FarettiLedReception += "/set";

            string LuceAscensore;
            LuceAscensore = "homeassistant/light/R2_A012";
            LuceAscensore += "/set";

            string LuceSalaQuadro;
            LuceSalaQuadro = "homeassistant/light/R2_A014";
            LuceSalaQuadro += "/set";

            string LuceFioriera;
            LuceFioriera = "homeassistant/light/R2_A016";
            LuceFioriera += "/set";

            string LuceLedScale;
            LuceLedScale = "homeassistant/light/D2_A006";
            LuceLedScale += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicBarraLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaStampanteAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(ScrivaniaDoraSopra, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(ScrivaniaDoraSotto, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(ScrivaniaDoraSotto2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(FarettiLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceAscensore, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceFioriera, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceLedScale, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniUffici_Click(object sender, EventArgs e)
        {
            // TopicFarettiMattiaPaolo
            string TopicFaretti12;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicFaretti12 = "homeassistant/light/D2_A009";
            TopicFaretti12 += "/set";

            // TopicFarettiGianluca
            string TopicFarett34;
            TopicFarett34 = "homeassistant/light/D2_A010";
            TopicFarett34 += "/set";


            string TopicGianluca;

            TopicGianluca = "homeassistant/light/D2_A003";
            TopicGianluca += "/set";


            string TopicMattia;
            TopicMattia = "homeassistant/light/D2_A005";
            TopicMattia += "/set";

            string TopicPaolo;
            TopicPaolo = "homeassistant/light/D2_A004";
            TopicPaolo += "/set";




            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicFaretti12, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarett34, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicGianluca, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMattia, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPaolo, Encoding.UTF8.GetBytes(Messaggio));

            }
        }


        #endregion


        #region "Accendi 2 piano"
        private void btnAccendiTuttoLuminosita_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            Topic = "homeassistant/light/D2_A255";

            Topic += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnImpostaValoreTrb_Click(object sender, EventArgs e)
        {
            int Luminosita;
            Luminosita = Convert.ToInt32(txtImpostaValoreTutteLuci.Text);
            trbImpostaLuminositaTutto.Value = Luminosita;
        }

        private void trbImpostaLuminositaTutto_ValueChanged(object sender, EventArgs e)
        {
            timer3.Stop();
            timer3.Start();

            label1.Text = Convert.ToString(trbImpostaLuminositaTutto.Value);
        }
        #endregion


        #region "SQL"
        private void btnCarica_Click(object sender, EventArgs e)
        {
            Carica();

        }

        private void Carica()
        {
            Lista = Conn.ctx.configurazioni_luci.ToList();
            configurazioniluciBindingSource.DataSource = Lista;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                Salva();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore ");
                throw;
            }
        }

        private void Salva()
        {
            Conn.ctx.SaveChanges();
        }


        private void btnNuovo_Click(object sender, EventArgs e)
        {

            // Istanzo un oggetto di tipo configurazione luci

            configurazioni_luci Configurazione = new configurazioni_luci();
            string text = "Inserisci nome";
            string caption = "";

            //string json = JsonConvert.SerializeObject(DatiLuci);

            Configurazione.Nome = ShowDialog(text, caption);
            string json = JsonConvert.SerializeObject(DatiLuci);

            Configurazione.Json = json;

            // cl.Nome = "pippo"; // da prompt?
            //cl.Json = ....serializza la lista dati, come quando salvi su file

            Conn.ctx.configurazioni_luci.Add(Configurazione);
            Conn.ctx.SaveChanges();

            Salva();
            Carica();
        }

        public string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 400 };
            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void btnSovrascrivi_Click(object sender, EventArgs e)
        {
            configurazioni_luci Configurazione = gvConfigurazioni.GetFocusedRow() as configurazioni_luci;
            if (Configurazione == null)
            {
                return;
            }
            else
            {

                string text = "Inserisci nome";
                string caption = "";


                Configurazione.Nome = ShowDialog(text, caption);
                string json = JsonConvert.SerializeObject(DatiLuci);

                Configurazione.Json = json;

                gvConfigurazioni.RefreshData();
                Conn.ctx.SaveChanges();

                Salva();
                Carica();
            }

        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            configurazioni_luci Configurazione = gvConfigurazioni.GetFocusedRow() as configurazioni_luci;
            if (Configurazione == null)
            {
                return;
            }
            else
            {
                Lista.Remove(Configurazione);
                gvConfigurazioni.RefreshData();
                Conn.ctx.configurazioni_luci.Remove(Configurazione);
                Conn.ctx.SaveChanges();

                Salva();
                Carica();
            }
        }

        private void btnApplica_Click(object sender, EventArgs e)
        {
            configurazioni_luci Configurazione = gvConfigurazioni.GetFocusedRow() as configurazioni_luci;

            // ContenutoSerializzato -> datiluci

            List<Dati> DatiLuci = JsonConvert.DeserializeObject<List<Dati>>(Configurazione.Json);

            // sparere su mqtt per ogni elementi diu datiluci on/off/luminosità
            foreach (Dati Dati in DatiLuci)
            {
                string Topic;
                string Messaggio;
                Messaggio = "{\"brightness\": " + Dati.Curr_Brightness +
                    ",\"state\":\"" + Dati.Curr_State + "\"} ";

                //Messaggio = "{\"state\": " + Dati.Curr_State +
                //    ",\"brightness\":\"" + Dati.Curr_Brightness + "\"} ";
                Topic = "homeassistant/light/";
                Topic += Dati.unique_id;
                Topic += "/set";
                // Non funziona quando si imposta l luminosita diversa da 10 
                // Ricordarisi l' ultimo test fatto
                // si chiamka bassa
                if (Topic != "homeassistant/light/D2_BroadcastEVG/set")
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
                Thread.Sleep(50);

            }

            Salva();
            Carica();
        }

        private void btnDuplica_Click(object sender, EventArgs e)
        {
            configurazioni_luci Configurazione = gvConfigurazioni.GetFocusedRow() as configurazioni_luci;
            if (Configurazione == null)
            {
                return;
            }
            else
            {
                Conn.ctx.configurazioni_luci.Add(Configurazione);
                gvConfigurazioni.RefreshData();
                Conn.ctx.SaveChanges();

                Salva();
                Carica();
            }
        }


        #endregion

       

        private void timer3_Tick(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"brightness\": " + trbImpostaLuminositaTutto.Value +
                ",\"state\": \"ON\"} ";
            Topic = "homeassistant/light/D2_A255";
            Topic += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
            timer3.Stop();
        }
    }
}
