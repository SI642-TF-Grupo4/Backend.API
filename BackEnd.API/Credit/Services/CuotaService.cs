using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Domain.Services.Communication;
using BackEnd.API.Shared.Domain.Repositories;

namespace BackEnd.API.Credit.Services;

public class CuotaService: ICuotaService
{
    private readonly ICuotaRepository _cuotaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICreditRepository _creditRepository;

    public CuotaService(ICuotaRepository cuotaRepository, IUnitOfWork unitOfWork, ICreditRepository creditRepository)
    {
        _cuotaRepository = cuotaRepository;
        _unitOfWork = unitOfWork;
        _creditRepository = creditRepository;
    }

    public async Task<IEnumerable<Cuota>> ListByCreditId(int creditId)
    {
        return await _cuotaRepository.ListByCreditoId(creditId);
    }

    public async Task<CuotaResponse> SaveAsync(Cuota cuota)
    {
        var existingCredit = await _creditRepository.FindById(cuota.CreditoId);
        if (existingCredit == null)
            return new CuotaResponse("Invalid credit");

        try
        {
            await _cuotaRepository.AddAsync(cuota);
            await _unitOfWork.CompleteAsync();

            return new CuotaResponse(cuota);
        }
        catch (Exception e)
        {
            return new CuotaResponse($"An error occurred while saving {e.Message}");
        }
    }

    public async Task<CuotaResponse> UpdateAsync(int cuotaId, Cuota cuota)
    {
        var existingCuota = await _cuotaRepository.FindByIdAsync(cuotaId);
        if (existingCuota == null)
            return new CuotaResponse("Cuota not found.");

        var existingCredit = await _creditRepository.FindById(cuota.CreditoId);
        if (existingCredit == null)
            return new CuotaResponse("Invalid credit");
        
        throw new NotImplementedException();
    }

    public async Task<CuotaResponse> DeleteAsync(int cuotaId)
    {
        var existingCuota = await _cuotaRepository.FindByIdAsync(cuotaId);
        if (existingCuota == null)
            return new CuotaResponse("Cuota not found.");

        try
        {
            _cuotaRepository.Remove(existingCuota);
            await _unitOfWork.CompleteAsync();
            return new CuotaResponse(existingCuota);
        }
        catch (Exception e)
        {
            return new CuotaResponse($"An error occurred while deleting the cuota: {e.Message}");
        }
    }
}