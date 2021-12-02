using NoleggioAuto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetByCode(string codFiscaleCliente);
    }
}
