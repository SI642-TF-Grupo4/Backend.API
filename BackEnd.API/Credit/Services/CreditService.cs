using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Domain.Services.Communication;
using BackEnd.API.Security.Domain.Repositories;
using BackEnd.API.Shared.Domain.Repositories;

namespace BackEnd.API.Credit.Services;

public class CreditService: ICreditoService
{
    private readonly ICreditRepository _creditRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;


    public CreditService(ICreditRepository creditRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _creditRepository = creditRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<CreditoResponse> SaveAsync(Credito credito)
    {
        var existingUser = await _userRepository.FindByIdAsync(credito.UserId);
        if (existingUser == null)
            return new CreditoResponse("Invalid user.");

        try
        {
            await _creditRepository.AddAsync(credito);
            await _unitOfWork.CompleteAsync();

            return new CreditoResponse(credito);
        }
        catch (Exception e)
        {
            return new CreditoResponse($"An error occurred while saving {e.Message}");
        }
    }

    public async Task<Credito> FindByUserId(int userId)
    {
        return await _creditRepository.FindByUserId(userId);
    }

    public async Task<CreditoResponse> DeleteAsync(int creditId)
    {
        var existingCredito = await _creditRepository.FindById(creditId);
        if (existingCredito == null)
            return new CreditoResponse("User not found");

        try
        {
            _creditRepository.Remove(existingCredito);
            await _unitOfWork.CompleteAsync();
            return new CreditoResponse(existingCredito);
        }
        catch (Exception e)
        {
            return new CreditoResponse($"An error occurred while deleting the credit: {e.Message}");
        }
    }
}