using CadCliente.Data.Cliente.Context;
using CadCliente.Data.Cliente.Repository.Interfaces;
using CadCliente.Domain.Cliente.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCliente.Data.Cliente.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _clienteContext;

        public ClienteRepository(ClienteContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public async Task<Domain.Cliente.Entites.Cliente> GetAsync(Guid id)
        {
            return await _clienteContext.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Cliente.Entites.Cliente>> GetAllAsync()
        {
            return await _clienteContext.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task SaveAsync(Domain.Cliente.Entites.Cliente entity)
        {
            _clienteContext.Clientes.Add(entity);
            await _clienteContext.SaveChangesAsync();
        }
    }
}
