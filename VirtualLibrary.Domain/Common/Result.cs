
namespace VirtualLibrary.Domain.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public List<string>? Errors { get; }

        private Result(bool isSuccess, T? value, List<string>? errors)
        {
            IsSuccess = isSuccess;
            Value = value;
            Errors = errors;
        }

        public static Result<T> Success(T value) => new(true, value, null);

        public static Result<T> Failure(List<string> errors) => new(false, default, errors);

        public static Result<T> Failure(string error) => new(false, default, new List<string> { error });
    }
}
