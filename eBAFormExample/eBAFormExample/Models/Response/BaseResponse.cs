namespace eBAFormExample.Models.Response
{
    public class BaseResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool Status { get; set; }
    }
}
