using NoleggioAuto.Core.Entities;
using NoleggioAuto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Mock.Repositories
{
    public class MockClienteRepository : IClienteRepository
    {
        public bool Add(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetByCode(string codFiscaleCliente)
        {
            List<Cliente> cliente = MemoryStorage.clienti;
            foreach (var item in cliente)
            {
                if (item.CodFiscale==codFiscaleCliente)
                {
                    return item;
                }
            }
            return null;
        
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
