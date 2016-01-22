using System;
public class HeaderReader
{
    public Int32 VersionOffset = 0x00000000;
    public Int32 IsHeroPresentOffset = 0x00000004;
    public Int32 MapSizeOffset = 0x00000005;
    public Int32 HasSubterrainOffset = 0x0000009;
    public Int32 NameSizeOffset = 0x000000A;
    public Int32 NameOffset = 0x000000E;
    public Int32 DescriptionSizeOffset;
    public Int32 DescriptionOffset;
    public Int32 DifficultyOffset;
    private Int32? _nameSize;
    public Int32 NameSize
    {
        get
        {
            if(_nameSize == null)
            {
                _nameSize = Reader.ReadInt32(NameSizeOffset, Source);
            }
            return (Int32)_nameSize;
        }
    }
    
    private Int32? _descriptionSize;
    public Int32 DescriptionSize
    {
        get
        {
            if (_descriptionSize == null)
            {
                _descriptionSize = Reader.ReadInt32(DescriptionSizeOffset, Source);
            }    
            return  (Int32)_descriptionSize;
        }
    }
    
    public byte[] Source;
    
    BinaryReader Reader;
    
    public HeaderReader(byte[] Source)
    {
        this.Source = Source;
        this.Reader = new BinaryReader();
        CalculateOffsets();
    }

    private void CalculateOffsets()
    {
        DescriptionSizeOffset = NameOffset + NameSize;
        DescriptionOffset = DescriptionSizeOffset + 4;
        DifficultyOffset = DescriptionOffset + DescriptionSize;
    }
    public Version GetVersion()
    {
        var Result = Reader.ReadInt32(VersionOffset, Source);
        return (Version)Result;
    }
     
    public Int32 GetMapSize()
    {
        var Result = Reader.ReadInt32(MapSizeOffset, Source);
        return Result;
    }
    
    public String GetName()
    {
        return Reader.ReadString(NameOffset, NameSize, Source);
    }
    
    public String GetDescription()
    {
        return Reader.ReadString(DescriptionOffset, DescriptionSize, Source);
    }
        
    public Boolean GetIsHeroPresent()
    {
        return Reader.ReadBoolean(IsHeroPresentOffset, Source);
    }

    public Boolean GetHasSubterrain()
    {
        return Reader.ReadBoolean(HasSubterrainOffset, Source);
    }
    
    public Difficulty GetDifficulty()
    {
        return (Difficulty)Source[DifficultyOffset];
    }
}