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
    public interface IRolesService
    {
        ResponseHelper InsertOrUpdate(Roles model);
        ResponseHelper DeleteRol(int id);
        Roles Get(int id);
    }

    public class RolesService : IRolesService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Roles> _rolesRepository;

        public RolesService(
             IDbContextScopeFactory dbContextScopeFactory,
             IRepository<Roles> rolesRepository
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _rolesRepository = rolesRepository;

        }

        public ResponseHelper DeleteRol(int id)
        {
            throw new NotImplementedException();
        }

        public Roles Get(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseHelper InsertOrUpdate(Roles model)
        {
            throw new NotImplementedException();
        }
    }
}
