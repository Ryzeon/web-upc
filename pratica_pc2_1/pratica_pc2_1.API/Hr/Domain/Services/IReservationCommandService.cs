using pratica_pc2_1.API.Hr.Domain.Model.Aggregates;
using pratica_pc2_1.API.Hr.Domain.Model.Commands;

namespace pratica_pc2_1.API.Hr.Domain.Services;

public interface IReservationCommandService
{
    Task<Reservation> CreateReservationAsync(CreateReservationCommand command);
}