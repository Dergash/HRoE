using System;
using System.IO;
public class Map
{
    public Version Version;
    public Int32 MapSize;
    public Map(byte[] Source)
    {
        var Reader = new BinaryReader(Source);
        this.Version = Reader.ReadVersion();
        this.MapSize = Reader.ReadMapSize();
    }
    
    public Map()
    {
        
    }
}