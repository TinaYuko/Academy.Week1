using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Entities
{
    public class Automobile: Veicolo
    {
        //Le automobili hanno:
        //- numero di posti
        public int Posti { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" - Posti: {Posti}";
        }
    }

   
}
