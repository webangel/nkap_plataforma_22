using Common;
using Common.CustomFilters;
using EntityFramework.DynamicFilters;
using Model.Auth;
using Model.Core;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext
{
    public class NkapDbContext : DbContext
    {

        public NkapDbContext()
        : base(string.Format("name={0}", Parameters.AppContext))
        {

        }

        public DbSet<Usuarios> UsersN { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddMyFilters(ref modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(NkapDbContext)));
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }
        public static NkapDbContext Create()
        {
            return new NkapDbContext();
        }
        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AuditEntity
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                    || x.State == EntityState.Deleted
                )
            );

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;
                if (entity != null)
                {
                    var date = DateTime.Now;
                    var userId = UserSessionHelper.GetUser() != 0 ? UserSessionHelper.GetUser() : 0;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void AddMyFilters(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(Enums.MyFilters.IsDeleted.ToString(), (ISoftDeleted ea) => ea.Deleted, false);
        }

    }
}
