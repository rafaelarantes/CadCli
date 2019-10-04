[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CadCliente.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CadCliente.API.App_Start.NinjectWebCommon), "Stop")]

namespace CadCliente.API.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using AutoMapper;
    using CadCliente.Application.Cliente.AutoMapper;
    using CadCliente.Application.Cliente.Services;
    using CadCliente.Application.Cliente.Services.Interfaces;
    using CadCliente.Data.Cliente.Context;
    using CadCliente.Data.Cliente.Repository;
    using CadCliente.Data.Cliente.Repository.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi.Filter;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var config = new MapperConfiguration(m =>
            {
                m.AddProfile(new ClienteDomainToViewModelMappingProfile());
                m.AddProfile(new ClienteViewModelToDomainMappingProfile());
            });

            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(config)).InSingletonScope();
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<ClienteContext>().ToSelf().WithConstructorArgument(GlobalConfiguration.Configuration.Services.GetFilterProviders());
        }        
    }
}