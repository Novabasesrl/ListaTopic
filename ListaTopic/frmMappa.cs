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

        private double Window_W = 0;
        private double Window_H = 0;

        private bool m_bEvitaResize = false;
        //public string Percentuale;


        clsConn Conn;
        List<configurazioni_luci> Lista = new List<configurazioni_luci>();
        List<ucBottoneLuce> TuttiIBottoni = new List<ucBottoneLuce>();

        public frmMappa()
        {
            //gesq3.DPI_check.Check((_Process_DPI_Awareness)clsFileIni.GetIniStringXml("DPI", 0));
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


            Window_W = this.Width;
            Window_H = this.Height;

            // Aggiungi tutti
            TuttiIBottoni_Add(ucLuceMagazzino);
            TuttiIBottoni_Add(ucLuceLaboratorio);
            TuttiIBottoni_Add(ucLuceServer);
            TuttiIBottoni_Add(ucLuceCorridoioMagazzino);
            TuttiIBottoni_Add(ucLuceBagnoMagazzino);


            // Aggiungi tutti
            TuttiIBottoni_Add(ucLuceLedSalaRiunioni);
            TuttiIBottoni_Add(ucLuceLampadario);
            TuttiIBottoni_Add(ucLuceCucina);
            TuttiIBottoni_Add(ucFarettiAurelio);
            TuttiIBottoni_Add(ucScrivaniaAurelio);
            TuttiIBottoni_Add(ucClaudioSopra);
            TuttiIBottoni_Add(ucClaudioSotto1);
            TuttiIBottoni_Add(ucClaudioSotto2);
            TuttiIBottoni_Add(ucFarettiClaudio);
            TuttiIBottoni_Add(ucFarettiUffici12);
            TuttiIBottoni_Add(ucFarettiUffici34);
            TuttiIBottoni_Add(ucScrivaniaGianluca);
            TuttiIBottoni_Add(ucLuceLucernario);
            TuttiIBottoni_Add(ucLuceDmitryUp);
            TuttiIBottoni_Add(ucLuceDmitryDown1);
            TuttiIBottoni_Add(ucLuceDmitryDown2);
            TuttiIBottoni_Add(ucScrivaniaMattia);
            TuttiIBottoni_Add(ucScrivaniaPaolo);
            TuttiIBottoni_Add(ucLedReception);
            TuttiIBottoni_Add(ucLuciScrivaniaStampanteAnna);
            TuttiIBottoni_Add(ucScrivaniaAnna);
            TuttiIBottoni_Add(ucScrivaniaDoraSopra);
            TuttiIBottoni_Add(ucScrivaniaDoraSotto);
            TuttiIBottoni_Add(ucScrivaniaDoraSotto2);
            TuttiIBottoni_Add(ucFarettiLedReception);
            TuttiIBottoni_Add(ucLuceAscensore);
            TuttiIBottoni_Add(ucLuceSalaQuadro);
            TuttiIBottoni_Add(ucFioriera);
            TuttiIBottoni_Add(ucLuceLedScale);
            TuttiIBottoni_Add(ucLuceAntiBagno);
            TuttiIBottoni_Add(ucLuceBagno);
            TuttiIBottoni_Add(ucLuceSpecchioBagno);
            TuttiIBottoni_Add(ucLuceFuoriBagno);
            TuttiIBottoni_Add(ucSpecchioAntiBagno);
            

            foreach (Control uu in TuttiIBottoni)
            {
      //          uu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            }



            m_bEvitaResize = false;

            timer1.Start();

            Conn = new clsConn();

        }

        private void TuttiIBottoni_Add(ucBottoneLuce bl)
        {

            bl.Tag = new Tuple<double, double>( bl.Location.X / Window_W, bl.Location.Y / Window_H);
            TuttiIBottoni.Add(bl);
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
           // WindowState = FormWindowState.Maximized;
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



            // ------------------------- LUCI SALA RIUNIONI ---------------------------------

            ResizeUserControl(ucLuceLedSalaRiunioni);
            ResizeUserControl(ucLuceLampadario);
            ResizeUserControl(ucLuceCucina);

            ResizeUserControl(ucFarettiAurelio);
            ResizeUserControl(ucScrivaniaAurelio);
            ResizeUserControl(ucClaudioSopra);
            ResizeUserControl(ucClaudioSotto1);
            ResizeUserControl(ucClaudioSotto2);
            ResizeUserControl(ucFarettiClaudio);


            // ------------------------- LUCI UFFICIO TECNICO ---------------------------

            ResizeUserControl(ucFarettiUffici12);
            ResizeUserControl(ucFarettiUffici34);
            ResizeUserControl(ucScrivaniaGianluca);
            ResizeUserControl(ucLuceDmitryUp);
            ResizeUserControl(ucLuceDmitryDown1);
            ResizeUserControl(ucLuceDmitryDown2);

            ResizeUserControl(ucScrivaniaMattia);
            ResizeUserControl(ucScrivaniaPaolo);



            // --------------------------- LUCI RECEPTION -------------------------------

            ResizeUserControl(ucLedReception);
            ResizeUserControl(ucLuciScrivaniaStampanteAnna);
            ResizeUserControl(ucScrivaniaAnna);
            ResizeUserControl(ucScrivaniaDoraSopra);
            ResizeUserControl(ucScrivaniaDoraSotto);
            ResizeUserControl(ucScrivaniaDoraSotto2);
            ResizeUserControl(ucFarettiLedReception);
            ResizeUserControl(ucLuceAscensore);
            ResizeUserControl(ucLuceSalaQuadro);
            ResizeUserControl(ucFioriera);
            ResizeUserControl(ucLuceLedScale);
            ResizeUserControl(ucLuceLucernario);




            // ---------------------------- LUCI BAGNO --------------------------------------

            ResizeUserControl(ucLuceAntiBagno);
            ResizeUserControl(ucLuceBagno);
            ResizeUserControl(ucLuceSpecchioBagno);
            ResizeUserControl(ucLuceFuoriBagno);
            ResizeUserControl(ucSpecchioAntiBagno);



            // ------------------------ LUCI MAGAZZINO ---------------------------

            ResizeUserControl(ucLuceMagazzino);
            ResizeUserControl(ucLuceLaboratorio);
            ResizeUserControl(ucLuceServer);
            ResizeUserControl(ucLuceCorridoioMagazzino);
            ResizeUserControl(ucLuceBagnoMagazzino);


        }


        private void ResizeUserControl(UserControl us)
        {
            double New_X = this.Width * ((Tuple<double, double>)us.Tag).Item1;
            double New_Y = this.Height * ((Tuple<double, double>)us.Tag).Item2;

            us.Location = new Point((int)New_X, (int)New_Y);
            us.BringToFront();
            us.Visible = true;
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
