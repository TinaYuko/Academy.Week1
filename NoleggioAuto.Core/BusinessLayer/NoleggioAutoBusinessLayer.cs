using NoleggioAuto.Core.Entities;
using NoleggioAuto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Core.BusinessLayer
{
    public class NoleggioAutoBusinessLayer: IBusinessLayer
    {
        private readonly INoleggioRepository _noleggioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVeicoloRepository _veicoloRepository;
        public NoleggioAutoBusinessLayer(INoleggioRepository noleggioRepo, IClienteRepository clienteRepo, IVeicoloRepository veicoloRepo)
        {
            _clienteRepository = clienteRepo;
            _noleggioRepository = noleggioRepo;
            _veicoloRepository = veicoloRepo;

        }

        public bool AggiungiNoleggio(Noleggio noleggio)
        {
            return _noleggioRepository.Add(noleggio);
        }

        public decimal CalcolaTotByTarga(string targa)
        {
            return _noleggioRepository.CalcolaByTarga(targa);
        }

        public List<Cliente> GetAllClienti()
        {
            return _clienteRepository.GetAll();

        }

        public List<Noleggio> GetAllNoleggi()
        {
            return _noleggioRepository.GetAll();
        }

        public List<Veicolo> GetAllVeicoli()
        {
            return _veicoloRepository.GetAll();

        }

        public Cliente GetClienteByCF(string codFiscaleCliente)
        {
            Cliente cliente = _clienteRepository.GetByCode(codFiscaleCliente);
            return cliente;
        }

        public List<Noleggio> GetNoleggiAttivi()
        {
            return _noleggioRepository.GetNoleggiAttivi();
        }

        public Veicolo GetVeicoloByTarga(string targaVeicolo)
        {
            Veicolo veicolo = _veicoloRepository.GetByTarga(targaVeicolo);
            return veicolo;
        }

        public decimal RicavaTotAuto()
        {
            return _noleggioRepository.RicavaTotAuto();
        }

        public bool VerificaDisponibilitàAuto(string? targa, DateTime data)
        {
            if (_veicoloRepository.VerificaDisponibilità(targa, data)==true)
            {
                return true;
            }
            return false;
        }
    }
}
