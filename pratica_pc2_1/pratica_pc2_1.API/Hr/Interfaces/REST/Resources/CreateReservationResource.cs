namespace pratica_pc2_1.API.Hr.Interfaces.REST.Resources;

public record CreateReservationResource(
    string CustomerName,
    string CompanyName,
    string Email,
    string ServiceType,
    DateTime StartDate,
    DateTime EndDate
);