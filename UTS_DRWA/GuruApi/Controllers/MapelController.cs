using GuruApi.Models;
using GuruApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuruApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapelController : ControllerBase
{
    private readonly MatkulService _matkul;

    public MapelController(MatkulService matkulService) =>
        _matkul = matkulService;

    [HttpPost]
    public async Task<IActionResult> Post(Guru newMatkul)
    {
        await _matkul.CreateAsync(newMatkul);

        return CreatedAtAction(nameof(Get), new { id = newMatkul.Mapel }, newMatkul);
    }

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _matkul.GetAsync();

    [HttpGet("{nip:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var matkul = await _matkul.GetAsync(nip);

        if (matkul is null)
        {
            return NotFound();
        }

        return matkul;
    }
}