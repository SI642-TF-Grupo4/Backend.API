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
public class CreditsController : ControllerBase
{
    private readonly ICreditoService _creditoService;
    private readonly IMapper _mapper;


    public CreditsController(ICreditoService creditoService, IMapper mapper)
    {
        _creditoService = creditoService;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    [SwaggerOperation(Summary = "Get Credit by User id")]
    public async Task<CreditoResource> GetByUserId(int userId)
    {
        var credito = await _creditoService.FindByUserId(userId);
        var resource = _mapper.Map<Credito, CreditoResource>(credito);
        
        Console.WriteLine(resource);
        Console.WriteLine(credito);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCreditoResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var credit = _mapper.Map<SaveCreditoResource, Credito>(resource);
        var result = await _creditoService.SaveAsync(credit);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var creditResource = _mapper.Map<Credito, CreditoResource>(result.Resource);
        return Created(nameof(PostAsync), creditResource);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _creditoService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var creditResource = _mapper.Map<Credito, CreditoResource>(result.Resource);

        return Ok(creditResource);
    }
}