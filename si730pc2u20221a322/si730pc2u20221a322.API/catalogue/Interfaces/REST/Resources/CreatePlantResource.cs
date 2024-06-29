namespace si730pc2u20221a322.API.catalogue.Interfaces.REST.Resources;

public record CreatePlantResource(
    string CommonName,
    string ScientificName,
    int WateringLevelId,
    string OtherName,
    string ReferenceImageUrl 
    );