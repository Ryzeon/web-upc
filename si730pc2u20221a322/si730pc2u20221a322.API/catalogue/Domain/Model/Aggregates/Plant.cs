using System.ComponentModel.DataAnnotations;
using si730pc2u20221a322.API.catalogue.Domain.Model.Commands;
using si730pc2u20221a322.API.catalogue.Domain.Model.ValueObjects;

namespace si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;

public partial class Plant
{
    public int Id {get; set;}
    
    // e id (int, obligatorio,
    //     autogenerado, llave primaria), commonName (string, obligatorio, máximo 50 caracteres),
    // scientificName (string, obligatorio, máximo 150 caracteres), wateringLevelId (int, obligatorio,
    //     en base a enumeration EWateringLevel), otherName (string, opcional, máximo 360
    //     caracteres), referenceImageUrl (string, obligatorio)
    
    [Required]
    public string CommonName {get; set;}
    
    [Required]
    public string ScientificName {get; set;}
    
    [Required]
    public EWateringLevel WateringLevelId {get; set;}
    
    public string OtherName {get; set;}
    
    [Required]
    public string ReferenceImageUrl {get; set;}
    
    public string WateringLevel => WateringLevelId.ToString();
    
    public Plant() {}

    public Plant(CreatePlantCommand command)
    {
        CommonName = command.CommonName;
        ScientificName = command.ScientificName;
        WateringLevelId = (EWateringLevel)command.WateringLevelId;
        OtherName = command.OtherName;
        ReferenceImageUrl = command.ReferenceImageUrl;
    }
}