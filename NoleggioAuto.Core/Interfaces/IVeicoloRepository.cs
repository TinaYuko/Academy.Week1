using NoleggioAuto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Interfaces
{
    public interface IVeicoloRepository : IRepository<Veicolo>
    {
        Veicolo GetByTarga(string targaVeicolo);
        bool VerificaDisponibilità(string? targa, DateTime data);
    }
}
