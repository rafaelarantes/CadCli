
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadCliente.Application.Cliente.Services.Interfaces
{
    public interface IClienteAppService
    {
        Task Save(Domain.Cliente.Entites.Cliente cliente);
        Task<Domain.Cliente.Entites.Cliente> Get(Guid id);
        Task<IEnumerable<Domain.Cliente.Entites.Cliente>> GetAll();
    }
}
