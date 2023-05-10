using Application.Dto;
using Domain.Models;

namespace Application.Mapping;

public static class UserGroupMapping
{
    public static UserGroupDto toDto(this UserGroup userGroup)
        => new UserGroupDto(userGroup.UserGroupId, userGroup.GroupCode, userGroup.Description);
}