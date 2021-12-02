using Esercitazione_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Core.Entities
{
    internal class Box: Immobile 
    {
        public string Tipo { get; set; }

        public Box()
        {

        }
        public Box(int id, string indirizzo, int cap, string città, int superficie, bool available, string tipo)
            : base(id, indirizzo, cap, città, superficie, available)
        {
            Tipo= tipo;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Tipo: {Tipo}";
        }
    }
}
