using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Generales.IRepository
{
    public interface IClienteRepository
    {
        List<Cliente> FindAllClientes(ClienteSearchOptions options);
        StatusResponse InsertCliente(Cliente cliente);
        StatusResponse UpdateCliente(Cliente cliente);
        StatusResponse DeleteCliente(Cliente cliente);
        Cliente GetClientebyId(int clienteId);
    }
}
