using si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;
using si730pc2u20221a322.API.catalogue.Interfaces.REST.Resources;

namespace si730pc2u20221a322.API.catalogue.Interfaces.REST.Transforms;

public class PlanResourceFromEntityAssembler
{
    /// <summary>
    /// Simple assembler for create a PlantResource from a Plant entity
    /// </summary>
    /// <param name="plant"></param>
    /// <returns></returns>
    /// <author>Alex Avila Asto (u20221a322) </author>
    public static PlantResource ToResourceFromEntity(Plant plant)
    {
        return new PlantResource(
            plant.Id,
            plant.CommonName,
            plant.ScientificName,
            (int)plant.WateringLevelId,
            plant.WateringLevel,
            plant.OtherName,
            plant.ReferenceImageUrl
        );
    }
}