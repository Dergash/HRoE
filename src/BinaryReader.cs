using System;
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
        for(int i = BinaryFormat.VersionOffset; i < 4; i++)
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
    
    public Int32 ReadMapSize()
    {
        Int32 Start = BinaryFormat.MapSizeOffset;
        Int32 End = BinaryFormat.MapSizeOffset + 4;
        int j = 0;
        for(int i = Start; i < End; i++)
        {
            Out.MapSize[j] = Source[i];
            j++;
        }
        return BitConverter.ToInt32(Out.MapSize,0);
    }
}