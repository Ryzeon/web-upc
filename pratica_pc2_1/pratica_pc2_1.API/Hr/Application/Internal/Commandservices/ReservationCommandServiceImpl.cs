using pratica_pc2_1.API.Hr.Domain.Model.Aggregates;
using pratica_pc2_1.API.Hr.Domain.Model.Commands;
using pratica_pc2_1.API.Hr.Domain.Model.ValueObjects;
using pratica_pc2_1.API.Hr.Domain.Repositories;
using pratica_pc2_1.API.Hr.Domain.Services;
using pratica_pc2_1.API.Shared.Domain.Repositories;

namespace pratica_pc2_1.API.Hr.Application.Internal.Commandservices;

public class ReservationCommandServiceImpl(IReservationRepository reservationRepository, IUnitOfWork unitOfWork): IReservationCommandService
{
    public async Task<Reservation> CreateReservationAsync(CreateReservationCommand command)
    {
        if (await reservationRepository.ExitsByEmailAndCompanyName(command.Email, command.CompanyName))
        {
            throw new Exception("Reservation with the same email and company name already exists");
        }

        // Validate service type as enum
        if (!Enum.IsDefined(typeof(EServiceType), command.ServiceType))
        {
            throw new Exception("Invalid service type");
        }

        var reservation = new Reservation(command);
        await reservationRepository.AddAsync(reservation);
        await unitOfWork.CompleteAsync();
        return reservation;
    }
}