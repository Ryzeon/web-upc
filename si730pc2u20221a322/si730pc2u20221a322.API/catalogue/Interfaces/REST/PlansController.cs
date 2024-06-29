using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730pc2u20221a322.API.catalogue.Domain.Services;
using si730pc2u20221a322.API.catalogue.Interfaces.REST.Resources;
using si730pc2u20221a322.API.catalogue.Interfaces.REST.Transforms;

namespace si730pc2u20221a322.API.catalogue.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PlansController(IPlantCommandService commandService): ControllerBase
{
    /// <summary>
    /// Post method for creating a plant, using CQRS, the command is handled by the commandService, returning the created plant with a 201 status code
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    /// <author>Alex Avila Asto (u20221a322) </author>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreatePlant(CreatePlantResource resource)
    {
        var createPlantCommand = CreatePlantCommandFromResourceAssembler.ToCommandFromResource(resource);
        var plant = await commandService.handle(createPlantCommand);
        var plantResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plant);
        return StatusCode(201, plantResource);
    }
}