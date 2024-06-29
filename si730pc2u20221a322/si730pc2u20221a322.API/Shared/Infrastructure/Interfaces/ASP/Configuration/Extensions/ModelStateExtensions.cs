using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace si730pc2u20221a322.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary
                .SelectMany(m => m.Value!.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
