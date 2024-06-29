using pratica_pc2_1.API.Hr.Domain.Model.Commands;
using pratica_pc2_1.API.Hr.Interfaces.REST.Resources;

namespace pratica_pc2_1.API.Hr.Interfaces.REST.Transforms;

public class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource) => new CreateReservationCommand(
        resource.CustomerName,
        resource.CompanyName,
        resource.Email,
        resource.ServiceType,
        resource.StartDate,
        resource.EndDate
    );
}