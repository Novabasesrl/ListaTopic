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
using static GestioneLuci.frmGestioneSinglaLuce;
using System.Threading;

namespace GestioneLuci
{
    public partial class frmGestioneSinglaLuce : Form
    {


        clsConn Conn ;
        List<configurazioni_luci> Lista = new List<configurazioni_luci> ();


        public frmGestioneSinglaLuce()
        {
            InitializeComponent();
            Conn = new clsConn();
        }

        private string m_sTopicSpecifico;
        public string TopicSpecifico {
            get { return m_sTopicSpecifico; }
            set { m_sTopicSpecifico = value;
                this.Text = $"Punto luce - {m_sTopicSpecifico}";
            }
        }

        public int Percentuale;
        public string StatoLuce;
        public string Luce;
        public int Luminosita;

        //public configurazioni_luci GetDatiSelezionati()
        //{
        //    foreach (int i in gvConfigurazioni.GetSelectedRows())
        //    {
        //        configurazioni_luci so = (configurazioni_luci)gvConfigurazioni.GetRow(i);
        //        if (so != null)
        //        {
        //            return so;
        //        }
        //    }

        //    return null;
        //}

        public void Init(MqttClient _mqttClient, List<Dati> _DatiLuci, List<configurazioni_luci> _ConfigLuci)
        {
            mqttClient = _mqttClient;
            DatiLuci = _DatiLuci;
            Lista = _ConfigLuci;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived -= MqttClient_MqttMsgPublishReceived;
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            //mqttClient.Connect("Test");
            //mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });


            lblLuminosita.BringToFront();

            if (Luce == "OFF")
            {
                AttivaAccendi();
                DisattivaSpegni();
                imgAcceso.Visible = false;
                imgSpento.Visible = true;
            }
            else
            {
                AttivaSpegni();
                DisattivaAccendi();
                imgAcceso.Visible = true;
                imgSpento.Visible = false;
            }
            trbLuminosita.Value = Luminosita;
            timer1.Stop();

            AfterMove();
        }

        private void AfterMove()
        {
            lblLuminosita.Text = Convert.ToString(trbLuminosita.Value) + "%";
            Percentuale = trbLuminosita.Value;
        }

        private void DisattivaSpegni()
        {
            btnSpegnimi.Visible = false;
            trbLuminosita.Enabled = btnSpegnimi.Visible;
            lblLuminosita.Enabled = btnSpegnimi.Visible;

        }

        private void AttivaSpegni()
        {
            btnSpegnimi.Visible = true;
            trbLuminosita.Enabled = btnSpegnimi.Visible;
            lblLuminosita.Enabled = btnSpegnimi.Visible;
        }

        private void DisattivaAccendi()
        {
            btnAccendimi.Visible = false;
        }

        private void AttivaAccendi()
        {
            btnAccendimi.Visible = true;
        }
            

        #region "Accendi - Spegni"
        private void btnAccendi_Click(object sender, EventArgs e)
        {
        }




        private void btnSpegni_Click(object sender, EventArgs e)
        {

        }


            #endregion


            #region "Mqtt"
            MqttClient mqttClient;
    
        private List<Dati> DatiLuci = new List<Dati>();

        private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            if (e.Topic.EndsWith("config"))
            {
               
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


        #region "ImpostaLuminosita"
 
        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            if (btnSpegnimi.Visible == false)
            {
                AttivaSpegni();
                DisattivaAccendi();
            }

            AfterMove();
        }


        #endregion


        #region "Timer"
        private void timer1_Tick(object sender, EventArgs e)
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
        }


        #endregion

        private void btnAccendimi_Click(object sender, EventArgs e)
        {

            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"ON\"}";
            Topic = TopicSpecifico;

            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }

            trbLuminosita.Value = 100;
            timer1.Stop();


            //homeassistant / light / 
            StatoLuce = "ON";
            DisattivaAccendi();
            AttivaSpegni();
            AfterMove();

            imgAcceso.Visible = true;
            imgSpento.Visible = false;


        }

        private void btnSpegnimi_Click(object sender, EventArgs e)
        {
            string Topic;
            string Messaggio;
            Messaggio = "{\"state\": \"OFF\"}";
            Topic = TopicSpecifico;
            if (mqttClient != null && mqttClient.IsConnected)
            {
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
            }
            trbLuminosita.Value = 0;
            timer1.Stop();


            StatoLuce = "OFF";
            AttivaAccendi();
            DisattivaSpegni();
            AfterMove();
            imgAcceso.Visible = false;
            imgSpento.Visible = true;

        }
    }
}

