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

            Console.WriteLine("Version: " + Map.Version);
            Console.WriteLine("Size is: " + GetFormattedMapSize(Map.MapSize, Map.HasSubterrain));
            Console.WriteLine("Has heroes: " + Map.IsHeroPresent);
        }
        
        private String GetFormattedMapSize(Int32 Size, Boolean HasSubterrain)
        {
            String Result = Size.ToString() + "x" + Size.ToString() + "x";
            Result = (HasSubterrain) ? Result + "1" : Result + "0";
            return Result;
        }
    }
}
