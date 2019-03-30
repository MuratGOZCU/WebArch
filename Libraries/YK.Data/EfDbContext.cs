#region Usings

using System;
using System.Linq;
using YK.Core;
using YK.Core.Data;
using YK.Core.Engine;
using YK.Core.Reflection;
using Microsoft.EntityFrameworkCore;

#endregion

namespace YK.Data
{
    public class EfDbContext : DbContext, IDbContext
    {
        #region Ctors

        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Utils

        private void AddAllConfigurations(ModelBuilder modelBuilder)
        {
            var entityRegistrars = EngineContext.Current.IocManager
                .Resolve<ITypeFinder>().FindClassesOfType<IEntityRegistrar>()
                .ToList();

             var instances = entityRegistrars
                .Select(mapperConfiguration => (IEntityRegistrar)Activator.CreateInstance(mapperConfiguration))
                .ToList();

            foreach (var instance in instances)
            {
                instance.Register(modelBuilder);             
            }
        }

        #endregion

        #region Overriding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            AddAllConfigurations(modelBuilder);         
        }

        #endregion

        #region Methods

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity => base.Set<TEntity>();

        #endregion
    }
}