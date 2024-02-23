using AutorizationUserForm.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AutorizationUserForm.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<UserEntity> Users { get; set; }
}