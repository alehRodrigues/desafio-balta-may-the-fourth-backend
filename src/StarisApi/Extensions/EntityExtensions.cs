using StarisApi.Dtos;
using StarisApi.Models;

namespace StarisApi.Extensions
{
    public static class EntityExtensions
    {
        public static IList<T> ToDtoList<TEntity, T>(this IList<TEntity> lista)
            where TEntity : Entity
            where T : class
        {
            return lista.Select(entity => entity.ConvertToDto<T>()).ToList() ?? [];
        }
    }
}
