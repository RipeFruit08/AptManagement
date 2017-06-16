using Ninject.Modules;

namespace AptManagement.Data.Context.Dapper.Config
{
    public class AppDataModule : NinjectModule
    {
        public override void Load()
        {
            DoBind<AppDataContext, AppDataContext>();
        }

        private void DoBind<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            Bind<TInterface>().To<TImplementation>().InThreadScope();
        }
    }
}