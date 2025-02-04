using System.Net.Mime;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;
using CatchUpPlatform.API.News.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CatchUpPlatform.API.News.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FavoriteSourcesController(
    IFavoriteSourceCommandService favoriteSourceCommandService,
    IFavoriteSourceQueryService favoriteSourceQueryService
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await favoriteSourceCommandService.Handle(createFavoriteSourceCommand);
        return CreatedAtAction(
            nameof(GetFavoriteSourceById),
            new { id = result.Id },
            FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result)
        );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
        var favoriteSource = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(favoriteSource);
        return Ok(resource);
    }

    private async Task<ActionResult> GetAllFavoriteSourcesByNewsApiKey(string newsApiKey)
    {
        var getAllFavoriteSourcesByNewsApiKeyQuery = new GetAllFavoriteSourcesByNewsApiKeyQuery(newsApiKey);
        var result = await favoriteSourceQueryService.Handle(getAllFavoriteSourcesByNewsApiKeyQuery);
        var resources = result.Select(FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetFavoriteSourceByNewsApiKeyAndSourceId(string newsApiKey, string sourceId)
    {
        var getFavoriteSourceByNewsApiKeyAndSourceIdQuery =
            new GetFavoriteSourceByNewsApiKeyAndSourceIdQuery(newsApiKey, sourceId);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByNewsApiKeyAndSourceIdQuery);
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllFavoriteSourcesFromQuery(
        [FromQuery] string newsApiKey,
        [FromQuery] string? sourceId)
    {
        return string.IsNullOrEmpty(sourceId)
            ? await GetAllFavoriteSourcesByNewsApiKey(newsApiKey)
            : await GetFavoriteSourceByNewsApiKeyAndSourceId(newsApiKey, sourceId);
    }
}