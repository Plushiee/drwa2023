using GuruApi.Models;
using GuruApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuruApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapelController : ControllerBase
{
    private readonly MapelService _mapelService;

    public MapelController(MapelService mapelService) =>
        _mapelService = mapelService;

    [HttpPost]
    public async Task<IActionResult> Post(Mapel newMapel)
    {
        await _mapelService.CreateAsync(newMapel);

        return CreatedAtAction(nameof(Get), new { id = newMapel.idMapel }, newMapel);
    }

    [HttpGet]
    public async Task<List<Mapel>> Get() =>
        await _mapelService.GetAsync();

    [HttpGet("{NIP}")]
    public async Task<ActionResult<Mapel>> Get(string idMapel)
    {
        var mapel = await _mapelService.GetAsync(idMapel);

        if (mapel is null)
        {
            return NotFound();
        }

        return mapel;
    }
}