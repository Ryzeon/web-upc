using CatchUpPlatform.API.News.Domain.Model.Commands;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

public class FavoriteSource
{
    public int Id { get; private set; }
    public string NewsApiKey { get; private set; }
    public string SourceId { get; private set; }

    protected FavoriteSource()
    {
        this.SourceId = string.Empty;
        this.NewsApiKey = string.Empty;
    }

    public FavoriteSource(CreateFavoriteSourceCommand command)
    {
        
        this.NewsApiKey = command.NewsApiKey;
        this.SourceId = command.SourceId;
    }
}