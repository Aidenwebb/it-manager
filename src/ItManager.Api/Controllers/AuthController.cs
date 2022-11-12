using AutoMapper;
using ItManager.Api.Resources;
using ItManager.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ItManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IMapper _mapper;

    public AuthController(
        IMapper mapper,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterResource registerUserDto)
    {
        var user = _mapper.Map<ApplicationUser>(registerUserDto);
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginResource userLoginResource)
    {
        var user = await _userManager.FindByEmailAsync(userLoginResource.Email);
        if (user == null)
        {
            return BadRequest("Invalid username or password");
        }

        var result = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);
        if (!result)
        {
            return BadRequest("Invalid username or password");
        }

        return Ok();
    }
}