namespace YK.Core.Events
{
    public class EntityDeleted<T> where T : BaseEntity
    {
        public EntityDeleted(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}