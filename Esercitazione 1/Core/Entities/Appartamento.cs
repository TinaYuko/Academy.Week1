using Esercitazione_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Core.Entities
{
    internal class Appartamento: Immobile
    {
        public int Stanza { get; set; }
        public int Bagno { get; set; }

        public Appartamento(int id, string indirizzo, int cap, string città, int superficie, bool available, int stanza, int bagno) 
            : base (id, indirizzo, cap, città, superficie, available)
        {
            Stanza = stanza;
            Bagno = bagno;
        }
        public Appartamento()
        {

        }
        public override string ToString()
        {
            return base.ToString() + $" - Numero Vani: {Stanza} - Numero Bagni: {Bagno}";

        }
    }
}
