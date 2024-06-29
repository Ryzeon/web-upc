using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using pratica_pc2_1.API.Hr.Domain.Services;
using pratica_pc2_1.API.Hr.Interfaces.REST.Resources;
using pratica_pc2_1.API.Hr.Interfaces.REST.Transforms;

namespace pratica_pc2_1.API.Hr.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ReservationController(IReservationCommandService reservationCommandService): ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateReservation(CreateReservationResource resource)
    {
        var createReservationCommand = CreateReservationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var reservation = await reservationCommandService.CreateReservationAsync(createReservationCommand);
        var reservationResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return StatusCode(201, reservationResource);
    }
}