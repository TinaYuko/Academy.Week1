using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.LinQ
{
    public class DemoLINQ2
    {
        public static void Demo()
        {
            List<Impiegato> impiegati = new List<Impiegato>();
            Impiegato impiegato = new Impiegato()
            { Id = 1, Nome = "Mario Rossi", Salario = 1200 };
            Impiegato impiegato2 = new Impiegato()
            { Id = 2, Nome = "Marco Verdi", Salario = 1200 };
            Impiegato impiegato3 = new Impiegato()
            { Id = 3, Nome = "Sara Bianchi", Salario = 1500 };
            Impiegato impiegato4 = new Impiegato()
            {Id = 4,Nome = "Tania Verdi",Salario = 1640};
            impiegati.Add(impiegato4);
            impiegati.Add(impiegato);
            impiegati.Add(impiegato2);
            impiegati.Add(impiegato3);

            //Lambda expression

            //Recupero i nomi degli impiegati
            var nomiImpiegati = impiegati.Select(x => x.Nome).ToList();
            foreach (var item in nomiImpiegati)
            {
                Console.WriteLine(item);
            }

            //IEnumerable<Impiegato> impiegatiFiltrati =
            //   from i in impiegati
            //   where i.Id == 2
            //   select i;
            IEnumerable<Impiegato> impiegatiFiltrati= impiegati.Where(item => item.Id == 2).ToList();
            foreach (var item in impiegatiFiltrati)
            {
                Console.WriteLine(item.Nome);
            }


            //IEnumerable<Impiegato> impiegatiFiltrati =
            //   from i in impiegati
            //   where i.Id == 2
            //   select i.Nome;
            var nomiById= impiegati.Where(i => i.Id == 2).Select(i => i.Nome).ToList();
            //Ottengo una lista di stringhe coi nomi di impiegati il cui id è 2

            var impiegatoTrovato= impiegati.FirstOrDefault(i => i.Id==2); //mi prende il primo che soddisfa questa condizione
            var impiegatoTrovato2 = impiegati.First(i => i.Id == 10); //Mentre FirstOrDefault se non trova nulla, ci da null, First e basta va in eccezione
            var impiegatoTrivato3= impiegati.SingleOrDefault(i => i.Id==3); //Se so che esiste uno solo con questa condizione

            //IEnumerable<Impiegato> impiegatiFiltrati2 =
            //   from i in impiegati
            //   where i.Salario < 1500
            //   select i;
            IEnumerable<Impiegato> impiegatiFiltrati2 = impiegati.Where(item => item.Salario < 1500).ToList();
            foreach (var item in impiegatiFiltrati)
            {
                Console.WriteLine(item.Nome);
            }


            //var impiegatiOrdinati =
            //    from i in impiegati
            //    orderby i.Nome
            //    select i;
            var impiegatiOrdinati= impiegati.OrderBy(i => i.Nome).ToList();


            //Se voglio manipolare i dati, prendo i nomi e li voglio tutti in maiuscolo
            var nomi2=impiegati.Select(i => i.Nome.ToUpper()).ToList(); //mi rende una stringa 

            //ATTENZIONE
            //WHERE E SELECT SONO DIVERSI
            var nomi3 = impiegati.Select(i => i.Id == 2); //Non mi restituisce una lista, ma una lista di booleani



        }
    }
}
