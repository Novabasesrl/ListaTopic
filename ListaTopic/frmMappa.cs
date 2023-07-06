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
using static GestioneLuci.frmMappa;
using static gesq3.DPI_check;

//using static GestioneLuci.Form1;


using System.Threading;
using Novabase.Framework.FileIni;
using Novabase.FrameworkNoGui;
using System.Reflection;

namespace GestioneLuci
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
            gesq3.DPI_check.Check((_Process_DPI_Awareness)clsFileIni.GetIniStringXml("DPI", 0));
            clsLogger.Zippa();
            this.Text = clsFileIni.GetIniStringXml("Applicazione.Nome", "Gestione Luci") + " - " + clsFileIni.GetIniStringXml("Cliente.Nome", "Novabase srl") + " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ControllaVersione(false);

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
            ucLuceDmitryUp.Tag = "D2_A021";
            ucLuceDmitryDown1.Tag = "D2_A022";
            ucLuceDmitryDown2.Tag = "D2_A023";
            ucLuceLucernario.Tag = "D2_A007";
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
            TuttiIBottoni.Add(ucLuceLucernario);
            TuttiIBottoni.Add(ucLuceDmitryUp);
            TuttiIBottoni.Add(ucLuceDmitryDown1);
            TuttiIBottoni.Add(ucLuceDmitryDown2);
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

            timer1.Start();

            Conn = new clsConn();

        }


        public void ControllaVersione(bool bAzzeraParametri)
        {
            AutoUpdate au = new AutoUpdate();
            string CommandLine = "";
            if (!clsFileIni.GetIniStringXml("AutoUpdate", false)) return;


            /*  if (clsFileIni.GetIniStringXml("AutoUpdate.Sql", false))
              {
                  // Prima cerca eventuali aggiornamenti del db.
                  clsGestoreAggiornamentoSql ga = clsGestoreAggiornamentoSql.IstanzaSingleton();
                  if (!ga.Aggiorna(Assembly.GetExecutingAssembly().GetName().Version.ToString()))
                  {
                      frmMiaMessage.Show(clsLingue.Traduci("STR_ERRORE_NEL_AGGIORNAMENTO_DAL_DB") + ga.GetErrori());
                  }
              }*/

            string sIndirizzoWeb =
                clsFileIni.GetIniStringXml("AutoUpdate.Indirizzo", "http://localhost:8080/webupdate/Updates/");

            if (bAzzeraParametri) GestioneLuci.Program.ParametriExe = new string[0];

            /*
            MessageBox.Show(au.VersioneDisponibile(ref CommandLine,
                sIndirizzoWeb,
                clsFileIni.GetIniStringXml("LinguaDefault", "Italiano.def"),
                clsFileIni.GetIniStringXml("AutoUpdate.Autenticazione.Utente", ""),
                clsFileIni.GetIniStringXml("AutoUpdate.Autenticazione.Password", ""),
                clsFileIni.GetIniStringXml("AutoUpdate.ForzaAggiornamento", true),
                gesq3.Program.ParametriExe), "");

            string sss = "";
            if (!au.CheckInternet(ref sss, "ooo.oo.oo")) MessageBox.Show("Internet KO: " + sss, "");

            sss = "";
            if (!au.CheckInternet( ref sss)) MessageBox.Show("Internet KO" + sss, "");

            if (!au.CheckInternet()) MessageBox.Show("Internet KO", "");

            */


            if (au.Go(ref CommandLine,
                sIndirizzoWeb,
                clsFileIni.GetIniStringXml("LinguaDefault", "Italiano.def"),
                clsFileIni.GetIniStringXml("AutoUpdate.Autenticazione.Utente", ""),
                clsFileIni.GetIniStringXml("AutoUpdate.Autenticazione.Password", ""),
                clsFileIni.GetIniStringXml("AutoUpdate.ForzaAggiornamento", true),
                GestioneLuci.Program.ParametriExe))
            {

                clsLogger.LogIt("CLIENT", "UPDATE DA " + sIndirizzoWeb);
                Environment.Exit(0);
            }
        }


        private void AggiornaTasto(Dati ilDato)
        {

            try
            {
                _AggiornaTasto(ilDato);
            }
            catch (Exception)
            {

                //throw;
            }


        }
        private void _AggiornaTasto(Dati ilDato)
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


        private void frmMappa_Load(object sender, EventArgs e)
        {
            frmGestioneSinglaLuce frm = InitForm1();

            mqttClient = new MqttClient("192.168.46.133", 1883, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect("Mappa");
            mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            mqttClient.ConnectionClosed += MqttClient_ConnectionClosed;
            // Rende la form a schermo intero 
            WindowState = FormWindowState.Maximized;
        }

        private void MqttClient_ConnectionClosed(object sender, EventArgs e)
        {
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

            pictureBox1.SendToBack();
            pictureBox2.SendToBack();


            double W = New_W;
            double H = New_H;

            New_W = pictureBox1.Size.Width;
            New_H = pictureBox1.Size.Height;


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
            ResizeUserControl(ucLuceDmitryUp, W, H);
            ResizeUserControl(ucLuceDmitryDown1, W, H);
            ResizeUserControl(ucLuceDmitryDown2, W, H);

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
            ResizeUserControl(ucLuceLucernario, W, H);




            // ---------------------------- LUCI BAGNO --------------------------------------

            ResizeUserControl(ucLuceAntiBagno, W, H);
            ResizeUserControl(ucLuceBagno, W, H);
            ResizeUserControl(ucLuceSpecchioBagno, W, H);
            ResizeUserControl(ucLuceFuoriBagno, W, H);
            ResizeUserControl(ucSpecchioAntiBagno, W, H);



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
            us.BringToFront();
            us.Visible = true;
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

        frmGestioneSinglaLuce frm;
        private void GestisciLuce(string NomeUniqueId, ucBottoneLuce ucBottone)
        {
            string TopicSalaRiunioni = $"homeassistant/light/{NomeUniqueId}";
            TopicSalaRiunioni += "/set";

            if (frm == null) frm = InitForm1();
            frm.TopicSpecifico = TopicSalaRiunioni;
            frm.TopMost = true;

            Dati dato = DatiLuci.Where(a => a.unique_id == (NomeUniqueId)).FirstOrDefault();
            frm.Luminosita = dato.Curr_Brightness;

            frm.Luce = dato.Curr_State;
            //if(frm.is)
            frm.ShowDialog();
            /*
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
            */
            // ucBottone.SetLuminosità(frm.Percentuale);
            // ucBottone.SetImmagine(Immagine);
        }

        private void btnVisualizzaComandi_Click(object sender, EventArgs e)
        {
            frmComandi frm = new frmComandi();

            frm.ShowDialog();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = mqttClient.IsConnected ? "CONNESSO" : "NON CONNESSO!";
            label1.BackColor = mqttClient.IsConnected ? Color.Lime : Color.Red;
            label1.ForeColor = mqttClient.IsConnected ? Color.Black : Color.White;
            label1.BringToFront();

            if (!mqttClient.IsConnected)
            {
                mqttClient.Connect("Mappa");
                mqttClient.Subscribe(new string[] { "homeassistant/light/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            }
        }

        private void frmMappa_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            mqttClient.Disconnect();
        }
    }
}
