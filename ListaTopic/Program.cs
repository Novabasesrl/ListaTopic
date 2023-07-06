using Novabase.FrameworkNoGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneLuci
{
    internal static class Program
    {
        public static string[] ParametriExe;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] argc)
        {
            ParametriExe = argc;

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMappa());
        }


        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                clsLogger.LogIt("Application_ThreadException", "Unhandled Exception:\n\n" +
                                                         ex.Message + "\n\n" +
                                                         ex.GetType() +
                                                         "\n\nStack Trace:\n" +
                                                         ex.StackTrace + "\n\n" +
                                                         ex.ToString());
            }
            catch (Exception)
            {
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            try
            {

                Exception ex = (Exception)e.ExceptionObject;
                clsLogger.LogIt("CurrentDomain_UnhandledException", "Unhandled Exception:\n\n" +
                                                         ex.Message + "\n\n" +
                                                         ex.GetType() +
                                                         "\n\nStack Trace:\n" +
                                                         ex.StackTrace + "\n\n" +
                                                         ex.ToString());
            }
            catch (Exception)
            {
            }
        }
    }
}
