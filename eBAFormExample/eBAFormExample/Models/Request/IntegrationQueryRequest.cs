using System.Collections.Generic;

namespace eBAFormExample.Models.Request
{
    public class IntegrationQueryRequest
    {
        public Token Token { get; set; }
        public string ConnectionName { get; set; }
        public string QueryName { get; set; }
        public List<IntegrationQueryParameter> Parameters { get; set; } = new List<IntegrationQueryParameter>();
    }

    public class IntegrationQueryParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
