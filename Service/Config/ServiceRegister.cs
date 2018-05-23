
using LightInject;
using Model.Auth;
using Model.Core;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<Usuarios>>((x) => new Repository<Usuarios>(ambientDbContextLocator));
            container.Register<IRepository<Categoria>>((x) => new Repository<Categoria>(ambientDbContextLocator));


            container.Register<IUsuarioService, UsuarioService>();
            container.Register<ICategoriaService, CategoriaService>();

        }
    }
}