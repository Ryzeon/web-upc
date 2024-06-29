using Microsoft.EntityFrameworkCore;
using pratica_pc2_1.API.Hr.Domain.Model.Aggregates;
using pratica_pc2_1.API.Hr.Domain.Repositories;
using pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pratica_pc2_1.API.Hr.Infrastructure.Persistence.EFC.Repositories;

public class ReservationRepositoryImpl(AppDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
    public async Task<bool> ExitsByEmailAndCompanyName(string email, string companyName)
    {
       return await context.Set<Reservation>().AnyAsync(r => r.Email == email && r.CompanyName == companyName);
    }
}