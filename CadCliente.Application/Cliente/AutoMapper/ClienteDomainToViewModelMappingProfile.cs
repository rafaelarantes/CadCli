using AutoMapper;
using CadCliente.Application.Cliente.ViewModel;

namespace CadCliente.Application.Cliente.AutoMapper
{
    public class ClienteDomainToViewModelMappingProfile : Profile
    {
        public ClienteDomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Cliente.Entites.Cliente, ClienteVModel>();
        }
    }
}
