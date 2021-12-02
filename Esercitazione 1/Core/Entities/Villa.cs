using Esercitazione_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Core.Entities
{
    internal class Villa: Appartamento 
    {
        public int Piano { get; set; }
        public bool Giardino { get; set; }
        public bool Piscina { get; set; }

        public Villa()
        {

        }
        public Villa(int id, string indirizzo, int cap, string città, int superficie, bool available, int stanza, int bagno, int piano, bool giardino, bool piscina ) 
            : base (id, indirizzo, cap, città, superficie, available, stanza, bagno)
        {
            Piano = piano;
            Giardino = giardino;
            Piscina = piscina;
        }
        public override string ToString()
        {
            return base.ToString() + $" - Numero Piani: {Piano} - Giardino: {Giardino} - Piscina: {Piscina}";
        }
    }
}
