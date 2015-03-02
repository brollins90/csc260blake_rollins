using DataPersistence3.Interfaces;
using Ninject.Modules;

namespace DataPersistence3.DAL
{
    public class NinjectDal : NinjectModule
    {
        public override void Load()
        {
            Bind<IDal>().To<EfDal>();
        }
    }
}