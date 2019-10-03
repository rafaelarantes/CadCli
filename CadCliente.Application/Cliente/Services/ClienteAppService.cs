using CadCliente.Application.Cliente.Services.Interfaces;
using CadCliente.Data.Cliente.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCliente.Application.Cliente.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteAppService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Save(Domain.Cliente.Entites.Cliente cliente)
        {
            await _clienteRepository.SaveAsync(cliente);
        }

        public async Task<Domain.Cliente.Entites.Cliente> Get(Guid id)
        {
            return await _clienteRepository.GetAsync(id);
        }
        public async Task<IEnumerable<Domain.Cliente.Entites.Cliente>> GetAll()
        {
            return await _clienteRepository.GetAllAsync();
        }
    }
}
