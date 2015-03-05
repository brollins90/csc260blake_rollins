using Ninject;
using System;
using System.Web.Mvc;
using DataPersistence3.DAL;
using DataPersistence3.Interfaces;
using System.Web.Hosting;

namespace DataPersistence3
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IDal>().To<EfDal>().When(x => NinjectWebCommon.UseEfDal);
            _ninjectKernel.Bind<IDal>().To<FlatFileDal>().When(x => !NinjectWebCommon.UseEfDal).WithConstructorArgument("path", HostingEnvironment.MapPath("~\\Products"));
        }
    }
}