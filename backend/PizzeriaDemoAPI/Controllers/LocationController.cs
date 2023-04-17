using Microsoft.AspNetCore.Mvc;
using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Services;

namespace PizzeriaDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILocationService _service;

        public LocationController(ILocationService service, ILogger<LocationController> logger)
        => (_service, _logger) = (service, logger);

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(_service.GetAllLocations());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving the full location list from the database");
            }
        }
    }
}