using SalesAndService.Core.Extentions.FluentValidation.ComplexTypes;
using SalesAndService.Core.Utilities.Result.ComplexTypes;

namespace SalesAndService.Core.Utilities.Result.Base
{
    public class Result : IResult
    {
        public string Messages { get; }
        public ResultStatus Status { get; }
        public IEnumerable<ErrorModels> ValidationErrors { get; }
        public Result(ResultStatus status, string StatusMessages, IEnumerable<ErrorModels> Errors) : this(status, StatusMessages)
        {
            ValidationErrors = Errors;
        }

        public Result(ResultStatus status, string StatusMessages) : this(status)
        {
            this.Messages = StatusMessages;
        }

        public Result(ResultStatus status)
        {
            this.Status = status;
        }

        public Result(ResultStatus status, IEnumerable<ErrorModels> Errors) : this(status, string.Empty, Errors)
        {

        }
    }
}
