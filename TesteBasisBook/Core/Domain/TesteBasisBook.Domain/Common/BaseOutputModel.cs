
namespace TesteBasisBook.Domain.Common
{
    public class BaseOutputModel<T>
    {
        public BaseOutputModel()
        {
            IsSuccess = true;
            BusinessRuleViolation = false;
        }
        public BaseOutputModel(string message)
        {
            IsSuccess = true;
            BusinessRuleViolation = false;
            Message = message;
        }
        public T Value { get; } = default!;
        public BaseOutputModel(string message, bool success, bool businessRuleViolation)
        {
            IsSuccess = success;
            Message = message;
            BusinessRuleViolation = businessRuleViolation;
        }
        public BaseOutputModel(T data, string message = null, bool businessRuleViolation = false)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
            BusinessRuleViolation = businessRuleViolation;
        }
        public BaseOutputModel(T data)
        {
            IsSuccess = true;
            Data = data;
            BusinessRuleViolation = false;
        }

        public static BaseOutputModel<T> Success(T value)
        {
            return new BaseOutputModel<T>(value);
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool BusinessRuleViolation { get; set; }
        public bool GetNotFount { get; set; }
        public T Data { get; set; }
    }
}
