namespace TesteBasisBook.Domain.Common
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            IsSuccess = true;
        }
        public BaseResponse(string message)
        {
            IsSuccess = true;
            Message = message;
        }
        public BaseResponse(string message, bool success)
        {
            IsSuccess = success;
            Message = message;
        }
        public BaseResponse(T data, string message = null)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }
        public BaseResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public static BaseResponse<T> Success(T value)
        {
            return new BaseResponse<T>(value);
        }

        public bool IsSuccess { get; set; }
        public bool BusinessRuleViolation { get; set; }
        public bool GetNotFount { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public T Data { get; set; }
    }
}
