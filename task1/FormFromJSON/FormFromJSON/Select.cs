using System;
using System.Collections.Generic;
using System.Text;

namespace FormFromJSON
{
    public class Select:PageItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
        public string Class { get; set; }
        public bool Disabled { get; set; }
        public string[,] Options { get; set; }
        public List<Option> LOptions { get; private set; }

        public void FillList()
        {
            LOptions = new List<Option>();
            for(var i = 0; i < Options.Length/3; i++)
            {
                LOptions.Add(new Option(Options[i,0], Options[i, 1], Options[i, 2]));
            }
        }
        public override string ToHtmlStr()
        {
            var Result = new StringBuilder("<p><b>");
            Result.Append(Label).Append("</b><br></p>\n<p><select ");
            Result.AppendFormat("name = \"{0}\" value = \"{1}\" class = \"{2}\" ", Name, Value, Class);
            if (Required) Result.Append("Required ");
            if (Disabled) Result.Append("Disabled");
            Result.Append(">\n");
            if(LOptions == null || LOptions.Count == 0)
            {
                FillList();
            }
            foreach(var o in LOptions)
            {
                Result.Append("<option value =\"").Append(o.Value).Append("\" ");
                if(o.Selected)
                {
                    Result.Append("selected");
                }
                Result.Append(">").Append(o.Text).Append("</option>\n");
            }
            Result.Append("</select></p>\n");
            return Result.ToString();
        }
    }
    public class Option
    {
        public string Value { get; private set; }
        public string Text { get; private set; }
        public bool Selected { get; private set; }

        public Option(string value, string text, string selected)
        {
            Value = value;
            Text = text;
            Selected = Convert.ToBoolean(selected);
        }
    }

}
