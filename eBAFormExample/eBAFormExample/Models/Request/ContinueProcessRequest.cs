namespace eBAFormExample.Models.Request
{
    public class ContinueProcessRequest
    {
        public Token Token { get; set; }
        public int ProcessId { get; set; }
        public int RequestId { get; set; }
        public int EventId { get; set; }
        public string ReasonText { get; set; }
        public int EventFormId { get; set; }
        public bool HasSigned { get; set; }
    }
}
