using System.Runtime.Serialization;

namespace PasteBinDataBaseManager;

[Serializable]
public class DataBaseException : Exception
{
    public DataBaseException(string message) : base(message)
    { }
    
    // Ensure Exception is Serializable
    protected DataBaseException(SerializationInfo info, StreamingContext ctxt) 
        : base(info, ctxt)
    { }
}