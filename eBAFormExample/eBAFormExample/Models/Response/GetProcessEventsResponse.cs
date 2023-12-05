using System.Collections.Generic;

namespace eBAFormExample.Models.Response
{
    public class GetProcessEventsResponse : BaseResponse
    {
        public bool ShowEvents { get; set; }
        public int OwnedStatus { get; set; }
        public List<DetailedEvent> DetailedEvents { get; set; } = new List<DetailedEvent>();
    }

    public class DetailedEvent
    {
        public int IdField { get; set; }
        public string DescriptionField { get; set; }
        public bool ReasonRequiredField { get; set; }
        public bool ValidationField { get; set; }
        public string EventFormField { get; set; }
        public string EventIconField { get; set; }
        public bool ConfirmField { get; set; }
        public bool FastApproveField { get; set; }
    }
}
