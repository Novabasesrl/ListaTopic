#define VERSIOfffNE_CA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Objects;



namespace GestioneLuci
{
#if DEBUGSQL
    public class GesQEntitiesTraced : GesQEntities1
    {

        public GesQEntitiesTraced()  : base(EFTracingProviderUtils.CreateTracedEntityConnection("GesQEntities1"))
        {
        
            this.EnableTracing();
        }


    }

    public class clsConn
    {

        public GesQEntitiesTraced ctx;
        private bool m_bTraceAttivo = true;

        public bool TraceAttivo
        {
            get { return m_bTraceAttivo; }
            set { m_bTraceAttivo = value; }
        }

        public clsConn()
        {
            ctx = new GesQEntitiesTraced(); 
            TraceAttivo = true;
        }



        public bool Salva()
        {
             try
            {
                ctx.SaveChanges();
                return true;
            }
            catch (Exception Excp)
            {
                MessageBox.Show("Impossibile salvare : " + Excp.ToString(), "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
    }
#else


    public class clsConn
    {
        public GesQEntities ctx;

        public string EntityName()
        {
           return ctx.GetType().Name;
        }
            

        public clsConn()
        {
#if VERSIONE_CA
            ctx = new GesQEntities1(ConfigurationManager.ConnectionStrings["GesQEntities1CA"].ConnectionString);
#else
            ctx = new GesQEntities();
#endif
     
        

      }

      public void Reset()
        {
            ctx = null;
#if VERSIONE_CA
            ctx = new GesQEntities1(ConfigurationManager.ConnectionStrings["GesQEntities1CA"].ConnectionString);
#else
            ctx = new GesQEntities();
#endif
         

      }

        public bool Salva()
        {
            try
            {
                ctx.SaveChanges();
                return true;
            }
            catch (System.Data.OptimisticConcurrencyException ocException)
            {

                foreach (var objectStateEntry in ocException.StateEntries)
                    Console.WriteLine(objectStateEntry.GetType().Name);

                return false;
             /*   foreach (var objectStateEntry in ocException.StateEntries)
                    _Context.Refresh(System.Data.Objects.RefreshMode.StoreWins, objectStateEntry.Entity);*/
               // _Context.SaveChanges();
            }
            catch (Exception Excp)
            {
                MessageBox.Show("Impossibile salvare : " + Excp.ToString(), "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
#endif

}
