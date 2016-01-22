using System;
public class HeaderReader
{
    public Int32 VersionOffset = 0x00000000;
    public Int32 VersionSize = 4;
    public Int32 IsHeroPresentOffset = 0x00000004;
    public Int32 MapSizeOffset = 0x00000005;
    public Int32 MapSizeSize = 4;
    public Int32 HasSubterrainOffset = 0x0000009;
    
    public Int32 NameOffset = 0x000000A;
    
    private Int32? _nameSize;
    public Int32 NameSize
    {
        get
        {
            if(_nameSize == null)
            {
                var Reader = new BinaryReader();
                _nameSize = Reader.ReadInt32(NameOffset, Source);
            }
            return (Int32)_nameSize;
        }
    }
    
    public byte[] Source;
    
    Version Version;
    
    public HeaderReader(byte[] Source)
    {
        this.Source = Source;
    }

    public Version GetVersion()
    {
        var Reader = new BinaryReader();
        var Result = Reader.ReadInt32(VersionOffset, Source);
        return (Version)Result;
    }
     
    public Int32 GetMapSize()
    {
        var Reader = new BinaryReader();
        var Result = Reader.ReadInt32(MapSizeOffset, Source);
        return Result;
    }
    
    public String GetName()
    {
        return null;
    }
        
    public Boolean GetIsHeroPresent()
    {
        var Reader = new BinaryReader();
        return Reader.ReadBoolean(IsHeroPresentOffset, Source);
    }

    public Boolean GetHasSubterrain()
    {
        var Reader = new BinaryReader();
        return Reader.ReadBoolean(HasSubterrainOffset, Source);
    }
}