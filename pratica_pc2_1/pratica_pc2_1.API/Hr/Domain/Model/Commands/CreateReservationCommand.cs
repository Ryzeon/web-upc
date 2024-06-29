namespace pratica_pc2_1.API.Hr.Domain.Model.Commands;

public record CreateReservationCommand(
    string CustomerName,
    string CompanyName,
    string Email,
    string ServiceType,
    DateTime StartDate,
    DateTime EndDate
);