using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatform.API.News.Interfaces.REST.Transform;

public class FavoriteSourceResourceFromEntityAssembler
// public static class FavoriteSourceResourceFromEntityAssembler
{
    // public static FavoriteSourceResource ToResourceFromEntity(this FavoriteSource entity)
    public static FavoriteSourceResource ToResourceFromEntity(FavoriteSource entity)
    {
        return new FavoriteSourceResource(
            entity.Id,
            entity.NewsApiKey,
            entity.SourceId
        );
    }
}