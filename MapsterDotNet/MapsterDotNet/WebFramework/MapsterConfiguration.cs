using Mapster;
using System.Reflection;
using MapsterDotNet.Models;

namespace MapsterDotNet.WebFramework
{
    public static class MapsterConfiguration
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            Assembly applicationAssembly = typeof(BaseModel<,>).Assembly;
            typeAdapterConfig.Scan(applicationAssembly);
        }
    }
}
