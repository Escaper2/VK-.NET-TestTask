namespace WebAPI.Models;

public record CreateUserModel(string Login, string Password, Guid UserGroupId, string Name, string UserStateDescription);