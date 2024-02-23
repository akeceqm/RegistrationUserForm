using AutorizationUserForm.DAL.Interfaces;
using AutorizationUserForm.Domain.Entity;
using AutorizationUserForm.Domain.Enum;
using AutorizationUserForm.Domain.Response;
using AutorizationUserForm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegistrationUser.Service.Interfaces;

namespace RegistrationUser.Service.Implementation;

public class UserService:IUserService
{
    public UserService Logger { get; }
    private readonly IBaseRepository<UserEntity> _baseRepository;
    private ILogger<UserService> _logger;
    public UserService(IBaseRepository<UserEntity> baseRepository, ILogger<UserService> logger)
    {
        _logger = logger;
        _baseRepository = baseRepository;
    }

    public async Task<BaseResponse<UserEntity>> Create(CreateUserViewModel model)
    {
        try
        {
            _logger.LogInformation($"Запрос на создание User - {model.Login}");

            var user = await _baseRepository.GetAll()
                .Where(x => x.Login == model.Login)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                return new BaseResponse<UserEntity>()
                {
                    Description = "Пользователь с таким логином уже есть!",
                    StatusCode=StausCode.UserHasAlready
                };
            }

            user = new UserEntity()
            {
                Id = model.Id,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role.Equals(1)?2:1
            };
            await _baseRepository.Create(user);

            return new BaseResponse<UserEntity>()
            {
                StatusCode = StausCode.Ok,
                Description = "Пользователь создан"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"[UserService]:{ex.Message}");
            return new BaseResponse<UserEntity>()
            {
                StatusCode = StausCode.InternalServerError
            };
        }
    }
}