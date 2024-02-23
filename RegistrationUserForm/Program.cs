using AutorizationUserForm.DAL;
using AutorizationUserForm.DAL.Interfaces;
using AutorizationUserForm.DAL.Repositories;
using AutorizationUserForm.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using RegistrationUser.Service.Implementation;
using RegistrationUser.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBaseRepository<UserEntity>,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();


var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RegistrationUser}/{action=Index}/{id?}");

app.Run();
