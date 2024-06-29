using pratica_pc2_1.API.Hr.Domain.Model.Aggregates;
using pratica_pc2_1.API.Shared.Domain.Repositories;

namespace pratica_pc2_1.API.Hr.Domain.Repositories;

public interface IReservationRepository: IBaseRepository<Reservation>
{
    Task<bool> ExitsByEmailAndCompanyName(string email, string companyName);
}