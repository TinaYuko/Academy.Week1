
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1
{
    internal abstract class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età { get; set; }
        public abstract void IsAdult();
    }
}
