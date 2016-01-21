public class BinaryReader
{
    byte[] Source;
    BinaryFormat Out;
    public BinaryReader(byte[] Source)
    {
        this.Source = Source;
        Out = new BinaryFormat();
    }
    
    
    public Version ReadVersion()
    {
        for(int i = 0; i < 4; i++)
        {
            Out.Version[i] = Source[i];
        }
        if(Out.Version[0] == (byte)Version.ROE)
        {
            return Version.ROE;
        }
        if(Out.Version[1] == (byte)Version.AB)
        {
            return Version.AB;
        }
        if(Out.Version[2] == (byte)Version.SOD)
        {
            return Version.SOD;
        }
        return Version.Unknown;
    }
}