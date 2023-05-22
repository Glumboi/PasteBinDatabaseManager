using System.Runtime.Serialization;

namespace PasteBinDatabaseManager;

[Serializable]
public class DatabaseException : Exception
{
    public DatabaseException(string message) : base(message)
    { }
    
    // Ensure Exception is Serializable
    protected DatabaseException(SerializationInfo info, StreamingContext ctxt) 
        : base(info, ctxt)
    { }
}