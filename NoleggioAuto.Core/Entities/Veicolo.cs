using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Entities
{
    public class Veicolo
    {
        // I veicoli sono caratterizzati da:
        // - Targa
        // - Modello
        // - Tariffa giornaliera
        public string Targa { get; set; }
        public string Modello { get; set; }
        public decimal TariffaGiornaliera { get; set; }

        public Discriminatore Tipo { get; set; }

        public override string ToString()
        {
            return $"Veicolo di Targa: {Targa} - Modello: {Modello} - Tariffa giornaliera: {TariffaGiornaliera} euro";
        }

    }
    public enum Discriminatore
    {
        Automobile=1,
        Furgone=2
    }
}
