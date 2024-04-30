using Microsoft.AspNetCore.Mvc;
using StarisApi.Dtos;
using StarisApi.Models;
using StarisApi.Repository;
using StarisApi.Requests;

namespace StarisApi.Endpoints
{
    public static class GenericEndpoint
    {
        public static IEndpointRouteBuilder MapGenericEndpoint<TEntity, TDto>(
            this IEndpointRouteBuilder app
        )
            where TEntity : Entity, new()
            where TDto : class, IDto
        {
            var endpoint =
                $"{typeof(TDto).ToString().Split(".").Last().Replace("Dto", string.Empty).ToLower()}s";
            var tag = typeof(TDto).ToString().Split(".").Last().Replace("Dto", string.Empty);

            app.MapGet(
                    $"/{endpoint}",
                    ([AsParameters] Request request, Repository<TEntity> context) =>
                    {
                        var lista = context.GetAll<TDto>(request);
                        return lista.Results.Any() ? TypedResults.Ok(lista) : Results.NoContent();
                    }
                )
                .WithTags(tag)
                .Produces(TypedResults.Ok().StatusCode)
                .Produces(TypedResults.NoContent().StatusCode)
                .WithOpenApi()
                .WithSummary("retorna uma lista de " + endpoint)
                .WithDescription(
                    "<b>search</b> => busca por palavra chave. <br> "
                        + "<b>page</b> => número da página a ser retornada. <br>"
                        + "<b>perPage</b> => quantos itens retorna por página. <br>"
                        + "<b>sortBy</b> => qual propriedade dever ser ordenada.<br>"
                        + "<b>SortOrder</b> => <i>asc<i/> para ascendente e <i>desc</i> para descendente.<br>"
                );

            app.MapGet(
                    endpoint + "/{id}",
                    ([FromRoute] int id, Repository<TEntity> context) =>
                    {
                        var result = context.Find(id);

                        return result is null ? Results.NotFound() : TypedResults.Ok(result);
                    }
                )
                .WithTags(tag)
                .WithOpenApi()
                .WithSummary("retorna uma entidade do tipo " + tag.ToLower())
                .WithDescription("<b>Id</b> => id da busca pela entidade<br> ");

            return app;
        }
    }
}
