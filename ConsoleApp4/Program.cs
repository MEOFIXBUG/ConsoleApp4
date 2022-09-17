using BoxPacker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var packer = new Packer();

            Random rand = new Random();

            for (uint i = 1; i <= 30; i++)
            {
                Packer.Box box = new Packer.Box()
                {
                    width = i * 10,
                    height = 50
                };
                packer.AddBox(box);
            }
            int HeightContainer = 100;
            int WidthContainer = 1550;
            packer.Pack(WidthContainer, HeightContainer);
            var res = packer.boxes.Where(c => c.position != null).ToList();
            var COLORS = new List<string>(){ "#FFF7A5", "#FFA5E0", "#A5B3FF", "#BFFFA5", "#FFCBA5" ,
            "silver", "gray", "red", "maroon", "yellow", "olive", "lime", "green", "aqua", "teal", "blue", "navy", "fuchsia", "purple",
            "#111", "#222", "#333", "#444", "#555", "#666", "#777", "#888", "#999", "#AAA", "#BBB", "#CCC", "#DDD", "#EEE",
            "#EFD279", "#95CBE9", "#024769", "#AFD775", "#2C5700", "#DE9D7F", "#7F9DDE", "#00572C", "#75D7AF", "#694702", "#E9CB95", "#79D2EF",
            "#b58900", "#cb4b16", "#dc322f", "#d33682", "#6c71c4", "#268bd2", "#2aa198", "#859900"};
            int numberColors = COLORS.Count;
            var SVGObject = new SVG();
            SVGObject.HeightContainer = HeightContainer;
            SVGObject.WidthContainer = WidthContainer;
            Random rnd = new Random();
            SVGObject.data = res.Select(c => new SVGBox()
            {
                x = c.position.x,
                y=c.position.y,
                h=c.height,
                w=c.width,
                strokeColor=COLORS[rnd.Next(numberColors)]
            }).ToList();
            SVGObject.SVgContent();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(SVGObject.SVgContent());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            // Save the document to a file and auto-indent the output.
            XmlWriter writer = XmlWriter.Create("Demo.svg", settings);
            doc.Save(writer);
        }
    }
}
