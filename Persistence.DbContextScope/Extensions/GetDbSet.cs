using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DbContextScope
{
    public static class GetDbSet
    {
        public static DbSet<T> GetEntity<T>(this IDbContextReadOnlyScope value) where T : class
        {
            return value.DbContexts.Get<NkapDbContext>().Set<T>();
        }

        public static DbSet<T> GetEntity<T>(this IDbContextScope value) where T : class
        {
            return value.DbContexts.Get<NkapDbContext>().Set<T>();
        }

        public static int ExecuteCommand(
            this IDbContextReadOnlyScope ctx,
            string query,
            params object[] parameters
        )
        {
            return ctx.DbContexts.Get<NkapDbContext>().Database.ExecuteSqlCommand(query, parameters);
        }

        public static int ExecuteCommand(
            this IDbContextScope ctx,
            string query,
            params object[] parameters
        )
        {
            return ctx.DbContexts.Get<NkapDbContext>().Database.ExecuteSqlCommand(query, parameters);
        }

        public static IQueryable<T> SqlQuery<T>(
            this IDbContextReadOnlyScope ctx,
            string query,
            params object[] parameters
        )
        {
            return ctx.DbContexts.Get<NkapDbContext>().Database.SqlQuery<T>(query, parameters).AsQueryable();
        }

        public static IQueryable<T> SqlQuery<T>(
            this IDbContextScope ctx,
            string query,
            params object[] parameters
        )
        {
            return ctx.DbContexts.Get<NkapDbContext>().Database.SqlQuery<T>(query, parameters).AsQueryable();
        }
    }
}
