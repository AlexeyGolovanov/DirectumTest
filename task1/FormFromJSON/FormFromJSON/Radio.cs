using System;
using System.Collections.Generic;
using System.Text;

namespace FormFromJSON
{
    public class Radio:PageItem
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Class { get; set; }
        public bool Disabled { get; set; }
        public string[,] Items { get; set; }
        public List<Item> LItems { get; private set; }
        public void FillList()
        {
            LItems = new List<Item>();
            for (var i = 0; i < Items.Length / 3; i++)
            {
                LItems.Add(new Item(Items[i, 0], Items[i, 1], Items[i, 2]));
            }
        }
        public override string ToHtmlStr()
        {
            var Result = new StringBuilder("<p><b>");
            Result.Append(Label).Append("</b><br>\n");
            if (LItems == null || LItems.Count == 0)
            {
                FillList();
            }
            foreach (var i in LItems)
            {
                Result.AppendFormat("<input type=\"radio\" name=\"{0}\" class = \"{1}\" value=\"{2}\" ",Name, Class, i.Value);
                if(Disabled)
                {
                    Result.Append("disabled ");
                }
                if (i.Checked)
                {
                    Result.Append("checked ");
                }
                Result.Append(">").Append(i.Label).Append("<Br>");
            }
            Result.Append("</p>\n");
            return Result.ToString();
        }
    }
    public class Item
    {
        public string Value { get; private set; }
        public string Label { get; private set; }
        public bool Checked { get; private set; }

        public Item(string value, string label, string check)
        {
            Value = value;
            Label = label;
            Checked = Convert.ToBoolean(check);
        }
    }
}
