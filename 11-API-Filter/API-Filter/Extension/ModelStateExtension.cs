using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;

namespace API_Filter.Extension
{
    public static class ModelStateExtension
    {
        public static List<string> ExtractError(this ModelStateDictionary modelState)
        {
            return modelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();
        }
    }
}
