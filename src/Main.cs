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
            Console.WriteLine("Name:" + Map.Name);
            Console.WriteLine("Version: " + Map.Version);
            Console.WriteLine("Size: " + Map.Size);
            Console.WriteLine("Desc:" + Map.Description);
            Console.WriteLine("Has heroes: " + Map.IsHeroPresent);
            Console.WriteLine("Difficulty: " + Map.Difficulty);
            Console.WriteLine("Players: ");
            foreach(Player Player in Map.Players)
            {
                if(!Player.AllowedForHuman && !Player.AllowedForComputer )
                {
                    continue;
                }
                Console.Write("    ");
                Console.Write("Player " + ((int)Player.Color));
                Console.Write(" (" + Player.Color + ")");
                Console.WriteLine("\n        Allowed for human: " + Player.AllowedForHuman);
                Console.WriteLine("        Allowed for computer: " + Player.AllowedForComputer);
                Console.WriteLine("        Behavior: " + Player.Behavior);
                Console.WriteLine("        Towns available: " + Player.TownsAvailable);
                Console.WriteLine("        Unknown: " + Player.Unknown.ToString("X2"));         
                if(Player.HasMainTown)
                {
                    Console.WriteLine("        Has main town at: " + Player.MainTownLocation);    
                }      
                if(Player.StartingHero != null)
                {
                    Console.WriteLine("        Starting hero: " + Player.StartingHero.Id); 
                    Console.WriteLine("        Starting hero portrait: " + Player.StartingHero.Portrait);
                    Console.WriteLine("        Starting hero name: " + Player.StartingHero.Name);
                }
            }
        }
    }
}
