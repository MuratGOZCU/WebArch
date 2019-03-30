using YK.Core;
using YK.Core.Mapper;
using YK.Web.Framework.Mvc.Models;

namespace YK.Web.Api.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region Languages

        public static TModel ToModel<TEntity, TModel>(this TEntity entity)
             where TEntity : BaseEntity
             where TModel : BaseAppEntityModel
        {
            return entity.MapTo<TEntity, TModel>();
        }

        public static TEntity ToEntity<TEntity, TModel>(this TModel model)
            where TEntity : BaseEntity
            where TModel : BaseAppEntityModel
        {
            return model.MapTo<TModel, TEntity>();
        }

        public static TEntity ToEntity<TEntity, TModel>(this TModel model, TEntity destination)
            where TEntity : BaseEntity
            where TModel : BaseAppEntityModel
        {
            return model.MapTo(destination);
        }

        #endregion

    }
}
