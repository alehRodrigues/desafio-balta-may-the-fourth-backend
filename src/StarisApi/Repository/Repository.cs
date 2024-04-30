using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using StarisApi.DbContexts;
using StarisApi.Dtos;
using StarisApi.Extensions;
using StarisApi.Models;
using StarisApi.Requests;
using StarisApi.Responses;

namespace StarisApi.Repository
{
    public class Repository<TEntity>
        where TEntity : Entity, new()
    {
        private readonly SqliteContext context;

        public Repository(SqliteContext context) => this.context = context;

        public IDto? Find(int id)
        {
            var res = context.Find<TEntity>(id);
            if (res is null)
                return null;
            return res.ConvertToDto<IDto>();
        }

        public ResponseList<IList<IDto>, T> GetAll<T>(Request request)
            where T : class
        {
            var total = context.Set<TEntity>().Count();
            var searchParam = new TEntity().GetSearchParameter();
            var sortParameters = new TEntity().ValidateSortParameter(request.SortBy);
            int offset = ((request.Page ?? 1) - 1) * (request.PerPage ?? 10);

            IQueryable<TEntity> listaEntity = context.Set<TEntity>().AsNoTracking();

            if (searchParam != null && request.Search != null)
                listaEntity = listaEntity.Where(
                    $"{searchParam}.ToLower().Contains(@0)",
                    $"{request.Search.Trim().ToLower()}"
                );

            if (sortParameters != null)
                listaEntity = listaEntity.OrderBy(sortParameters, request.SortOrder);

            listaEntity = listaEntity.Skip(offset).Take(request.PerPage ?? 10);

            var listaDto = listaEntity.ToList().ToDtoList<TEntity, T>();

            return new ResponseList<IList<IDto>, T>(listaDto, total, request);
        }
    }
}
