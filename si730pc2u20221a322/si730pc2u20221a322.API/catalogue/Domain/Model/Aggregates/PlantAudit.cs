using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;

public partial class Plant : IEntityWithCreatedUpdatedDate
{
    
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}