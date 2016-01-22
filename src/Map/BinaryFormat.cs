
using System;
public class BinaryFormat
{
   
    public class MapFormatException : System.FormatException
    {
        public Int32 ErrorOffset;
        public Byte [] ErrorValue;
        
        public MapFormatException( Int32 Offset, Byte[] Value)
        {
            this.ErrorOffset = Offset;
            this.ErrorValue = Value;
        }
        public MapFormatException( string message ) : base( message ) { }
        public MapFormatException( string message, System.Exception inner ) : base( message, inner ) { }
    }
      
}