using Microsoft.EntityFrameworkCore;
using si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;
using si730pc2u20221a322.API.catalogue.Domain.Repositories;
using si730pc2u20221a322.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u20221a322.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730pc2u20221a322.API.catalogue.Infrastructure.Persistence.EFC.Repositories;

public class PlantRepositoryImpl(AppDbContext context): BaseRepository<Plant>(context), IPlantRepository
{
    /// <summary>
    /// Using Microsoft.EntityFrameworkCore to check if a plant exists by its common name and scientific name by Querying the database
    /// </summary>
    /// <param name="commonName"></param>
    /// <param name="scientificName"></param>
    /// <returns></returns>
    /// <author>Alex Avila Asto (u20221a322) </author>
    public async Task<bool> ExistPlantByNameAndScientificName(string commonName, string scientificName)
    {
        return await context.Set<Plant>().AnyAsync(x => x.CommonName == commonName && x.ScientificName == scientificName);
    }

    /// <summary>
    /// Using Microsoft.EntityFrameworkCore to check if a plant exists by other name by Querying the database
    /// </summary>
    /// <param name="otherName"></param>
    /// <returns></returns>
    /// <author>Alex Avila Asto (u20221a322) </author>
    public async Task<bool> ExistPlantByOtherName(string otherName)
    {
       return await context.Set<Plant>().AnyAsync(x => x.OtherName == otherName);
    }
}