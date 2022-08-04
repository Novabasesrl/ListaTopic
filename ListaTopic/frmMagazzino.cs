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
using static ListaTopic.frmMagazzino;
using System.Threading;


namespace ListaTopic
{
    public partial class frmMagazzino : Form
    {



        private double New_W = 0;
        private double New_H = 0;

        private bool m_bEvitaResize = false;

        clsConn Conn;
        List<configurazioni_luci> Lista = new List<configurazioni_luci>();
        List<ucBottoneLuce> TuttiIBottoni = new List<ucBottoneLuce>();


        public frmMagazzino()
        {
            InitializeComponent();

            m_bEvitaResize = true;

            InitializeComponent();


            ucLuceMagazzino.Tag = "R1_A050";
            ucLuceLaboratorio.Tag = "R1_A049";
            ucLuceServer.Tag = "R1_A051";
            ucLuceCorridoioMagazzino.Tag = "R1_A052";
            ucLuceBagnoMagazzino.Tag = "R1_A053";


            // Aggiungi tutti
            TuttiIBottoni.Add(ucLuceMagazzino);
            TuttiIBottoni.Add(ucLuceLaboratorio);
            TuttiIBottoni.Add(ucLuceServer);
            TuttiIBottoni.Add(ucLuceCorridoioMagazzino);
            TuttiIBottoni.Add(ucLuceBagnoMagazzino);

            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;

            m_bEvitaResize = false;

            Conn = new clsConn();
        }

        private void AggiornaTasto(Dati ilDato)
        {
            //ucBottoneLuce ilBottone = TuttiIBottoni.Where(uniquieid = ilDato.unique_id).first;
            //ucBottoneLuce ilBottone = TuttiIBottoni.Where(TuttiIBottoni.ToList(Tag) = ilDato.unique_id).first;

            List<ucBottoneLuce> lstBott = TuttiIBottoni.Where(a => a.Tag == null).ToList();

            ucBottoneLuce ilBottone = TuttiIBottoni.Where(a => a.Tag.ToString() == ilDato.unique_id).FirstOrDefault();

            if (ilBottone == null)
            {
                Console.WriteLine($"Il Bottone con unique_id:{ilDato.unique_id} non è stato trovato!");
                return;
            }

            ilBottone.Invoke((MethodInvoker)(() =>
            {
                ilBottone.SetLuminosità(ilDato.Curr_Brightness);
                ilBottone.SetImmagine(ilDato.Curr_State == "ON" ? true : false);
            }));
        }



        private void frmMagazzino_Load(object sender, EventArgs e)
        {
            Form1 frm = InitForm1();


            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Magazzino");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            // Rende la form a schermo intero 
            WindowState = FormWindowState.Maximized;

            ucLuceMagazzino.BringToFront();
            ucLuceLaboratorio.BringToFront();
            ucLuceServer.BringToFront();
            ucLuceCorridoioMagazzino.BringToFront();
            ucLuceBagnoMagazzino.BringToFront();

            btnPianoSuperiore.BringToFront();
            btnPianoInferiore.BringToFront();

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

                // Aggiorna ogni tasto
                AggiornaTasto(dati);
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


                    // Aggiorna il tasto relativo
                    AggiornaTasto(luce);

                }
                else
                {
                    Console.WriteLine(id);
                }

            }
        }

        #endregion


        private void frmMagazzino_Resize(object sender, EventArgs e)
        {
            if (m_bEvitaResize) return;

            double W = New_W;
            double H = New_H;

            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;


            // ---------------------- BOTTONE ---------------------

            ResizeButton(btnPianoSuperiore, W, H);
            ResizeButton(btnPianoInferiore, W, H);


            // ------------------------ LUCI MAGAZZINO ---------------------------

            ResizeUserControl(ucLuceMagazzino, W, H);
            ResizeUserControl(ucLuceLaboratorio, W, H);
            ResizeUserControl(ucLuceServer, W, H);
            ResizeUserControl(ucLuceCorridoioMagazzino, W, H);
            ResizeUserControl(ucLuceBagnoMagazzino, W, H);

        }


        private void ResizeUserControl(UserControl us, double W, double H)
        {
            double X = us.Location.X;
            double Y = us.Location.Y;

            double New_X = (New_W / W) * X;
            double New_Y = (New_H / H) * Y;

            us.Location = new Point((int)New_X, (int)New_Y);
        }


        private void ResizeButton(System.Windows.Forms.Button btn, double W, double H)
        {
            double X = btn.Location.X;
            double Y = btn.Location.Y;

            double New_X = (New_W / W) * X;
            double New_Y = (New_H / H) * Y;

            btn.Location = new Point((int)New_X, (int)New_Y);
        }


        private void ucLuceMagazzino_Click(object sender, EventArgs e)
        {
            GestisciLuce(((ucBottoneLuce)sender).Tag.ToString(), (ucBottoneLuce)sender);
        }


        private void GestisciLuce(string NomeUniqueId, ucBottoneLuce ucBottone)
        {
            string TopicMagazzino = $"homeassistant/light/{NomeUniqueId}";
            TopicMagazzino += "/set";

            Form1 frm = InitForm1();
            frm.TopicSpecifico = TopicMagazzino;



            Dati dato = DatiLuci.Where(a => a.unique_id == (NomeUniqueId)).FirstOrDefault();
            frm.Luminosita = dato.Curr_Brightness;

            frm.Luce = dato.Curr_State;


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

            //ucBottone.SetLuminosità(frm.Percentuale);
            //ucBottone.SetImmagine(Immagine);
        }


        #region "Navigatore"

        private void btnPianoSuperiore_Click(object sender, EventArgs e)
        {

            frmMappa frm = new frmMappa();
            frm.ShowDialog();
            this.Close();

        }

        private void btnPianoInferiore_Click(object sender, EventArgs e)
        {
            //frmMappa frm = new frmMappa();
            //frm.ShowDialog();
            //this.Close();
        }



        #endregion
    }
}
