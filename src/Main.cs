using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HMM3
{
    public class Program
    {
        public void Main(string[] args)
        {
            byte[] Source = File.ReadAllBytes("Maps/Map1");
            var Map = new Map(Source);
            Console.WriteLine("Map version is: " + Map.Version);
        }
    }
}
