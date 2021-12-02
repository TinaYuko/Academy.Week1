using Esercitazione_1.Core.BusinessLayer;
using Esercitazione_1.Core.Entities;
using Esercitazione_1.Entities;
using Esercitazione_1.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_1.Client
{
    internal class Menu
    {
        /*
         Realizzare un programma che all'accesso consente all'utente di:
        -Visualizzare tutti gli immobili
        Terminata un'operazione l'utente deve poter eseguire una nuova scelta,
        a meno che non decida di terminare.
        Il risultato della ricerca è visualizzato a video stampando la scheda degli immobili.
        -Visualizzare gli immobili con una superficie maggiore di...
        (Chiedere all'utente i mq. Filtrare gli immobili con superficie maggiore di quella scelta dall'utente)
        - Visualizzare gli immobili disponibili all'acquisto/affitto
        - Mostrare gli immobili di una certa categoria
        - Inserire un nuovo immobile
        (Chiedere all'utente le informazioni sull'immobile e aggiungere il nuovo immobile.
        Il nuovo immobile che viene aggiunto sarà inizialmente disponibile. Quando aggiungo un nuovo immobile
        incremento di 1 l'id rispetto all'ultimo id in lista)
        - Eliminare un immobile.
        (Chiedere all'utente quale immobile vuole eliminare (esempio: input id) e eliminarlo).
        - Modificare lo stato di un immobile in 'Non disponibile' se è stato
        venduto/affittato.
        */

        private static readonly AgenziaBusinessLayer bl = new AgenziaBusinessLayer(new ImmobileRepoMock());
        internal static void Start()
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("Si prega di premere: ");
                Console.WriteLine("[1] Per visualizzare gli immobili presenti.");
                Console.WriteLine("[2] Per filtrare gli immobili per superficie.");
                Console.WriteLine("[3] Per visualizzare gli immobili disponibili.");
                Console.WriteLine("[4] Per visualizzare gli immobili di una certa categoria.");
                Console.WriteLine("[5] Per inserire un nuovo immobile");
                Console.WriteLine("[6] Per eliminare un immobile dal catalogo");
                Console.WriteLine("[7] Per modificare la disponibilità di un immobile");
                Console.WriteLine("[0] Per uscire");


                int scelta;
                do
                {
                    Console.WriteLine("Si prega di scegliere");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 8));

                switch (scelta)
                {
                    case 1:
                        VisualizzaImmobili();
                        break;
                    case 2:
                        FiltraPerMq();
                        break;
                    case 3:
                        VisualizzaDisponibili();
                        break;
                    case 4:
                        VisualizzaPerCategoria();
                        break;
                    case 5:
                        InserisciImmobile();
                        break;
                    case 6:
                        EliminaImmobile();
                        break;
                    case 7:
                        ModificaDisponibilità();
                        break;
                    case 0:
                        Console.WriteLine("La ringraziamo per aver visionato il nostro portale. Arrivederci!");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, attenzione!");
                        break;
                }
            }
        }

        private static void ModificaDisponibilità()
        {
            Console.WriteLine("Scegli il codice dell'immobile da comprare tra quelli presenti!");
            VisualizzaImmobili();
            int codice;
            Console.Write("Inserisci codice: ");
            while (!(int.TryParse(Console.ReadLine(), out codice) && codice > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }

            bool esito = bl.CompraImmobile(codice);
            if (esito)
            {
                Console.WriteLine("Immobile comprato con successo");
            }
            else
            {
                Console.WriteLine("Ops, qualcosa è andato storto");
            }
        }

        private static void EliminaImmobile()
        {
            Console.WriteLine("Scegli il codice dell'immobile da eliminare tra quelli presenti!");
            VisualizzaImmobili();
            int codice;
            Console.Write("Inserisci codice: ");
            while (!(int.TryParse(Console.ReadLine(), out codice) && codice > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            
            bool esito= bl.Delete(codice);
            if (esito)
            {
                Console.WriteLine("Immobile eliminato con successo");
            }
            else
            {
                Console.WriteLine("Ops, qualcosa è andato storto");
            }
        }

        private static void InserisciImmobile()
        {
            Console.WriteLine("Quale immobile vuoi aggiungere?");
            Console.WriteLine("[1] Appartamenti.");
            Console.WriteLine("[2] Box.");
            Console.WriteLine("[3] Villa.");
            int scelta;
            do
            {
                Console.WriteLine("Si prega di scegliere");
            }
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 4));

            if (scelta==1)
            {
                AggiungiAppartamento();
            }
            else if (scelta==2)
            {
                AggiungiBox();
            }
            else
            {
                AggiungiVilla();
            }
        }

        private static void AggiungiVilla()
        {
            Console.Write("Inserisci via: ");
            string via = Console.ReadLine();
            int cap;
            Console.Write("Inserisci cap: ");
            while (!(int.TryParse(Console.ReadLine(), out cap) && cap > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            Console.Write("Inserisci città: ");
            string città = Console.ReadLine();
            int superficie;
            Console.Write("Inserisci superficie: ");
            while (!(int.TryParse(Console.ReadLine(), out superficie) && superficie > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int stanze;
            Console.Write("Inserisci numero stanze: ");
            while (!(int.TryParse(Console.ReadLine(), out stanze) && stanze > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int bagni;
            Console.Write("Inserisci numero bagni: ");
            while (!(int.TryParse(Console.ReadLine(), out bagni) && bagni > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int piani;
            Console.Write("Inserisci numero piani: ");
            while (!(int.TryParse(Console.ReadLine(), out piani) && piani > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int piscina;
            Console.WriteLine("Ha la piscina? " +
                "\n Premi [1] per sì, [2] per no");
            while (!(int.TryParse(Console.ReadLine(), out piscina) && piscina > 0 && piscina <3))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int giardino;
            Console.WriteLine("Ha il giardino? " +
                "\n Premi [1] per sì, [2] per no");
            while (!(int.TryParse(Console.ReadLine(), out giardino) && giardino > 0 && giardino < 3))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }

            Villa villa = new Villa();
            villa.Indirizzo = via;
            villa.CAP = cap;
            villa.Città = città;
            villa.Superficie = superficie;
            villa.isAvailable = true;

            if (piscina==1)
            { villa.Piscina = true; }
            else { villa.Piscina = false; }
            if (giardino == 1)
            { villa.Giardino = true; }
            else { villa.Giardino = false; }
            bool esito = bl.AddImmobile(villa);
        }

        private static void AggiungiBox()
        {
            Console.Write("Inserisci via: ");
            string via = Console.ReadLine();
            int cap;
            Console.Write("Inserisci cap: ");
            while (!(int.TryParse(Console.ReadLine(), out cap) && cap > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            Console.Write("Inserisci città: ");
            string città = Console.ReadLine();
            int superficie;
            Console.Write("Inserisci superficie: ");
            while (!(int.TryParse(Console.ReadLine(), out superficie) && superficie > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            Console.Write("Inserisci di che tipo è il box: ");
            string tipo=Console.ReadLine();

            Box box = new Box();
            box.Indirizzo = via;
            box.CAP = cap;
            box.Città = città;
            box.Superficie = superficie;
            box.Tipo = tipo;
            box.isAvailable = true;

            bool esito = bl.AddImmobile(box);
        }

        private static void AggiungiAppartamento()
        {
            Console.Write("Inserisci via: ");
            string via= Console.ReadLine();
            int cap;
            Console.Write("Inserisci cap: ");
            while (!(int.TryParse(Console.ReadLine(), out cap) && cap > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            Console.Write("Inserisci città: ");
            string città= Console.ReadLine();
            int superficie;
            Console.Write("Inserisci superficie: ");
            while (!(int.TryParse(Console.ReadLine(), out superficie) && superficie > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int stanze;
            Console.Write("Inserisci numero stanze: ");
            while (!(int.TryParse(Console.ReadLine(), out stanze) && stanze > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int bagni;
            Console.Write("Inserisci numero bagni: ");
            while (!(int.TryParse(Console.ReadLine(), out bagni) && bagni > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }

            Appartamento flat = new Appartamento();
            flat.Indirizzo = via;
            flat.CAP=cap;
            flat.Città = città;
            flat.Superficie=superficie;
            flat.Bagno = bagni;
            flat.Stanza=stanze;
            flat.isAvailable=true;

            bool esito = bl.AddImmobile(flat);
        }

        private static void VisualizzaPerCategoria()
        {
            Console.WriteLine("Quale categoria vuoi visualizzare?");
            Console.WriteLine("[1] Appartamenti.");
            Console.WriteLine("[2] Box.");
            Console.WriteLine("[3] Villa.");
            int scelta;
            do
            {
               Console.WriteLine("Si prega di scegliere");
            } 
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 4));   
            List<Immobile> list = bl.GetByCategory(scelta);
        }

        private static void VisualizzaDisponibili()
        {
            List<Immobile> immobili = bl.GetDisponibili();
            foreach (Immobile immobile in immobili)
            {
                Console.WriteLine(immobile.ToString());
            }
        }

        private static void FiltraPerMq()
        {
            int supMin;
            Console.Write("Quale dovrebbe essere la superficie minima? ");
            while (!(int.TryParse(Console.ReadLine(), out supMin) && supMin > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            List<Immobile> immobili = bl.GetByMq(supMin);
            foreach (Immobile immobile in immobili)
            {
                Console.WriteLine(immobile.ToString());
            }

        }

        private static void VisualizzaImmobili()
        {
            List<Immobile> immobili = bl.GetAll();
            foreach (Immobile immobile in immobili)
            {
                Console.WriteLine(immobile.ToString());
            }
        }
    }
}
