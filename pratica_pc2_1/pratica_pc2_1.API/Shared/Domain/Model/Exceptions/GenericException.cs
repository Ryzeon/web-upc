namespace pratica_pc2_1.API.Shared.Domain.Model.Exceptions
{
public class GenericException : Exception
{
    public GenericException(string message) : base(message)
    {
    }
    
    public GenericException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
}
