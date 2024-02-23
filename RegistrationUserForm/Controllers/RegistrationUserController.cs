using System.Diagnostics;
using AutorizationUserForm.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using AutorizationUserForm.Models;
using RegistrationUser.Service.Interfaces;

namespace AutorizationUserForm.Controllers;

public class RegistrationUserController : Controller
{
    private readonly IUserService _userService;

    public RegistrationUserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        var response = await _userService.Create(model);
        if (response.StatusCode == StausCode.Ok)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(new{description=response.Description});
    }
}