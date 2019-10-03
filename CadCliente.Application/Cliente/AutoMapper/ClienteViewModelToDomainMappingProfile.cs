using AutoMapper;
using CadCliente.Application.Cliente.ViewModel;

namespace CadCliente.Application.Cliente.AutoMapper
{
    public class ClienteViewModelToDomainMappingProfile : Profile
    {
        public ClienteViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteVModel, Domain.Cliente.Entites.Cliente>();
        }
    }
}
