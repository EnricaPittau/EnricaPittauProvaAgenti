using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek6
{
    internal abstract class Persona
    {
        public string CodiceFiscaleDellAgente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        
        public Persona()
        {
        }
        public Persona(string codiceFiscaleDellAgente, string nome, string cognome)
        {
            CodiceFiscaleDellAgente = codiceFiscaleDellAgente;
            Nome = nome;
            Cognome = cognome;
            
        }
        public override string ToString()
        {
            return $"CF: {CodiceFiscaleDellAgente} - Nome: {Nome} - Cognome: {Cognome}";
        }
    }
}
