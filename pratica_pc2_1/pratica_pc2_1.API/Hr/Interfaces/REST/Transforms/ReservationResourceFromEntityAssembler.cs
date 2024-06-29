using pratica_pc2_1.API.Hr.Domain.Model.Aggregates;
using pratica_pc2_1.API.Hr.Interfaces.REST.Resources;

namespace pratica_pc2_1.API.Hr.Interfaces.REST.Transforms;

public class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(Reservation entity) => new ReservationResource(
        entity.Id,
        entity.Email,
        entity.CustomerName,
        entity.CompanyName,
        entity.ServiceType,
        entity.StartDate,
        entity.EndDate);
}