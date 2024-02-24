using SalesAndService.Core.Extentions.FluentValidation.ComplexTypes;
using SalesAndService.Core.Utilities.Result.ComplexTypes;

namespace SalesAndService.Core.Utilities.Result.Base
{
    public interface IResult
    {
        public ResultStatus Status { get; }
        public string Messages { get; }
        public IEnumerable<ErrorModels> ValidationErrors { get; }
    }
}
