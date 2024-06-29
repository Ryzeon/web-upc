namespace si730pc2u20221a322.API.catalogue.Interfaces.REST.Resources;

public record PlantResource(
    int Id,
    string CommonName,
    string ScientificName,
    int WateringLevelId,
    string WateringLevel,
    string OtherName,
    string ReferenceImageUrl
    );