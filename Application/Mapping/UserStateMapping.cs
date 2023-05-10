using Application.Dto;
using Domain.Models;

namespace Application.Mapping;

public static class UserStateMapping
{
    public static UserStateDto toDto(this UserState userState)
        => new UserStateDto(userState.UserStateId, userState.StateCode, userState.Description);
}