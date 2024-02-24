namespace SalesAndService.Core.Utilities.Result.Base
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
