using System.Collections.Generic;

namespace YK.Core.Data
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        void Delete(TEntity entity);

        IList<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity entity);
        
        void Insert(IList<TEntity> entities);

        void Update(TEntity entity);

        void Update(IList<TEntity> entities);

       

    }
}
