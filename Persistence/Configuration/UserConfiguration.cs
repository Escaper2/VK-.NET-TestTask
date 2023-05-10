using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
        builder.Property(x => x.Login).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
        builder
            .HasOne(x => x.UserState)
            .WithOne(y => y.User)
            .HasForeignKey<UserState>(x => x.UserStateId)
            .HasPrincipalKey<User>(x => x.UserStateId);
    }
}