using si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;
using si730pc2u20221a322.API.Shared.Domain.Repositories;

namespace si730pc2u20221a322.API.catalogue.Domain.Repositories;

public interface IPlantRepository: IBaseRepository<Plant>
{
 
 /// <summary>
 /// Define a async method to check if a plant exists by its common name and scientific name
 /// </summary>
 /// <param name="commonName"></param>
 /// <param name="scientificName"></param>
 /// <author>Alex Avila Asto (u20221a322) </author>
 /// <returns></returns>
 Task<bool> ExistPlantByNameAndScientificName(string commonName, string scientificName);
 
 /// <summary>
 /// Define a async method to check if a plant exists by its other name
 /// </summary>
 /// <param name="otherName"></param>
 /// <returns></returns>
 /// <author>Alex Avila Asto (u20221a322) </author>
 Task<bool> ExistPlantByOtherName(string otherName);
}