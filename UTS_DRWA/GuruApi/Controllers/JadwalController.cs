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
    public async Task<IActionResult> Post(Jadwal newJadwal)
    {
        await _jadwalService.CreateAsync(newJadwal);

        return CreatedAtAction(nameof(Get), new { id = newJadwal.idJadwal }, newJadwal);
    }

    [HttpGet]
    public async Task<List<Jadwal>> Get() =>
        await _jadwalService.GetAsync();
        

    [HttpGet("{NIP:length(24)}")]
    public async Task<ActionResult<Jadwal>> Get(string NIP)
    {
        var jadwal = await _jadwalService.GetAsync(NIP);

        if (jadwal is null)
        {
            return NotFound();
        }

        return jadwal;
        
    }

     [HttpGet("{idMapel:length(24)}")]
    public async Task<ActionResult<Jadwal>> GetByIdMapel(string idMapel)
    {
        var jadwal = await _jadwalService.GetAsync(idMapel);

        if (jadwal is null)
        {
            return NotFound();
        }

        return jadwal;
        
    }
}