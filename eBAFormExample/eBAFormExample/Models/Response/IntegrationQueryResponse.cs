using System.Data;

namespace eBAFormExample.Models.Response
{
    public class IntegrationQueryResponse : BaseResponse
    {
        public DataTable Data { get; set; }
    }
}
