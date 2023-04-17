using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace PizzeriaDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        private readonly ILogger _logger;

        public MenuController(IMenuService service, ILogger<MenuController> logger)
        => (_service, _logger) = (service, logger);

        [HttpGet("{locationId:int}")]
        public IActionResult GetMenuByLocation(int locationId)
        {
            try
            {
                var menu = _service.GetMenuByLocation(locationId);
                //_logger.LogInformation("Retrieved menu by locationId {locationId} successfully", locationId);
                return Ok(menu);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}