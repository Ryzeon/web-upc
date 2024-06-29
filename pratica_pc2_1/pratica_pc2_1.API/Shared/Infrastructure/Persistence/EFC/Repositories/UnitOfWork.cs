using pratica_pc2_1.API.Shared.Domain.Repositories;
using pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}
