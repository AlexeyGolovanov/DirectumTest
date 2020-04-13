namespace FormFromJSON
{
    public class TextArea:PageItem
    {
        public string Name { get; set; }
        public string Placeholder { get; set; }
        public bool Required { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
        public string Class { get; set; }
        public bool Disabled { get; set; }

        public override string ToHtmlStr()
        {
            var tmpRes = string.Format("<p><b>{0}</b><br>\n<textarea type = \"text\" name = \"{1}\" placeholder = \"{2}\" value = \"{3}\" class = \"{4}\" ", Label, Name, Placeholder, Value, Class);
            if (Required) tmpRes += "Required ";
            if (Disabled) tmpRes += "Disabled";
            tmpRes += "></textarea>\n </p>\n";
            return tmpRes;
        }
    }
}
