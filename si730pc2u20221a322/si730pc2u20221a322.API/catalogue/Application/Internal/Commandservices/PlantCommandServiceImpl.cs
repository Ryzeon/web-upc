using si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;
using si730pc2u20221a322.API.catalogue.Domain.Model.Commands;
using si730pc2u20221a322.API.catalogue.Domain.Model.ValueObjects;
using si730pc2u20221a322.API.catalogue.Domain.Repositories;
using si730pc2u20221a322.API.catalogue.Domain.Services;
using si730pc2u20221a322.API.Shared.Domain.Repositories;

namespace si730pc2u20221a322.API.catalogue.Application.Internal.Commandservices;

public class PlantCommandServiceImpl(IPlantRepository plantRepository, IUnitOfWork unitOfWork): IPlantCommandService
{
    
    /// <summary>
    /// Allows handling the creation of a plant, with constraints
    /// - If plant has other name, verify if it exists also with other name
    /// - If not, verify if it exists with the same common name and scientific name
    /// - Check if watering level is valid
    /// - Finally, add the plant to the repository
    /// </summary>
    /// <param name="command"></param>
    /// <author>Alex Avila Asto (u20221a322) </author>
    /// <exception cref="Exception"></exception>
    public async Task<Plant> handle(CreatePlantCommand command)
    {
        bool existPlant = 
            await plantRepository.ExistPlantByNameAndScientificName(command.CommonName, command.ScientificName);
        if (existPlant)
        {
            throw new Exception("Plant already exists");
        }

        // Check if plant exists with other name
        if (command.OtherName.Length > 1)
        {
            existPlant = await plantRepository.ExistPlantByOtherName(command.OtherName);
            if (existPlant)
            {
                throw new Exception("Plant already exists with other name");
            }
        }
        
        if (!Enum.IsDefined(typeof(EWateringLevel), command.WateringLevelId))
        {
            throw new Exception("Invalid watering level");
        }

        var plant = new Plant(command);
        await plantRepository.AddAsync(plant);
        await unitOfWork.CompleteAsync();
        return plant;
    }
}