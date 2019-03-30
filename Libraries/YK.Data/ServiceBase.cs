using YK.Core;
using YK.Core.Data;
using YK.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YK.Data
{


    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : BaseEntity
    {
        #region Fields
        public readonly IRepository<TEntity> _repository;
        #endregion

        #region Ctor
        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        #endregion

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.GetType().GetProperty("Deleted") != null)
            {
                entity.GetType().GetProperty("Deleted").SetValue(entity, true);
                Update(entity);
            }
            else
            {
                _repository.Delete(entity);
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            return _repository.Table.ToList();
        }

        public virtual TEntity GetById(int entityId)
        {
            if (entityId <= 0)
                return null;

            return _repository.GetById(id: entityId);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Insert(entity: entity);
        }

        public virtual void Insert(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _repository.Insert(entities: entities);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Update(entity: entity);
        }

        public virtual void Update(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _repository.Update(entities: entities);
        }
    }
}
