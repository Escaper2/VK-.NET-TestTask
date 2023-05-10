namespace Application.Exceptions;

public class AdministratorsExcessException : Exception
{
    private AdministratorsExcessException(string? msg) : base(msg) { }

    public static AdministratorsExcessException ThrowException()
    {
        return new AdministratorsExcessException($"Only one administrator can exist in the system");
    }
}