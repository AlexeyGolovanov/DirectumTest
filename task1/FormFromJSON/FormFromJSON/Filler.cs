namespace FormFromJSON
{
    public class Filler:PageItem
    {
        public string Message { get; set; }
        public override string ToHtmlStr()
        {
            return "<p>" + Message + "</p>\n";
        }
    }
}
