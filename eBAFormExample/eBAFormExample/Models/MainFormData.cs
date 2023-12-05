using eBAFormExample.Models.Request;
using System.Collections.Generic;

namespace eBAFormExample.Models
{
    public class MainFormData
    {
        public KeyValuePair<string,string> Department { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsOpen { get; set; }
        public KeyValuePair<string, string> Gender { get; set; }
        public string OptionName { get; set; }
        public List<ObjectItem> Fruits { get; set; }
        public List<DetailsGridItem> DetailsGridItem { get; set; }
        public List<TableItem> TableItem { get; set; }
        public Details Details { get; set; }
    }
}
