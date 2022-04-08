using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek6
{
    internal class Agente : Persona
    {
        public string AreaGeografica { get; set; }
        public int AnnoDiInizioAttivita { get; set; }
        public Agente()
        {

        }
        public Agente(string nome, string cognome, string codiceFiscaleDellAgente, string areaGeografica, int annoDiInizioAttivita )
            :base(codiceFiscaleDellAgente, nome, cognome)
        {
            AreaGeografica = areaGeografica;
            AnnoDiInizioAttivita = annoDiInizioAttivita;
        }
        public override string ToString()
        {
            return base.ToString() + $" Anni di servizio: {CalcolaAnniServizio()}";
        }
        public int CalcolaAnniServizio()
        {
            int anniDiServizio = DateTime.Now.Year - AnnoDiInizioAttivita;
            return anniDiServizio;
        }
    }
}
