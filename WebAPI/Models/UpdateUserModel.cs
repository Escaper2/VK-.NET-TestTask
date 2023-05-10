namespace WebAPI.Models;

public record UpdateUserModel(Guid UserId, string Login, string Password, string Name);