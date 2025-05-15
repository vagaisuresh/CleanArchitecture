using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILoggerService _logger;

    public LogsController(ILoggerService logger)
    {
        _logger = logger;
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
}