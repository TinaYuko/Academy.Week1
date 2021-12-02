using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.LinQ
{
    internal class DemoLINQ
    {
        public static void Demo()
        {
            List<Impiegato> impiegati = new List<Impiegato>();
            Impiegato impiegato = new Impiegato()
            {Id=1, Nome="Mario Rossi", Salario=1200};
            Impiegato impiegato2 = new Impiegato()
            { Id = 2, Nome = "Marco Verdi", Salario = 1200 };
            Impiegato impiegato3 = new Impiegato()
            { Id = 3, Nome = "Sara Bianchi", Salario = 1500 };

            impiegati.Add(impiegato);
            impiegati.Add(impiegato2);
            impiegati.Add(impiegato3);

            foreach (Impiegato item in impiegati)
            {
                if (item.Id==2)
                {
                    Console.WriteLine($"Nome impiegato con foreach: {item.Nome}");
                }
            }

            //Query syntax
            IEnumerable<string> names =
                from i in impiegati
                where i.Id == 2
                select i.Nome;
            //mi ritrovo un enumerable di string a prescindere
            //per vedere cosa c'è dentro

            Console.WriteLine("Nome dell'impiegato con query sintax: ");
            foreach (string item in names)
            {
                Console.WriteLine(item);
            }

            //from -> specifica l'origine dei dati
            //where -> filtro
            //select -> specifica il tipo di ritorno

            IEnumerable<Impiegato> impiegatiFiltrati =
               from i in impiegati
               where i.Id == 2
               select i ;

            Console.WriteLine("Nome impiegato: ");
            foreach (var item in impiegatiFiltrati)
            {
                Console.WriteLine(item.Nome);
            }

            IEnumerable<Impiegato> impiegatiFiltrati2 =
               from i in impiegati
               where i.Salario < 1500
               select i;

            Console.WriteLine("Impiegati con salario minore di 1500: ");
            foreach ( var item in impiegatiFiltrati2)
            {
                Console.WriteLine(item.Nome);
            }

            Impiegato impiegato4 = new Impiegato()
            {
                Id = 4,
                Nome = "Tania Verdi",
                Salario = 1640
            };
            impiegati.Add(impiegato4);
            var impiegatiOrdinati= 
                from i in impiegati
                orderby i.Nome
                select i;
            Console.WriteLine("Impiegati in ordine alfabetico");
            foreach (var i in impiegatiOrdinati)
            {
                Console.WriteLine(i.Nome);
            }

            

        }
    }
}
