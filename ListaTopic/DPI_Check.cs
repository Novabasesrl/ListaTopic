using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace gesq3
{
    

    public class DPI_check
    {
        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(_Process_DPI_Awareness value);

        public enum _Process_DPI_Awareness
        {
            Process_DPI_Unaware = 0,
            Process_System_DPI_Aware = 1,
            Process_Per_Monitor_DPI_Aware = 2
        }

        public static _Process_DPI_Awareness Attuale;

        public static void Check(_Process_DPI_Awareness def = _Process_DPI_Awareness.Process_DPI_Unaware)
        {
            //per evitare resize quando ingrandito font in windows e presente live chart o componente WPF
            if ((System.Environment.OSVersion.Version.Major > 6) ||
               ((System.Environment.OSVersion.Version.Major == 6) && (System.Environment.OSVersion.Version.Minor >= 2)))
            {
                SetProcessDpiAwareness(def);
                Attuale = def;
            }
        }
        public static _Process_DPI_Awareness Rotate()
        {

            if ((System.Environment.OSVersion.Version.Major > 6) ||
               ((System.Environment.OSVersion.Version.Major == 6) && (System.Environment.OSVersion.Version.Minor >= 2)))
            {
                if(Attuale== _Process_DPI_Awareness.Process_DPI_Unaware)
                {
                    Attuale = _Process_DPI_Awareness.Process_System_DPI_Aware;
                    SetProcessDpiAwareness(Attuale);
                    return Attuale;
                }
                if (Attuale == _Process_DPI_Awareness.Process_System_DPI_Aware)
                {
                    Attuale = _Process_DPI_Awareness.Process_Per_Monitor_DPI_Aware;
                    SetProcessDpiAwareness(Attuale);
                    return Attuale;
                }
                if (Attuale == _Process_DPI_Awareness.Process_Per_Monitor_DPI_Aware)
                {
                    Attuale = _Process_DPI_Awareness.Process_DPI_Unaware;
                    SetProcessDpiAwareness(Attuale);
                    return Attuale;
                }
            }
            return Attuale;

        }
    

}
}
