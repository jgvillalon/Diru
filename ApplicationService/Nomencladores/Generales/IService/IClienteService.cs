using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Generales.IService
{
    public interface IClienteService
    {
        Response InsertCliente(Cliente cliente);
        Response UpdateCliente(Cliente cliente);
        Response DeleteCliente(int clienteId);
        Cliente GetClientebyId(int clienteId);
        List<Cliente> FindAllClientes(ClienteSearchOptions options = null);
    }
}
