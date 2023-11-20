using AutoMapper;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Domain.Services.Communication;
using BackEnd.API.Credit.Resources;
using BackEnd.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Credit.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EntidadesController : ControllerBase
{
    private readonly IEntidadService _entidadService;
    private readonly IMapper _mapper;


    public EntidadesController(IEntidadService entidadService, IMapper mapper)
    {
        _entidadService = entidadService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EntidadResource>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var entidades = await _entidadService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Entidad>, IEnumerable<EntidadResource>>(entidades);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<EntidadResource> GetById(int id)
    {
        var user = await _entidadService.GetById(id);
        var resource = _mapper.Map<Entidad, EntidadResource>(user);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(EntidadResource), 201)]
    public async Task<IActionResult> PostAsync(SaveEntidadResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var entidad = _mapper.Map<SaveEntidadResource, Entidad>(resource);
        var result = await _entidadService.SaveAsync(entidad);

        if (!result.Success)
            return BadRequest(result.Message);

        var entidadResource = _mapper.Map<Entidad, EntidadResource>(result.Resource);
        return Created(nameof(PostAsync), entidadResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _entidadService.Delete(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var entidadResource = _mapper.Map<Entidad, EntidadResource>(result.Resource);
        return Ok(entidadResource);
    }

}