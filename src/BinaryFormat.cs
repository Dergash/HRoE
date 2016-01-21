
using System;
public class BinaryFormat
{
    public const Int32 VersionOffset = 0x00000000;
    public const Int32 IsHeroPresentOffset = 0x00000004;
    public const Int32 MapSizeOffset = 0x00000005;
    

    public byte[] File;
    public byte[] Version = new byte[4]; 
    public byte[] IsHeroPresent = new byte[1];
    public byte[] MapSize = new byte[4];
    public byte[] HasUndegroundLevel = new byte[1];
    public byte[] MapDescriptionSize = new byte[4];
    public byte[] MapDescription;
    public byte[] MapNameSize = new byte[4];
    public byte[] MapName;
    public byte[] Difficulty = new byte[1];
    
}