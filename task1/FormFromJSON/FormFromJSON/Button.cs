namespace FormFromJSON
{
    public class Button:PageItem
    {
        public string Class { get; set; }
        public string Text { get; set; }

        public override string ToHtmlStr()
        {
            var tmpRes = string.Format("<p><button class = \"{0}\" >{1}</button></p>\n",Class, Text);
            return tmpRes;
        }
    }
}
