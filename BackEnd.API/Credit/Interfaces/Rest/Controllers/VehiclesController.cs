using AutoMapper;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Resources;
using BackEnd.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Credit.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly IMapper _mapper;

    public VehiclesController(IVehicleService vehicleService, IMapper mapper)
    {
        _vehicleService = vehicleService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<VehicleResource> GetById(int id)
    {
        var vehicle = await _vehicleService.GetById(id);
        var resource = _mapper.Map<Vehicle, VehicleResource>(vehicle);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(VehicleResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveVehicleResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(resource);
        var result = await _vehicleService.SaveAsync(vehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(result.Resource);
        return Created(nameof(PostAsync), vehicleResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _vehicleService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(result.Resource);
        return Ok(vehicleResource);
    }
}