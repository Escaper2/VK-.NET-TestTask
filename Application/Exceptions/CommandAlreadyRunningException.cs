namespace Application.Exceptions;

public class CommandAlreadyRunningException : Exception
{
    private CommandAlreadyRunningException(string? msg) : base(msg) { }

    public static CommandAlreadyRunningException ThrowException(string login)
    {
        return new CommandAlreadyRunningException($"Registration is already running for a user with login {login}");
    }
}