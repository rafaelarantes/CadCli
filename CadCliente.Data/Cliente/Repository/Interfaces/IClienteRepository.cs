
using CadCliente.Data.Core.Repository.Interfaces;
using CadCliente.Domain.Cliente.Entites;

namespace CadCliente.Data.Cliente.Repository.Interfaces
{
    public interface IClienteRepository : IRepository<Domain.Cliente.Entites.Cliente>
    {
    }
}
