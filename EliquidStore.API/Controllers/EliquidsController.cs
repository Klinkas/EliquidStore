using EliquidStore.API.Contracts;
using EliquidStore.Application.Services;
using EliquidStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EliquidStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EliquidsController : ControllerBase
{
    private readonly IEliquidsService _eliquidsService;

    public EliquidsController(IEliquidsService eliquidsService)
    {
        _eliquidsService = eliquidsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<EliquidsResponse>>> GetEliquids()
    {
        var eliquids = await _eliquidsService.GetAllEliquids();

        var response = eliquids.Select(e => new EliquidsResponse(e.Id, e.Name, e.Flavor, e.Capacity));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateEliquid([FromBody] EliquidsRequest request)
    {
        var (eliquid, error) = Eliquid.Create(
            Guid.NewGuid(),
            request.Name,
            request.Flavor,
            request.Capacity);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var eliquidId = await _eliquidsService.CreateEliquid(eliquid);
        
        return Ok(eliquidId);
    }
}