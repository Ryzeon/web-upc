namespace si730pc2u20221a322.API.catalogue.Domain.Model.Commands;

public record CreatePlantCommand(
    string CommonName,
    string ScientificName,
    int WateringLevelId,
    string OtherName,
    string ReferenceImageUrl
    );