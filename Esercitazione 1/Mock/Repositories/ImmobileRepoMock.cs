using Esercitazione_1.Core.Entities;
using Esercitazione_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Mock.Repositories
{
    internal class ImmobileRepoMock
    {
        internal List<Immobile> GetAll()
        {
            List<Immobile> immobili = MemoryStorage.immobili;
            return immobili;

            
        }


        internal List<Immobile> GetByCategory(int scelta)
        {
            List<Immobile> immobili = MemoryStorage.immobili;
            if (scelta == 1)
            {
                //foreach (var item in immobili)
                //{
                //    if (item is Appartamento)
                //    {
                //        immobili.Add(item);
                //    }
                //}

                List<Immobile> appartamenti= immobili.Where( i=> i is Appartamento).ToList();
                return appartamenti;
            }
            else if (scelta == 2)
            {
                //foreach (var item in immobili)
                //{
                //    if (item is Box)
                //    {
                //        immobili.Add(item);
                //    }
                //}
                List<Immobile> boxes = immobili.Where(i => i is Box).ToList();
                return boxes;
            }
            else
            {
                //foreach (var item in immobili)
                //{
                //    if (item is Villa)
                //    {
                //        immobili.Add(item);
                //    }
                //}
                List<Immobile> ville = immobili.Where(i => i is Villa).ToList();
                return ville;
            }
            //return immobili;
        }

        internal bool Delete(int codice)
        {
            List<Immobile> immobili = MemoryStorage.immobili;

            foreach (var item in immobili)
            {
                if (item.Id==codice)
                {
                    immobili.Remove(item);
                }
            }
            return true;

        }

        internal bool Buy(int codice)
        {
            List<Immobile> immobili = MemoryStorage.immobili;

            foreach (var item in immobili)
            {
                if (item.Id == codice)
                {
                    item.isAvailable = false;
                }
            }
            return true;
        }

        internal bool AddImmobile(Immobile flat)
        {
            List<Immobile> immobili= MemoryStorage.immobili;
            if (immobili.Count == 0)
            {
                flat.Id = 1;
            }
            else 
            {
                int maxId = 1;
                foreach (var i in immobili)
                {
                    if (i.Id > maxId)
                    {
                        maxId = i.Id;
                    }
                }
                flat.Id = maxId + 1;
            }
            immobili.Add(flat);
            return true;
        }
    }
}
