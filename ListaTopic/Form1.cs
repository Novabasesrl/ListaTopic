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
    public partial class Form1 : Form
    {


        clsConn Conn ;
        List<configurazioni_luci> Lista = new List<configurazioni_luci> ();


        public Form1()
        {
            InitializeComponent();
            Conn = new clsConn();
        }

        public string TopicSpecifico;
        public int Percentuale;
        public string StatoLuce;

        private void Form1_Load(object sender, EventArgs e)
        {

            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Test");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            // Set up how the form should be displayed and add the controls to the form.
            this.ClientSize = new System.Drawing.Size(296, 62);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtValoreLuminosita, this.trbLuminosita });

            //this.trbLuminosita.Scroll += new System.EventHandler(this.trackBar1_Scroll);

            // The Maximum property sets the value of the track bar when
            // the slider is all the way to the right.
            trbLuminosita.Maximum = 101;

            // The TickFrequency property establishes how many positions
            // are between each tick-mark.
            trbLuminosita.TickFrequency = 10;

            // The LargeChange property sets how many positions to move
            // if the bar is clicked on either side of the slider.
            trbLuminosita.LargeChange = 1;

            // The SmallChange property sets how many positions to move
            // if the keyboard arrows are used to move the slider.
            trbLuminosita.SmallChange = 2;


            trbLuminosita.BringToFront();
            lblLuminosita.BringToFront();
            txtValoreLuminosita.BringToFront();

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



            AfterMove();
            label1.Text = trbImpostaLuminositaTutto.Value.ToString();
        }

        private void AfterMove()
        {
            lblLuminosita.Text = Convert.ToString(trbLuminosita.Value);
            Percentuale = Convert.ToInt32(lblLuminosita.Text);
        }

        private void DisattivaSpegni()
        {
            btnSpegni.Enabled = false;
        }

        private void AttivaSpegni()
        {
            btnSpegni.Enabled = true;
        }

        private void DisattivaAccendi()
        {
            btnAccendi.Enabled = false;
        }

        private void AttivaAccendi()
        {
            btnAccendi.Enabled = true;
        }

            

        #region "Accendi - Spegni"
        private void btnAccendi_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                string Topic;
                string Messaggio;
                Messaggio = "{\"state\": \"ON\"}";
                Topic = "homeassistant/light/";
                Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;
                Topic += "/set";
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
            }
            else
            {
                string Topic;
                string Messaggio;
                Messaggio = "{\"state\": \"ON\"}";
                //Topic = "homeassistant/light/";
                Topic = TopicSpecifico;
                //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;
                //Topic += "/set";
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
            }
            //homeassistant / light / 
            StatoLuce = "ON";
            DisattivaAccendi();
            AttivaSpegni();
        }

        private void btnAccendiTutto_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            Topic = "homeassistant/light/D2_BroadcastEVG";
            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;
            Topic += "/set";

            string TopicCorridioio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicCorridioio = "homeassistant/light/R1_CORRIDOIO";
            TopicCorridioio += "/set";


            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_LABORATORIO";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_MAGAZZINO";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_SERVER";
            TopicServer += "/set";


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));

                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));

            }
        }

        private void btnAccendiSecondoPiano_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            Topic = "homeassistant/light/D2_BroadcastEVG";
            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;


            Topic += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnAccendiMagazzino_Click(object sender, EventArgs e)
        {
            string TopicCorridioio;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicCorridioio = "homeassistant/light/R1_CORRIDOIO";
            TopicCorridioio += "/set";


            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_LABORATORIO";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_MAGAZZINO";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_SERVER";
            TopicServer += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
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


            string TopicScrivaniaAurelio;
            TopicScrivaniaAurelio = "homeassistant/light/D2_SCRIVANIA_AURELIO";
            TopicScrivaniaAurelio += "/set";

            string TopicClaudioSopra;
            TopicClaudioSopra = "homeassistant/light/D2_SCRIVANIA_CLAUDIO_SOPRA";
            TopicClaudioSopra += "/set";

            string TopicClaudioSotto;
            TopicClaudioSotto = "homeassistant/light/D2_SCRIVANIA_CLAUDIO_SOTTO1";
            TopicClaudioSotto += "/set";

            string TopicClaudioSotto2;
            TopicClaudioSotto2 = "homeassistant/light/D2_SCRIVANIA_CLAUDIO_SOTTO2";
            TopicClaudioSotto2 += "/set";

            string Topic7;
            Topic7 = "homeassistant/light/7";
            Topic7 += "/set";

            string TopicFarettiAurelio;
            TopicFarettiAurelio = "homeassistant/light/D2_FARETTI_AURELIO";
            TopicFarettiAurelio += "/set";

            string TopicFarettiClaudio;
            TopicFarettiClaudio = "homeassistant/light/D2_FARETTI_CLAUDIO";
            TopicFarettiClaudio += "/set";


            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_OUT18";
            TopicCucina += "/set";

            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_LUCE_PARETE_LUCERNAIO";
            TopicPareteLucernario += "/set";

            // 

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicSalaRiunioni, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicScrivaniaAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSopra, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic7, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiClaudio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));

            }
        }

        private void btnAccendiReception_Click(object sender, EventArgs e)
        {
            string TopicReception;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicReception = "homeassistant/light/D2_BARRALED_RECEPTION";
            TopicReception += "/set";


            string TopicScrivaniaAnna;
            TopicScrivaniaAnna = "homeassistant/light/D2_SCRIVANIA_ANNA";
            TopicScrivaniaAnna += "/set";

            string TopicLedScrivania;
            TopicLedScrivania = "homeassistant/light/R2_LED_SCRIVANIA_RECEPTION";
            TopicLedScrivania += "/set";

            string TopicSalaQuadro;
            TopicSalaQuadro = "homeassistant/light/R2_LUCE_SALA_QUADRO";
            TopicSalaQuadro += "/set";

            string TopicPresaDirezione1;
            TopicPresaDirezione1 = "homeassistant/light/R2_PRESA_DIREZIONE1";
            TopicPresaDirezione1 += "/set";

            string TopicPresaDirezione2;
            TopicPresaDirezione2 = "homeassistant/light/R2_PRESA_DIREZIONE2";
            TopicPresaDirezione2 += "/set";

            string Topic18;
            Topic18 = "homeassistant/light/18";
            Topic18 += "/set";

            string Topic19;
            Topic19 = "homeassistant/light/19";
            Topic19 += "/set";


            string Topic20;
            Topic20 = "homeassistant/light/20";
            Topic20 += "/set";

            // FarettiReception
            string TopicR2_OUT19;
            TopicR2_OUT19 = "homeassistant/light/R2_OUT19";
            TopicR2_OUT19 += "/set";


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicScrivaniaAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLedScrivania, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPresaDirezione1, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPresaDirezione2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic18, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic19, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic20, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicR2_OUT19, Encoding.UTF8.GetBytes(Messaggio));

            }
        }

        private void btnAccendiUffici_Click(object sender, EventArgs e)
        {
            string TopicGianluca;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            TopicGianluca = "homeassistant/light/D2_SCRIVANIA_GIANLUCA";
            TopicGianluca += "/set";


            string TopicMattia;
            TopicMattia = "homeassistant/light/D2_SCRIVANIA_MATTIA";
            TopicMattia += "/set";

            string TopicPaolo;
            TopicPaolo = "homeassistant/light/D2_SCRIVANIA_PAOLO";
            TopicPaolo += "/set";

            string TopicFarettiMattiaPaolo;
            TopicFarettiMattiaPaolo = "homeassistant/light/D2_FARETTI_UFFICIO1_2";
            TopicFarettiMattiaPaolo += "/set";

            string TopicFarettiGianluca;
            TopicFarettiGianluca = "homeassistant/light/D2_FARETTI_UFFICIO3_4";
            TopicFarettiGianluca += "/set";


            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicGianluca, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMattia, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPaolo, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiMattiaPaolo, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiGianluca, Encoding.UTF8.GetBytes(Messaggio));
            }
        }


        private void btnAccendiTuttoLuminosita_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            Topic = "homeassistant/light/D2_BroadcastEVG";
            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;


            Topic += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
        }


        private void btnSpegni_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                string Topic;
                string Messaggio;
                Messaggio = "{\"state\": \"OFF\"}";
                Topic = "homeassistant/light/";
                Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;
                Topic += "/set";
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
            }
            else
            {
                string Topic;
                string Messaggio;
                Messaggio = "{\"state\": \"OFF\"}";
                //Topic = "homeassistant/light/";
                Topic = TopicSpecifico;
                //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;
                //Topic += "/set";
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
            }
            StatoLuce = "OFF";
            AttivaAccendi();
            DisattivaSpegni();
        }

        private void btnSpegniTutto_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            Topic = "homeassistant/light/D2_BroadcastEVG";
            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;
            Topic += "/set";


            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/";
            TopicMagazzino += "/set";

            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_MAGAZZINO";
            TopicLaboratorio += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/";
            TopicServer += "/set";



            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLaboratorio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMagazzino, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicServer, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniSecondoPiano_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            Topic = "homeassistant/light/D2_BroadcastEVG";
            //Topic = Topic + (listBox2.SelectedItem as Dati).unique_id;


            Topic += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniMgazzino_Click(object sender, EventArgs e)
        {
            string TopicCorridioio;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicCorridioio = "homeassistant/light/R1_CORRIDOIO";
            TopicCorridioio += "/set";


            string TopicLaboratorio;
            TopicLaboratorio = "homeassistant/light/R1_LABORATORIO";
            TopicLaboratorio += "/set";

            string TopicMagazzino;
            TopicMagazzino = "homeassistant/light/R1_MAGAZZINO";
            TopicMagazzino += "/set";

            string TopicServer;
            TopicServer = "homeassistant/light/R1_SERVER";
            TopicServer += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicCorridioio, Encoding.UTF8.GetBytes(Messaggio));
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
            TopicSalaRiunioni = "homeassistant/light/D2_BARRALED_SALARINUONI";
            TopicSalaRiunioni += "/set";


            string TopicScrivaniaAurelio;
            TopicScrivaniaAurelio = "homeassistant/light/D2_SCRIVANIA_AURELIO";
            TopicScrivaniaAurelio += "/set";

            string TopicClaudioSopra;
            TopicClaudioSopra = "homeassistant/light/D2_SCRIVANIA_CLAUDIO_SOPRA";
            TopicClaudioSopra += "/set";

            string TopicClaudioSotto;
            TopicClaudioSotto = "homeassistant/light/D2_SCRIVANIA_CLAUDIO_SOTTO1";
            TopicClaudioSotto += "/set";

            string TopicClaudioSotto2;
            TopicClaudioSotto2 = "homeassistant/light/D2_SCRIVANIA_CLAUDIO_SOTTO2";
            TopicClaudioSotto2 += "/set";

            string Topic7;
            Topic7 = "homeassistant/light/7";
            Topic7 += "/set";

            string TopicFarettiAurelio;
            TopicFarettiAurelio = "homeassistant/light/D2_FARETTI_AURELIO";
            TopicFarettiAurelio += "/set";

            string TopicFarettiClaudio;
            TopicFarettiClaudio = "homeassistant/light/D2_FARETTI_CLAUDIO";
            TopicFarettiClaudio += "/set";


            string TopicCucina;
            TopicCucina = "homeassistant/light/R2_OUT18";
            TopicCucina += "/set";

            string TopicPareteLucernario;
            TopicPareteLucernario = "homeassistant/light/R2_LUCE_PARETE_LUCERNAIO";
            TopicPareteLucernario += "/set";

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicSalaRiunioni, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicScrivaniaAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSopra, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicClaudioSotto2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic7, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiAurelio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiClaudio, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicCucina, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPareteLucernario, Encoding.UTF8.GetBytes(Messaggio));
            }
        }

        private void btnSpegniReception_Click(object sender, EventArgs e)
        {
            string TopicReception;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicReception = "homeassistant/light/D2_BARRALED_RECEPTION";
            TopicReception += "/set";


            string TopicScrivaniaAnna;
            TopicScrivaniaAnna = "homeassistant/light/D2_SCRIVANIA_ANNA";
            TopicScrivaniaAnna += "/set";

            string TopicLedScrivania;
            TopicLedScrivania = "homeassistant/light/R2_LED_SCRIVANIA_RECEPTION";
            TopicLedScrivania += "/set";

            string TopicSalaQuadro;
            TopicSalaQuadro = "homeassistant/light/R2_LUCE_SALA_QUADRO";
            TopicSalaQuadro += "/set";

            string TopicPresaDirezione1;
            TopicPresaDirezione1 = "homeassistant/light/R2_PRESA_DIREZIONE1";
            TopicPresaDirezione1 += "/set";

            string TopicPresaDirezione2;
            TopicPresaDirezione2 = "homeassistant/light/R2_PRESA_DIREZIONE2";
            TopicPresaDirezione2 += "/set";

            string Topic18;
            Topic18 = "homeassistant/light/18";
            Topic18 += "/set";

            string Topic19;
            Topic19 = "homeassistant/light/19";
            Topic19 += "/set";


            string Topic20;
            Topic20 = "homeassistant/light/20";
            Topic20 += "/set";

            // FarettiReception
            string TopicR2_OUT19;
            TopicR2_OUT19 = "homeassistant/light/R2_OUT19";
            TopicR2_OUT19 += "/set";

            // 

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicReception, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicScrivaniaAnna, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicLedScrivania, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicSalaQuadro, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPresaDirezione1, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPresaDirezione2, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic18, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic19, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(Topic20, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicR2_OUT19, Encoding.UTF8.GetBytes(Messaggio));

            }
        }

        private void btnSpegniUffici_Click(object sender, EventArgs e)
        {
            string TopicGianluca;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            TopicGianluca = "homeassistant/light/D2_SCRIVANIA_GIANLUCA";
            TopicGianluca += "/set";


            string TopicMattia;
            TopicMattia = "homeassistant/light/D2_SCRIVANIA_MATTIA";
            TopicMattia += "/set";

            string TopicPaolo;
            TopicPaolo = "homeassistant/light/D2_SCRIVANIA_PAOLO";
            TopicPaolo += "/set";

            //D2_FARETTI_UFFICIO1_2

            string TopicFarettiMattiaPaolo;
            TopicFarettiMattiaPaolo = "homeassistant/light/D2_FARETTI_UFFICIO1_2";
            TopicFarettiMattiaPaolo += "/set";


            //    D2_FARETTI_UFFICIO3_4

            string TopicFarettiGianluca;
            TopicFarettiGianluca = "homeassistant/light/D2_FARETTI_UFFICIO3_4";
            TopicFarettiGianluca += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(TopicGianluca, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicMattia, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicPaolo, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiMattiaPaolo, Encoding.UTF8.GetBytes(Messaggio));
                mqttClient.Publish(TopicFarettiGianluca, Encoding.UTF8.GetBytes(Messaggio));
            }
           
        }
        #endregion


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
                listBox2.Invoke((MethodInvoker)(() => listBox2.Items.Add(dati)));
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


        #region "ImpostaLuminosita"
        private void btnImpostaLuminosita_Click(object sender, EventArgs e)
        {
            int Luminosita;
            Luminosita = Convert.ToInt32(txtValoreLuminosita.Text);
            trbLuminosita.Value = Luminosita;

            AfterMove();
        }

        private void btnImpostaValoreTrb_Click(object sender, EventArgs e)
        {
            int Luminosita;
            Luminosita = Convert.ToInt32(txtImpostaValoreTutteLuci.Text);
            trbImpostaLuminositaTutto.Value = Luminosita;

            AfterMove();
        }
        private void trbImpostaLuminositaTutto_ValueChanged(object sender, EventArgs e)
        {
            timer3.Stop();
            timer3.Start();

            label1.Text = Convert.ToString(trbImpostaLuminositaTutto.Value);
        }

        private void trbLuminosita_ValueChanged(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer1.Stop();
            timer1.Start();

            AfterMove();
        }


        #endregion


        #region "Timer"
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                //string json = JsonConvert.SerializeObject(DatiLuci);
                //List<Dati> DatiLuci = JsonConvert.DeserializeObject<List<Dati>>(ContenutoSerializzato);


                string Topic;
                string Messaggio;
                Messaggio = "{\"brightness\": " + trbLuminosita.Value +
                    ",\"state\": \"ON\"} ";
                Topic = "homeassistant/light/";
                Topic += (listBox2.SelectedItem as Dati).unique_id;
                Topic += "/set";
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
                timer1.Stop();

                timer2.Enabled = true;
            }
            else
            {
                string Topic;
                string Messaggio;
                Messaggio = "{\"brightness\": " + trbLuminosita.Value +
                    ",\"state\": \"ON\"} ";
                Topic = TopicSpecifico;
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
                timer1.Stop();

                timer2.Enabled = true;
            }


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                //Dati stato = TopicSpecifico;
                if (TopicSpecifico == null) return;

                int Trovato = listBox2.FindString(TopicSpecifico);
                if (Trovato == -1) return;
                Dati stato = listBox2.Items[Trovato] as Dati;

                if (stato.Curr_State == "OFF")
                {
                    DisattivaSpegni();
                    AttivaAccendi();
                }
                else
                {
                    AttivaSpegni();
                    DisattivaAccendi();
                }
                trbLuminosita.Value = stato.Curr_Brightness;
                timer1.Stop();

                timer2.Start();
                AfterMove();

            }
            else
            {
                Dati stato = listBox2.SelectedItem as Dati;

                if (stato.Curr_State == "OFF")
                {
                    DisattivaSpegni();
                    AttivaAccendi();
                }
                else
                {
                    AttivaSpegni();
                    DisattivaAccendi();
                }
                trbLuminosita.Value = stato.Curr_Brightness;
                timer1.Stop();

                timer2.Start();
                AfterMove();
            }
           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            listBox2_SelectedIndexChanged(this, null);
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"brightness\": " + trbImpostaLuminositaTutto.Value +
                ",\"state\": \"ON\"} ";
            Topic = "homeassistant/light/D2_BroadcastEVG";
            Topic += "/set";
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
            timer3.Stop();

        }

        #endregion


        #region "Salva - Carica - Elimina"
        private void button1_Click(object sender, EventArgs e)
        {
            // DatiLuci -> xml o json
            string ContenutoSerializzato = "";

            string json = JsonConvert.SerializeObject(DatiLuci);


            ContenutoSerializzato = json;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, ContenutoSerializzato);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ContenutoSerializzato = "";

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //Get the path of specified file
                //filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                string s = openFileDialog1.FileName;

                string NomeFile;

                // Cercare path su ibternet 
                NomeFile= Path.GetFileName(s);

                txtConfigurazione.Text = NomeFile;
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    ContenutoSerializzato = reader.ReadToEnd();
                }

                // ferma timer lettura mqtt
                timer2.Stop();

                // ContenutoSerializzato -> datiluci

                List<Dati> DatiLuci = JsonConvert.DeserializeObject<List<Dati>>(ContenutoSerializzato);

                // sparere su mqtt per ogni elementi diu datiluci on/off/luminosità
                foreach(Dati Dati in DatiLuci)
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

                // far partire timer
                timer2.Start();

            }
        }

        private void btnEliminaConfigurazione_Click(object sender, EventArgs e)
        {
            DialogResult Risposta;
            Risposta=MessageBox.Show("Sei sicuro?", "Elimina configurazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (Risposta == DialogResult.Yes) 
            {
                string path = "C:\\Users\\claudio.NOVABASE\\Desktop\\" + txtConfigurazione.Text;
                
                bool result = File.Exists(path);
                if (result == true)
                {
                    Console.WriteLine("File Found");
                    File.Delete(path);  
                    Console.WriteLine("File Deleted Successfully");
                    txtConfigurazione.Clear();
                }
                else
                {
                    Console.WriteLine("File Not Found");
                }
            }
        }

        #endregion
           
            
        #region "Sql"
        private void button3_Click(object sender, EventArgs e)
        {

            //Conn.ctx.configurazioni_luci.Where();

            /*
            List<Dati> SoloAccese = DatiLuci.Where(a => a.Curr_State == "on").ToList();
            List<Dati> SoloAcceseXNome = DatiLuci.Where(a => a.Curr_State == "on").OrderBy(a => a.name).ToList();
            List<Dati> SoloAcceseXNomeDiscendente = DatiLuci.Where(a => a.Curr_State == "on").OrderByDescending(a => a.name).ToList();
            */
            /*
            configurazioni_luci cl = Conn.ctx.configurazioni_luci.Where(a => a.Nome == "tutto acceso").FirstOrDefault();
            if (cl == null)
            {
            }*/

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
                //  string connString = ConfigurationManager.ConnectionStrings["GesQEntities"].ConnectionString;
                /*   MySqlConnection conn = new MySqlConnection(connString);
                      conn.Open();
                   /  MySqlCommand comm = conn.CreateCommand();
                      SqlCommand cmd = new SqlCommand();

                      cmd.CommandText = "INSERT INTO configurazioni_luci(Nome, Json) VALUES(?Nome, ?Json)";
                      cmd.Parameters.AddWithValue("?Nome", MySqlDbType.VarChar).Value = "Nome";
                      cmd.Parameters.AddWithValue("?Json", MySqlDbType.VarChar).Value = "Json";
                      comm.ExecuteNonQuery();
                      conn.Close();
                      */
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

        #endregion

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuovo_Click(object sender, EventArgs e)
        {
            // Istanzo un oggetto di tipo configurazione luci

            configurazioni_luci Configurazione = new configurazioni_luci();
            string text = "Inserisci nome";
            string caption = "";

            //string json = JsonConvert.SerializeObject(DatiLuci);

            Configurazione.Nome= ShowDialog(text, caption);
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
          
            //ferma timer lettura mqtt
            timer2.Stop();

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

            // far partire timer
            timer2.Start();

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

        private void button5_Click(object sender, EventArgs e)
        {
            frmMappa laMappa = new frmMappa();
            laMappa.Show();
        }

      
    }
}

