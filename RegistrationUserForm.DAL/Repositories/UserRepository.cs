using AutorizationUserForm.DAL.Interfaces;
using AutorizationUserForm.Domain.Entity;

namespace AutorizationUserForm.DAL.Repositories;

public class UserRepository : IBaseRepository<UserEntity>
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Create(UserEntity entity)
    {
        await _appDbContext.Users.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public IQueryable<UserEntity> GetAll()
    {
        return _appDbContext.Users;
    }
}