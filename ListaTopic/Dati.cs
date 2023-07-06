using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLuci
{

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

        public bool Attivo { get; set; }

    }

    public class Stato
    {

        public int Brightness { get; set; }
        public string State { get; set; }

    }
}
