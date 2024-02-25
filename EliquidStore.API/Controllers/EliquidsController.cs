using EliquidStore.API.Contracts;
using EliquidStore.Application.Services;
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
}