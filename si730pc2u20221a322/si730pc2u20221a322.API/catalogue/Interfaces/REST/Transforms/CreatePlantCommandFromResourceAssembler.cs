using si730pc2u20221a322.API.catalogue.Domain.Model.Commands;
using si730pc2u20221a322.API.catalogue.Interfaces.REST.Resources;

namespace si730pc2u20221a322.API.catalogue.Interfaces.REST.Transforms;

public class CreatePlantCommandFromResourceAssembler
{
    /// <summary>
    /// Simple assembler for retrieving a CreatePlantCommand from a CreatePlantResource
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    /// <author>Alex Avila Asto (u20221a322) </author>
    public static CreatePlantCommand ToCommandFromResource(CreatePlantResource resource)
    {
        return new CreatePlantCommand(
            resource.CommonName,
            resource.ScientificName,
            resource.WateringLevelId,
            resource.OtherName,
            resource.ReferenceImageUrl
        );
    }
}