using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace FormFromJSON
{
    public class ItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(PageItem).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var type= (string)jo["Type"];

            PageItem item;

            switch (type)
            {
                case "filler":
                    item = new Filler();
                    break;
                case "text":
                    item = new Text();
                    break;
                case "textArea":
                    item = new TextArea();
                    break;
                case "checkbox":
                    item = new Checkbox();
                    break;
                case "button":
                    item = new Button();
                    break;
                case "select":
                    item = new Select();
                    break;
                case "radio":
                    item = new Radio();
                    break;
                default:
                    item = null;
                    break;
            }

            serializer.Populate(jo.CreateReader(), item);

            return item;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
