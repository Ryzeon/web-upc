using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Repositories;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.News.Infrastructure.Persistence.EFC.Repositories;

public class FavoriteSourceRepositoryImpl : BaseRepository<FavoriteSource>, IFavoriteSourceRepository

{
    public FavoriteSourceRepositoryImpl(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FavoriteSource>> FindAllByNewsApiKeyAsync(string newsApiKey)
    {
        return await Context.Set<FavoriteSource>()
            .Where(f => f.NewsApiKey == newsApiKey)
            .ToListAsync();
    }

    public async Task<FavoriteSource> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId)
    {
        return await Context.Set<FavoriteSource>()
            .FirstOrDefaultAsync(f => f.NewsApiKey == newsApiKey && f.SourceId == sourceId)
            ;
    }
}