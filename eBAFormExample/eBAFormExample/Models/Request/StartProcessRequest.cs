using System.Collections.Generic;

namespace eBAFormExample.Models.Request
{
    public class StartProcessRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string Process { get; set; }
        public List<StartProcessParameter> Parameters { get; set; } = new List<StartProcessParameter>();
    }

    public class StartProcessParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
