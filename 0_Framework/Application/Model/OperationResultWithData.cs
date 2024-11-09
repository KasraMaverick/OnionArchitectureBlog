namespace _0_Framework.Application.Model
{
    public class OperationResultWithData<T>
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public T? Result { get; set; }

        public OperationResultWithData()
        {
            IsSucceeded = false;
        }

        public OperationResultWithData<T> Succeeded(T result, string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            Result = result;
            return this;
        }

        public OperationResultWithData<T> Failed(string message = "عملیات ناموفق")
        {
            IsSucceeded = false;
            Message = message;
            Result = default;
            return this;
        }
    }
}
