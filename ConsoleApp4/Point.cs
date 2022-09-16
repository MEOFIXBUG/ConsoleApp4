using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Point()
        {


        }
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        public string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
