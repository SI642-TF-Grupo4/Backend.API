using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Domain.Services.Communication;
using BackEnd.API.Shared.Domain.Repositories;

namespace BackEnd.API.Credit.Services;

public class EntidadService: IEntidadService
{
    private readonly IEntidadRepository _entidadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EntidadService(IEntidadRepository entidadRepository, IUnitOfWork unitOfWork)
    {
        _entidadRepository = entidadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Entidad>> ListAsync()
    {
        return await _entidadRepository.ListAsync();
    }

    public async Task<Entidad> GetById(int entidadId)
    {
        return await _entidadRepository.FindByIdAsync(entidadId);
    }

    public async Task<EntidadResponse> SaveAsync(Entidad entidad)
    {
        try
        {
            await _entidadRepository.AddAsync(entidad);
            await _unitOfWork.CompleteAsync();
            return new EntidadResponse(entidad);
        }
        catch (Exception e)
        {
            return new EntidadResponse($"An error occurred while saving {e.Message}");
        }
    }

    public async Task<EntidadResponse> Delete(int entidadId)
    {
        var existingEntidad = await _entidadRepository.FindByIdAsync(entidadId);
        if (existingEntidad == null)
        {
            return new EntidadResponse("Entidad not found");
        }

        try
        {
            _entidadRepository.Remove(existingEntidad);
            await _unitOfWork.CompleteAsync();
            return new EntidadResponse(existingEntidad);
        }
        catch (Exception e)
        {
            return new EntidadResponse($"$An error ocurred while deleting the entidad: {e.Message}");
        }
    }
}