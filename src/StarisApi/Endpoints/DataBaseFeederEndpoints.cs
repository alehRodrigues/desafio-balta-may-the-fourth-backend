using StarisApi.Models;
using StarisApi.Models.Movies;
using StarisApi.Repository;

namespace StarisApi.Endpoints;

public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits<TEntity>(
        this IEndpointRouteBuilder app
    )
        where TEntity : Entity, new()
    {
        var endpoint =
            $"{typeof(TEntity).ToString().Split(".").Last().Replace("TEntity", string.Empty)}s";
        var tag = endpoint[..^1];
        app.MapPost(
                $"/seed{endpoint}",
                async (DataBaseFeederRepository<TEntity> contextFeeder) =>
                {
                    try
                    {
                        var infos = await contextFeeder.GetInfoFromEndpoint(tag);
                        var entityBase = await contextFeeder.GetEntityBase<TEntity>(infos);
                        await contextFeeder.InsertNew<TEntity>(entityBase);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            )
            .WithTags(tag)
            .Produces(TypedResults.Ok("Database successfully feed.").StatusCode)
            .Produces(TypedResults.NoContent().StatusCode)
            .WithOpenApi()
            .WithSummary("Populaicona tabela " + endpoint)
            .WithDescription(
                "<b><p style='color: yellow'>⚠️⚠️⚠️WARNING⚠️⚠️⚠️<br> Por favor Ordem de Feeder:</b>"
                    + "<ol><li>Planets</li><li>Characters ou Vehicles ou Starships</li><li>por ultimo Movies</li></ol>"
            );
        return app;
    }

    public static IEndpointRouteBuilder MapDataRelationFeederEndpoits(
        this IEndpointRouteBuilder app
    )
    {
        app.MapPost(
                "/seedRelations",
                async (DataBaseFeederRepository<Movie> contextFeeder) =>
                {
                    var infos = await contextFeeder.GetInfoFromEndpoint("Movie");
                    await contextFeeder.FeedRelationsTable(infos);
                }
            )
            .WithTags("Relation")
            .Produces(TypedResults.Ok("Database successfully feed.").StatusCode)
            .Produces(TypedResults.NoContent().StatusCode)
            .WithOpenApi()
            .WithSummary("Populaicona todas as tabelas de Relação")
            .WithDescription(
                "<b><p style='color: yellow'>⚠️⚠️⚠️WARNING⚠️⚠️⚠️<br>"
                    + "Por favor, para que todas as relações ocorrerem certo<br>"
                    + "todo os elementos a serem relacionados devem ja existir na tabela.</b>"
            );
        return app;
    }
}
