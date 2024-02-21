using FluentValidation.Results;
using SalesAndService.Core.Extentions.FluentValidation.ComplexTypes;

namespace SalesAndService.Core.Extentions.FluentValidation
{
    public static class FluentApiExtentions
    {
        public static List<ErrorModels> GetErrors(this ValidationResult result)
        {
            List<ErrorModels> errors = new();
            foreach (var item in result.Errors)
            {
                errors.Add(new ErrorModels { PropertyName = item.PropertyName, ErrorMessage = item.ErrorMessage });
            }
            return errors;

        }
    }
}
