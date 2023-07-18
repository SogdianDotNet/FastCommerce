namespace FastCommerce.Application.Exceptions;

[Serializable]
public class ServiceException : Exception
{
    public ServiceException(string? message) : base(message)
    {

    }

    public static void ThrowIfNull<T>(T? argument, string? argumentName)
    {
        if (argument is null)
        {
            throw new ServiceException($"Object '{typeof(T).FullName}' with argumentName {argumentName} is null.");
        }
    }
}
