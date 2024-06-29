using pratica_pc2_1.API.Hr.Domain.Model.Commands;
using pratica_pc2_1.API.Hr.Domain.Model.ValueObjects;

namespace pratica_pc2_1.API.Hr.Domain.Model.Aggregates;

public partial class Reservation
{
    public int Id { get; set; }
    
    public string CustomerName { get; set; }
    
    public string CompanyName { get; set; }
    
    public string Email { get; set; }
    
    public string ServiceType { get; private set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }

    public Reservation() {}
    public Reservation(CreateReservationCommand command)
    {
        CustomerName = command.CustomerName;
        CompanyName = command.CompanyName;
        Email = command.Email;
        ServiceType = Enum.Parse<EServiceType>(command.ServiceType).ToString();
        StartDate = command.StartDate;
        EndDate = command.EndDate;
    }
}