using si730pc2u20221a322.API.catalogue.Domain.Model.Aggregates;
using si730pc2u20221a322.API.catalogue.Domain.Model.Commands;

namespace si730pc2u20221a322.API.catalogue.Domain.Services;

public interface IPlantCommandService
{
    Task<Plant> handle(CreatePlantCommand command);
}