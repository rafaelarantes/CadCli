using AutoMapper;
using CadCliente.Application.Cliente.AutoMapper;
using CadCliente.Application.Cliente.Services;
using CadCliente.Application.Cliente.Services.Interfaces;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace CadCliente.API.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            IKernel kernel = new StandardKernel();

            var config = new MapperConfiguration(m =>
            {
                m.AddProfile(new ClienteDomainToViewModelMappingProfile());
                m.AddProfile(new ClienteViewModelToDomainMappingProfile());
            });

            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(config)).InSingletonScope();
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}