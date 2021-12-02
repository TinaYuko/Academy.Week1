using Esercitazione_1.Core.Entities;
using Esercitazione_1.Entities;
using Esercitazione_1.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Core.BusinessLayer
{
    internal class AgenziaBusinessLayer
    {
        private readonly ImmobileRepoMock repoMock;
        public AgenziaBusinessLayer(ImmobileRepoMock immobileRepoMock)
        {
            repoMock = immobileRepoMock;
        }

        internal List<Immobile> GetAll()
        {
            List<Immobile> immobili = repoMock.GetAll();
            return immobili;
        }

        internal List<Immobile> GetByMq(int supMin)
        {
            //List<Immobile> immobiliFiltrati= new List<Immobile>();
            //foreach (var item in repoMock.GetAll())
            //{
            //    if (item.Superficie>supMin)
            //    {
            //        immobiliFiltrati.Add(item);
            //    }
            //}
            //return immobiliFiltrati;

           var immobiliFiltrati2=repoMock.GetAll().Where(i=> i.Superficie>supMin).ToList();
            return immobiliFiltrati2;
        }

        internal List<Immobile> GetDisponibili()
        {
            //List<Immobile> disponibili = new List<Immobile>();
            //foreach (var item in repoMock.GetAll())
            //{
            //    if (item.isAvailable=true)
            //    {
            //        disponibili.Add(item);
            //    }
            //}
            //return disponibili;

            var disponibili2= repoMock.GetAll().Where(i=> i.isAvailable==true).ToList();
            return disponibili2;
        }


        internal List<Immobile> GetByCategory(int scelta)
        {
            List<Immobile> immobili = repoMock.GetByCategory(scelta);
            return immobili;
        }

        internal bool Delete(int codice)
        {
            return repoMock.Delete(codice);
        }

        internal bool CompraImmobile(int codice)
        {
            return repoMock.Buy(codice);
        }

        internal bool AddImmobile(Immobile i)
        {
            return repoMock.AddImmobile(i);
        }
    }
}
