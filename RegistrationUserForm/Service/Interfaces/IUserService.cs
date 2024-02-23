using AutorizationUserForm.Domain.Entity;
using AutorizationUserForm.Domain.Response;
using AutorizationUserForm.Models;


namespace RegistrationUser.Service.Interfaces;

public interface IUserService
{
    Task<BaseResponse<UserEntity>> Create(CreateUserViewModel model);
}