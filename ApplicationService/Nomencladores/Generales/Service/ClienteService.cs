using ApplicationService.Common;
using ApplicationService.Nomencladores.Generales.IService;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Generales.Service
{
   public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {

            _clienteRepository = clienteRepository;
        }

        public Response DeleteCliente(int clienteId)
        {
            var cliente = _clienteRepository.GetClientebyId(clienteId);

            if (cliente != null)
            {
                var status = _clienteRepository.DeleteCliente(cliente);
                return new Response
                {
                    Status = status
                };

            }
            return new Response
            {
                Status = StatusResponse.NotFound
            };
        }

        public List<Cliente> FindAllClientes(ClienteSearchOptions options = null)
        {
            return _clienteRepository.FindAllClientes(options);


        }

        public Cliente GetClientebyId(int clienteId)
        {
            return _clienteRepository.GetClientebyId(clienteId);
        }
        public Response InsertCliente(Cliente cliente)
        {

            var status = _clienteRepository.InsertCliente(cliente);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateCliente(Cliente cliente)
        {
            var status = _clienteRepository.UpdateCliente(cliente);
            return new Response
            {
                Status = status
            };
        }
    }
}


