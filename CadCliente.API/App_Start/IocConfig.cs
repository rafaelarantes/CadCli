using AutoMapper;
using CadCliente.Application.Cliente.AutoMapper;
using CadCliente.Application.Cliente.Services;
using CadCliente.Application.Cliente.Services.Interfaces;
using CadCliente.Data.Cliente.Context;
using CadCliente.Data.Cliente.Context.Interfaces;
using CadCliente.Data.Cliente.Repository;
using CadCliente.Data.Cliente.Repository.Interfaces;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            kernel.Bind<DefaultFilterProviders>().ToSelf().WithConstructorArgument(GlobalConfiguration.Configuration.Services.GetFilterProviders());
            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(config)).InSingletonScope();
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<ClienteContext>().ToSelf().WithConstructorArgument(GlobalConfiguration.Configuration.Services.GetFilterProviders());

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}