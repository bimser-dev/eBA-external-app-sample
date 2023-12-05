namespace eBAFormExample.Models.Request
{
    public class GetProcessEventsRequest
    {
        public Token Token { get; set; }
        public int ProcessId { get; set; }
        public int RequestId { get; set; }
    }
}
