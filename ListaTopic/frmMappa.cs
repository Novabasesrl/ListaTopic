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
        List<ucBottoneLuce> TuttiIBottoni = new List<ucBottoneLuce>();

        public frmMappa()
        {
            m_bEvitaResize = true;

            InitializeComponent();

            ucLuceLedSalaRiunioni.Tag = "D2_A002";
            ucLuceLampadario.Tag = "R2_A011";
            ucLuceCucina.Tag = "R2_A018";
            ucFarettiAurelio.Tag = "D2_A011";
            ucScrivaniaAurelio.Tag = "D2_A008";
            ucClaudioSopra.Tag = "D2_A015";
            ucClaudioSotto1.Tag = "D2_A016";
            ucClaudioSotto2.Tag = "D2_A017";
            ucFarettiClaudio.Tag = "D2_A012";
            ucFarettiUffici12.Tag = "D2_A009";
            ucFarettiUffici34.Tag = "D2_A010";
            ucScrivaniaGianluca.Tag = "D2_A003";
            ucScrivaniaMattia.Tag = "D2_A005";
            ucScrivaniaPaolo.Tag = "D2_A004";
            ucLedReception.Tag = "D2_A001";
            ucLuciScrivaniaStampanteAnna.Tag = "R2_A017";
            ucScrivaniaAnna.Tag = "D2_A013";
            ucScrivaniaDoraSopra.Tag = "D2_A018";
            ucScrivaniaDoraSotto.Tag = "D2_A019";
            ucScrivaniaDoraSotto2.Tag = "D2_A020";
            ucFarettiLedReception.Tag = "R2_A019";
            ucLuceAscensore.Tag = "R2_A012";
            ucLuceSalaQuadro.Tag = "R2_A014";
            ucFioriera.Tag = "R2_A016";
            ucLuceLedScale.Tag = "D2_A006";
            ucLuceAntiBagno.Tag = "R2_A020";
            ucLuceBagno.Tag = "R2_A021";
            ucLuceSpecchioBagno.Tag = "R2_A022";
            ucLuceFuoriBagno.Tag = "R2_A024";
            ucSpecchioAntiBagno.Tag = "R2_A023";

            // Aggiungi tutti
            TuttiIBottoni.Add(ucLuceLedSalaRiunioni);

            TuttiIBottoni.Add(ucLuceLampadario);

            TuttiIBottoni.Add(ucLuceCucina);

            TuttiIBottoni.Add(ucFarettiAurelio);

            TuttiIBottoni.Add(ucScrivaniaAurelio);

            TuttiIBottoni.Add(ucClaudioSopra);

            TuttiIBottoni.Add(ucClaudioSotto1);

            TuttiIBottoni.Add(ucClaudioSotto2);

            TuttiIBottoni.Add(ucFarettiClaudio);

            TuttiIBottoni.Add(ucFarettiUffici12);

            TuttiIBottoni.Add(ucFarettiUffici34);

            TuttiIBottoni.Add(ucScrivaniaGianluca);

            TuttiIBottoni.Add(ucScrivaniaMattia);

            TuttiIBottoni.Add(ucScrivaniaPaolo);

            TuttiIBottoni.Add(ucLedReception);

            TuttiIBottoni.Add(ucLuciScrivaniaStampanteAnna);

            TuttiIBottoni.Add(ucScrivaniaAnna);

            TuttiIBottoni.Add(ucScrivaniaDoraSopra);

            TuttiIBottoni.Add(ucScrivaniaDoraSotto);

            TuttiIBottoni.Add(ucScrivaniaDoraSotto2);

            TuttiIBottoni.Add(ucFarettiLedReception);

            TuttiIBottoni.Add(ucLuceAscensore);

            TuttiIBottoni.Add(ucLuceSalaQuadro);

            TuttiIBottoni.Add(ucFioriera);

            TuttiIBottoni.Add(ucLuceLedScale);

            TuttiIBottoni.Add(ucLuceAntiBagno);

            TuttiIBottoni.Add(ucLuceBagno);

            TuttiIBottoni.Add(ucLuceSpecchioBagno);

            TuttiIBottoni.Add(ucLuceFuoriBagno);

            TuttiIBottoni.Add(ucSpecchioAntiBagno);


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

            if(ilBottone==null)
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


        private void frmMappa_Load(object sender, EventArgs e)
        {
            Form1 frm = InitForm1();


            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Test");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            // Rende la form a schermo intero 
            WindowState = FormWindowState.Maximized;

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


        private void frmMappa_Resize(object sender, EventArgs e)
        {
            if (m_bEvitaResize) return;

            double W = New_W;
            double H = New_H;
            
            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;


            // ---------------------- BOTTONE ---------------------

            ResizeButton(btnVisualizzaComandi, W, H);
            ResizeButton(btnPianoInferiore, W, H);





            // ------------------------- LUCI SALA RIUNIONI ---------------------------------

            ResizeUserControl(ucLuceLedSalaRiunioni, W, H);

            ResizeUserControl(ucLuceLampadario, W, H);

            ResizeUserControl(ucLuceCucina, W, H);

            ResizeUserControl(ucFarettiAurelio, W, H);
            ResizeUserControl(ucScrivaniaAurelio, W, H);
            ResizeUserControl(ucClaudioSopra, W, H);
            ResizeUserControl(ucClaudioSotto1, W, H);
            ResizeUserControl(ucClaudioSotto2, W, H);
            ResizeUserControl(ucFarettiClaudio, W, H);


            // ------------------------- LUCI UFFICIO TECNICO ---------------------------

            ResizeUserControl(ucFarettiUffici12, W, H);
            ResizeUserControl(ucFarettiUffici34, W, H);
            ResizeUserControl(ucScrivaniaGianluca, W, H);
            ResizeUserControl(ucScrivaniaMattia, W, H);
            ResizeUserControl(ucScrivaniaPaolo, W, H);



            // --------------------------- LUCI RECEPTION -------------------------------

            ResizeUserControl(ucLedReception, W, H);
            ResizeUserControl(ucLuciScrivaniaStampanteAnna, W, H);
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

        private void ResizeButton(System.Windows.Forms.Button btn, double W, double H)
        {
            double X = btn.Location.X;
            double Y = btn.Location.Y;

            double New_X = (New_W / W) * X;
            double New_Y = (New_H / H) * Y;

            btn.Location = new Point((int)New_X, (int)New_Y);
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

            ucBottone.SetLuminosità(frm.Percentuale);
            ucBottone.SetImmagine(Immagine);
        }

        private void btnVisualizzaComandi_Click(object sender, EventArgs e)
        {
            frmComandi frm = new frmComandi();

            frm.ShowDialog();
        }

        

        private void btnPianoInferiore_Click(object sender, EventArgs e)
        {
            frmMagazzino frm = new frmMagazzino();
            frm.ShowDialog();
            this.Close();
        }
    }
}
