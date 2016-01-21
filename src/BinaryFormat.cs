public class BinaryFormat
{
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