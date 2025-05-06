namespace CandidateHub.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string Message { get; }

        private Result(bool isSuccess, T value, string message)
        {
            IsSuccess = isSuccess;
            Value = value;
            Message = message;
        }

        public static Result<T> Success(T value) => new(true, value, "success");

        public static Result<T> Failure(string error) => new(false, default, error);
    }

}
