using Esercitazione_1.Core.Entities;
using Esercitazione_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Mock.Repositories
{
    internal class MemoryStorage
    {
        //Creiamo dati di prova

        public static List<Immobile> immobili = new List<Immobile>
        {
            new Appartamento{ Id=1, Indirizzo="Cannelles, 18", CAP=09045, Città="Quartu S.E.", Superficie= 75, isAvailable=true, Bagno=1, Stanza=3},
            new Box{Id=2, Indirizzo="Roma, 113", CAP=09045, Città= "Quartu S.E.", Superficie=40, isAvailable=false, Tipo="Auto"},
            new Villa{Id=3, Indirizzo="delle Azalee, 7", CAP=09045, Città= "Quartu S.E.", Superficie=450, isAvailable=true, Stanza=7, Bagno=3, Piano=3, Giardino=true, Piscina=true},
            new Appartamento{Id=4, Indirizzo="Cagliari, 22", CAP=09045, Città= "Quartu S.E.", Superficie=120, isAvailable=true, Bagno=2, Stanza=4},
            new Box{Id=5, Indirizzo="Dante, 75", CAP=09045, Città= "Quartu S.E.", Superficie=35, isAvailable=true, Tipo="Magazzino"},
            new Villa{Id=6, Indirizzo="dei Gigli, 1", CAP=09045, Città= "Quartu S.E.", Superficie=375, isAvailable=false, Stanza=5, Bagno=2, Piano=2, Giardino=true, Piscina=false}
        };
    }
}
