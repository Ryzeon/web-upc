using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelStringExtensions
{
    public static List<String> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}