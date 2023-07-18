namespace FastCommerce.Application.Exceptions;

[Serializable]
public class InvalidCategoryException : Exception
{
    public InvalidCategoryException(string? message) : base(message)
    {

    }
}
