using NoleggioAuto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Interfaces
{
    public interface IBusinessLayer
    {
        List<Veicolo> GetAllVeicoli();
        List<Cliente> GetAllClienti();
        List<Noleggio> GetAllNoleggi();
        Cliente GetClienteByCF(string codFiscaleCliente);
        Veicolo GetVeicoloByTarga(string targaVeicolo);
        List<Noleggio> GetNoleggiAttivi();
        bool VerificaDisponibilitàAuto(string? targa, DateTime data);
        bool AggiungiNoleggio(Noleggio noleggio);
        decimal CalcolaTotByTarga(string targa);
        decimal RicavaTotAuto();
    }
}
