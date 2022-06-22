using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
  private readonly ICategoriaService _categoriaService;

  public CategoriaController(ICategoriaService categoriaService)
  {
    _categoriaService = categoriaService;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_categoriaService.Get());
  }

  [HttpPost]
  public async Task<IActionResult> Save([FromBody] Categoria categoria)
  {
    await _categoriaService.Save(categoria);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Guid id, [FromBody] Categoria categoria)
  {
    await _categoriaService.Update(id, categoria);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _categoriaService.Delete(id);
    return Ok();
  }
}