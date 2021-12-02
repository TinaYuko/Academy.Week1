using NoleggioAuto.Core.Entities;
using NoleggioAuto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Mock.Repositories
{
    public class MockVeicoloRepository : IVeicoloRepository
    {
        public bool Add(Veicolo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Veicolo entity)
        {
            throw new NotImplementedException();
        }

        public List<Veicolo> GetAll()
        {
            List<Veicolo> veicoli = MemoryStorage.veicoli;
            return veicoli;
        }

        public Veicolo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Veicolo GetByTarga(string targaVeicolo)
        {
            List<Veicolo> veicoli = MemoryStorage.veicoli;
            foreach (var item in veicoli)
            {
                if (item.Targa==targaVeicolo)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Update(Veicolo entity)
        {
            throw new NotImplementedException();
        }

        public bool VerificaDisponibilità(string? targa, DateTime data)
        {
            List<Noleggio> noleggi= MemoryStorage.noleggi;
            foreach (var item in noleggi)
            {
                if (item.TargaVeicolo==targa && data >= item.DataInizio.AddDays(item.Giorni))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
