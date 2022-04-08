using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek6
{
    internal interface IRepositoryGestioneAgenti
    {
        void GetAllAgenti();//Mostrare tutti gli agenti di polizia
        void GetAgenteByArea(string areaGeografica);//Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
        void GetAgenteByAnniServizio(int anniServizio);//Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input

        void InsertNewAgente(string codiceFiscaleDellAgente, string nome, string cognome, string areaGeografica, int annoDiInizioAttivita);//Inserire un nuovo agente solo se non è già presente nel database
    }
}
