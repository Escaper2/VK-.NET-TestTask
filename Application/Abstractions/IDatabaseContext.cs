using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions;
public interface IDatabaseContext
{
    DbSet<User> Users { get; set; }
    DbSet<UserGroup> UserGroups { get; set; }
    DbSet<UserState> UserStates { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}