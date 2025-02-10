namespace CQRSMediaTR.API.Models
{
    public class DataResponse
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public object Result { get; set; }
        public bool IsSuccess { get; set; }
        public int? Count { get; set; }

        public DataResponse()
        {
        }

        public DataResponse(string message, string statusCode, object result, bool isSuccess, int? count)
        {
            Message = message;
            StatusCode = statusCode;
            Result = result;
            IsSuccess = isSuccess;
            Count = count;
        }
    }
}
