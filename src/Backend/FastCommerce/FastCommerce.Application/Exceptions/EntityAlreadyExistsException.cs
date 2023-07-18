namespace FastCommerce.Application.Exceptions;

[Serializable]
public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException(string? paramName) : base(paramName)
    {

    }
}
