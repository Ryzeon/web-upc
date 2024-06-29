using si730pc2u20221a322.API.Shared.Domain.Repositories;
using si730pc2u20221a322.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace si730pc2u20221a322.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}
