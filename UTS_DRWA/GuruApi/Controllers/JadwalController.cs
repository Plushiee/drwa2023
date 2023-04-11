using GuruApi.Models;
using GuruApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuruApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JadwalController : ControllerBase
{
    private readonly JadwalService _jadwalService;

    public JadwalController(JadwalService jadwalService) =>
        _jadwalService = jadwalService;

    [HttpPost]
    public async Task<IActionResult> Post(Guru newJadwal)
    {
        await _jadwalService.CreateAsync(newJadwal);

        return CreatedAtAction(nameof(Get), new { id = newJadwal.nip }, newJadwal);
    }

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _jadwalService.GetAsync();

    [HttpGet("{nip:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var jadwal = await _jadwalService.GetAsync(nip);

        if (jadwal is null)
        {
            return NotFound();
        }

        return jadwal;
        
    }

     [HttpGet("{id_mapel:length(24)}")]
    public async Task<ActionResult<Guru>> get(string idMapel)
    {
        var jadwal = await _jadwalService.GetAsync(idMapel);

        if (jadwal is null)
        {
            return NotFound();
        }

        return jadwal;
        
    }
}