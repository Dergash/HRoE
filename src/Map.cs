using System.IO;
public class Map
{
    public Version Version;
    public Map(byte[] Source)
    {
        var Reader = new BinaryReader(Source);
        this.Version = Reader.ReadVersion();
    }
    
    public Map()
    {
        
    }
}