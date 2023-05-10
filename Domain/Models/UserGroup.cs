

namespace Domain.Models;

public class UserGroup
{
    public Guid UserGroupId { get; init; }
    public string GroupCode { get; set; }
    public string Description { get; set; } 
    
    public virtual User User { get; set; }
}