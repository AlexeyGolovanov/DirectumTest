namespace FormFromJSON
{
    public abstract class PageItem
    {
        public string Type { get; set; }
        public abstract string ToHtmlStr();
    }
}
