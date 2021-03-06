[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BattleOfTheMachines.WebForms.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BattleOfTheMachines.WebForms.App_Start.NinjectWebCommon), "Stop")]

namespace BattleOfTheMachines.WebForms.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Data.Entity;
    using Data;
    using Data.Repositories;
    using Services.Data.Contracts;
    using Services.Data;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel.Bind<DbContext>().To<BattleOfTheMachinesDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
        };

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
            DependenciesRegistration(kernel);

            kernel.Bind<IQuestsService>().To<QuestsService>().InRequestScope();
            kernel.Bind<ICpusService>().To<CpusService>().InRequestScope();
            kernel.Bind<IGpusService>().To<GpusService>().InRequestScope();
            kernel.Bind<INetworksService>().To<NetworksService>().InRequestScope();
            kernel.Bind<IRamsService>().To<RamsService>().InRequestScope();
            kernel.Bind<IMotherboardService>().To<MotherboardService>().InRequestScope();
        }        
    }
}
