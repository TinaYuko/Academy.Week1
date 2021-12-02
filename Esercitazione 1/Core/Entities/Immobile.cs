using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Entities
{
    /*.
    Gli immobili sono caratterizzati da un identificativo
    numerico, indirizzo, cap, città, da una superficie
    espressa in mq attraverso un numero intero e da un flag
    disponibile/non disponibile.
    L’agenzia gestisce diverse tipologie di immobili:
    Box, Appartamenti e Ville.
    */

   internal class Immobile
    {
        public int Id { get; set; }
        public string Indirizzo { get; set; }
        public int CAP { get; set; }
        public string Città { get; set; }
        public int Superficie { get; set; }
        public bool isAvailable { get; set; }

        //public Tipologia Tipologia { get; set; }

        public Immobile(int id, string indirizzo, int cap, string città, int superficie, bool available)
        {
            Id = id;
            Indirizzo = indirizzo;
            CAP = cap;
            Città = città;
            Superficie = superficie;
            isAvailable = available;
        }
        public Immobile()
        {

        }
        public override string ToString()
        {
            return $"Codice: {Id} - Immobile in via {Indirizzo} {CAP} {Città} - Superficie: {Superficie} m^2 " +
                $"- Disponibilità: {isAvailable}";
        }

    }

    //enum Tipologia
    //{
    //    Box=1,
    //    Appartamento=2,
    //    Villa=3
    //}
}
