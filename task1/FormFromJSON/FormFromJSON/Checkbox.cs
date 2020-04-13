using System.Text;

namespace FormFromJSON
{
    public class Checkbox: PageItem
    {
        public string Label { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Required { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
        public override string ToHtmlStr()
        {
            var Result = new StringBuilder("<p><b>");
            Result.Append(Label).Append("</b><br>\n");
                Result.AppendFormat("<input type = \"checkbox\" name = \"{0}\" value = \"{1}\" class = \"{2}\" ", Name, Value, Class);
                if (Required) Result.Append("Required ");
                if (Disabled) Result.Append("Disabled");
                if (Checked) Result.Append("Checked");
                Result.Append(">").Append(Value).Append("\n");
            Result.Append(" </p>\n");
            return Result.ToString();
        }
    }
}
