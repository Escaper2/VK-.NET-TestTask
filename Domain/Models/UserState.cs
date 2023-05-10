

namespace Domain.Models;

public class UserState
{
    public Guid UserStateId { get; init; }
    public string StateCode { get; set; }
    public string Description { get; set; }
    public virtual User User { get; init; }
}