using Common;
using Model.Auth;
using Model.Core;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service
{
    public interface ICategoriaService
    {
        //ResponseHelper InsertOrUpdate(Usuarios model, HttpPostedFileBase foto);
        //ResponseHelper DeleteUser(int id);
        //Usuarios Get(int id);
    }

    public class CategoriaService : ICategoriaService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Categoria> _categoriaRepository;

        public CategoriaService(
             IDbContextScopeFactory dbContextScopeFactory,
             IRepository<Categoria> categoriaRepository
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _categoriaRepository = categoriaRepository;

        }

    }
}
