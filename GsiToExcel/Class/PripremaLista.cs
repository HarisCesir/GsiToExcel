using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsiToExcel.Class
{
   public class PripremaLista
    {
        public int ID { get; set; }
        public int IDZaGrid { get; set; }
        public string VeznaTacka { get; set; }
        public decimal OdstojanjeODLetve { get; set; }
        public decimal PrvaPodjela { get; set; }
        public decimal DrugaPodjela { get; set; }
        public decimal Proba { get; set; }
        public decimal SrednjaVisinskaRazlika { get; set; }
        public string ODDO { get; set; }
        public string OdakleJeuzeta { get; set; }
        public decimal SumaVisinskihRazlika { get; set; }
        public decimal SumaDuzina { get; set; }
        public string Oznaka { get; set; }
    }
}
