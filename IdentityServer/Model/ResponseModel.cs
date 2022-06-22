namespace IdentityServer.API.Model
{
    public class ResponseModel
    {
        public bool isError { get; set; }
        public string errorMessage { get; set; }
        public Object data { get; set; }
        public string? stackTrace { get; set; }
        public static ResponseModel GetSuccess(Object data)
        {
            return new ResponseModel
            {
                isError = false,
                data = data
            };
        }

        public static ResponseModel GetError(Exception ex)
        {
            return new ResponseModel
            {
                isError = true,
                errorMessage = ex.Message,
                stackTrace = ex.StackTrace
            };
        }
    }
}
