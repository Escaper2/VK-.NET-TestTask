namespace Application.Dto;

public class UserDto
{
    public UserDto(Guid userId, string userLogin, string userPassword, DateOnly userCreatedDate, Guid userGroupId, Guid userStateId, string userName, UserStateDto userStateDto, UserGroupDto userGroupDto)
    {
        UserId = userId;
        Login = userLogin;
        Password = userPassword;
        CreatedDate = userCreatedDate;
        UserGroupId = userGroupId;
        UserStateId = userStateId;
        Name = userName;
        UserStateDto = userStateDto;
        UserGroupDto = userGroupDto;
    }

    public Guid UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateOnly CreatedDate { get; set; }
    public Guid UserGroupId { get; set; }
    public Guid UserStateId { get; set; }
    public string Name { get; set; }
    public UserGroupDto UserGroupDto { get; set; }
    public UserStateDto UserStateDto { get; set; }
}