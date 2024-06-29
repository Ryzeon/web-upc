namespace pratica_pc2_1.API.Hr.Interfaces.REST.Resources;

public record ReservationResource(
    int Id,
    string Email,
    string CustomerName,
    string CompanyName,
    string ServiceType,
    DateTime StartDate,
    DateTime EndDate
);