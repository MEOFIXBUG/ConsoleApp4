using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class SVG
    {
        const string HeaderText = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <svg xmlns=\"http://www.w3.org/2000/svg\" " +
                                  "xmlns:xlink=\"http://www.w3.org/1999/xlink\" height=\"{0}\" width=\"{1}\" style=\"border:1px solid black\">";

        private string BoxSVG;
        const string Footer = "</svg>";
        public int HeightContainer { get; set; }
        public int WidthContainer { get; set; }
        public List<SVGBox> data { get; set; }
        public SVG()
        {
            BoxSVG = System.IO.File.ReadAllText(@"RectangleFormat.xml");
        }
        public string SVgContent()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format(HeaderText, HeightContainer, WidthContainer));
            foreach (var item in data)
            {
                result.AppendLine(string.Format(BoxSVG, item.x, item.y, item.w, item.h, item.strokeColor, item.x+item.w/2, item.y+item.h/2, $"{item.h}x{item.w}"));
            }
            result.AppendLine(Footer);
            return result.ToString();
        }
    }
}
