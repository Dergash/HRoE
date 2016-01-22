using System;
public class HeaderReader
{
    public Int16 VersionOffset = 0x00000000;
    public Int16 VersionSize = 4;
    public Int16 IsHeroPresentOffset = 0x00000004;
    public Int16 MapSizeOffset = 0x00000005;
    public Int16 MapSizeSize = 4;
    public Int16 HasSubterrainOffset = 0x0000009;
    
    public Int16 MapNameOffset = 0x000000A;
    public Int16 MapNameSize;
    
    public byte[] Source;
    
    Version Version;
    
    public HeaderReader(byte[] Source)
    {
        this.Source = Source;
    }

    public Version GetVersion()
    {
        Byte[] Value = new Byte[VersionSize];
        for(int i = VersionOffset; i < VersionSize; i++)
        {
            Value[i] = Source[i];
        }
        if(Value[0] == (byte)Version.ROE)
        {
            return Version.ROE;
        }
        if(Value[0] == (byte)Version.AB)
        {
            return Version.AB;
        }
        if(Value[0] == (byte)Version.SOD)
        {
            return Version.SOD;
        }
        
        return Version.Unknown;
    }
    
    public Boolean GetIsHeroPresent()
    {
        return ReadBoolean(IsHeroPresentOffset, Source);
    }
    
    public Int32 GetMapSize()
    {
        Byte[] MapSizeValue = new Byte[MapSizeSize]; 
        Int32 Start = MapSizeOffset;
        Int32 End = MapSizeOffset + MapSizeSize;
        int j = 0;
        for(int i = Start; i < End; i++)
        {
            MapSizeValue[j] = Source[i];
            j++;
        }
        return BitConverter.ToInt32(MapSizeValue,0);
    }
    
    public Boolean GetHasSubterrain()
    {
        return ReadBoolean(HasSubterrainOffset, Source);
    }
    
    private Boolean ReadBoolean(Int32 Offset, Byte[] Source)
    {
        Byte Value = Source[Offset];
        if(Value == 0x00)
        {
            return false;
        }
        if(Value == 0x01)
        {
            return true;
        }
        throw new BinaryFormat.MapFormatException(Offset, new byte[] {Value});
    }
}