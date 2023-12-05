using System.Collections.Generic;

namespace eBAFormExample.Models.Request
{
    public class SaveDocumentDataRequest
    {
        public Token Token { get; set; }
        public int ProcessId { get; set; }
        public List<Form> Forms { get; set; } = new List<Form>();
    }

    public class Form
    {
        public string Name { get; set; }
        public List<Control> Controls { get; set; } = new List<Control>();
    }

    public class Control
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class DetailsGridItem
    {
        public List<Control> Columns { get; set; } = new List<Control>();
    }

    public class TableItem
    {
        public List<TableRowItem> Columns { get; set; } = new List<TableRowItem>();
    }

    public class TableRowItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Details
    {
        public string DetailsForm { get; set; }
        public List<DetailsRow> Rows { get; set; } = new List<DetailsRow>();
    }

    public class DetailsRow
    {
        public List<Control> Controls { get; set; } = new List<Control>();
    }
}
