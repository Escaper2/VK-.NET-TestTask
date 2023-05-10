namespace Domain.Models;

public class User
{
    public Guid UserId { get; init; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateOnly CreatedDate { get; init; }
    public Guid UserGroupId { get; init; }
    public Guid UserStateId { get; init; }
    public string Name { get; set; }
    public virtual UserState UserState { get; set; }

}