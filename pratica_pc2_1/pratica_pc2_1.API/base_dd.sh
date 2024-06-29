#!/bin/bash

# Verificar si se proporcionaron suficientes argumentos
if [ "$#" -ne 2 ]; then
    echo "Uso: $0 <path> <DIR_NAME>"
    exit 1
fi

# Obtener los argumentos
BASE_PATH=$1
DIR_NAME=$2

# Crear la carpeta base
mkdir -p "$BASE_PATH/$DIR_NAME"

# Crear las subcarpetas
mkdir -p "$BASE_PATH/$DIR_NAME/Application/Internal/Commandservices"
mkdir -p "$BASE_PATH/$DIR_NAME/Application/Internal/Queryservices"

mkdir -p "$BASE_PATH/$DIR_NAME/Domain/Model/Aggregates"
mkdir -p "$BASE_PATH/$DIR_NAME/Domain/Model/Commands"
mkdir -p "$BASE_PATH/$DIR_NAME/Domain/Model/Queries"
mkdir -p "$BASE_PATH/$DIR_NAME/Domain/Model/ValueObjects"
mkdir -p "$BASE_PATH/$DIR_NAME/Domain/Repositories"
mkdir -p "$BASE_PATH/$DIR_NAME/Domain/Services"
mkdir -p "$BASE_PATH/$DIR_NAME/Infrastructure/Persistence/EFC/Repositories"

mkdir -p "$BASE_PATH/$DIR_NAME/Interfaces/REST"
mkdir -p "$BASE_PATH/$DIR_NAME/Interfaces/REST/Resources"
mkdir -p "$BASE_PATH/$DIR_NAME/Interfaces/REST/Transforms"

cat > "$BASE_PATH/${DIR_NAME}/Interfaces/REST/Transforms/Example.MD" << EOF
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.Id}, profileResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }
    
    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
    
}
EOF

echo "Estructura de directorios creada en $BASE_PATH/$DIR_NAME"