using NoleggioAuto.Core.Entities;
using NoleggioAuto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Mock.Repositories
{
    public class MockNoleggioRepository : INoleggioRepository
    {
        public bool Add(Noleggio item)
        {
            List<Noleggio> noleggi = MemoryStorage.noleggi;
            List<Veicolo> veicoli= MemoryStorage.veicoli;

            if (noleggi.Count == 0)
            {
                item.Id = 1;
            }
            else 
            {
                int maxId = 1;
                foreach (var n in noleggi)
                {
                    if (n.Id > maxId)
                    {
                        maxId = n.Id;
                    }
                }
                item.Id = maxId + 1;
            }

            foreach (var v in veicoli)
            {
                if (item.TargaVeicolo==v.Targa)
                {
                    item.CostoTot = (v.TariffaGiornaliera * item.Giorni);
                }
            }

            noleggi.Add(item);
            return true;


        }

        public decimal CalcolaByTarga(string targa)
        {
            decimal tot = 0;
            List<Noleggio> noleggi = MemoryStorage.noleggi;
            foreach (var item in noleggi)
            {
                if (item.TargaVeicolo==targa)
                {
                    tot = tot + item.CostoTot;
                }
            }
            return tot;
        }

        public bool Delete(Noleggio entity)
        {
            throw new NotImplementedException();
        }

        public List<Noleggio> GetAll()
        {
            List<Noleggio> noleggi = MemoryStorage.noleggi;
            return noleggi;

        }

        public Noleggio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Noleggio> GetNoleggiAttivi()
        {
            List<Noleggio> noleggi = MemoryStorage.noleggi;
            List<Noleggio> noleggiAttivi=new List<Noleggio>();
            foreach (var item in noleggi)
            {
                if (item.DataInizio<=DateTime.Today && item.DataInizio.AddDays(item.Giorni)>= DateTime.Today)
                {
                    noleggiAttivi.Add(item);
                }
            }
            return noleggiAttivi;
        }

        public decimal RicavaTotAuto()
        {
            decimal tot = 0;
            List<Noleggio> noleggi = MemoryStorage.noleggi;
            List<Veicolo> veicoli = MemoryStorage.veicoli;
            foreach (var item in veicoli)
            {
                if (item is Automobile)
                {
                    foreach (var n in noleggi)
                    {

                        if (item.Targa==n.TargaVeicolo)
                        {
                            tot += n.CostoTot;
                        }
                    }
                }
            }
            
            return tot;
        }

        public bool Update(Noleggio entity)
        {
            throw new NotImplementedException();
        }
    }
}
