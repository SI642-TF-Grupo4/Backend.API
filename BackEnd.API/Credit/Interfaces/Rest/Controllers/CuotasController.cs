using AutoMapper;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Resources;
using BackEnd.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackEnd.API.Credit.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CuotasController : ControllerBase
{
    private readonly ICuotaService _cuotaService;
    private readonly IMapper _mapper;

    public CuotasController(ICuotaService cuotaService, IMapper mapper)
    {
        _cuotaService = cuotaService;
        _mapper = mapper;
    }

    [HttpGet("{credit-id}")]
    [SwaggerOperation(Summary = "Get all Cuotas for Given Credit",
        Description = "Get existing Cuotas associated with the specified credit")]
    public async Task<IEnumerable<CuotaResource>> GetAllByCreditId(int creditId)
    {
        var cuotas = await _cuotaService.ListByCreditId(creditId);
        var resources = _mapper.Map<IEnumerable<Cuota>, IEnumerable<CuotaResource>>(cuotas);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCuotaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cuota = _mapper.Map<SaveCuotaResource, Cuota>(resource);

        var result = await _cuotaService.SaveAsync(cuota);

        var cuotaResource = _mapper.Map<Cuota, CuotaResource>(result.Resource);
        return Created(nameof(PostAsync), cuotaResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cuotaService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var cuotaResource = _mapper.Map<Cuota, CuotaResource>(result.Resource);
        return Ok(cuotaResource);
    }


}