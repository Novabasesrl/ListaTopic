﻿using System;
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
using static GestioneLuci.frmComandi;
using System.Threading;



namespace GestioneLuci
{
    public partial class frmComandi : Form
    {

        clsConn Conn;
        List<configurazioni_luci> Lista = new List<configurazioni_luci>();

        public frmComandi()
        {
            InitializeComponent();
            Conn = new clsConn();

            this.Size = new Size(1650, 1241);
        }


        public string TopicSpecifico;
        public int Percentuale;
        public string StatoLuce;
        public string Luce;

        private void frmComandi_Load(object sender, EventArgs e)
        {
            //Form1 frm = InitForm1();

            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            //mqttClient.MqttMsgPublishReceived -= MqttClient_MqttMsgPublishReceived;
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Comandi");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            Carica();
        }



        public void Init(MqttClient _mqttClient, List<Dati> _DatiLuci, List<configurazioni_luci> _ConfigLuci)
        {
            mqttClient = _mqttClient;
            DatiLuci = _DatiLuci;
            Lista = _ConfigLuci;

        }


        private frmGestioneSinglaLuce InitForm1()
        {
            frmGestioneSinglaLuce f = new frmGestioneSinglaLuce();
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


        #region "Accendi"
        private void btnAccendiTutto_Click(object sender, EventArgs e)
        {
            string TopicDali;
            string Messaggio;

            TopicDali = "homeassistant/light/D2_A255";
            Messaggio = "{\"state\": \"ON\"}";
            TopicDali += "/set";

            string TopicRele;
            TopicRele = "homeassistant/light/P2_A251";
            TopicRele += "/set";


            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_A011";
            TopicPareteLucernario += "/set";


            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_A018";
            TopicCucina += "/set";


            string TopicFioriera;
            TopicFioriera = "homeassistant/light/R2_A016";
            TopicFioriera += "/set";


            string FarettiLedReception;
            FarettiLedReception = "homeassistant/light/R2_A019";
            FarettiLedReception += "/set";

            string LuciScrivaniaStampanteAnna;
            LuciScrivaniaStampanteAnna = "homeassistant/light/R2_A017";
            LuciScrivaniaStampanteAnna += "/set";


            string LuceSalaQuadro;
            LuceSalaQuadro = "homeassistant/light/R2_A014";
            LuceSalaQuadro += "/set";


            string LuceAscensore;
            LuceAscensore = "homeassistant/light/R2_A012";
            LuceAscensore += "/set";


            string LuceFuoriBagno;
            LuceFuoriBagno = "homeassistant/light/R2_A024";
            LuceFuoriBagno += "/set";


            string TopicLuceAntiBagno;
            TopicLuceAntiBagno = "homeassistant/light/R2_A020";
            TopicLuceAntiBagno += "/set";


            string TopicLuceSpecchioAntiBagno;
            TopicLuceSpecchioAntiBagno = "homeassistant/light/R2_A023";
            TopicLuceSpecchioAntiBagno += "/set";


            string TopicLuceSpecchioBagno;
            TopicLuceSpecchioBagno = "homeassistant/light/R2_A022";
            TopicLuceSpecchioBagno += "/set";


            string TopicLuceBagno;
            TopicLuceBagno = "homeassistant/light/R2_A021";
            TopicLuceBagno += "/set";


            string TopicCorridioio;
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


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFioriera, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(FarettiLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaStampanteAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceAscensore, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceFuoriBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceBagno, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicBagnoMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnAccendiSecondoPiano_Click(object sender, EventArgs e)
        {
            string TopicDali;
            string Messaggio;

            TopicDali = "homeassistant/light/D2_A255";
            Messaggio = "{\"state\": \"ON\"}";
            TopicDali += "/set";

            string TopicRele;
            TopicRele = "homeassistant/light/P2_A251";
            TopicRele += "/set";


            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_A011";
            TopicPareteLucernario += "/set";


            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_A018";
            TopicCucina += "/set";


            string TopicFioriera;
            TopicFioriera = "homeassistant/light/R2_A016";
            TopicFioriera += "/set";


            string FarettiLedReception;
            FarettiLedReception = "homeassistant/light/R2_A019";
            FarettiLedReception += "/set";

            string LuciScrivaniaStampanteAnna;
            LuciScrivaniaStampanteAnna = "homeassistant/light/R2_A017";
            LuciScrivaniaStampanteAnna += "/set";


            string LuceSalaQuadro;
            LuceSalaQuadro = "homeassistant/light/R2_A014";
            LuceSalaQuadro += "/set";


            string LuceAscensore;
            LuceAscensore = "homeassistant/light/R2_A012";
            LuceAscensore += "/set";


            string LuceFuoriBagno;
            LuceFuoriBagno = "homeassistant/light/R2_A024";
            LuceFuoriBagno += "/set";


            string TopicLuceAntiBagno;
            TopicLuceAntiBagno = "homeassistant/light/R2_A020";
            TopicLuceAntiBagno += "/set";


            string TopicLuceSpecchioAntiBagno;
            TopicLuceSpecchioAntiBagno = "homeassistant/light/R2_A023";
            TopicLuceSpecchioAntiBagno += "/set";


            string TopicLuceSpecchioBagno;
            TopicLuceSpecchioBagno = "homeassistant/light/R2_A022";
            TopicLuceSpecchioBagno += "/set";


            string TopicLuceBagno;
            TopicLuceBagno = "homeassistant/light/R2_A021";
            TopicLuceBagno += "/set";


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFioriera, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(FarettiLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaStampanteAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceAscensore, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceFuoriBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceBagno, Encoding.UTF8.GetBytes(Messaggio));

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
            TopicFarettiAurelio = "homeassistant/light/D2_A011";
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
            TopicFarettiClaudio = "homeassistant/light/D2_A012";
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
            string TopicDali;
            string Messaggio;

            TopicDali = "homeassistant/light/D2_A255";
            Messaggio = "{\"state\": \"OFF\"}";
            TopicDali += "/set";

            string TopicRele;
            TopicRele = "homeassistant/light/P2_A251";
            TopicRele += "/set";


            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_A011";
            TopicPareteLucernario += "/set";


            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_A018";
            TopicCucina += "/set";


            string TopicFioriera;
            TopicFioriera = "homeassistant/light/R2_A016";
            TopicFioriera += "/set";


            string FarettiLedReception;
            FarettiLedReception = "homeassistant/light/R2_A019";
            FarettiLedReception += "/set";

            string LuciScrivaniaStampanteAnna;
            LuciScrivaniaStampanteAnna = "homeassistant/light/R2_A017";
            LuciScrivaniaStampanteAnna += "/set";


            string LuceSalaQuadro;
            LuceSalaQuadro = "homeassistant/light/R2_A014";
            LuceSalaQuadro += "/set";


            string LuceAscensore;
            LuceAscensore = "homeassistant/light/R2_A012";
            LuceAscensore += "/set";


            string LuceFuoriBagno;
            LuceFuoriBagno = "homeassistant/light/R2_A024";
            LuceFuoriBagno += "/set";


            string TopicLuceAntiBagno;
            TopicLuceAntiBagno = "homeassistant/light/R2_A020";
            TopicLuceAntiBagno += "/set";


            string TopicLuceSpecchioAntiBagno;
            TopicLuceSpecchioAntiBagno = "homeassistant/light/R2_A023";
            TopicLuceSpecchioAntiBagno += "/set";


            string TopicLuceSpecchioBagno;
            TopicLuceSpecchioBagno = "homeassistant/light/R2_A022";
            TopicLuceSpecchioBagno += "/set";


            string TopicLuceBagno;
            TopicLuceBagno = "homeassistant/light/R2_A021";
            TopicLuceBagno += "/set";


            string TopicCorridioio;
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


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFioriera, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(FarettiLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaStampanteAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceAscensore, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceFuoriBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceBagno, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicBagnoMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniSecondoPiano_Click(object sender, EventArgs e)
        {
            string TopicDali;
            string Messaggio;

            TopicDali = "homeassistant/light/D2_A255";
            Messaggio = "{\"state\": \"OFF\"}";
            TopicDali += "/set";

            string TopicRele;
            TopicRele = "homeassistant/light/P2_A251";
            TopicRele += "/set";


            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_A011";
            TopicPareteLucernario += "/set";


            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_A018";
            TopicCucina += "/set";


            string TopicFioriera;
            TopicFioriera = "homeassistant/light/R2_A016";
            TopicFioriera += "/set";


            string FarettiLedReception;
            FarettiLedReception = "homeassistant/light/R2_A019";
            FarettiLedReception += "/set";

            string LuciScrivaniaStampanteAnna;
            LuciScrivaniaStampanteAnna = "homeassistant/light/R2_A017";
            LuciScrivaniaStampanteAnna += "/set";


            string LuceSalaQuadro;
            LuceSalaQuadro = "homeassistant/light/R2_A014";
            LuceSalaQuadro += "/set";


            string LuceAscensore;
            LuceAscensore = "homeassistant/light/R2_A012";
            LuceAscensore += "/set";


            string LuceFuoriBagno;
            LuceFuoriBagno = "homeassistant/light/R2_A024";
            LuceFuoriBagno += "/set";


            string TopicLuceAntiBagno;
            TopicLuceAntiBagno = "homeassistant/light/R2_A020";
            TopicLuceAntiBagno += "/set";


            string TopicLuceSpecchioAntiBagno;
            TopicLuceSpecchioAntiBagno = "homeassistant/light/R2_A023";
            TopicLuceSpecchioAntiBagno += "/set";


            string TopicLuceSpecchioBagno;
            TopicLuceSpecchioBagno = "homeassistant/light/R2_A022";
            TopicLuceSpecchioBagno += "/set";


            string TopicLuceBagno;
            TopicLuceBagno = "homeassistant/light/R2_A021";
            TopicLuceBagno += "/set";


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicDali, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicRele, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicFioriera, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(FarettiLedReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuciScrivaniaStampanteAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceAscensore, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(LuceFuoriBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioAntiBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceSpecchioBagno, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLuceBagno, Encoding.UTF8.GetBytes(Messaggio));
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
            TopicFarettiAurelio = "homeassistant/light/D2_A011";
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
            TopicFarettiClaudio = "homeassistant/light/D2_A012";
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

        public configurazioni_luci GetDatiSelezionati()
        {
            foreach (int i in gvConfigurazioni.GetSelectedRows())
            {
                configurazioni_luci so = (configurazioni_luci)gvConfigurazioni.GetRow(i);
                if (so != null)
                {
                    return so;
                }
            }

            return null;
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

                /* string text = "Inserisci nome";
                 string caption = "";


                 Configurazione.Nome = ShowDialog(text, caption);*/
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

            // sparare su mqtt per ogni elementi diu datiluci on/off/luminosità
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

                Console.WriteLine($"{Topic} -> {Messaggio}");



                if (Topic != "homeassistant/light/D2_A255/set")
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

                string text = "Inserisci nome";
                string caption = Configurazione.Nome;


                Configurazione.Nome = ShowDialog(text, caption);

                Conn.ctx.configurazioni_luci.Add(Configurazione);
                gvConfigurazioni.RefreshData();
                Conn.ctx.SaveChanges();

                Salva();
                Carica();
            }
        }




        #endregion

        private void frmComandi_FormClosing(object sender, FormClosingEventArgs e)
        {
           // timer1.Stop();
            mqttClient.Disconnect();
        }
    }
}
