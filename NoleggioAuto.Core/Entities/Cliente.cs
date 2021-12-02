using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Entities
{
    public class Cliente
    {
        //Il cliente ha:
        //- Nome,
        //- Cognome,
        //- Codice fiscale

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodFiscale { get; set; }

        public override string ToString()
        {
            return $"Codice Fiscale: {CodFiscale} - Nominativo: {Nome} {Cognome}";
        }

    }
}
