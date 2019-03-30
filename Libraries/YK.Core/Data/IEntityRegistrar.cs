using Microsoft.EntityFrameworkCore;

namespace YK.Core.Data
{
    public interface IEntityRegistrar
    {
        void Register(ModelBuilder modelBuilder);
    }
}