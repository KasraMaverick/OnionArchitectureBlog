namespace _0_Framework.Application.Model
{
    public class OperationResult
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public OperationResult()
        {
            IsSucceeded = false;
        }

        public OperationResult Succeeded(object data, string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            Data = data;
            return this;
        }
        public OperationResult Succeeded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            Data = null;
            return this;
        }


        public OperationResult Failed(string message = "عملیات ناموفق")
        {
            IsSucceeded = false;
            Message = message;
            Data = null;
            return this;
        }
    }
}
