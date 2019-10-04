
using CadCliente.Application.Cliente.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadCliente.Application.Cliente.Services.Interfaces
{
    public interface IClienteAppService
    {
        Task Save(ClienteVModel clienteVModel);
        Task<ClienteVModel> Get(Guid id);
        Task<IEnumerable<ClienteVModel>> GetAll();
    }
}
