using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace PizzeriaDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;
        private readonly ILogger _logger;

        public IngredientController(IIngredientService service, ILogger<IngredientController> logger)
        => (_service, _logger) = (service, logger);

        [HttpGet]
        public IActionResult Tops()
        {
            try
            {
                var topIngredients = _service.GetTopIngredients();
                return Ok(topIngredients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving Top ingredients from the database");
            }
        }
    }
}