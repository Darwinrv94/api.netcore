using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    private readonly ITareaService _tareaService;

    public TareaController(ITareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tareaService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] Tarea tarea)
    {
        await _tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Tarea tarea)
    {
        await _tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tareaService.Delete(id);
        return Ok();
    }
}