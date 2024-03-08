using AutorizationUserForm.Domain.Enum;

namespace AutorizationUserForm.Domain.Entity;

public class UserEntity
{
    public long Id { get; set; }
    public string Login { get; set; }
    public string  Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}