using CadCliente.API.ViewModel;
using CadCliente.Application.Cliente.Services.Interfaces;
using CadCliente.Application.Cliente.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CadCliente.API.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }


        [Route("api/cliente/id/{id:guid}")]
        [HttpGet]
        public async Task<JsonResult<ResultViewModel>> Get(Guid id)
        {
            var resultViewModel = new ResultViewModel();

            try
            {
                resultViewModel.Data = await _clienteAppService.Get(id);
                resultViewModel.Success = true;
            }
            catch(Exception ex)
            {
                resultViewModel.Message = "Erro interno";
                resultViewModel.Success = false;
            }

            return Json(resultViewModel);
        }

        [Route("api/cliente/all")]
        [HttpGet]
        public async Task<JsonResult<ResultViewModel>> GetAll()
        {
            var resultViewModel = new ResultViewModel();

            try
            {
                resultViewModel.Data = await _clienteAppService.GetAll();
                resultViewModel.Success = true;
            }
            catch(Exception ex)
            {
                resultViewModel.Message = "Erro interno";
                resultViewModel.Success = false;
            }
            
            return Json(resultViewModel);
        }

        public async Task<JsonResult<ResultViewModel>> Post(ClienteVModel clienteVModel)
        {
            var resultViewModel = new ResultViewModel();

            try
            {
                await _clienteAppService.Save(clienteVModel);
                resultViewModel.Success = true;
            }
            catch (Exception ex)
            {
                resultViewModel.Message = "Erro interno";
                resultViewModel.Success = false;
            }

            return Json(resultViewModel);
        }
    }
}