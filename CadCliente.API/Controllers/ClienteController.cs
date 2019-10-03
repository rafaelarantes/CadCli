using CadCliente.Application.Cliente.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CadCliente.API.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public async Task<Domain.Cliente.Entites.Cliente> Get(Guid id)
        {
            return await _clienteAppService.Get(id);
        }

        public async Task<IEnumerable<Domain.Cliente.Entites.Cliente>> GetAll(Guid id)
        {
            return await _clienteAppService.GetAll();
        }


        public async Task Post(Domain.Cliente.Entites.Cliente cliente)
        {
            await _clienteAppService.Save(cliente);
        }
    }
}