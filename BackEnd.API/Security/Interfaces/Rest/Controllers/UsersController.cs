using System.Net.Mime;
using AutoMapper;
using BackEnd.API.Security.Authorization.Attributes;
using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Security.Domain.Services;
using BackEnd.API.Security.Domain.Services.Communication;
using BackEnd.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BackEnd.API.Security.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            await _userService.RegisterAsync(request);
            return Ok(new { message = "Registration successful" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<UserResource> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return resource;
    }
    
}