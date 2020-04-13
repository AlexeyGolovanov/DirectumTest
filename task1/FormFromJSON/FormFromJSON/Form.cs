using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FormFromJSON
{
    public class Form
    {
        public string Name { get; set; }
        public string PostMessage { get; set; }
        public List<PageItem> Items { get; set; }

        public void ReadFromJson(string path)
        {
            var str = File.ReadAllText(path);
            Form tmp = JsonConvert.DeserializeObject<Form>(str, new ItemConverter());
            Name = tmp.Name;
            PostMessage = tmp.PostMessage;
            Items = tmp.Items;
        }

        public void WriteToHtml(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write("<!DOCTYPE html >\n" +
                    "<html lang=\"ru\" dir=\"ltr\">\n" +
                    "<head>\n" +
                    "<meta charset=\"utf - 8\">\n" +
                    "<title>Form generator</title>\n" +
                    "</head>\n"+
                    "<body>\n"+
                    "<form name=\"" + Name + "\">\n"+
                    "<h2>" + Name + "</h2>\n");
                foreach (var element in Items)
                {
                    sw.Write(element.ToHtmlStr());
                }
                sw.Write("</form>\n"+
                        "</body>\n" +
                        "</ html >");
            }
        }
    }
}
