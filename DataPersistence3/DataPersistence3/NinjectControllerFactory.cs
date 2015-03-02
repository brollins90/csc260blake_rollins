using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataPersistence3.DAL;
using DataPersistence3.Interfaces;
using Ninject.Web.Common;
using System.Web.Hosting;

namespace DataPersistence3
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IDal>().To<EfDal>().When(x => NinjectWebCommon.IsAlreadyADbDal);
            ninjectKernel.Bind<IDal>().To<FlatFileDal>().When(x => !NinjectWebCommon.IsAlreadyADbDal).WithConstructorArgument("path", HostingEnvironment.MapPath("~\\Products"));
        }
    }
}