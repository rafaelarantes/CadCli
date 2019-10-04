using AutoMapper;
using CadCliente.Application.Cliente.Services.Interfaces;
using CadCliente.Application.Cliente.ViewModel;
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
        private readonly IMapper _mapper;
        public ClienteAppService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task Save(ClienteVModel clienteVModel)
        {
            var cliente = _mapper.Map<Domain.Cliente.Entites.Cliente>(clienteVModel);
            await _clienteRepository.SaveAsync(cliente);
        }

        public async Task<ClienteVModel> Get(Guid id)
        {
            return _mapper.Map<ClienteVModel>(await _clienteRepository.GetAsync(id));
        }
        public async Task<IEnumerable<ClienteVModel>> GetAll()
        {

            return _mapper.Map<IEnumerable<ClienteVModel>>(await _clienteRepository.GetAllAsync());
        }
    }
}
