using NoleggioAuto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Interfaces
{
    public interface INoleggioRepository : IRepository<Noleggio>
    {
        List<Noleggio> GetNoleggiAttivi();
        decimal CalcolaByTarga(string targa);
        decimal RicavaTotAuto();
    }
}
