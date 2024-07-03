namespace TimeLogger.Application
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string? Error { get; }
        public int StatusCode { get; }

        protected Result(bool isSuccess, T value, string error, int statusCode) 
            : this(isSuccess, value, error)
        {
            StatusCode = statusCode;
        }
        protected Result(bool isSuccess, T value, string error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, string.Empty);
        }

        public static Result<T> Failure(string error, int statusCode)
        {
            return new Result<T>(false, default, error, statusCode);
        }
    }
}
