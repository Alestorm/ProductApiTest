namespace ProductsApiTest.WebApi.Domain.Entities
{
    public class Result<T>
    {
        public T Value{ get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSucess => ErrorMessage == null;

        public static Result<T> Success(int status,T value)
        {
            return new Result<T>
            {
                Status = status,
                Value = value
            };
        }
        public static Result<T> Failure(int status,string errorMessage)
        {
            return new Result<T>
            {
                Status = status,
                ErrorMessage = errorMessage
            };
        }
    }
}
