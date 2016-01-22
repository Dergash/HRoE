using System;
using System.IO;
public class Map
{
    public Version Version;
    public Boolean IsHeroPresent;
    public Int32 MapSize;
    public Boolean HasSubterrain;
    public String Name;
    public String Description;
    public Difficulty Difficulty;
    public Map(byte[] Source)
    {
        this.Parse(Source);
    }
    
    private void Parse(byte[] Source)
    {
        try
        {
            GetHeader(Source);
        }
        catch(BinaryReader.MapFormatException e)
        {
            Console.WriteLine("\nInvalid value occured while reading offest: " + e.ErrorOffset.ToString());
            Console.WriteLine("\n Value encountered: " + e.ErrorValue.ToString());
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
        
    private void GetHeader(Byte[] Source)
    {
        var HReader = new HeaderReader(Source); 
        this.Version = HReader.GetVersion();
        this.IsHeroPresent = HReader.GetIsHeroPresent();
        this.MapSize = HReader.GetMapSize();
        this.HasSubterrain = HReader.GetHasSubterrain();
        this.Name = HReader.GetName();
        this.Description = HReader.GetDescription();
        this.Difficulty = HReader.GetDifficulty();
    }
}