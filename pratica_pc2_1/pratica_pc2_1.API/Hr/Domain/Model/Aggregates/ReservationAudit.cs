using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pratica_pc2_1.API.Hr.Domain.Model.Aggregates;

public partial class Reservation: IEntityWithCreatedUpdatedDate
{
    
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}