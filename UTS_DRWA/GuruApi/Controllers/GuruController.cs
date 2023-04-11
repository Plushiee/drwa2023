using GuruApi.Models;
using GuruApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuruApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuruController : ControllerBase
{
    private readonly GuruService _guruService;

    public GuruController(GuruService guruService) =>
        _guruService = guruService;

    [HttpPost]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _guruService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.NIP }, newGuru);
    }

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _guruService.GetAsync();

    [HttpGet("{NIP:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string NIP)
    {
        var guru = await _guruService.GetAsync(NIP);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }
}