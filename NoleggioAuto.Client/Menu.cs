using NoleggioAuto.Core.BusinessLayer;
using NoleggioAuto.Core.Entities;
using NoleggioAuto.Core.Interfaces;
using NoleggioAuto.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Client
{
    public class Menu
    {
        private static readonly IBusinessLayer bl = new NoleggioAutoBusinessLayer(new MockNoleggioRepository(), new MockClienteRepository(), new MockVeicoloRepository());

        internal static void Start()
        {
            //All'accesso, l'utente può:
            //1 Visualizzare tutti i noleggi, con i dati del veicolo e del cliente
            //2 Visualizzare i noleggi di un certo veicolo (input: targa)
            //3 Visualizzare i dettagli di un certo noleggio (input: id)
            //4 Visualizzare i noleggi attivi
            //5 Inserire un nuovo noleggio verificando che il veicolo non sia impegnato.
            //Il costo del noleggio si calcola moltiplicando la tariffa per il numero
            //di giorni.
            //6 Data una targa, calcolare il totale in euro dei noleggi
            //7 Ricavare il totale in euro dei noleggi di automobili

            bool continua = true;
            Console.WriteLine("Benvenuto da Auto&Moto Rent!\n");
            while (continua)
            {
                Console.WriteLine("\nSi prega di premere: ");
                Console.WriteLine("[1] Per visualizzare i noleggi.");
                Console.WriteLine("[2] Per visualizzare i noleggi di un certo veicolo.");
                Console.WriteLine("[3] Per visualizzare i dettagli di un certo noleggio.");
                Console.WriteLine("[4] Per visualizzare i noleggi attivi.");
                Console.WriteLine("[5] Per inserire un noleggio");
                Console.WriteLine("[6] Per calcolare il totale in euro dei noleggi, data una targa");
                Console.WriteLine("[7] Per ricavare il totale in euro dei noleggi di automobili");
                Console.WriteLine("[0] Per uscire");


                int scelta;
                do
                {
                    Console.WriteLine("Si prega di scegliere");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 8));

                switch (scelta)
                {
                    case 1:
                        VisualizzaNoleggi();
                        break;
                    case 2:
                        VisualizzaNoleggiVeicolo();
                        break;
                    case 3:
                        VisualizzaInfoNoleggi();
                        break;
                    case 4:
                        VisualizzaNoleggiAttivi();
                        break;
                    case 5:
                        InserisciNoleggio();
                        break;
                    case 6:
                        CalcolaTot();
                        break;
                    case 7:
                        RicavaTotAuto();
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

        private static void RicavaTotAuto()
        {
            Console.WriteLine("Visto che vuoi farti i cavoli nostri, ti mostriamo il ricavato del noleggio auto: ");
            decimal tot = bl.RicavaTotAuto();
            Console.WriteLine($"Ricavato = {tot} euro");
        }

        private static void CalcolaTot()
        {
            Console.WriteLine("Ecco la lista dei veicoli presenti nel nostro centro!");
            VisualizzaVeicoli();
            Console.Write("Scegli la targa del veicolo da noleggiare: ");
            string targa = Console.ReadLine();
            decimal tot = bl.CalcolaTotByTarga(targa);
            Console.WriteLine($"L'importo totale dei noleggi emessi per la targa: {targa} è di {tot} euro");
        }

        private static void InserisciNoleggio()
        {
            DateTime data;
            Console.Write("Vuoi noleggiare una vettura? Per quale data ti serve? ");
            while (!(DateTime.TryParse(Console.ReadLine(), out data) && data > DateTime.Today))
            {
                Console.WriteLine("Non puoi noleggiare nel passato...");
            }
            int giorni;
            Console.WriteLine("Per quanti giorni ti serve?");
            while (!(int.TryParse(Console.ReadLine(), out giorni) && giorni > 0))
            {
                Console.WriteLine("Riprova!");
            }
            bool esito;
            string targa;
            do
            {
                Console.WriteLine("Ecco la lista dei veicoli presenti nel nostro centro!");
                VisualizzaVeicoli();
                Console.Write("Scegli la targa del veicolo da noleggiare: ");
                targa = Console.ReadLine();
                Console.WriteLine("Verifichiamo la disponibilità");
                esito = bl.VerificaDisponibilitàAuto(targa, data);
                if (esito)
                {
                    Console.WriteLine("Auto disponibile!");
                }
                else
                {
                    Console.WriteLine("Scegli un'altra auto...");
                }
            } while (!esito);
            Console.Write("Manca poco! \nInserisci il codice fiscale: ");
            string codFiscale=Console.ReadLine();

            Noleggio noleggio = new Noleggio();
            noleggio.CodFiscaleCliente = codFiscale;
            noleggio.DataInizio = data;
            noleggio.Giorni = giorni;
            noleggio.TargaVeicolo = targa;

            bool aggiunta = bl.AggiungiNoleggio(noleggio);

            if (aggiunta)
            {
                Console.WriteLine("Noleggio aggiunto correttamente!");
                Console.WriteLine(noleggio.ToString());
            }
            else
            {
                Console.WriteLine("Ops, si è verificato un problema...");
            }
        }

        private static void VisualizzaNoleggiAttivi()
        {
            List<Noleggio> noleggiAttivi = bl.GetNoleggiAttivi();
            if (noleggiAttivi.Count == 0)
            {
                Console.WriteLine("Non abbiamo noleggi attivi!");
            }
            else
            {
                foreach (var item in noleggiAttivi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaInfoNoleggi()
        {
            VisualizzaAllNoleggi();
            int id;
            Console.Write("Inserire Id noleggio: ");
            while (!(int.TryParse(Console.ReadLine(), out id) && id > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            List<Noleggio> noleggi = bl.GetAllNoleggi();
            foreach (var item in noleggi)
            {
                if (item.Id==id)
                {
                    Cliente cliente = bl.GetClienteByCF(item.CodFiscaleCliente);
                    Veicolo veicolo = bl.GetVeicoloByTarga(item.TargaVeicolo);

                    Console.WriteLine($"Noleggio a nome di: {cliente.Nome} {cliente.Cognome} " +
                        $"per il veicolo: {veicolo.Modello} di targa: {veicolo.Targa}");
                }
            }
        }

        private static void VisualizzaAllNoleggi()
        {
            List<Noleggio> noleggi = bl.GetAllNoleggi();
            if (noleggi.Count == 0)
            {
                Console.WriteLine("Lista vuota!");
            }
            else
            {
                foreach (var item in noleggi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaNoleggiVeicolo()
        {
            VisualizzaVeicoli();
            
            Console.Write("\nInserisci la targa del veicolo di cui vuoi visionare i noleggi: ");
            string targa= Console.ReadLine();
            Veicolo veicolo= bl.GetVeicoloByTarga(targa);
            List<Noleggio> noleggi = bl.GetAllNoleggi();
            foreach (var item in noleggi)
            {
                if (item.TargaVeicolo==targa)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaVeicoli()
        {
            List<Veicolo> veicoli = bl.GetAllVeicoli();
            if (veicoli.Count == 0)
            {
                Console.WriteLine("Lista vuota!");
            }
            else
            {
                foreach (var item in veicoli)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaNoleggi()
        {
            List<Noleggio> noleggi = bl.GetAllNoleggi();

            if (noleggi.Count==0)
            {
                Console.WriteLine("Lista vuota!");
            }
            else
            {
                foreach (var item in noleggi)
                {
                    Cliente cliente = bl.GetClienteByCF(item.CodFiscaleCliente);
                    Veicolo veicolo = bl.GetVeicoloByTarga(item.TargaVeicolo);

                    Console.WriteLine($"Noleggio a nome di: {cliente.Nome} {cliente.Cognome} " +
                        $"per il veicolo: {veicolo.Modello} di targa: {veicolo.Targa}");

                }
            }
        }
    }
}
