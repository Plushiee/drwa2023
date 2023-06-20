using UAS_DRWA.Models;
using UAS_DRWA.Services;
using UAS_DRWA.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace UAS_DRWA.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PresensiHarianGuruController : ControllerBase
{
    private readonly PresensiHarianGuruService _presensiHarianGuruService;

    public PresensiHarianGuruController(PresensiHarianGuruService presensiHarianGuruService) =>
        _presensiHarianGuruService = presensiHarianGuruService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiHarianGuru>> Get() =>
        await _presensiHarianGuruService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<PresensiHarianGuru>> Get(string id)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(id);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        return presensiHarianGuru;
    }

    [HttpPost]
    [Authorize]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Post(PresensiHarianGuru newPresensiHarianGuru)
    { 
        await _presensiHarianGuruService.CreateAsync(newPresensiHarianGuru);

        return CreatedAtAction(nameof(Get), new { id = newPresensiHarianGuru.Id }, newPresensiHarianGuru);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, PresensiHarianGuru updatedPresensiharianGuru)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(id);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        updatedPresensiharianGuru.Id = presensiHarianGuru.Id;

        await _presensiHarianGuruService.UpdateAsync(id, updatedPresensiharianGuru);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(id);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        await _presensiHarianGuruService.RemoveAsync(id);

        return NoContent();
    }

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}