using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly IHelloWorldService _helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;
    private readonly TareasContext _context;

    public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger, TareasContext context)
    {
        _helloWorldService = helloWorldService;
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando Hello World");
        return Ok(_helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createDb")]
    public IActionResult CreateDataBase()
    {
        _context.Database.EnsureCreated();
        return Ok();
    }
}