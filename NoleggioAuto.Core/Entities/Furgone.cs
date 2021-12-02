using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Entities
{
    public class Furgone: Veicolo
    {
        //I furgoni hanno:
        //- capacità di carico espressa in kg.
        public int CapacitàCarico { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" - Capacità carico: {CapacitàCarico}kg";
        }
    }
}
