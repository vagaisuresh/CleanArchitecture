using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILoggerService _logger;
    private readonly AppDbContext _context;

    public LogsController(ILoggerService logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInfo("Here is info message from the controller.");
        _logger.LogDebug("Here is debug message from the controller.");
        _logger.LogWarning("Here is warn message from the controller.");
        _logger.LogError("Here is error message from the controller.");

        return new string[] { "value1", "value2" };
    }

    [HttpGet("db-check")]
    public IActionResult CheckDatabase()
    {
        if (_context.Database.CanConnect())
            return Ok("✅ Database connection successful.");
        else
            return StatusCode(500, "❌ Cannot connect to database.");
    }
}