namespace YK.Core.Events
{
    public class EntityInserted<T> where T : BaseEntity
    {
        public EntityInserted(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}