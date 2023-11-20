using AutoMapper;
using BackEnd.API.Security.Authorization.Handlers.Interfaces;
using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Security.Domain.Repositories;
using BackEnd.API.Security.Domain.Services;
using BackEnd.API.Security.Domain.Services.Communication;
using BackEnd.API.Security.Exceptions;
using BackEnd.API.Shared.Domain.Repositories;

namespace BackEnd.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    //private readonly IPasswordHashingService _passwordHashingService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null)
            throw new AppException("User not found");

        return user;
    }

    public async Task RegisterAsync(RegisterRequest model)
    {
        var existingUserWithEmail = await _userRepository.FindByEmailAsync(model.Email);

        if (existingUserWithEmail != null)
            throw new AppException("Email is already taken");

        var user = _mapper.Map<User>(model);
        //user.PasswordHash = _passwordHashingService.GetHash(model.Password);
        
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
        
    }
}