using AutoMapper;
using CadCliente.Application.Cliente.ViewModel;

namespace CadCliente.Application.Cliente.AutoMapper
{
    public class ClienteViewModelToDomainMappingProfile : Profile
    {
        public ClienteViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteVModel, Domain.Cliente.Entites.Cliente>()
                .ConstructUsing(v => 
                    new Domain.Cliente.Entites.Cliente(v.Nome, v.Sobrenome, v.DataNascimento)
                );
        }
    }
}
