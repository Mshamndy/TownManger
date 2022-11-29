using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using TownManger.Domain.Concrete;
using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;

namespace TownMangerWebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            kernel.Bind<IResdientRepository>().To<EFResdientRepostory>();
            kernel.Bind<IBuildingRepository>().To<EFBuildingRepository>();
            kernel.Bind<IFloorRepository>().To<EFFloorRepository>();
            kernel.Bind<IUnitRepository>().To<EFUnitRepository>();





        }
    }
}