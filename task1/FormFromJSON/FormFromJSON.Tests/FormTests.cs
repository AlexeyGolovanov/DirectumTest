using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace FormFromJSON.Tests
{
    [TestClass]
    public class FormTests
    {
        [TestMethod]
        public void ReadJson()
        {
            var form = new Form();
            form.ReadFromJson(@"../../filename.json");
            Assert.IsNotNull(form);
        }

        [TestMethod]
        public void WriteToHtml()
        {
            var form = new Form();
            form.ReadFromJson(@"../../filename.json");
            form.WriteToHtml(@"example.html");
            Process.Start(@"example.html");
            Assert.IsNotNull(form);
        }
    }
}
