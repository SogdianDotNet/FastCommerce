namespace FastCommerce.Application.Exceptions;

[Serializable]
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base() { }
    public EntityNotFoundException(string? message) : base(message) { }

    public static void ThrowIfNotFound<T>(T? entity, string? argument)
    {
        if (entity is null)
        {
            throw new EntityNotFoundException($"Entity '{typeof(T).FullName}' with argument {argument} was not found.");
        }
    }
}
