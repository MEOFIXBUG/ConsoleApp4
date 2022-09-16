using BoxPacker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var packer = new RotatePacker();

            Random rand = new Random();

            for (uint i = 1; i < 10; i++)
            {
                RotatePacker.Box box = new RotatePacker.Box()
                {
                    width = i * 100,
                    height = 500
                };
                packer.AddBox(box);
            }
            packer.Pack(1300, 1000);
            var a = packer.boxes.Where(c => c.position != null).ToList();
            
        }
    }
}
