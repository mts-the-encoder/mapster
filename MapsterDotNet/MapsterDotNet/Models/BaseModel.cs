using Mapster;

namespace MapsterDotNet.Models
{
    public abstract class BaseModel<TModel, TEntity> : IRegister
        where TModel : class, new()
        where TEntity : class, new()
    {
        public TEntity ToEntity()
        {
            return this.Adapt<TEntity>();
        }

        public TEntity ToEntity(TEntity entity)
        {
            return (this as TModel).Adapt(entity);
        }

        public static TModel FromEntity(TEntity entity)
        {
            return entity.Adapt<TModel>();
        }

        protected virtual void AddCustomMappings()
        { }

        private TypeAdapterConfig Config { get; set; }

        protected TypeAdapterSetter<TModel,TEntity> SetCustomMappings()
            => Config.ForType<TModel,TEntity>();

        protected TypeAdapterSetter<TEntity,TModel> SetCustomMappingsInverse()
            => Config.ForType<TEntity,TModel>();

        public void Register(TypeAdapterConfig config)
        {
            Config = config;
            AddCustomMappings();
        }
    }
}
