using Application.Dto;
using Domain.Models;

namespace Application.Mapping;

public static class UserMapping
{
    public static UserDto toDto(this User user, UserStateDto userStateDto, UserGroupDto userGroupDto)
        => new UserDto(user.UserId, user.Login, user.Password, user.CreatedDate, user.UserGroupId, user.UserStateId,
            user.Name, userStateDto, userGroupDto);
}