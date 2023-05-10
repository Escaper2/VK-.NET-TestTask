namespace Application.Exceptions;

public class NotFoundException<T> : Exception
{
    private NotFoundException(string? msg) : base(msg) { }

    public static NotFoundException<T> ThrowException(Guid id)
    {
        return new NotFoundException<T>($"{typeof(T).Name} with id {id} was not found.");
    }
}