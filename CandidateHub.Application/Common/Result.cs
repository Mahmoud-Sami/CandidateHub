using System.Text.Json.Serialization;

namespace CandidateHub.Application.Common
{
    public class Result<T>
    {
        [JsonPropertyOrder(0)]
        public bool IsSuccess { get; }

        [JsonPropertyOrder(2)]
        public T Value { get; }

        [JsonPropertyOrder(1)]
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
