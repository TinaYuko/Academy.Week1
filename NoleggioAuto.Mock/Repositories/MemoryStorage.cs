using NoleggioAuto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Mock.Repositories
{
    public class MemoryStorage
    {

        //Clienti
        //CodiceFiscale; Nome; Cognome
        //RSSMRA76A01L219J; Mario; Rossi
        //RSSMRC80A01L219M; Marco; Rossi
        public static List<Cliente> clienti = new List<Cliente>()
        {
            new Cliente{Nome="Mario", Cognome="Rossi", CodFiscale="RSSMRA80A01L219M"},
            new Cliente{Nome="Marco", Cognome ="Rossi", CodFiscale="NREFBA76A01L219J"}
        };

        //Noleggi
        //ID; Targa; CodiceFiscale; DataInizio; NumeroGiorni; Costo
        //1; AX743HJ; NREFBA76A01L219J; 29 / 12 / 2021; 5; 275
        //2; GJ924LR; NREFBA76A01L219J; 3 / 12 / 2021; 2; 120
        //3; UY248QW; NREFBA76A01L219J; 7 / 6 / 2020; 1; 65
        //4; AX743HJ; RSSMRA80A01L219M; 10 / 10 / 2021; 1; 70
        //5; TY467WE; RSSMRA80A01L219M; 29 / 12 / 2021; 5; 625
        //6; GH567KU; RSSMRA80A01L219M; 19 / 4 / 2020; 3; 600
       public static List<Noleggio> noleggi = new List<Noleggio>()
        {
            new Noleggio{Id=1, TargaVeicolo="AX743HJ", CodFiscaleCliente="NREFBA76A01L219J", DataInizio=new DateTime(2021,12,29), Giorni=5, CostoTot=275},
            new Noleggio{Id=2, TargaVeicolo="GJ924LR", CodFiscaleCliente="NREFBA76A01L219J", DataInizio= new DateTime(2021,12,3), Giorni=2, CostoTot= 120},
            new Noleggio{Id =3, TargaVeicolo="UY248QW", CodFiscaleCliente= "NREFBA76A01L219J", DataInizio= new DateTime(2020, 6, 7), Giorni= 1, CostoTot= 65},
            new Noleggio{Id=4, TargaVeicolo= "AX743HJ", CodFiscaleCliente= "RSSMRA80A01L219M", DataInizio= new DateTime(2021, 10, 10), Giorni= 1, CostoTot= 70},
            new Noleggio{Id=5, TargaVeicolo= "TY467WE", CodFiscaleCliente= "RSSMRA80A01L219M", DataInizio= new DateTime(2021, 12, 29), Giorni= 5, CostoTot= 625},
            new Noleggio{Id=6, TargaVeicolo= "GH567KU", CodFiscaleCliente= "RSSMRA80A01L219M", DataInizio= new DateTime(2020, 4, 09), Giorni= 3, CostoTot= 600},
        };

        //Veicoli
        //Targa; Modello; Tariffa; Posti / Capacità
        //AX743HJ; Fiat Panda; 55; 4 (automobile)
        //GJ924LR; Fiat Punto; 60; 5 (automobile)
        //UY248QW; Fiat Tipo; 65; 5 (automobile)
        //GK823NB; Smart fortwo coupè; 70; 2 (automobile)
        //TY467WE; Fiat Ducato; 125; 750 (furgone)
        //GH567KU; Fiat Fiorino; 100; 450 (furgone)
        public static List<Veicolo> veicoli = new List<Veicolo>()
        {
            new Automobile{ Targa="AX743HJ", Modello="Fiat Panda", Posti=4, TariffaGiornaliera=55, Tipo=Discriminatore.Automobile},
            new Automobile{ Targa="GJ924LR", Modello="Fiat Punto", Posti=5, TariffaGiornaliera=60, Tipo=Discriminatore.Automobile},
            new Automobile{ Targa="UY248QW", Modello="Fiat Tipo", Posti=5, TariffaGiornaliera=65, Tipo=Discriminatore.Automobile},
            new Automobile{ Targa="GK823NB", Modello="Smart Fortwo Coupè", Posti=2, TariffaGiornaliera=75, Tipo=Discriminatore.Automobile},
            new Furgone{ Targa="TY467WE", Modello="Fiat Ducato", TariffaGiornaliera=1255, CapacitàCarico=750, Tipo=Discriminatore.Furgone},
            new Furgone{ Targa="GH567KU", Modello="Fiat Fiorino", TariffaGiornaliera=100, CapacitàCarico=450, Tipo=Discriminatore.Furgone}

        };
    }
}
