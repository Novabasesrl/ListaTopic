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
using System.Threading;

namespace GestioneLuci
{
    public partial class frmGestioneConfigurazioni : Form
    {


        clsConn Conn ;
        List<configurazioni_luci> Lista = new List<configurazioni_luci> ();


        public frmGestioneConfigurazioni()
        {
            InitializeComponent();
            Conn = new clsConn();
        }

        public string TopicSpecifico;
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
            listBox2.Items.Clear();
            foreach(Dati ilDato in DatiLuci) listBox2.Items.Add(ilDato);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived -= MqttClient_MqttMsgPublishReceived;
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            //mqttClient.Connect("Test");
            //mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

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

            if (Luce == "OFF")
            {
                AttivaAccendi();
                DisattivaSpegni();
            }
            else
            {
                AttivaSpegni();
                DisattivaAccendi();
            }
            trbLuminosita.Value = Luminosita;
            timer1.Stop();

            timer2.Start();
            AfterMove();
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
                Topic = TopicSpecifico;

                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }

                trbLuminosita.Value = 100;
                timer1.Stop();

            }
            //homeassistant / light / 
            StatoLuce = "ON";
            DisattivaAccendi();
            AttivaSpegni();
            AfterMove();

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
                Topic = TopicSpecifico;
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(Messaggio));
                }
                trbLuminosita.Value = 0;
                timer1.Stop();

            }
            StatoLuce = "OFF";
            AttivaAccendi();
            DisattivaSpegni();
            AfterMove();
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



        #endregion


        #region "ImpostaLuminosita"
        private void btnImpostaLuminosita_Click(object sender, EventArgs e)
        {
            int Luminosita;
            Luminosita = Convert.ToInt32(txtValoreLuminosita.Text);
            trbLuminosita.Value = Luminosita;

            AfterMove();
        }

        private void trbLuminosita_ValueChanged(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer1.Stop();
            timer1.Start();
            if (btnSpegni.Enabled == false)
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

        #endregion


        #region "Salva - Modifica - Elimina"
        private void btnSalvaConfigurazione_Click(object sender, EventArgs e)
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

        private void btnCaricaFileConfigurazione_Click(object sender, EventArgs e)
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
                NomeFile = Path.GetFileName(s);

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

            }
        }

        private void btnEliminaConfigurazione_Click(object sender, EventArgs e)
        {
            DialogResult Risposta;
            Risposta = MessageBox.Show("Sei sicuro?", "Elimina configurazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

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











    }
}

