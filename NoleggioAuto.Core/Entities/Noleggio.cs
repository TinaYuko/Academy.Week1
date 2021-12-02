using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Entities
{
    public class Noleggio
    {
        //Il noleggio ha:
        //- Id (identificativo)
        //- Data di inizio,
        //- Numero di giorni
        //- Costo totale,
        //- Codice fiscale del Cliente,
        //- Targa del Veicolo

        public int Id { get; set; }
        public DateTime DataInizio{ get; set; }
        public int Giorni { get; set; }
        public decimal CostoTot { get; set; }
        public string CodFiscaleCliente { get; set; }
        public string TargaVeicolo { get; set; }
        public override string ToString()
        {
            return $"\nNoleggio n°: {Id} - Iniziato il {DataInizio.ToShortDateString()} per un durata di {Giorni}gg \n- Fattura da {CostoTot} euro " +
                $"emessa per {CodFiscaleCliente} \n- Targa Veicolo: {TargaVeicolo}";
        }
    }
}
